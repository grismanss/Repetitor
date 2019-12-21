using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BLL;
using BLL.Models;



namespace курсовой
{
    public class ViewModel1 : Vmodel
    {
        DBDataOperation bd;
        public List<EXPENSE_GUIDE_Model> ExpenseGuide { get; set; }
        public List<INCOME_GUIDE_Model> IncomeGuide { get; set; }

        public List<Order> order { get; set; }
       /* private List<Order> dataGrid_;

        public List<Order> _dataGrid
        {
            get { return _dataGrid; }
            set { _dataGrid = value; OnProperty("_dataGrid"); }
        }
        */
        public List<Order2> order2 { get; set; }
       /* private List<Order2> dataGrid2_;

        public List<Order2> _dataGrid2
        {
            get { return _dataGrid2; }
            set { _dataGrid2 = value; OnProperty("_dataGrid"); }
        }
        */
        private EXPENSE_GUIDE_Model a;
        public EXPENSE_GUIDE_Model A
        {
            get { return a; }
            set { a = value; OnProperty("A"); }
        }

        private string Text_;

        public string _text
        {
            get { return Text_; }
            set { Text_ = value; OnProperty("_text"); }
        }

        private DateTime dateTime;

        public DateTime Date
        {
            get { return dateTime; }
            set { dateTime = value; OnProperty("Date"); }
        }

        private DateTime dateTime1;

        public DateTime Date1
        {
            get { return dateTime1; }
            set { dateTime1 = value; OnProperty("Date1"); }
        }

        private DateTime dateTime2;

        public DateTime Date2
        {
            get { return dateTime2; }
            set { dateTime2 = value; OnProperty("Date2"); }
        }

        public RelayCommand myRelay { get
            {
                return new RelayCommand(o => {                  
                                       
                    INCOME_Model income = new INCOME_Model();
                    income.income_user_FK = App.id;
                    income.income_date = Date;
                    income.income_size = Convert.ToInt32(_text);
                    income.income_guide_FK = Convert.ToInt32(A.expense_guide_code_ID);
                    bd.CreateINCOME(income);
                });
            } }


        public ViewModel1(DBDataOperation myBd)
        {
            bd = myBd;
            ExpenseGuide = bd.GetEXPENSE_GUIDE();
            Date = DateTime.Now;
            Date1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Date2 = DateTime.Now;
            order2 = bd.GetINCOMESELECT(Date1, Date2, App.id);
            order = bd.GetEXPENSESELECT(Date1, Date2, App.id);

        }
    }
}
