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
    class EmployeeRepository : IRepository<Employee>, IDisposable
    {

        public bool DeleteById(int id)
        {

            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    data.Calisan.Remove(data.Calisan.Where(e => e.ID == id).FirstOrDefault());
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("EmployeeRepository::Insert:Error occured.", ex);
            }
        }

        public bool Insert(Employee entity)
        {

            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    Calisan calisan = new Calisan()
                    {
                        TC = entity.TC,
                        Isim = entity.Isim,
                        Soyisim = entity.Soyisim,
                        Telefon = entity.Telefon,
                        Email = entity.Email,
                        Sifre = entity.Sifre
                    };
                    data.Calisan.Add(calisan);
                    data.SaveChanges();
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("EmployeeRepository::Insert:Error occured.", ex);
            }
        }

        public IList<Employee> SelectAll()
        {

            IList<Employee> employees = new List<Employee>();

            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    var calisanlar = from c in data.Calisan select c;

                    foreach (var c in calisanlar)
                    {
                        Employee temp = new Employee();
                        temp.ID = c.ID;
                        temp.TC = c.TC;
                        temp.Isim = c.Isim;
                        temp.Soyisim = c.Soyisim;
                        temp.Telefon = c.Telefon;
                        temp.Email = c.Email;
                        temp.Sifre = c.Sifre;
                        employees.Add(temp);
                    }
                }
                return employees;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("EmployeeRepository::SelectAll:Error occured.", ex);
            }
        }

        public Employee SelectById(int id)
        {

            Employee employee = null;

            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    Calisan calisan = data.Calisan.Where(c => c.ID == id).FirstOrDefault();

                    employee.ID = calisan.ID;
                    employee.TC = calisan.TC;
                    employee.Isim = calisan.Isim;
                    employee.Soyisim = calisan.Soyisim;
                    employee.Telefon = calisan.Telefon;
                    employee.Email = calisan.Email;
                    employee.Sifre = calisan.Sifre;
                }
                return employee;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("EmployeeRepository::SelectById:Error occured.", ex);
            }
        }

        public bool Update(Employee entity)
        {

            try
            {
                using (AracLazimEntities data = new AracLazimEntities())
                {
                    Calisan calisan = data.Calisan.Where(c => c.ID == entity.ID).FirstOrDefault();

                    calisan.TC = entity.TC;
                    calisan.Isim = entity.Isim;
                    calisan.Soyisim = entity.Soyisim;
                    calisan.Telefon = entity.Telefon;
                    calisan.Email = entity.Email;
                    calisan.Sifre = entity.Sifre;
                    data.SaveChanges();
                }
                //Return the results of query/ies
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("EmployeeRepository::Update:Error occured.", ex);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
