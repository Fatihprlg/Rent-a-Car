using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_a_Car.Commons.Conceretes.Helpers;
using Rent_a_Car.Commons.Conceretes.Loggers;
using Rent_a_Car.DataAccess.Abstractions;
using Rent_a_Car.Models.Concerets;
using Rent_a_Car.DataAccess;

namespace Rent_a_Car.DataAccess.Conceretes
{

    public class AdminRepository : IRepository<Admin>, IDisposable
    {

        public bool DeleteById(int id)
        {
            try
            {
                using(AracLazimEntities data = new AracLazimEntities())
                {
                    data.Yonetici.Remove(data.Yonetici.Where(y => y.ID == id).FirstOrDefault());
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("AdminRepository::Insert:Error occured.", ex);
            }
        } 

        public bool Insert(Admin entity)
        {

            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    Yonetici yonetici = new Yonetici()
                    {
                        TC = entity.TC,
                        Isim = entity.Isim,
                        Soyisim = entity.Soyisim,
                        Telefon = entity.Telefon,
                        Email = entity.Email,
                        Sifre = entity.Sifre
                    };
                    data.Yonetici.Add(yonetici);
                    data.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("AdminRepository::Insert:Error occured.", ex);
            }
        }

        public IList<Admin> SelectAll()
        {
            IList<Admin> admins = new List<Admin>();
            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    var yoneticiler = from y in data.Yonetici select y;

                    foreach (var y in yoneticiler)
                    {
                        Admin temp = new Admin();
                        temp.ID = y.ID;
                        temp.TC = y.TC;
                        temp.Isim = y.Isim;
                        temp.Soyisim = y.Soyisim;
                        temp.Telefon = y.Telefon;
                        temp.Email = y.Email;
                        temp.Sifre = y.Sifre;
                        admins.Add(temp);
                    }
                }
                return admins;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("AdminRepository::Update:Error occured.", ex);
            }
        }

        public Admin SelectById(int id)
        {
            try
            {
                Admin entity = new Admin();
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    Yonetici yonetici = data.Yonetici.Where(y => y.ID == id).FirstOrDefault();

                    entity.TC = yonetici.TC;
                    entity.Isim = yonetici.Isim;
                    entity.Soyisim = yonetici.Soyisim;
                    entity.Telefon = yonetici.Telefon;
                    entity.Email = yonetici.Email;
                    entity.Sifre = yonetici.Sifre;
                }
                return entity;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("AdminRepository::Update:Error occured.", ex);
            }
        }

        public bool Update(Admin entity)
        {
            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    Yonetici yonetici = data.Yonetici.Where(y => y.ID == entity.ID).FirstOrDefault();

                    yonetici.TC = entity.TC;
                    yonetici.Isim = entity.Isim;
                    yonetici.Soyisim = entity.Soyisim;
                    yonetici.Telefon = entity.Telefon;
                    yonetici.Email = entity.Email;
                    yonetici.Sifre = entity.Sifre;
                    data.SaveChanges();
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("AdminRepository::Update:Error occured.", ex);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
