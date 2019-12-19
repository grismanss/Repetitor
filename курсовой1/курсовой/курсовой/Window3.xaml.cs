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
using BLL;
using BLL.Models;

namespace курсовой
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        DBDataOperation bd = new DBDataOperation();
        public Window3()
        {
            InitializeComponent();
            
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text.Trim()!="" && TextBox2.Text.Trim() != "" && TextBox3.Text.Trim() != "" && PasswordBox1.Password.Trim() != "" && PasswordBox2.Password.Trim() != "")
            {
                if (PasswordBox1.Password != PasswordBox2.Password)
                {
                    MessageBox.Show("Пароли не совпадают");
                }
                else
                {
                    //получить данные из текстовых полей в переменныеы
                    string login = TextBox3.Text.Trim();
                    string password = PasswordBox1.Password.Trim();
                    string name = TextBox1.Text.Trim();
                    string surname = TextBox2.Text.Trim();
                    USER_Model u = new USER_Model();
                    u.name = name;
                    u.surname = surname;
                    u.login = login;
                    u.password = password;
                    bd.CreateUSER(u);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }
}
