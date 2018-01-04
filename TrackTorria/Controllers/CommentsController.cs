﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrackTorria.Models;
using TrackTorria.Services;

namespace TrackTorria.Controllers
{
    [Route("api/cards")]
    public class CommentsController : Controller
    {
        private ILogger<CommentsController> _logger;
        private ICardRepository _cardRepository;

        public CommentsController(ILogger<CommentsController> logger, ICardRepository cardRepository)
        {
            _logger = logger;
            _cardRepository = cardRepository;
        }

        [HttpGet("{cardId}/comments")]
        public IActionResult GetComments(int cardId)
        {
            try
            {
                if (!_cardRepository.CardExists(cardId))
                {
                    _logger.LogInformation($"Card with {cardId} wasn't found.");
                    return NotFound();
                }

                var commentsForCard = _cardRepository.GetComments(cardId);

                var commentsForCardResult = new List<CommentDto>();
                foreach (var comment in commentsForCard)
                {
                    commentsForCardResult.Add(new CommentDto()
                    {
                        Id = comment.Id,
                        User = comment.User,
                        Description = comment.Description,
                        Stage = comment.Stage,
                        AddedAt = comment.AddedAt
                    });
                }

                return Ok(commentsForCardResult);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception while getting comments for card with id {cardId}.", ex);
                return StatusCode(500, "A problem happened while hendling your request.");
            }

        }

        [HttpGet("{cardId}/comments/{commentId}", Name = "GetComment")]
        public IActionResult GetComment(int cardId, int commentId)
        {
            if (!_cardRepository.CardExists(cardId))
            {
                _logger.LogInformation($"Card with Id {cardId} wasn't found.");
                return NotFound();
            }

            var comment = _cardRepository.GetComment(cardId, commentId);

            if (comment == null)
            {
                return NotFound();
            }

            var commentResult = new CommentDto()
            {
                Id = comment.Id,
                User = comment.User,
                Description = comment.Description,
                Stage = comment.Stage,
                AddedAt = comment.AddedAt
            };

            return Ok(commentResult);
        }

        [HttpPost("{cardId}/comments")]
        public IActionResult CreateComment(int cardId, [FromBody] CommentForCreationDto comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            if (comment.User == comment.Description)
            {
                ModelState.AddModelError("Desctiption", "The provided Description should be different from the User.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var card = CardsDataStore.Current.Cards.FirstOrDefault(c => c.Id == cardId);

            if (card == null)
            {
                return NotFound();
            }

            var maxCommentId = CardsDataStore.Current.Cards.SelectMany(c => c.Comments).Max(c => c.Id);

            var finalComment = new CommentDto()
            {
                Id = ++maxCommentId,
                User = comment.User,
                Description = comment.Description,
                Stage = comment.Stage,
                AddedAt = DateTime.Now
            };

            card.Comments.Add(finalComment);

            return CreatedAtRoute("GetComment", new { cardId = cardId, commentId = finalComment.Id }, finalComment);
        }

        [HttpPut("{cardId}/comments/{commentId}")]
        public IActionResult UpdateComment(int cardId, int commentId, [FromBody] CommentForUpdateDto comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var card = CardsDataStore.Current.Cards.FirstOrDefault(c => c.Id == cardId);
            if (card == null)
            {
                return NotFound();
            }

            var commentFromStore = card.Comments.FirstOrDefault(c => c.Id == commentId);
            if (commentFromStore == null)
            {
                return NotFound();
            }

            commentFromStore.Description = comment.Description;

            return NoContent();
        }

        [HttpPatch("{cardId}/comments/{commentId}")]
        public IActionResult PartiallyUpdateComment(int cardId, int commentId, [FromBody] JsonPatchDocument<CommentForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var card = CardsDataStore.Current.Cards.FirstOrDefault(c => c.Id == cardId);
            if (card == null)
            {
                return NotFound();
            }

            var commentFromStore = card.Comments.FirstOrDefault(c => c.Id == commentId);
            if (commentFromStore == null)
            {
                return NotFound();
            }

            var commentToPatch = new CommentForUpdateDto()
            {
                Description = commentFromStore.Description
            };

            patchDoc.ApplyTo(commentToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TryValidateModel(commentToPatch);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            commentFromStore.Description = commentToPatch.Description;

            return NoContent();
        }

        [HttpDelete("{cardId}/comments/{commentId}")]
        public IActionResult DeleteComment(int cardId, int commentId)
        {
            var card = CardsDataStore.Current.Cards.FirstOrDefault(c => c.Id == cardId);
            if (card == null)
            {
                return NotFound();
            }

            var commentFromStore = card.Comments.FirstOrDefault(c => c.Id == commentId);
            if (commentFromStore == null)
            {
                return NotFound();
            }

            card.Comments.Remove(commentFromStore);

            return NoContent();
        }
    }
}
