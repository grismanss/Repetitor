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
using BLL.Models;
using BLL;

namespace курсовой
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public int id;
        DBDataOperation bd = new DBDataOperation();

        public Window2(int newid)
        {
            InitializeComponent();
            id = newid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            INCOME_Model income = new INCOME_Model();
            income.income_user_FK = id;

            income.income_date = DatePicker1.SelectedDate;
            income.income_size = Convert.ToInt32(TextBox1.Text);
            income.income_guide_FK = Convert.ToInt32(ComboBox1.SelectedValue);
            bd.CreateINCOME(income);
        }
    }
}
