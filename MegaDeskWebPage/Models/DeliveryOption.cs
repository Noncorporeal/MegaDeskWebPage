using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDeskWebPage.Models
{
    public class DeliveryOption
    {
        public int Id { get; set; }

        [Display(Name = "Delivery Type"), StringLength(20)]
        public string DeliveryType { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }

        [Display(Name = "Shipping Time")]
        public TimeSpan ShippingTime { get; set; }

        public int MinSize { get; set; }
    }
}
