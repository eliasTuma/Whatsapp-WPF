using cSharpDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cSharpServer.Models
{
    public class MessageModel
    {
        private static CSharpDB context;

        public MessageModel()
        {
            context = new CSharpDB();
        }
        /// <summary>
        /// Gets all the messages between two users
        /// </summary>
        /// <param name="_user">user</param>
        /// <param name="_contact">contact</param>
        /// <returns></returns>
        public List<Message> GetMessages(string _user, string _contact)
        {
            try
            {
                // Get all the messages where Message.Sender == user && Message.Reciever == contact || the othwise
                var messages = context.Messages.Where(x => (x.Sender.Equals(_user) && x.Reciever.Equals(_contact))
                || (x.Sender.Equals(_contact) && x.Reciever.Equals(_user)));

                if (messages == null)
                    return null;
                return messages.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Gets all the existing messages from the database
        /// </summary>
        /// <returns>list of all the messages</returns>
        public List<Message> GetAllMessages()
        {
            return context.Messages.ToList();
        }

        /// <summary>
        /// Removes all the messages between two users
        /// </summary>
        /// <param name="firstUser"></param>
        /// <param name="secondUser"></param>
        public string RemoveAllMessage(string firstUser, string secondUser)
        {
            try
            {
                var messages = context.Messages.Where(message => (message.Sender.Equals(firstUser) && message.Reciever.Equals(secondUser))
            || (message.Sender.Equals(secondUser) && message.Reciever.Equals(firstUser)));

                if (messages == null)
                    return "User and messages removed";
                foreach (Message m in messages)
                {
                    context.Messages.Remove(m);
                }

                context.SaveChanges();
                return "User and messages removed";
            }
            catch (Exception e)
            {

                return e.Message;
            }

        }

        /// <summary>
        /// Store a new message 
        /// </summary>
        /// <param name="loggedInUser">logged in user</param>
        /// <param name="contactUser">contact user</param>
        /// <param name="date">date</param>
        /// <param name="message">message</param>
        public void SendMessage(string loggedInUser, string contactUser, DateTime date, string message)
        {
            context.Messages.Add(new Message(loggedInUser, contactUser, date, message));
            context.SaveChanges();
        }
    }
}