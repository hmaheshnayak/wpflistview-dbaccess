using ListView_DatabaseAccess.DataAccessLayer;
using ListView_DatabaseAccess.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace ListView_DatabaseAccess.ViewModels
{
    class DeleteEmployeeCommand : ICommand
    {
        Action ExecuteMethod;
        Func<bool> CanExecuteMethod;

        public DeleteEmployeeCommand(Action executeMethod)
        {
            ExecuteMethod = executeMethod;
        }

        public DeleteEmployeeCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            ExecuteMethod = executeMethod;
            CanExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteMethod != null)
                return CanExecuteMethod();

            if (ExecuteMethod != null)
                return true;

            return false;
        }

        public void Execute(object parameter)
        {
            ExecuteMethod?.Invoke();
        }
    }

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

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get
            {
                return selectedEmployee;
            }
            
            set
            {
                selectedEmployee = value;
                DeleteEmployee.RaiseCanExecuteChanged();
            }
        }

        public EmployeesViewModel()
        {
            employeeStore = EmployeeStore.GetInstance();
            EmployeesList = new ObservableCollection<Employee>();

            LoadEmployees();

            DeleteEmployee = new DeleteEmployeeCommand(OnDelete, CanDelete);
        }

        public DeleteEmployeeCommand DeleteEmployee { get; set; }

        public void LoadEmployees()
        {
            employeeStore.LoadEmployees();

            EmployeesList = new ObservableCollection<Employee>(employeeStore.EmployeesList);
        }

        private bool CanDelete()
        {
            return SelectedEmployee != null;
        }

        private void OnDelete()
        {
            employeeStore.RemoveEmployee(selectedEmployee.EmployeeId);

            EmployeesList.Clear();
            employeeStore.EmployeesList.ForEach(employee => EmployeesList.Add(employee));
        }
    }
}
