using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackTorria.Models;

namespace TrackTorria.Entity
{
    public static class CardContextExtensions
    {
        public static void EnsureSeedDataForContext(this CardContext context)
        {
            if (context.Cards.Any())
            {
                return;
            }

            // Init seed data
            var cards = new List<Card>()
            {
                new Card()
                {
                    Name = "First card",
                    Description = "Description first card",
                    CreatedAt = new DateTime(2017, 07, 20),
                    Stage = Stage.ToDo,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            User = "Ben",
                            Description = "First comment for first card",
                            AddedAt = new DateTime(2017, 12, 20),
                            Stage = Stage.ToDo
                        },
                        new Comment()
                        {
                            User = "Jins",
                            Description = "Second comment for first card",
                            AddedAt = new DateTime(2017, 12, 20),
                            Stage = Stage.InProgress
                        },
                    }
                },
                new Card()
                {
                    Name = "Second card",
                    Description = "Description second card",
                    CreatedAt = new DateTime(2017, 07, 20),
                    Stage = Stage.InProgress,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            User = "Ben",
                            Description = "First comment for second card",
                            AddedAt = new DateTime(2017, 12, 20),
                            Stage = Stage.ToDo
                        },
                        new Comment()
                        {
                            User = "Jins",
                            Description = "Second comment for second card",
                            AddedAt = new DateTime(2017, 12, 20),
                            Stage = Stage.InProgress
                        },
                    }
                },
                new Card()
                {
                    Name = "Third card",
                    Description = "Description third card",
                    CreatedAt = new DateTime(2017, 07, 20),
                    Stage = Stage.InProgress,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            User = "Ben",
                            Description = "First comment for third card",
                            AddedAt = new DateTime(2017, 12, 20),
                            Stage = Stage.ToDo
                        },
                        new Comment()
                        {
                            User = "Jins",
                            Description = "Second comment for third card",
                            AddedAt = new DateTime(2017, 12, 20),
                            Stage = Stage.InProgress
                        },
                    }
                }
            };

            context.Cards.AddRange(cards);
            context.SaveChanges();
        }
    }
}
