using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackTorria.Models;
using TrackTorria.Services;

namespace TrackTorria.Controllers
{
    [Route("api/cards")]
    public class CardsController : Controller
    {
        private ICardRepository _cardRepository;

        public CardsController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet()]
        public IActionResult GetCards()
        {
            var cardEntities = _cardRepository.GetCards();
            var results = new List<CardWithoutCommentsDto>();

            foreach (var cardEntity in cardEntities)
            {
                results.Add(new CardWithoutCommentsDto()
                {
                    Id = cardEntity.Id,
                    Name = cardEntity.Name,
                    Description = cardEntity.Description,
                    CreatedAt = cardEntity.CreatedAt,
                    Stage = cardEntity.Stage
                });
            }

            return Ok(results);
        }

        [HttpGet("{cardId}")]
        public IActionResult GetCard(int cardId, bool includeComments = false)
        {
            var cardEntity = _cardRepository.GetCard(cardId, includeComments);
            if (cardEntity == null)
            {
                return NotFound();
            }

            if (includeComments)
            {
                var cardResult = new CardDto()
                {
                    Id = cardEntity.Id,
                    Name = cardEntity.Name,
                    Description = cardEntity.Description,
                    Stage = cardEntity.Stage,
                    CreatedAt = cardEntity.CreatedAt
                };

                foreach (var commentEntity in cardEntity.Comments)
                {
                    cardResult.Comments.Add(new CommentDto()
                    {
                        Id = commentEntity.Id,
                        User = commentEntity.User,
                        Description = commentEntity.Description,
                        Stage = commentEntity.Stage,
                        AddedAt = commentEntity.AddedAt
                    });
                }

                return Ok(cardResult);
            }

            var cardWithoutComments = new CardWithoutCommentsDto()
            {
                Id = cardEntity.Id,
                Name = cardEntity.Name,
                Description = cardEntity.Description,
                Stage = cardEntity.Stage,
                CreatedAt = cardEntity.CreatedAt
            };

            return Ok(cardWithoutComments);
        }

    }
}
