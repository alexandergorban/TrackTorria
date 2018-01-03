using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackTorria.Entity;

namespace TrackTorria.Controllers
{
    public class TestDbController : Controller
    {
        private CardContext _ctx;

        public TestDbController(CardContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
