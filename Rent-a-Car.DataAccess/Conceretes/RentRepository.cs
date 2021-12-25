using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_a_Car.DataAccess.Abstractions;
using Rent_a_Car.Models.Concerets;

namespace Rent_a_Car.DataAccess.Conceretes
{
    class RentRepository : IRepository<Rent>
    {
        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Rent entity)
        {
            throw new NotImplementedException();
        }

        public IList<Rent> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Rent SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Rent entity)
        {
            throw new NotImplementedException();
        }
    }
}
