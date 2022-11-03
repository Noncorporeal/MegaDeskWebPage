using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDeskWebPage.Models
{
    public class Quote
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public decimal Price { get; set; }

        public DateTime QuoteDate { get; set; }

        public int DeskId { get; set; }

        public int DeliveryOptionId { get; set; }


        [ForeignKey("DeskId")]
        public Desk Desk { get; set; }

        [ForeignKey("DeliveryOptionId")]
        public DeliveryOption DeliveryOption { get; set; }
    }
}
