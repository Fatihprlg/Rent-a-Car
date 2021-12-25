using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_a_Car.Models.Concerets;
using Rent_a_Car.DataAccess.Conceretes;

namespace Rent_a_Car.BusinessLogic.Concerets
{
    public class CustomerLogic : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public CustomerLogic()
        {

        }
        public bool InsertCustomer(Customer entity)
        {
            return true;
        }
    }
}
