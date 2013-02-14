using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardManipulation
{
    public class Column
    {
        public Column()
        {
            cards = new List<Card>();
        }
        
        public string title;

        // le board dont est issu la colonne
        private Board currentBoard;

        // L'ensemble des cartes de la colonne
        private IList<Card> cards;
        public virtual IList<Card> getCards()
        {
            return cards;
        }

        public virtual void AddCard(Card card)
        {
            cards.Add(card);
            // la colonne courante de la carte ajoutée doit pointer vers la colonne qui l'ajoute
            card.setActualColumn(this);
        }

        public virtual void RemoveCard(Card card)
        {
            cards.Remove(card);
            // la colonne courante de la carte ne doit plus pointer vers aucune colonne
            card.setActualColumn(null);
        }

        /// <summary>
        /// La liste des cartes de la colonne filtrée
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IList<Card> getFilteredCards(Predicate<Card> filter)
        {
            return (IList<Card>) getCards().Where(card => filter(card));
        }

        /// <summary>
        /// Supprime les cartes de la colonne selon un filtre
        /// </summary>
        /// <param name="filter"></param>
        public void RemoveFilteredCards(Predicate<Card> filter)
        {
            foreach (Card card in getFilteredCards(filter))
            {
                cards.Remove(card);
            }
        }
        
    }
}
