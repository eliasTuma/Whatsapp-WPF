using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpDatabase
{
    public class LoggedIn
    {
        public int LoggedInId { get; set; }
        public string Username { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoggedIn()
        {

        }

        /// <summary>
        /// LoggedIn constructor
        /// </summary>
        /// <param name="_user">usernmae</param>
        public LoggedIn(string _user)
        {
            Username = _user;
        }
    }
}
