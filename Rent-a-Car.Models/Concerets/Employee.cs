using Rent_a_Car.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Models.Concerets
{
    public class Employee : IUser, IDisposable
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "TC Kimlik Numarası Zorunludur.")]
        [StringLength(11, MinimumLength = 11)]
        public string TC { get; set; }

        [Required(ErrorMessage = "İsim Zorunludur.")]
        [StringLength(50, MinimumLength = 3)]
        public string Isim { get; set; }

        [Required(ErrorMessage = "Soyisim Zorunludur.")]
        [StringLength(50, MinimumLength = 3)]
        public string Soyisim { get; set; }

        [Required(ErrorMessage = "Telefon Numarası Zorunludur.")]
        [StringLength(11, MinimumLength = 10)]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Sifre Zorunludur.")]
        [StringLength(200, MinimumLength = 10)]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Email Zorunludur.")]
        [StringLength(50, MinimumLength = 5)]
        public string Email { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
