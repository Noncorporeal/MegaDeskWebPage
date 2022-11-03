using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace MegaDeskWebPage.Models
{
    namespace MegaDesk_Ebenal
    {
        public enum DeliveryType
        {
            [Description("3 Day Shipping")]
            ThreeDay,
            [Description("5 Day Shipping")]
            FiveDay,
            [Description("7 Day Shipping")]
            SevenDay,
            [Description("Standard Shipping")]
            FourteenDay
        }

        public class DeskQuote
        {
            public DateTime QuoteDate { get; set; }
            public string CustomerName { get; set; }
            public DeliveryType DeliveryType { get; set; }
            public decimal QuoteAmount { get; set; }
            public Desk Desk { get; set; }

            [JsonConstructor]
            public DeskQuote(
                string customerName,
                DeliveryType deliveryType,
                Desk desk,
                decimal quoteAmount,
                DateTime quoteDate)
            {
                QuoteDate = quoteDate;
                CustomerName = customerName;
                DeliveryType = deliveryType;
                QuoteAmount = quoteAmount;
                Desk = desk;
            }

            public DeskQuote(
                string customerName,
                DeliveryType deliveryType,
                Desk desk)
            {
                QuoteDate = DateTime.Now;
                CustomerName = customerName;
                DeliveryType = deliveryType;
                Desk = desk;
                QuoteAmount = GetQuotePrice();
            }

            public decimal GetQuotePrice()
            {
                if (!File.Exists(@"./rushOrderPrices.txt"))
                {
                    return 0;
                }

                //List<List<decimal>> rushPrices = File.ReadAllLines(@"./rushOrderPrices.txt").Select((str, index) => new { index, number = decimal.Parse(str) }).ToLookup(_ => _.index / 3, _ => _.number).Select(_ => _.ToList()).ToList();
                List<(int index, string value)> fileLines = File.ReadAllLines(@"./rushOrderPrices.txt")
                    .Select((value, index) => (index, value)).ToList();
                List<List<decimal>> rushPrices =
                    (from price in fileLines
                     group decimal.Parse(price.value)
                     by price.index / 3
                     into prices
                     select prices
                     .ToList())
                     .ToList();

                decimal totalPrice = 200
                    + Desk.NumberOfDrawers * 50
                    + (Desk.GetArea() > 1000 ? Desk.GetArea() - 1000 : 0)
                    + (int)Desk.DeskMaterial;

                int idx = (int)Desk.GetArea() % 1000;
                totalPrice += (int)DeliveryType <= 2 ? rushPrices[(int)DeliveryType][idx <= 2 ? idx : 2] : 0;
                return totalPrice;
            }

            public string[] Stringify()
            {
                string[] stringQuote =
                {
                QuoteDate.ToString(),
                CustomerName,
                Desk.Width.ToString(),
                Desk.Depth.ToString(),
                Desk.NumberOfDrawers.ToString(),
                Desk.DeskMaterial.ToString(),
                DeliveryString(),
                QuoteAmount.ToString(),
            };
                return stringQuote;
            }

            private string DeliveryString()
            {
                switch (DeliveryType)
                {
                    case DeliveryType.FourteenDay:
                        return "14 Days";
                    case DeliveryType.SevenDay:
                        return "7 Days";
                    case DeliveryType.FiveDay:
                        return "5 days";
                    case DeliveryType.ThreeDay:
                        return "3 Days";
                }
                return "Not Specified";
            }
        }

