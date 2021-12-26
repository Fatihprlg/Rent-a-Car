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

namespace Rent_a_Car.DataAccess.Conceretes
{
    public class CustomerRepository : IRepository<Customer>, IDisposable
    {

        public bool DeleteById(int id)
        {

            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    data.Musteri.Remove(data.Musteri.Where(c => c.ID == id).FirstOrDefault());
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomerRepository::Insert:Error occured.", ex);
            }
        }

        public bool Insert(Customer entity)
        {

            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    Musteri musteri  = new Musteri()
                    {
                        TC = entity.TC,
                        Isim = entity.Isim,
                        Soyisim = entity.Soyisim,
                        Telefon = entity.Telefon,
                        Email = entity.Email,
                        Adres = entity.Adres,
                        EhliyetYasi = entity.EhliyetYasi,
                        Yas = entity.Yas
                    };
                    data.Musteri.Add(musteri);
                    data.SaveChanges();
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomerRepository::Insert:Error occured.", ex);
            }
        }

        public IList<Customer> SelectAll()
        {
            IList<Customer> musteriler= new List<Customer>();
            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    var musteriListesi = from m in data.Musteri select m;

                    foreach (var m in musteriListesi)
                    {
                        Customer temp = new Customer();
                        temp.ID = m.ID;
                        temp.TC = m.TC;
                        temp.Isim = m.Isim;
                        temp.Soyisim = m.Soyisim;
                        temp.Telefon = m.Telefon;
                        temp.Email = m.Email;
                        temp.Adres = m.Adres;
                        temp.EhliyetYasi = m.EhliyetYasi;
                        temp.Yas = m.Yas;
                        musteriler.Add(temp);
                    }
                    return musteriler;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomerRepository::Update:Error occured.", ex);
            }

        }

        public Customer SelectById(int id)
        {
            try
            {
                Customer entity = new Customer();
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    Musteri musteri = data.Musteri.Where(m => m.ID == id).FirstOrDefault();

                    entity.ID = musteri.ID;
                    entity.TC = musteri.TC;
                    entity.Isim = musteri.Isim;
                    entity.Soyisim = musteri.Soyisim;
                    entity.Telefon = musteri.Telefon;
                    entity.Email = musteri.Email;
                    entity.Adres = musteri.Adres;
                    entity.EhliyetYasi = musteri.EhliyetYasi;
                    entity.Yas = musteri.Yas;
                }
                return entity;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomerRepository::Update:Error occured.", ex);
            }
        }

        public bool Update(Customer entity)
        {
            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    Musteri musteri = data.Musteri.Where(y => y.ID == entity.ID).FirstOrDefault();

                    musteri.TC = entity.TC;
                    musteri.Isim = entity.Isim;
                    musteri.Soyisim = entity.Soyisim;
                    musteri.Telefon = entity.Telefon;
                    musteri.Email = entity.Email;
                    musteri.Adres = entity.Adres;
                    musteri.EhliyetYasi = entity.EhliyetYasi;
                    musteri.Yas = entity.Yas;
                    data.SaveChanges();
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("CustomerRepository::Update:Error occured.", ex);
            }
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        
    }
}
