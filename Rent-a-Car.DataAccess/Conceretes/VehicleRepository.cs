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
    class VehicleRepository : IRepository<Vehicle>, IDisposable
    {
        public bool DeleteById(int id)
        {
            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    data.Araba.Remove(data.Araba.Where(k => k.ID == id).FirstOrDefault());
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("VehicleRepository::Insert:Error occured.", ex);
            }
        }

        public bool Insert(Vehicle entity)
        {
            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    Araba arac = new Araba()
                    {
                        Plaka = entity.Plaka,
                        Marka = entity.Marka,
                        Model = entity.Model,
                        Kilometre = entity.Kilometre,
                        GunlukKMSinir = entity.GunlukKMSinir,
                        GunlukFiyat = entity.GunlukFiyat,
                        Resim = entity.Resim,
                        Aciklama = entity.Aciklama,
                        Airbag = entity.Airbag,
                        BagajHacmi = entity.BagajHacmi,
                        KoltukSayisi = entity.KoltukSayisi,
                        YakitTuru = entity.YakitTuru,
                        SanzimanTuru = entity.SanzimanTuru
                    };
                    data.Araba.Add(arac);
                    data.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("VehicleRepository::Insert:Error occured.", ex);
            }

        }

        public IList<Vehicle> SelectAll()
        {
            IList<Vehicle> araclar = new List<Vehicle>();
            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    var aracListesi = from a in data.Araba select a;

                    foreach (var a in aracListesi)
                    {
                        Vehicle temp = new Vehicle();
                        temp.ID= a.ID;
                        temp.Plaka= a.Plaka;
                        temp.Marka= a.Marka;
                        temp.Model= a.Model;
                        temp.Kilometre= a.Kilometre;
                        temp.GunlukKMSinir= a.GunlukKMSinir;
                        temp.GunlukFiyat= a.GunlukFiyat;
                        temp.Resim= a.Resim;
                        temp.Aciklama = a.Resim;
                        temp.Airbag = a.Airbag;
                        temp.BagajHacmi = a.BagajHacmi;
                        temp.KoltukSayisi = a.KoltukSayisi;
                        temp.YakitTuru = a.YakitTuru;
                        temp.SanzimanTuru = a.SanzimanTuru;

                        araclar.Add(temp);
                    }
                }
                return araclar;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("VehicleRepository::Update:Error occured.", ex);
            }
        }

        public Vehicle SelectById(int id)
        {
            Vehicle entity = null;

            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    Araba arac = data.Araba.Where(a => a.ID == id).FirstOrDefault();

                    entity.ID = arac.ID;
                    entity.Plaka = arac.Plaka;
                    entity.Marka = arac.Marka;
                    entity.Model = arac.Model;
                    entity.Kilometre = arac.Kilometre;
                    entity.GunlukKMSinir = arac.GunlukKMSinir;
                    entity.GunlukFiyat = arac.GunlukFiyat;
                    entity.Resim = arac.Resim;
                    entity.Aciklama = arac.Resim;
                    entity.Airbag = arac.Airbag;
                    entity.BagajHacmi = arac.BagajHacmi;
                    entity.KoltukSayisi = arac.KoltukSayisi;
                    entity.YakitTuru = arac.YakitTuru;
                    entity.SanzimanTuru = arac.SanzimanTuru;
                }
                return entity;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("VehicleRepository::SelectById:Error occured.", ex);
            }
        }

        public bool Update(Vehicle entity)
        {
            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    Araba arac = data.Araba.Where(a => a.ID == entity.ID).FirstOrDefault();

                    arac.Plaka = entity.Plaka;
                    arac.Marka = entity.Marka;
                    arac.Model = entity.Model;
                    arac.Kilometre = entity.Kilometre;
                    arac.GunlukKMSinir = entity.GunlukKMSinir;
                    arac.GunlukFiyat = entity.GunlukFiyat;
                    arac.Resim = entity.Resim;
                    arac.Aciklama = entity.Resim;
                    arac.Airbag = entity.Airbag;
                    arac.BagajHacmi = entity.BagajHacmi;
                    arac.KoltukSayisi = entity.KoltukSayisi;
                    arac.YakitTuru = entity.YakitTuru;
                    arac.SanzimanTuru = entity.SanzimanTuru;

                    data.SaveChanges();
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("VehicleRepository::Update:Error occured.", ex);
            }
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
