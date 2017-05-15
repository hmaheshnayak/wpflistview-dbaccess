namespace ListView_DatabaseAccess.Models
{
    internal class Employee
    {
        private int empID;

        public int EmployeeId
        {
            get { return empID; }
            set { empID = value; }
        }

        private string empName;

        public string EmployeeName
        {
            get { return empName; }
            set { empName = value; }
        }
    }
}