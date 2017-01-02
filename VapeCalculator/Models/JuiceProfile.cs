using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeCalculator.Models
{
    public class JuiceProfile
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal JuiceAmount { get; set; } = 0;

        public string FlavourOneName { get; set; } = "";

        public decimal FlavourOnePercent { get; set; } = 0;

        public string FlavourTwoName { get; set; } = "";

        public decimal FlavourTwoPercent { get; set; } = 0;

        public string FlavourThreeName { get; set; } = "";

        public decimal FlavourThreePercent { get; set; } = 0;

        public string FlavourFourName { get; set; } = "";

        public decimal FlavourFourPercent { get; set; } = 0;

        public string FlavourFiveName { get; set; } = "";

        public decimal FlavourFivePercent { get; set; } = 0;

        public string FlavourSixName { get; set; } = "";

        public decimal FlavourSixPercent { get; set; } = 0;

        public decimal VGPercent { get; set; } = 0;
        public decimal PGPercent { get; set; } = 0;
        public decimal NicPercent { get; set; } = 0;
        public string NicType { get; set; } = "PG";

    }
}
