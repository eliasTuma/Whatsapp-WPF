using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cSharpDatabase;

namespace cSharpServer.Models
{
    public class UserModel
    {
        private static CSharpDB context;

        public UserModel()
        {
            context = new CSharpDB();
        }

        /// <summary>
        /// Gets all the users from the database
        /// </summary>
        /// <returns>list of users</returns>
        public List<User> GetAllUsers()
        {
            try
            {
                return context.Users.ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Gets all the contact for the requested user
        /// </summary>
        /// <param name="_requestedUser">requeted user</param>
        /// <returns>list of contacs</returns>
        public List<Contacts> GetContacts(string _requestedUser)
        {
            var contacts = context.Contacts.Where(contact => contact.Username.Equals(_requestedUser));
            if (contacts == null)
                return null;
            return contacts.ToList();
        }

        /// <summary>
        /// Gets the name of the requested username
        /// </summary>
        /// <param name="_requestedName">username</param>
        /// <returns>User's name</returns>
        public string GetUsersName(string _requestedName)
        {
            return context.Users.FirstOrDefault(user => user.Username.Equals(_requestedName)).Name;
        }


        /// <summary>
        /// Add a user to contacts list
        /// </summary>
        /// <param name="_contactsUsername">requested username</param>
        /// <param name="_loggedInUser">logged in username</param>
        /// <returns></returns>
        public string AddNewContact(string _contactsUsername, string _loggedInUser)
        {
            try
            {
                // Check if the given username exists
                var check1 = context.Users.FirstOrDefault(user => user.Username.Equals(_contactsUsername));
                if (check1 == null)
                    return "User Does Not Exist";
                var check2 = context.Contacts.FirstOrDefault(user => user.Username.Equals(_loggedInUser) && user.Contact.Equals(_contactsUsername));
                if (check2 != null)
                    return "Already in contact list";
                var loggedInUser = context.Users.FirstOrDefault(user => user.Username.Equals(_loggedInUser));
                context.Contacts.Add(new Contacts(_loggedInUser, check1.Username));
                context.Contacts.Add(new Contacts(check1.Username, _loggedInUser));
                context.SaveChanges();
                return String.Format("{0} added to contacts", _contactsUsername);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Removes the user from contacts and removes all the messages related to him
        /// </summary>
        /// <param name="_contactToRemove">username to remove from contacts</param>
        /// <param name="_loggedInUser">logged in username</param>
        /// <returns>result message</returns>
        public string RemoveContact(string _contactToRemove, string _loggedInUser)
        {
            // Check if the given username exists
            var check1 = context.Users.FirstOrDefault(user => user.Username.Equals(_contactToRemove));
            if (check1 == null)
                return "User Does Not Exist";
            var check2 = context.Contacts.FirstOrDefault(user => (user.Username.Equals(_loggedInUser) && user.Contact.Equals(_contactToRemove))
            || (user.Username.Equals(_contactToRemove) && user.Contact.Equals(_loggedInUser)));

            if (check2 == null)
                return "Contact does not exists in your list";

            context.Contacts.Remove(check2);
            context.SaveChanges();
            var messageModel = new MessageModel();
            return messageModel.RemoveAllMessage(_loggedInUser, _contactToRemove);
        }

        /// <summary>
        /// Sign Up new user
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <param name="name">name</param>
        /// <returns></returns>
        public string SignUp(string username, string password, string name)
        {
            try
            {
                // Check if username exists
                var res = context.Users.FirstOrDefault(user => user.Username.Equals(username));
                if (res != null)
                    return "Username already exists.";

                // Create and add new user
                context.Users.Add(new User(username, password, name));
                context.SaveChanges();
                return "Sign-Up Completed !";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="loginUsername">username</param>
        /// <param name="loginPassword">password</param>
        /// <returns></returns>
        public string SignIn(string loginUsername, string loginPassword)
        {
            try
            {
                // Check if username exists
                var check1 = context.Users.FirstOrDefault(user => user.Username.Equals(loginUsername));
                if (check1 == null)
                    return "User does not exist";

                // Check if user already logged in
                var check2 = context.LoggedInUsers.FirstOrDefault(user => user.Username.Equals(loginUsername));
                if (check2 != null)
                    return "User already logged in";

                // Check for credentials
                var check3 = context.Users.FirstOrDefault(user => user.Username.Equals(loginUsername) && user.Password.Equals(loginPassword));
                if (check3 == null)
                    return "Wrong Credentials";

                // Good credentials, add user to logged in tabel
                context.LoggedInUsers.Add(new LoggedIn(loginUsername));
                context.SaveChanges();

                return "Logged in successfuly";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Sign out
        /// </summary>
        /// <param name="signOutUsername">username</param>
        public void SignOut(string signOutUsername)
        {
            try
            {
                var onlineUser = context.LoggedInUsers.FirstOrDefault(user => user.Username.Equals(signOutUsername));
                if (onlineUser != null)
                    context.LoggedInUsers.Remove(onlineUser);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}