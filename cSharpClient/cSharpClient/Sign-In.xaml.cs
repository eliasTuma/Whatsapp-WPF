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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cSharpClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            // Check if the username text and password are not empty
            if (String.IsNullOrWhiteSpace(usernameText.Text) || String.IsNullOrWhiteSpace(usernameText.Text))
            {
                MessageBox.Show("Please fill all the information.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var c = new HttpClient())
            {
                var result =
                    c.GetStringAsync(String.Format("http://localhost:23888/api/Users?loginUsername={0}&loginPassword={1}",
                    usernameText.Text, passwordText.Text)).Result;
                switch (result)
                {
                    case "\"User does not exist\"":
                    case "\"User already logged in\"":
                    case "\"Wrong Credentials\"":
                        MessageBox.Show(result, "Fail To Sign In", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                }

                if (result.Equals("\"Logged in successfuly\""))
                {
                    MessageBox.Show(result, "Logged In", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Save username in project settings
                    Properties.Settings.Default["username"] = usernameText.Text;
                    Properties.Settings.Default.Save();

                    Window window = new ContactsView();
                    this.Close();
                    window.Show();
                }
            }
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Sign_Up();
            window.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default["username"] = "none";
            Properties.Settings.Default.Save();
            // Check if user already logged in
            if (Properties.Settings.Default["username"].ToString() != "none")
            {
                Window window = new ContactsView();
                this.Close();
                window.Show();
            }
        }
    }
}
