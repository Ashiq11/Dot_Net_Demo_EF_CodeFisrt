using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private DataContext context;

        public EmployeeRepository() { this.context = new DataContext();}

        public List<Employee> GetAll()
        {
            return this.context.Employees.ToList();
        }

        public Employee Get(int id)
        {
            return this.context.Employees.SingleOrDefault(e => e.Id == id);
        }

        public int Insert(Employee emp)
        {
            this.context.Employees.Add(emp);
            return this.context.SaveChanges();
        }

        public int Update(Employee emp)
        {
            Employee empToUpdate = this.context.Employees.SingleOrDefault(e => e.Id == emp.Id);
            empToUpdate.Name = emp.Name;
            empToUpdate.Salary = emp.Salary;
            empToUpdate.DepartmentId = emp.DepartmentId;

            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Employee empToDelete = this.context.Employees.SingleOrDefault(e => e.Id == id);
            this.context.Employees.Remove(empToDelete);

            return this.context.SaveChanges();
        }
    }
}
