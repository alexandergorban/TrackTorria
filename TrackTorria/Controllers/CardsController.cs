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
        public JsonResult GetCards()
        {
            return new JsonResult(CardsDataStore.Current.Cards);
        }

        [HttpGet("{id}")]
        public JsonResult GetCard(int id)
        {
            return new JsonResult(CardsDataStore.Current.Cards.FirstOrDefault(c => c.Id == id));
        }

    }
}
