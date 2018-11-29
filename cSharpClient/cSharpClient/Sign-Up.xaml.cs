using System;
using System.Collections.Generic;
using System.Linq;
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
using cSharpDatabase;
using System.Net.Http;

namespace cSharpClient
{
    /// <summary>
    /// Interaction logic for Sign_Up.xaml
    /// </summary>
    public partial class Sign_Up : Window
    {
        public Sign_Up()
        {
            InitializeComponent();
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if any of the information is missing
            if(String.IsNullOrWhiteSpace(usernameText.Text) || String.IsNullOrWhiteSpace(passwordText.Text)
                || String.IsNullOrWhiteSpace(nameText.Text))
            {
                MessageBox.Show("Please fill all the information.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Send Get Request to the server with the new user's information
            using(var c = new HttpClient())
            {
                var result =
                    c.GetStringAsync(String.Format("http://localhost:23888/api/Users?username={0}&password={1}&name={2}", usernameText.Text
                    , passwordText.Text, nameText.Text)).Result;
                MessageBox.Show(result);
                // Keep the window open
                if (result.Equals("Username already exists."))
                    return;
                this.Close();
            }

        }
    }
}
