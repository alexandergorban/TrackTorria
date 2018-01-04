using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TrackTorria.Models;

namespace TrackTorria.Entities
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public Stage Stage { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
