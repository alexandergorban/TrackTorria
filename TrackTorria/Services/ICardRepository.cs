using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackTorria.Entities;

namespace TrackTorria.Services
{
    public interface ICardRepository
    {
        bool CardExists(int cardId);
        IEnumerable<Card> GetCards();
        Card GetCard(int cardId, bool includeComments);
        IEnumerable<Comment> GetComments(int cardId);
        Comment GetComment(int cardId, int commentId);
        void AddComment(int cardId, Comment comment);
        void DeleteComment(Comment comment);
        bool Save();
    }
}
