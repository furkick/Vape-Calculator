using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeCalculator.Models
{
    public class CalculationModel
    {
        public int JuiceAmount { get; set; } = 0;
        public decimal FlavourOne { get; set; } = 0.0m;
        public decimal FlavourTwo { get; set; } = 0.0m;
        public decimal FlavourThree { get; set; } = 0.0m;
        public decimal FlavourFour { get; set; } = 0.0m;
        public decimal FlavourFive { get; set; } = 0.0m;
        public decimal FlavourSix { get; set; } = 0.0m;
        public decimal VG { get; set; } = 0.0m;
        public decimal PG { get; set; } = 0.0m;
        public decimal Nic { get; set; } = 0.0m;
        public decimal TotalWeight { get; set; } = 0.0m;
    }
}
