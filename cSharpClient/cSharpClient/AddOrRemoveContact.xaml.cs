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

namespace cSharpClient
{
    /// <summary>
    /// Interaction logic for AddOrRemoveContact.xaml
    /// </summary>
    public partial class AddOrRemoveContact : Window
    {
        private string loggedInUsername;

        public AddOrRemoveContact()
        {
            InitializeComponent();
        }
        public AddOrRemoveContact(string _loggedInUsername)
        {
            InitializeComponent();
            this.loggedInUsername = _loggedInUsername;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(usernameText.Text))
            {
                MessageBox.Show("Please enter username first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string requestedUsername = usernameText.Text;
            try
            {
                using (var c = new HttpClient())
                {
                    var result =
                        c.GetStringAsync(String.Format("http://localhost:23888/api/Users?_contactsUsername={0}&_loggedInUser={1}",
                        requestedUsername, loggedInUsername)).Result;
                    if (result.Equals("\"User Does Not Exist\""))
                    {
                        MessageBox.Show(result, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    //""
                    if (result.Equals("\"Already in contact list\""))
                    {
                        MessageBox.Show(requestedUsername + " already in contact list", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (result.Equals("\"" + requestedUsername + " added to contacts\""))
                    {
                        MessageBox.Show(requestedUsername + " added to contacts", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                        return;
                    }

                    // If server thrown an error
                    MessageBox.Show(result, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(usernameText.Text))
            {
                MessageBox.Show("Please enter username first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string requestedUsername = usernameText.Text;

            try
            {
                using (var c = new HttpClient())
                {
                    var result =
                        c.GetStringAsync(String.Format("http://localhost:23888/api/Users?_contactToRemove={0}&_loggedInUser={1}",
                        requestedUsername, loggedInUsername)).Result;
                    if (result.Equals("\"User Does Not Exist\""))
                    {
                        MessageBox.Show(result, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (result.Equals("\"User and messages removed\""))
                    {
                        MessageBox.Show(result, "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                        return;
                    }

                    // If server thrown an error
                    MessageBox.Show(result, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
