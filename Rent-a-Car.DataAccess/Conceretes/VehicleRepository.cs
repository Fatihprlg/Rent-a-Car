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
    public class VehicleRepository : IRepository<Vehicle>, IDisposable
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
                    var aracListesi = data.Araba.ToList();

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
        
        public IList<Vehicle> FilterVehicles(DateTime startDate, DateTime endDate)
        {
            IList<Vehicle> response = new List<Vehicle>();
            try
            {
                using(AracLazimEntities data = new AracLazimEntities()) // (kBaslangic,kBitis) (sBas,sBit) (sBas>=kBaslangic sBas<=kBitis) (sBit>kBaslangic sBit<kBitis) (sBas<kBaslangic sBit>kBitis) 
                {
                    var rents = data.KiralamaIslemi.ToList();
                    var cars = SelectAll();

                    //var cars = data.Araba.Where(a => rents.Exists(b => b.AracID == a.ID));
                    var rentListesi = rents.Where(a => !(a.KiralamaBaslangici >= startDate && a.KiralamaBitisi >= startDate) || !(a.KiralamaBitisi >= endDate && a.KiralamaBaslangici <= endDate) || !(a.KiralamaBaslangici >= startDate && a.KiralamaBitisi <= endDate));

                    foreach(var r in rentListesi)
                    {
                        if(r.Durum == false)
                         response.Add(SelectById(r.AracID));
                    }
                    foreach(var c in cars)
                    {
                        if (!rents.Exists(r => r.AracID == c.ID))
                        {
                            Vehicle vehicle = new Vehicle()
                            {
                                ID = c.ID,
                                Plaka = c.Plaka,
                                Marka = c.Marka,
                                Model = c.Model,
                                Kilometre = c.Kilometre,
                                GunlukKMSinir = c.GunlukKMSinir,
                                GunlukFiyat = c.GunlukFiyat,
                                Resim = c.Resim,
                                Aciklama = c.Aciklama,
                                Airbag = c.Airbag,
                                BagajHacmi = c.BagajHacmi,
                                KoltukSayisi = c.KoltukSayisi,
                                YakitTuru = c.YakitTuru,
                                SanzimanTuru = c.SanzimanTuru
                            };

                            response.Add(vehicle);
                        }
                    }
                    return response;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("VehicleRepository::FilterVehicles:Error occured.", ex);
            }
        }

        public Vehicle SelectById(int id)
        {
            Vehicle response = new Vehicle();

            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    Araba arac = data.Araba.Where(a => a.ID == id).FirstOrDefault();

                    response.ID = arac.ID;
                    response.Plaka = arac.Plaka;
                    response.Marka = arac.Marka;
                    response.Model = arac.Model;
                    response.Kilometre = arac.Kilometre;
                    response.GunlukKMSinir = arac.GunlukKMSinir;
                    response.GunlukFiyat = arac.GunlukFiyat;
                    response.Resim = arac.Resim;
                    response.Aciklama = arac.Aciklama;
                    response.Airbag = arac.Airbag;
                    response.BagajHacmi = arac.BagajHacmi;
                    response.KoltukSayisi = arac.KoltukSayisi;
                    response.YakitTuru = arac.YakitTuru;
                    response.SanzimanTuru = arac.SanzimanTuru;
                }
                return response;
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
