using cSharpClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows;
using Newtonsoft.Json;
using cSharpDatabase;

namespace cSharpClient
{
    /// <summary>
    /// Interaction logic for Contacts.xaml
    /// </summary>
    public partial class ContactsView : Window
    {
        public List<ContactsData> ListData = new List<ContactsData>();
        public ContactsView()
        {
            InitializeComponent();
            contactsListView.ItemsSource = ListData;
            UpdateContacsList();
        }

        private void UpdateContacsList()
        {
            try
            {
                using (var c = new HttpClient())
                {
                    // Get Request to get messages from Message Controller
                    var messages =
                         c.GetStringAsync("http://localhost:23888/api/Message").Result;

                    // No messages
                    if (messages == null)
                        return;

                    // DeserializeObject that was sent by the server to list of messages
                    var messagesList = JsonConvert.DeserializeObject<List<Message>>(messages);

                    CreateListOfContactsData(messagesList);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateListOfContactsData(List<Message> messagesList)
        {
            List<ContactsData> data = new List<ContactsData>();
            try
            {
                // Get contact list for each contact
                using (var c = new HttpClient())
                {
                    var loggedInUser = Properties.Settings.Default["username"].ToString();
                    var contacts =
                         c.GetStringAsync(String.Format("http://localhost:23888/api/Users?_requestedUser={0}", loggedInUser)).Result;

                    if (contacts == null)
                        return;

                    //Deserialize json object to List of Contacts
                    var contactsList = JsonConvert.DeserializeObject<List<Contacts>>(contacts);

                    // Fetch the contacts and their last messages to data list
                    data = FetchContactsWithMessages(loggedInUser, contactsList, messagesList, data);

                    // Update ContactListView.ItemsSource
                    if (data != null)
                    {
                        contactsListView.ItemsSource = null;
                        contactsListView.ItemsSource = data;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private List<ContactsData> FetchContactsWithMessages(string loggedInUser, List<Contacts> contactsList, List<Message> messagesList, List<ContactsData> data)
        {
            foreach (Contacts contact in contactsList)
            {
                string name = "";
                using (var c = new HttpClient())
                {
                    name =
                       c.GetStringAsync(String.Format("http://localhost:23888/api/Users?_requestedName={0}", contact.Contact)).Result;
                }
                var result = messagesList.Where(message => message.Sender.Equals(loggedInUser) && message.Reciever.Equals(contact.Contact)
                || message.Sender.Equals(contact.Contact) && message.Reciever.Equals(loggedInUser)).ToList();

                // No Messages between user and contact
                if (result.Count == 0)
                {
                    // Add empty message to the data with -10 days to DateTime.Now
                    data.Add(new ContactsData(name, contact.Contact, "", DateTime.Now.AddDays(-10)));
                }
                else
                {
                    // Sort the messages by date and add it to the data list
                    List<Message> sortedMessages = (result.OrderBy(message => message.Body)).ToList();
                    data.Add(new ContactsData(name, contact.Contact, sortedMessages[0].Body, sortedMessages[0].Date));
                }
            }

            return data;
        }

        private void listViewItem_Click(object sender, RoutedEventArgs e)
        {
            var item = contactsListView.SelectedItem;
            Window window = new Conversation(((ContactsData)item).Username);
            window.ShowDialog();
        }

        // Sign out menu click
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var loggedInUser = Properties.Settings.Default["username"].ToString();

            using (var c = new HttpClient())
            {
                // Get Resquest
                var res =
                    c.GetStringAsync(String.Format("http://localhost:23888/api/Users?signOutUsername={0}", loggedInUser)).Result;
            }

            // Update the username in properties settings so the next time we run the app it starts in login window
            Properties.Settings.Default["username"] = "none";
            Properties.Settings.Default.Save();
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create Threading.DispatcherTimer that execute UpdateGUI every 10 seconds
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(GetUpdatedList);
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Start();
        }

        private void GetUpdatedList(object sender, EventArgs e)
        {
            UpdateContacsList();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Window window = new AddOrRemoveContact(Properties.Settings.Default["username"].ToString());
            window.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Window window = new AddOrRemoveContact(Properties.Settings.Default["username"].ToString());
            window.ShowDialog();
        }
    }
}
