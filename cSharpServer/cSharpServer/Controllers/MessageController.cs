using cSharpDatabase;
using cSharpServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace cSharpServer.Controllers
{
    public class MessageController : ApiController
    {
        private MessageModel model;

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public MessageController()
        {
            model = new MessageModel();
        }

        /// <summary>
        /// Returns all the messages between two users
        /// </summary>
        /// <param name="_user">username</param>
        /// <param name="_contact">contact</param>
        /// <returns>list of messages</returns>
        [HttpGet]
        public List<Message> GetConversation(string _user, string _contact)
        {
            return model.GetMessages(_user, _contact);
        }

        /// <summary>
        /// Gets all the messages from the database
        /// </summary>
        /// <returns>< list of the messages/returns>
        [HttpGet]
        public List<Message> GetAllMessages()
        {
            return model.GetAllMessages();
        }

        /// <summary>
        /// Send a new message to contact
        /// </summary>
        /// <param name="loggedInUser"></param>
        /// <param name="contactUser"></param>
        /// <param name="date"></param>
        /// <param name="message"></param>
        [HttpGet]
        public void SendMessage(string loggedInUser, string contactUser, DateTime date, string message)
        {
            model.SendMessage(loggedInUser, contactUser, date, message);
        }
    }
}
