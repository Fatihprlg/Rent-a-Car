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
    public class AdminLogic : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public Admin SelectAdminById(int id)
        {
            try
            {
                Admin responseEntitiy;
                using (var repo = new AdminRepository())
                {
                    responseEntitiy = repo.SelectById(id);
                    if (responseEntitiy == null)
                        throw new NullReferenceException("Admin doesn't exists!");
                }
                return responseEntitiy;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("BusinessLogic:AdminLogic::SelectAdminById::Error occured.", ex);
            }
        }

        public bool LoginControl(string email, string password)
        {
            bool response = false;
            try
            {
                using(var repo = new AdminRepository())
                {
                    IList<Admin> admins = repo.SelectAll();
                    Admin admin = admins.Where(a => a.Email.Equals(email) && a.Sifre.Equals(password)).FirstOrDefault();
                    if (admin != null) response = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("BusinessLogic:AdminLogic::LoginControl::Error occured.", ex);
            }
        }

    }
}
