using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackTorria.Models;

namespace TrackTorria.Controllers
{
    [Route("api/cards")]
    public class CardsController : Controller
    {
        [HttpGet()]
        public IActionResult GetCards()
        {
            return Ok(CardsDataStore.Current.Cards);
        }

        [HttpGet("{id}")]
        public IActionResult GetCard(int id)
        {
            var cardToReturn = CardsDataStore.Current.Cards.FirstOrDefault(c => c.Id == id);
            if (cardToReturn == null)
            {
                return NotFound();
            }

            return Ok(cardToReturn);
        }

    }
}
