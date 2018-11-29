using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpDatabase
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }

        // One To Many
        public virtual User UsertId { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Message()
        {
        }

        /// <summary>
        /// Message Constructor
        /// </summary>
        /// <param name="_sender">sender username</param>
        /// <param name="_reciever">reciever username</param>
        /// <param name="_date">date of the message</param>
        /// <param name="_body">body of the message</param>
        public Message(string _sender, string _reciever, DateTime _date, string _body)
        {
            Sender = _sender;
            Reciever = _reciever;
            Date = _date;
            Body = _body;
        }
    }
}
