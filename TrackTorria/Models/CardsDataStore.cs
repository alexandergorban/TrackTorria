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
            // todo remove mock data
            Cards = new List<CardDto>()
            {
                new CardDto()
                {
                    Id = 1,
                    Name = "First card",
                    Description = "Description first card",
                    CreatedAt = new DateTime(2017, 07, 20),
                    Stage = Stage.ToDo,
                    Comments = new List<CommentDto>()
                    {
                        new CommentDto()
                        {
                            Id = 1,
                            User = "Ben",
                            Description = "First comment for first card",
                            AddedAt = new DateTime(2017, 12, 20),
                            Stage = Stage.ToDo
                        },
                        new CommentDto()
                        {
                            Id = 2,
                            User = "Jins",
                            Description = "Second comment for first card",
                            AddedAt = new DateTime(2017, 12, 20),
                            Stage = Stage.InProgress
                        },
                    }
                },
                new CardDto()
                {
                    Id = 2,
                    Name = "Second card",
                    Description = "Description second card",
                    CreatedAt = new DateTime(2017, 07, 20),
                    Stage = Stage.InProgress,
                    Comments = new List<CommentDto>()
                    {
                        new CommentDto()
                        {
                            Id = 3,
                            User = "Ben",
                            Description = "First comment for second card",
                            AddedAt = new DateTime(2017, 12, 20),
                            Stage = Stage.ToDo
                        },
                        new CommentDto()
                        {
                            Id = 4,
                            User = "Jins",
                            Description = "Second comment for second card",
                            AddedAt = new DateTime(2017, 12, 20),
                            Stage = Stage.InProgress
                        },
                    }
                },
                new CardDto()
                {
                    Id = 3,
                    Name = "Third card",
                    Description = "Description third card",
                    CreatedAt = new DateTime(2017, 07, 20),
                    Stage = Stage.InProgress,
                    Comments = new List<CommentDto>()
                    {
                        new CommentDto()
                        {
                            Id = 5,
                            User = "Ben",
                            Description = "First comment for third card",
                            AddedAt = new DateTime(2017, 12, 20),
                            Stage = Stage.ToDo
                        },
                        new CommentDto()
                        {
                            Id = 6,
                            User = "Jins",
                            Description = "Second comment for third card",
                            AddedAt = new DateTime(2017, 12, 20),
                            Stage = Stage.InProgress
                        },
                    }
                }
            };

        }
    }
}
