using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardManipulation
{
    public class User
    {
        public User()
        {
            boards = new List<Board>();
        }
        
        private string name;
        private string forName;
        private string email;

        // les board auxquels a accès l'utilisateur
        private IList<Board> boards;

        public IList<Board> getBoards()
        {
            return boards;
        }

        /// <summary>
        /// Le mail de l'utilisateur a-t-il le format ? (exemple : "toto@tutu.fr")
        /// </summary>
        /// <returns></returns>
        public virtual bool IsEmailValid()
        {
            return true;
        }

        /// <summary>
        /// Les cartes de l'utilisateur pour un board donné selon un filtre
        /// </summary>
        /// <returns></returns>
        public virtual IList<Card> getOwnFilteredCards(Board board, Predicate<Card> filter)
        {
            return board.getFilteredCards(card => (card.getOwner().Equals(this) && filter(card)));
        }

        /// <summary>
        /// Supprime les cartes de l'utilisateur pour un board donné selon un filtre
        /// </summary>
        /// <param name="board"></param>
        public virtual void RemoveOwnFilteredCards(Board board, Predicate<Card> filter)
        {
            foreach(Card card in board.getFilteredCards(filter))
            {
                card.Delete();
            }
        }

        /// <summary>
        /// S'inscrire afin d'être un utilisater du board
        /// </summary>
        /// <param name="board"></param>
        public virtual void Subsribe(Board board)
        {
            boards.Add(board);
        }

        /// <summary>
        /// Se désinscrire afin de ne plus être un utilisater du board
        /// </summary>
        /// <param name="board"></param>
        public virtual void UnSubscribe(Board board)
        {
            boards.Remove(board);
        }
    }
}
