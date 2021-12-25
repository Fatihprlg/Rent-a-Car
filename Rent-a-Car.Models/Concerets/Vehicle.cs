using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Models.Concerets
{
    public class Vehicle : IDisposable
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Plaka Zorunludur.")]
        [StringLength(10, MinimumLength = 4)]
        public string Plaka { get; set; }

        [Required(ErrorMessage = "Marka Zorunludur.")]
        [StringLength(50, MinimumLength = 3)]
        public string Marka { get; set; }

        [Required(ErrorMessage = "Model Zorunludur.")]
        [StringLength(50, MinimumLength = 3)]
        public string Model { get; set; }

        [Required(ErrorMessage = "Resim Zorunludur.")]
        [StringLength(11, MinimumLength = 10)]
        public string Resim { get; set; }


        [Required(ErrorMessage = "Yakıt Türü Zorunludur.")]
        [StringLength(50, MinimumLength = 5)]
        public string YakitTuru { get; set; }

        [Required(ErrorMessage = "Şanzıman Türü Zorunludur.")]
        [StringLength(50, MinimumLength = 5)]
        public string SanzimanTuru { get; set; }

        [Required(ErrorMessage = "Kilometre Zorunludur.")]
        public long Kilometre { get; set; }

        [Required(ErrorMessage = "Günlük Kilometre Sınırı Zorunludur.")]
        public int GunlukKMSinir { get; set; }

        [Required(ErrorMessage = "Günlük Fiyat Zorunludur.")]
        public double GunlukFiyat { get; set; }

        [Required(ErrorMessage = "Airbag Zorunludur.")]
        public bool Airbag { get; set; }

        [Required(ErrorMessage = "Kilometre Türü Zorunludur.")]
        public Byte KoltukSayisi { get; set; }

        public string Aciklama { get; set; }

        public int? BagajHacmi { get; set; }


        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
