using Rent_a_Car.Commons.Conceretes.Helpers;
using Rent_a_Car.Commons.Conceretes.Loggers;
using Rent_a_Car.DataAccess.Conceretes;
using Rent_a_Car.Models.Concerets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Conceretes
{
    public class RentLogic : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public bool InsertRent(Rent entity)
        {
            try
            {
                bool isSuccess;
                using (var repo = new RentRepository())
                {
                    isSuccess = repo.Insert(entity);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("BusinessLogic:RentLogic::InsertRent::Error occured.", ex);
            }
        }

        public IList<Rent> SelecAllRents()
        {
            IList<Rent> rents = new List<Rent>();
            try
            {
                using (var repo = new RentRepository())
                {
                    rents = repo.SelectAll();
                }
                return rents;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("BusinessLogic:RentLogic::SelectAllRents::Error occured.", ex);
            }
        }

        public Rent SelectRentById(int id)
        {
            Rent rent = new Rent();
            try
            {
                using (var repo = new RentRepository())
                {
                    rent = repo.SelectById(id);
                    if (rent == null)
                        throw new NullReferenceException("Rent doesn't exists!");

                }
                return rent;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("BusinessLogic:RentLogic::SelectRentById::Error occured.", ex);
            }
        }

        public IDictionary<int, int> GetRentCountsByMonths()
        {
            try
            {
                IDictionary<int, int> response = new Dictionary<int, int>();
                using (var repo = new RentRepository())
                {
                    response = repo.RentCounts();
                }
                return response;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("BusinessLogic:RentLogic::GetRentCountsByMonths::Error occured.", ex);
            }
        }

        public bool DeleteRentById(int id)
        {
            try
            {
                bool isSuccess;
                using (var repo = new RentRepository())
                {
                    isSuccess = repo.DeleteById(id);
                    
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("BusinessLogic:RentLogic::DeleteRentById::Error occured.", ex);
            }
        }

        public bool UpdateRent(Rent entity)
        {
            try
            {
                bool isSuccess;
                using (var repo = new RentRepository())
                {
                    isSuccess = repo.Update(entity);
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("BusinessLogic:RentLogic::UpdateRent::Error occured.", ex);
            }
        }

    }
}
