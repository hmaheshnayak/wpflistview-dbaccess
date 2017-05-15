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

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                RaisePropertyChanged("LastName");
                RaisePropertyChanged("FullName");
            }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                RaisePropertyChanged("FirstName");
                RaisePropertyChanged("FullName");
            }
        }

        public string FullName { get { return firstName + " " + lastName; } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}