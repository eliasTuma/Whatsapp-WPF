using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpClient.Data
{
    /// <summary>
    /// Class that holds contacs data
    /// </summary>
    public class ContactsData
    {

        public string Name { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ContactsData()
        {

        }

        /// <summary>
        /// ContactsData constructor
        /// </summary>
        public ContactsData(string _name, string _username, string _message, DateTime _date)
        {
            Name = _name;
            Username = _username;
            Message = _message;
            Date = _date;
        }
    }
}
