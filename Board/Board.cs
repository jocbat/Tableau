using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardManipulation
{
    public class Board
    {
        /// <summary>
        /// Crée un board. Le 1er utilisateur est automatiquement administrateur.
        /// </summary>
        /// <param name="user"></param>
        public Board(User user)
        {
            columns = new List<Column>();
            members = new List<User>();
            members.Add(user);
        }

        private List<User> members;

        public virtual IList<User> getMembers()
        {
            return members;
        }

        private IList<Column> columns;

        /// <summary>
        /// Les colonnes du board
        /// </summary>
        /// <returns></returns>
        public IList<Column> getColumns()
        {
            return columns;
        }

        /// <summary>
        /// Retourne les colonnes du board vérifiant un critère
        /// </summary>
        /// <returns></returns>
        public IList<Column> getFilteredColumns(Predicate<Column> filter)
        {
            return (IList<Column>) columns.Where(column => filter(column));
        }

        private string title;

        public virtual string getTitle()
        {
            return title;
        }

        public virtual void setTitle(string value)
        {
            title = value;
        }

        /// <summary>
        /// Ajouter une colonne au board
        /// </summary>
        /// <param name="column"></param>
        public virtual void AddColumn(Column column)
        {
            columns.Add(column);
        }

        /// <summary>
        /// Retirer une colonne au board
        /// </summary>
        /// <param name="column"></param>
        public virtual void RemoveColumn(Column column)
        {
            columns.Remove(column);
        }

        /// <summary>
        /// Ajoute la carte "card" à la colonne "column"
        /// </summary>
        /// <param name="card"></param>
        /// <param name="column"></param>
        public void PutCardOnColumn(Card card, Column column)
        {
            card.MoveTo(column);
        }

        /// <summary>
        /// Retire la carte "card" de la colonne "column"
        /// </summary>
        /// <param name="card"></param>
        /// <param name="column"></param>
        public void RemoveCardFromColumn(Card card, Column column)
        {
            column.RemoveCard(card);
        }

        /// <summary>
        /// L'ensemble des cartes du board
        /// </summary>
        /// <returns></returns>
        public IList<Card> getCards()
        {
            List<Card> list = new List<Card>();
            foreach (Column column in columns)
            {
                list.AddRange(column.getCards());
            }
            return list;
        }

        /// <summary>
        /// Liste des cartes du board filtrées à l'aide d'un prédicat
        /// </summary>
        /// <param name="filter"></param>
        public IList<Card> getFilteredCards(Predicate<Card> filter)
        {
            return (IList<Card>) getCards().Where(card => filter(card));
        }

        /// <summary>
        /// Supprimer les cartes du board selon un filtre
        /// </summary>
        /// <param name="filter"></param>
        public void RemoveCards(Predicate<Card> filter)
        {
            foreach (Column column in columns)
            {
                column.RemoveFilteredCards(filter);
            }
        }

        /// <summary>
        /// Vide toutes les cartes du board
        /// </summary>
        public void CleanCards()
        {
            RemoveCards(card => true);
        }

        public void Delete()
        {
            CleanCards(); // Pour faire "joli" :p
            foreach (User user in members)
            {
                user.UnSubscribe(this);
            }
        }
    }
}
