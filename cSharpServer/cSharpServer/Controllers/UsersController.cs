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
    public class UsersController : ApiController
    {
        private UserModel model;

        /// <summary>
        /// Default constructor
        /// </summary>
        public UsersController()
        {
            model = new UserModel();
        }

        /// <summary>
        /// Gets all the users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<User> GetAllUsers()
        {
            return model.GetAllUsers();

        }

        /// <summary>
        /// Gets all the contacts for requested user
        /// </summary>
        /// <param name="_requestedUser">requested user</param>
        /// <returns>list of contacts</returns>
        [HttpGet]
        public List<Contacts> GetContacts(string _requestedUser)
        {
            return model.GetContacts(_requestedUser);
        }

        /// <summary>
        /// Gets the name of the requested username
        /// </summary>
        /// <param name="_requestedName">username</param>
        /// <returns>User's name</returns>
        [HttpGet]
        public string GetName(string _requestedName)
        {
            return model.GetUsersName(_requestedName);
        }

        /// <summary>
        /// Add a given username to contacts
        /// </summary>
        /// <param name="_contactsUsername">requested username</param>
        /// <param name="_loggedInUser">logged in username</param>
        /// <returns></returns>
        [HttpGet]
        public string AddNewContact(string _contactsUsername, string _loggedInUser)
        {
            return model.AddNewContact(_contactsUsername, _loggedInUser);
        }

        /// <summary>
        /// Removes the user from contacts and removes all the messages related to him
        /// </summary>
        /// <param name="_contactToRemove">username to remove from contacts</param>
        /// <param name="_loggedInUser">logged in username</param>
        /// <returns></returns>
        [HttpGet]
        public string RemoveContact(string _contactToRemove, string _loggedInUser)
        {
            return model.RemoveContact(_contactToRemove, _loggedInUser);
        }

        /// <summary>
        /// Sign up a new user
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <param name="name">name</param>
        /// <returns>success of fail message</returns>
        [HttpGet]
        public string SignUp(string username, string password, string name)
        {
            return model.SignUp(username, password, name);
        }

        /// <summary>
        /// Sign in user to the application
        /// </summary>
        /// <param name="loginUsername">username</param>
        /// <param name="loginPassword">password</param>
        /// <returns>success/fail message</returns>
        [HttpGet]
        public string SignIn(string loginUsername, string loginPassword)
        {
            return model.SignIn(loginUsername, loginPassword);
        }

        /// <summary>
        /// Sign out from application
        /// </summary>
        /// <param name="signOutUsername">username</param>
        [HttpGet]
        public void SignOut(string signOutUsername)
        {
            model.SignOut(signOutUsername);
        }


    }
}
