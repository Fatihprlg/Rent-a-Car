﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Rent_a_Car.Models.Abstractions;


namespace Rent_a_Car.Models.Concerets
{
    public class Customer : IDisposable, IUser
    {

        public int ID { get; set; }
        [Required(ErrorMessage ="TC Kimlik Numarası Zorunludur.") ]
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

        [Required(ErrorMessage = "Adres Bilgisi Zorunludur.")]
        [StringLength(200, MinimumLength = 10)]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Email Zorunludur.")]
        [StringLength(50, MinimumLength = 5)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ehliyet Yaşı Zorunludur.")]
        public int EhliyetYasi { get; set; }

        [Required(ErrorMessage = "Yaş Zorunludur.")]
        public int Yas { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
