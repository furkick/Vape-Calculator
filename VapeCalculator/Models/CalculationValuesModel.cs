using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeCalculator.Models
{
    public class CalculationValuesModel
    {
        public decimal FlavourOneWeight { get; set; } = 0;
        public decimal FlavourTwoWeight { get; set; } = 0;
        public decimal FlavourThreeWeight { get; set; } = 0;
        public decimal FlavorFourWeight { get; set; } = 0;
        public decimal FlavourFiveWeight { get; set; } = 0;
        public decimal FlavourSixWeight { get; set; } = 0;
        public decimal FlavourOnePercent { get; set; } = 0;
        public decimal FlavourTwoPercent { get; set; } = 0;
        public decimal FlavourThreePercent { get; set; } = 0;
        public decimal FlavourFourPercent { get; set; } = 0;
        public decimal FlavourFivePercent { get; set; } = 0;
        public decimal FlavourSixPercent { get; set; } = 0;
        public decimal JuiceAmount { get; set; } = 0;
        public decimal VGPercent { get; set; } = 0;
        public decimal PGPercent { get; set; } = 0;
        public decimal NicPercent { get; set; } = 0;
        public string NicType { get; set; } = "PG";
    }
}
