﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackTorria.Models
{
    public class CommentForCreationDto
    {
        public string User { get; set; }
        public string Description { get; set; }
        public Stage Stage { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
