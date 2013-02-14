using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardManipulation
{
    public class Card
    {
        private string title;

        /// <summary>
        /// Titre de la carte
        /// </summary>
        /// <returns></returns>
        public virtual string getTitle()
        {
            return title;
        }

        public virtual void setTitle(string value)
        {
            title = value;
        }

        // ce qu'il y a d'écrit sur la carte
        private string body;
        public virtual string getBody()
        {
            return body;
        }

        public virtual void setBody(string value)
        {
            body = value;
        }

        private User owner;

        /// <summary>
        /// le titulaire de la carte
        /// </summary>
        /// <returns></returns>
        public virtual User getOwner()
        {
            return owner;
        }

        public virtual void setOwner(User value)
        {
            owner = value;
        }


        // colonne sur laquelle est posée la carte
        private Column actualColumn;

        internal virtual void setActualColumn(Column column)
        {
            actualColumn = column;
        }

        /// <summary>
        /// colonne sur laquelle est posée la carte
        /// </summary>
        /// <returns></returns>
        public virtual Column getActualColumn()
        {
            return actualColumn;
        }

        public virtual void MoveTo(Column column)
        {
            if (actualColumn != null)
            {
                actualColumn.RemoveCard(this);
            }
            column.AddCard(this);
        }

        public virtual void Delete()
        {
            if (actualColumn != null)
            {
                actualColumn.RemoveCard(this);
            }
            title = "";
            body = "";
            owner = null;
        }

    }
}
