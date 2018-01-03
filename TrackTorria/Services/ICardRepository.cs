using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackTorria.Entity;

namespace TrackTorria.Services
{
    interface ICardRepository
    {
        IEnumerable<Card> GetCards();
        Card GetCard(int cardId, bool includeComments);
        IEnumerable<Comment> GetComments(int cardId);
        Comment GetComment(int cardId, int commentId);
    }
}
