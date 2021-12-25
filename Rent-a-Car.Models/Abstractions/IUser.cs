using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Models.Abstractions
{
    interface IUser
    {

        string TC { get; set; }
        string Isim { get; set; }
        string Soyisim { get; set; }
        string Telefon { get; set; }
        string Email { get; set; }
    }
}
