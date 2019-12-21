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
            this.DataContext = new ViewModel1(bd);
            
           // MessageBox.Show("");
           // Binding binding = new Binding();
            //ComboBox1.ItemsSource=Binding.ExpenseGuide

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*if (this.Title == "Доходы")
            {
                INCOME_Model income = new INCOME_Model();
                income.income_user_FK = id;

                income.income_date = DatePicker1.SelectedDate;
                income.income_size = Convert.ToInt32(TextBox1.Text);
                income.income_guide_FK = Convert.ToInt32(ComboBox1.SelectedValue);
                bd.CreateINCOME(income);
            }
            else if (this.Title == "Расходы")
            {
                EXPENSE_Model expense = new EXPENSE_Model();
                expense.expense_user_FK = id;

                expense.expense_date = DatePicker1.SelectedDate;
                expense.expense_size = Convert.ToInt32(TextBox1.Text);
                expense.expense_guide_FK = Convert.ToInt32(ComboBox1.SelectedValue);
                bd.CreateEXPENSE(expense);
            }*/
        }
        

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Title = "Расходы";
            //Button1.Background = new Brush(Color.FromRgb(100, 50, 90));
            Label1.Content = "Источники расхода";
            List<EXPENSE_GUIDE_Model> k = bd.GetEXPENSE_GUIDE();
ComboBox1.Items.Clear();
            for (int i = 0; i < k.Count; i++)
            {
                ComboBox1.Items.Add(k[i]);

            }
            
            ComboBox1.SelectedValuePath = "expense_guide_code_ID";
            ComboBox1.DisplayMemberPath = "expense_type";
            ComboBox1.SelectedIndex = 0;
            //List<Order2> d = bd.GetINCOMESELECT((System.DateTime)f.DatePicker2.SelectedDate, (System.DateTime)f.DatePicker3.SelectedDate, id);
           List<Order> d = bd.GetEXPENSESELECT((System.DateTime)DatePicker2.SelectedDate, (System.DateTime)DatePicker3.SelectedDate, id);

          DataGrid1.ItemsSource = d;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Title = "Доходы";
            Label1.Content = "Источники дохода";
            List<INCOME_GUIDE_Model> k = bd.GetINCOME_GUIDE();
            ComboBox1.Items.Clear();
            for (int i = 0; i < k.Count; i++)
            {
                ComboBox1.Items.Add(k[i]);

            }
            
            ComboBox1.SelectedValuePath = "income_guide_code_ID";
            ComboBox1.DisplayMemberPath = "income_type";
            ComboBox1.SelectedIndex = 0;
            List<Order2> d = bd.GetINCOMESELECT((System.DateTime)DatePicker2.SelectedDate, (System.DateTime)DatePicker3.SelectedDate, id);
            //List<Order> d = bd.GetEXPENSESELECT((System.DateTime)f.DatePicker2.SelectedDate, (System.DateTime)f.DatePicker3.SelectedDate, id);

          DataGrid1.ItemsSource = d;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<Order2> d = bd.GetINCOMESELECT((System.DateTime)DatePicker2.SelectedDate, (System.DateTime)DatePicker3.SelectedDate, id);
            //List<Order> d = bd.GetEXPENSESELECT((System.DateTime)f.DatePicker2.SelectedDate, (System.DateTime)f.DatePicker3.SelectedDate, id);

            DataGrid1.ItemsSource = d;
        }
    }
}
