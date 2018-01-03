using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackTorria.Models
{
    public class CardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Stage Stage { get; set; }

        public int NumberOfComments
        {
            get { return Comments.Count; }
        }

        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
