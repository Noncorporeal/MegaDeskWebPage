using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MegaDeskWebPage.Models
{
    public class DeskMaterial
    {
        public int Id { get; set; }

        [Display(Name = "Material"), StringLength(30)]
        public string MaterialName { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }
    }
}
