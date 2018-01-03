using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackTorria.Models
{
    public class CommentForCreationDto
    {
        [Required(ErrorMessage = "You should provide a User value.")]
        [MaxLength(50)]
        public string User { get; set; }

        [Required(ErrorMessage = "You should provide a Description value.")]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required(ErrorMessage = "You should provide a Stage value.")]
        public Stage Stage { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
