using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_a_Car.DataAccess.Abstractions;
using Rent_a_Car.Models.Concerets;

namespace Rent_a_Car.DataAccess.Conceretes
{
    class VehicleRepository : IRepository<Vehicle>
    {
        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public IList<Vehicle> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Vehicle SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Vehicle entity)
        {
            throw new NotImplementedException();
        }
    }
}
