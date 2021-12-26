using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_a_Car.Models.Concerets;
using Rent_a_Car.DataAccess.Conceretes;
using Rent_a_Car.Commons.Conceretes.Helpers;
using Rent_a_Car.Commons.Conceretes.Loggers;

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
            try
            {
                bool isSuccess;
                using (var repo = new CustomerRepository())
                {
                    isSuccess = repo.Insert(entity);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("BusinessLogic:CustomerBusiness::InsertCustomer::Error occured.", ex);
            }
        }
    }
}
