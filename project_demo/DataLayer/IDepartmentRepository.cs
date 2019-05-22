using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department Get(int id);
        int Insert(Department dept);
        int Update(Department dept);
        int Delete(int id);
    }
}
