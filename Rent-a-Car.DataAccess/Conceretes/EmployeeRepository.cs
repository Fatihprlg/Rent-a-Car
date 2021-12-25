using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_a_Car.DataAccess.Abstractions;
using Rent_a_Car.Models.Concerets;

namespace Rent_a_Car.DataAccess.Conceretes
{
    class EmployeeRepository : IRepository<Employee>
    {
        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Employee entity)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Employee SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
