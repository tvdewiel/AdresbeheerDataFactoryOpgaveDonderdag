using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerEFlayer.Model
{
    public class GemeenteEF
    {
        public GemeenteEF()
        {
        }

        public GemeenteEF(int nIScode, string gemeentenaam)
        {
            NIScode = nIScode;
            Gemeentenaam = gemeentenaam;
        }

        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NIScode { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(250)")]
        public string Gemeentenaam { get; set; }
    }
}
