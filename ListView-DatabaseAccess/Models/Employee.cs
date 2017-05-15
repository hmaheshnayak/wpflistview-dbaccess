using System.ComponentModel;

namespace ListView_DatabaseAccess.Models
{
    internal class Employee : INotifyPropertyChanged
    {
        private int empID;
        public int EmployeeId
        {
            get { return empID; }
            set
            {
                empID = value;
                RaisePropertyChanged("EmployeeId");
            }
        }

        private string empName;
        public string EmployeeName
        {
            get { return empName; }
            set
            {
                empName = value;
                RaisePropertyChanged("EmployeeName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}