using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrackTorria.Entities;

namespace TrackTorria.Services
{
    public class CardRepository : ICardRepository
    {
        private CardContext _context;

        public CardRepository( CardContext context)
        {
            _context = context;
        }

        public bool CardExists(int cardId)
        {
            return _context.Cards.Any(c => c.Id == cardId);
        }

        public IEnumerable<Card> GetCards()
        {
            return _context.Cards.OrderBy(c => c.Name).ToList();
        }

        public Card GetCard(int cardId, bool includeComments)
        {
            if (includeComments)
            {
                return _context.Cards.Include(c => c.Comments)
                    .Where(c => c.Id == cardId).FirstOrDefault();
            }

            return _context.Cards.Where(c => c.Id == cardId).FirstOrDefault();
        }

        public IEnumerable<Comment> GetComments(int cardId)
        {
            return _context.Comments.Where(c => c.CardId == cardId).ToList();
        }

        public Comment GetComment(int cardId, int commentId)
        {
            return _context.Comments.Where(c => c.CardId == cardId && c.Id == commentId).FirstOrDefault();
        }

        public void AddComment(int cardId, Comment comment)
        {
            var card = GetCard(cardId, false);
            card.Comments.Add(comment);
        }

        public void DeleteComment(Comment comment)
        {
            _context.Comments.Remove(comment);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
