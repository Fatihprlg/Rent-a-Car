using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Models.Concerets
{
    public class Rent: IDisposable
    {
        public int IslemID { get; set; }
        
        [Required(ErrorMessage = "Plaka Zorunludur.")]
        [StringLength(50, MinimumLength = 3)]
        public int AracID { get; set; }

        [Required(ErrorMessage = "Musteri TC Zorunludur.")]
        [StringLength(11, MinimumLength = 11)]
        public int MusteriID { get; set; }

        [Required(ErrorMessage = "Kiralama Başlangıç Tarihi Zorunludur.")]
        public DateTime KiralamaBaslangici { get; set; }

        [Required(ErrorMessage = "Kiralama Bitiş Tarihi Zorunludur.")]
        public DateTime KiralamaBitisi { get; set; }

        [Required(ErrorMessage = "Başlangıç Kilometre Zorunludur.")]
        public long BaslangicKM { get; set; }

        [Required(ErrorMessage ="Alinan Ucret Zournludur.")]
        public double AlinanUcret { get; set; }

        public long? TeslimKM { get; set; } 


        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
