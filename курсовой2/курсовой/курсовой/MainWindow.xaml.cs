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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.Models;
using BLL;

namespace курсовой
{
   
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// /*9.	Учет домашних финансов
   /* Ведение расходов и доходов для членов семьи.Расходы складываются из 
    * покупок товаров и трат на услуги.Учесть различные источники дохода.
    * Приложение должно предоставлять функцию формирования бюджета и  информировать
    * о превышении установленного лимита на бюджет.Предоставить возможность формирования
    * отчета «Итоговое сальдо» за указанный период.
 */
    public partial class MainWindow : Window
    {
        public int id = 0;
        DBDataOperation bd;
        public MainWindow()
        {
            InitializeComponent();
            var kernel = new Ninject.StandardKernel(new NinjectRegistrations());

            bd = new DBDataOperation();
            DataContext = new ApplicationViewModel(bd, MainFrame.NavigationService);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
           
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (PasswordBox1.Password.Trim() == "" || TextBox1.Text.Trim() == "")
            {
                MessageBox.Show("Поля не заполнены");
            }
            else
            {
                string Password = PasswordBox1.Password;
                string Login = TextBox1.Text;
                id = bd.GetUSER(Login, Password);
                if (id!=0)
                {
                    Window2 f = new Window2(id);

                    List<INCOME_GUIDE_Model> k= bd.GetINCOME_GUIDE();

                   for (int i = 0; i < k.Count; i++)
                    {
                        f.ComboBox1.Items.Add(k[i]);
                        
                    }

                    f.ComboBox1.SelectedValuePath = "income_guide_code_ID";
                    f.ComboBox1.DisplayMemberPath =  "income_type";
                    f.ComboBox1.SelectedIndex = 0;
                    f.DatePicker1.SelectedDate = DateTime.Now;
                    f.DatePicker2.SelectedDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
                    f.DatePicker3.SelectedDate = DateTime.Now;

                    //сформиррвать загрузку данных датагрил данных за выбранный период
                    f.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window3 f = new Window3();
            f.Show();
            this.Close();
        }
    }
}
