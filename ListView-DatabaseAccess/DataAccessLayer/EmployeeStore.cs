using ListView_DatabaseAccess.Models;
using System.Collections.Generic;

namespace ListView_DatabaseAccess.DataAccessLayer
{
    class EmployeeStore
    {
        private static EmployeeStore storeInstance;

        public static EmployeeStore GetInstance()
        {
            if (storeInstance == null)
            {
                storeInstance = new EmployeeStore();
            }

            return storeInstance;
        }

        public List<Employee> EmployeesList { get; set; }

        private EmployeeStore()
        {
            EmployeesList = new List<Employee>();
        }

        public void LoadEmployees()
        {
            EmployeesList.Add(new Employee() { EmployeeId = 100, EmployeeName = "John Doe" });
            EmployeesList.Add(new Employee() { EmployeeId = 101, EmployeeName = "William Doe" });
            EmployeesList.Add(new Employee() { EmployeeId = 102, EmployeeName = "Atta Boy" });
        }
    }
}
