using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackTorria.Models
{
    public enum Stage
    {
        BackLog = 1,
        ToDo = 2,
        InProgress = 3,
        CodeReview = 4,
        Merged = 5,
        InTest = 6,
        Tested = 7,
        Deployed = 8,
        Done = 9
    }
}
