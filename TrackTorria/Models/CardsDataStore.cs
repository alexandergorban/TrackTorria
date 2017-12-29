using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackTorria.Models
{
    public class CardsDataStore
    {
        public static CardsDataStore Current { get; } = new CardsDataStore();
        public List<CardDto> Cards { get; set; }

        public CardsDataStore()
        {
            // todo remove dummy data
            Cards = new List<CardDto>()
            {
                new CardDto()
                {
                    Id = 1,
                    Name = "First card",
                    Description = "Description first card",
                    CreatedAt = new DateTime(2017, 07, 20),
                    Stage = Stage.ToDo
                },
                new CardDto()
                {
                    Id = 2,
                    Name = "Second card",
                    Description = "Description second card",
                    CreatedAt = new DateTime(2017, 07, 20),
                    Stage = Stage.InProgress
                },
                new CardDto()
                {
                    Id = 3,
                    Name = "Third card",
                    Description = "Description third card",
                    CreatedAt = new DateTime(2017, 07, 20),
                    Stage = Stage.InProgress
                }
            };

        }
    }
}
