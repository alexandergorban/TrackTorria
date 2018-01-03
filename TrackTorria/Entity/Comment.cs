using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TrackTorria.Models;

namespace TrackTorria.Entity
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string User { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public Stage Stage { get; set; }

        [Required]
        public DateTime AddedAt { get; set; }

        [ForeignKey("CardId")]
        public Card Card { get; set; }
        public int CardId { get; set; }
    }
}
