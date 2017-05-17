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
            EmployeesList.Add(new Employee() { EmployeeId = 100, LastName = "Doe", FirstName = "John" });
            EmployeesList.Add(new Employee() { EmployeeId = 101, LastName = "Doe", FirstName = "William" });
            EmployeesList.Add(new Employee() { EmployeeId = 102, LastName = "Boy", FirstName = "Atta"});
        }

        public void RemoveEmployee(int employeeId)
        {
            Employee toDelete = EmployeesList.Find(employee => { if (employee.EmployeeId == employeeId) return true; return false; });

            if (toDelete != null)
                EmployeesList.Remove(toDelete); 
        }
    }
}
