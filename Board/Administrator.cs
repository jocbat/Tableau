using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardManipulation
{
    public class Administrator : User
    {
        /// <summary>
        /// Supprimer un board administré
        /// </summary>
        public virtual void DeleteBoard(Board board)
        {
            board.Delete();
        }

        public virtual void AllowAdministratorAccess(User user)
        {
            user
        }
    }
}
