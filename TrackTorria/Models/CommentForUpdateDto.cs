using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackTorria.Models
{
    public class CommentForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a Description value.")]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
