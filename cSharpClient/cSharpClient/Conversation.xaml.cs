using cSharpClient.Data;
using cSharpDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace cSharpClient
{
    /// <summary>
    /// Interaction logic for Conversation.xaml
    /// </summary>
    public partial class Conversation : Window
    {

        private List<ConversationData> data = new List<ConversationData>();
        private string _contactUser;
        public Conversation()
        {
            InitializeComponent();
        }

        public Conversation(string contactUser)
        {
            InitializeComponent();
            GetMessages();
            _contactUser = contactUser;
            conversationListView.ItemsSource = data;

            // Create timer to update the chat list every 10 seconds
            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(UpdateMessages);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
        }

        private void UpdateMessages(object sender, EventArgs e)
        {
            GetMessages();
        }

        private void GetMessages()
        {
            string loggedInUser = Properties.Settings.Default["username"].ToString();
            try
            {
                using (var c = new HttpClient())
                {
                    var result =
                         c.GetStringAsync(String.Format("http://localhost:23888/api/Message?_user={0}&_contact={1}", loggedInUser, _contactUser)).Result;
                    List<Message> messages = JsonConvert.DeserializeObject<List<Message>>(result);
                    if (messages.Count == 0)
                        return;
                    messages = messages.OrderBy(message => message.Date).ToList();
                    data.Clear();

                    for (int i = 0; i < messages.Count; i++)
                    {
                        if (messages[i].Sender.Equals(loggedInUser))
                        {
                            data.Add(new ConversationData(messages[i].Body, "", messages[i].Date));
                        }
                        else
                        {
                            data.Add(new ConversationData("", messages[i].Body, messages[i].Date));
                        }
                    }

                    conversationListView.ItemsSource = null;
                    conversationListView.ItemsSource = data;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(messageToSendText.Text))
            {
                return;
            }
            string loggedInUser = Properties.Settings.Default["username"].ToString();
            using (var c = new HttpClient())
            {
                var result =
                         c.GetStringAsync(String.Format("http://localhost:23888/api/Message?loggedInUser={0}&contactUser={1}&date={2}&message={3}", loggedInUser, _contactUser, DateTime.Now, messageToSendText.Text)).Result;
                messageToSendText.Text = "";
            }
        }
    }
}
