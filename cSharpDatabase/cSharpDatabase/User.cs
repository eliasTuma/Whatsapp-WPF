using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpDatabase
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        // One To Many
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Contacts> Contacts { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public User()
        {

        }

        /// <summary>
        /// User Constructor
        /// </summary>
        /// <param name="_username">usernme</param>
        /// <param name="_password">pass</param>
        /// <param name="_name">name of the user</param>
        public User(string _username, string _password, string _name)
        {
            Username = _username;
            Password = _password;
            Name = _name;
        }
    }
}
