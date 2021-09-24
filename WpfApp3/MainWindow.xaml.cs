using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            List<User> about = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public void Password()
        {
        

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            User user1 = new User(usernameTxb.Text,passwordTxb.Text,nameTxb.Text);
            about.Add(user1);


                var serializer = new JsonSerializer();
                using (var sw = new StreamWriter($"{about[0].Name}.json"))
                {
                    using (var jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                        serializer.Serialize(jw, about);
                    }
                }

            
        }
        public void Time()
        {
            for (int i = 0; i < about.Count; i++)
            {
                if (DateTime.Now.Minute - about[i].CreationDate.Minute <= 1 && DateTime.Now.Second == about[i].CreationDate.Second)
                {
                    File.Delete($"{about[i].Name}.json");
                    about.RemoveAt(i);
                }
            }
        }
    }
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
        public User()
        {

        }

        public User(string username, string password, string name)
        {
            Username = username;
            Password = password;
            Name = name;
        }
    }
}
