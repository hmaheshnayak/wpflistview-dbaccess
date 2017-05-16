using ListView_DatabaseAccess.DataAccessLayer;
using ListView_DatabaseAccess.Models;
using System.Collections.ObjectModel;

namespace ListView_DatabaseAccess.ViewModels
{
    class EmployeesViewModel
    {
        private EmployeeStore employeeStore; 

        private ObservableCollection<Employee> employeesList;
        public ObservableCollection<Employee> EmployeesList
        {
            get
            {
                return employeesList;
            }

            set
            {
                employeesList = value;
            }
        }

        public EmployeesViewModel()
        {
            employeeStore = EmployeeStore.GetInstance();
            EmployeesList = new ObservableCollection<Employee>();

            LoadEmployees();
        }

        public void LoadEmployees()
        {
            employeeStore.LoadEmployees();

            EmployeesList = new ObservableCollection<Employee>(employeeStore.EmployeesList);
        }

    }
}
