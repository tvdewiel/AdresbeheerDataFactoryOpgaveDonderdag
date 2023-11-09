using AdresbeheerDomain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerEFlayer.Model
{
    public class AdresEF
    {
        public int ID { get; set; }
        public int StraatID { get; set; }
        public StraatEF Straat { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Huisnummer { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string Appartementnummer { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string Busnummer { get; set; }
        public double XCoord { get; set; }
        public double YCoord { get; set; }
        public int Postcode { get; set; }
    }
}
