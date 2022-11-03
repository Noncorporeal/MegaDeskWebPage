using System;
namespace MegaDeskWebPage.Models
{
    
    public enum DeskMaterials
    {
        Oak = 200,
        Laminate = 100,
        Pine = 50,
        Rosewood = 300,
        Veneer = 125
    }

    public class Desk
    {
        public static readonly int maxWidth = 96;
        public static readonly int minWidth = 24;
        public static readonly int maxDepth = 48;
        public static readonly int minDepth = 12;
        public static readonly int minDrawers = 0;
        public static readonly int maxDrawers = 7;

        public decimal Depth { get; set; }
        public decimal Width { get; set; }
        public DeskMaterials DeskMaterial { get; set; }
        public int NumberOfDrawers { get; set; }

        public Desk(
            decimal depth,
            decimal width,
            DeskMaterials deskMaterial,
            int numberOfDrawers)
        {
            Depth = depth;
            Width = width;
            DeskMaterial = deskMaterial;
            NumberOfDrawers = numberOfDrawers;
        }

        public decimal GetArea()
        {
            return Depth * Width;
        }
    }
}

