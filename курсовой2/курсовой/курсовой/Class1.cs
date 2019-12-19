using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using BLL;

namespace курсовой
{
    public class ApplicationViewModel
    {
        DBDataOperation crud;
        NavigationService nav;


        public ApplicationViewModel(IDbRepository crud, NavigationService nav)
        {
            this.nav = nav;
            this.crud = crud;
            /* List<TimeSlotModel> tsm;
             TimeSlots = new List<TimeSlotViewModel>();
             scheduleTable = new DataTable();
             DataColumn column = new DataColumn();
             DataRow row;
             column.ColumnName = "Time";
             column.DataType = Type.GetType("System.String");
             scheduleTable.Columns.Add(column);
             for (TimeSpan t = new TimeSpan(9, 0, 0); t < new TimeSpan(13, 0, 0); t.Add(new TimeSpan(0, 30, 0)))
             {
                 row = scheduleTable.NewRow();
                 row["Time"] = t.ToString();
             }
             DateTime date1 = new DateTime(2019, 10, 30);
             DateTime date2 = new DateTime(2019, 10, 31);
             List<WorkDayModel> wdm = apSer.SelectWorkDay(3);
             foreach(WorkDayModel workDay in wdm)
             {
                 column = new DataColumn();
                 column.DataType = Type.GetType("System.Bool");

                 tsm = schedule.GetTimeSlots(workDay.WorkDayId);
             }*/
        }

        private ICommand _specialistListCommand;

        public ICommand SpecialistListCommand
        {
            get
            {
                if (_specialistListCommand == null)
                    _specialistListCommand = new RelayCommand(obj =>
                    {
                        nav.Navigate(new View.SpecialistList(new SpecialistPageViewModel(crud, nav)));
                    });
                return _specialistListCommand;
            }
            set { _specialistListCommand = value; }
        }

        private ICommand _categoryListCommand;

        public ICommand CategoryListCommand
        {
            get
            {
                if (_categoryListCommand == null)
                    _categoryListCommand = new RelayCommand(obj =>
                    {
                        nav.Navigate(new View.CategoryList(new CategoryListViewModel(crud, nav)));
                    });
                return _categoryListCommand;
            }
            set { _categoryListCommand = value; }
        }

        private ICommand _appPageCommand;

        public ICommand AppPageCommand
        {
            get
            {
                if (_appPageCommand == null)
                    _appPageCommand = new RelayCommand(obj =>
                    {
                        nav.Navigate(new View.AppointmentPage(new AppointmentPageVM(crud, nav)));
                    });
                return _appPageCommand;
            }
            set { _appPageCommand = value; }
        }

    }
}


