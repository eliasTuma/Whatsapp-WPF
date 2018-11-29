using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpDatabase
{
    public class Contacts
    {
        public int ContactsId { get; set; }
        public string Username { get; set; }
        public string Contact { get; set; }

        //One To Many
        public virtual User User { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Contacts()
        {

        }
        /// <summary>
        /// Contacts constructor
        /// </summary>
        /// <param name="_username">username</param>
        /// <param name="_contact">contact</param>
        public Contacts(string _username, string _contact)
        {
            Username = _username;
            Contact = _contact;
        }
    }
}
