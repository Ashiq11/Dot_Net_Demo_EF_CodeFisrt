using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private DataContext context;

        public DepartmentRepository() { this.context = new DataContext(); }

        public List<Department> GetAll()
        {
            return this.context.Departments.ToList();
        }

        public Department Get(int id)
        {
            return this.context.Departments.SingleOrDefault(d => d.Id == id);
        }

        public int Insert(Department dept)
        {
            this.context.Departments.Add(dept);
            return this.context.SaveChanges();
        }

        public int Update(Department dept)
        {
            Department deptToUpdate = this.context.Departments.SingleOrDefault(d => d.Id == dept.Id);
            deptToUpdate.Name = dept.Name;
            deptToUpdate.Location = dept.Location;

            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Department deptToDelete = this.context.Departments.SingleOrDefault(d => d.Id == id);
            this.context.Departments.Remove(deptToDelete);
            return this.context.SaveChanges();
        }
    }
}
