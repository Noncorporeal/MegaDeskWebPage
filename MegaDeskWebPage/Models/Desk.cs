using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskWebPage.Models
{
    public class Desk
    {
        public int Id { get; set; }

        [Range(12, 48,
            ErrorMessage = "Desk width must be between {1} and {2}")]
        public decimal Depth { get; set; }

        [Range(24, 96,
            ErrorMessage = "Desk width must be between {1} and {2}")]
        public decimal Width { get; set; }

        [Range(0, 7, 
            ErrorMessage = "Number of drawers must be between {1} and {2}")]
        public int NumberOfDrawers { get; set; }

        public int DeskMaterialId { get; set; }


        [ForeignKey("DeskMaterialId")]
        public DeskMaterial DeskMaterial { get; set; }
    }
}
