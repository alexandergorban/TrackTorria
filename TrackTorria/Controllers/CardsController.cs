using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
            var results = Mapper.Map<IEnumerable<CardWithoutCommentsDto>>(cardEntities);

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
                var cardResult = Mapper.Map<CardDto>(cardEntity);

                return Ok(cardResult);
            }

            var cardWithoutComments = Mapper.Map<CardWithoutCommentsDto>(cardEntity);

            return Ok(cardWithoutComments);
        }

    }
}
