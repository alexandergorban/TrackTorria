using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackTorria.Models;

namespace TrackTorria.Controllers
{
    [Route("api/cards")]
    public class CommentsController : Controller
    {
        [HttpGet("{cardId}/comments")]
        public IActionResult GetComments(int cardId)
        {
            var card = CardsDataStore.Current.Cards.FirstOrDefault(c => c.Id == cardId);

            if (card == null)
            {
                return NotFound();
            }

            return Ok(card.Comments);
        }

        [HttpGet("{cardId}/comments/{commentId}", Name = "GetComment")]
        public IActionResult GetComment(int cardId, int commentId)
        {
            var card = CardsDataStore.Current.Cards.FirstOrDefault(c => c.Id == cardId);

            if (card == null)
            {
                return NotFound();
            }

            var comment = card.Comments.FirstOrDefault(c => c.Id == commentId);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
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

    }
}
