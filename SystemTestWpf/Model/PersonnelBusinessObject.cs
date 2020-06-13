using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemTestWpf.DataAccessLayer;

namespace SystemTestWpf.Model
{
    public class PersonnelBusinessObject
    {
        List<User> Employee { get; set; }
        public PersonnelBusinessObject()
        {
            Employee = DatabaseLayer.GetEmployeeFromDatabase();
        }

        public List<User> GetEmployees()
        {
            return Employee = DatabaseLayer.GetEmployeeFromDatabase();
        }

        public void AddEmployee(User employee)
        {
            DatabaseLayer.InsertEmployee(employee);
            OnEmployeeChanged();
        }

        public void UpdateEmployee(User employee)
        {
            DatabaseLayer.UpdateEmployee(employee);
            OnEmployeeChanged();
        }

        public void DeleteEmployee(User employee)
        {
            DatabaseLayer.DeleteEmployee(employee);
            OnEmployeeChanged();
        }
        public event EventHandler EmployeeChanged;
        public void OnEmployeeChanged()
        {
            if (EmployeeChanged != null)
                EmployeeChanged(this, null);
        }
    }
}
