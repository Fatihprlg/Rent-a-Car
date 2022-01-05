using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rent_a_Car.Commons.Conceretes.Helpers;
using Rent_a_Car.Commons.Conceretes.Loggers;
using Rent_a_Car.DataAccess.Abstractions;
using Rent_a_Car.Models.Concerets;

namespace Rent_a_Car.DataAccess.Conceretes
{
    public class RentRepository : IRepository<Rent>, IDisposable
    {
        
        public bool DeleteById(int id)
        {
            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    data.KiralamaIslemi.Remove(data.KiralamaIslemi.Where(k => k.IslemID == id).FirstOrDefault());
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("RentRepository::Insert:Error occured.", ex);
            }
        }

        public bool Insert(Rent entity)
        {
            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    KiralamaIslemi islem = new KiralamaIslemi()
                    {
                        AracID = entity.AracID,
                        MusteriID = entity.MusteriID,
                        KiralamaBaslangici = entity.KiralamaBaslangici,
                        KiralamaBitisi = entity.KiralamaBitisi,
                        BaslangicKM = entity.BaslangicKM,
                        TeslimKM = entity.TeslimKM,
                        AlinanUcret = entity.AlinanUcret
                    };
                    data.KiralamaIslemi.Add(islem);
                    data.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("RentRepository::Insert:Error occured.", ex);
            }
        }

        public IList<Rent> SelectAll()
        {
            IList<Rent> islemler = new List<Rent>();
            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    var islemListesi = from i in data.KiralamaIslemi select i;

                    foreach (var i in islemListesi)
                    {
                        Rent temp = new Rent();
                        temp.IslemID = i.IslemID;
                        temp.AracID = i.AracID;
                        temp.MusteriID = i.MusteriID;
                        temp.KiralamaBaslangici = i.KiralamaBaslangici;
                        temp.KiralamaBitisi = i.KiralamaBitisi;
                        temp.BaslangicKM = i.BaslangicKM;
                        temp.TeslimKM = i.TeslimKM;
                        temp.AlinanUcret = i.AlinanUcret;
                        temp.Durum = i.Durum;

                        islemler.Add(temp);
                    }
                }
                return islemler;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("RentRepository::Update:Error occured.", ex);
            }
        }

        public Rent SelectById(int id)
        {
            Rent entity = null;

            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    KiralamaIslemi islem = data.KiralamaIslemi.Where(k => k.IslemID == id).FirstOrDefault();

                    entity.IslemID = islem.IslemID;
                    entity.AracID = islem.AracID;
                    entity.MusteriID= islem.MusteriID;
                    entity.KiralamaBaslangici= islem.KiralamaBaslangici;
                    entity.KiralamaBitisi= islem.KiralamaBitisi;
                    entity.BaslangicKM= islem.BaslangicKM;
                    entity.TeslimKM= islem.TeslimKM;
                    entity.AlinanUcret = islem.AlinanUcret;
                    entity.Durum = islem.Durum;
                }
                return entity;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("RentRepository::SelectById:Error occured.", ex);
            }
        }

        public IDictionary<int, int> RentCounts()
        {
            try
            {
                IDictionary<int, int> response = new Dictionary<int, int>();
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    response.Add(0, data.KiralamaIslemi.Count());
                    for (int i = 1; i <= 12; i++)
                    {
                        int day = DateTime.Now.Day;
                        int month = DateTime.Now.Month - i;
                        /*int endMonth = month + 1;*/
                        int year = DateTime.Now.Year;
                        /*int endYear = year;*/
                        if (month <= 0)
                        {
                            month = 12 - (i-1);
                           /* endMonth = (month == 12) ? 1 : month+1;*/
                            year -= 1;
                        }
                        
                        /*if (month > DateTime.Now.Month && endMonth >)
                        {
                            year -= 1;
                            if (month < 12) endYear = year;
                        }*/

                        DateTime startDate = new DateTime(year, month, day);
                        DateTime endDate = new DateTime(year, month, day).AddMonths(1);

                        response.Add(i, data.KiralamaIslemi.Where(k => k.KiralamaBaslangici > startDate && k.KiralamaBitisi < endDate).Count());

                    }

                    return response;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("RentRepository::RentCounts:Error occured.", ex);
            }
        }

        public bool Update(Rent entity)
        {
            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    KiralamaIslemi islem = data.KiralamaIslemi.Where(i => i.IslemID == entity.IslemID).FirstOrDefault();

                    islem.TeslimKM = entity.TeslimKM;
                    islem.Durum = entity.Durum;

                    data.SaveChanges();
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("RentRepository::Update:Error occured.", ex);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
