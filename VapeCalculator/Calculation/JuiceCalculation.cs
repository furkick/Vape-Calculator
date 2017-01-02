using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeCalculator.liteDB;
using VapeCalculator.Models;

namespace VapeCalculator.Calculation
{
    public class JuiceCalculation
    {
        public CalculationModel CalculateAmount(CalculationValuesModel data)
        {
            CalculationModel calcModel = new CalculationModel();
            LiteDBFlavourRepo db = new LiteDBFlavourRepo();

            decimal PGWeight = 1.038m;
            decimal VGWeight = 1.2636m;
            decimal NicWeight = 1.0365m;

            decimal FlavourOneCalc = (data.FlavourOneWeight * data.FlavourOnePercent);
            decimal FlavourTwoCalc = (data.FlavourTwoWeight * data.FlavourTwoPercent);
            decimal FlavourThreeCalc = (data.FlavourThreePercent * data.FlavourThreePercent);
            decimal FlavourFourCalc = (data.FlavorFourWeight * data.FlavourFourPercent);
            decimal FlavourFiveCalc = (data.FlavourFiveWeight * data.FlavourFivePercent);
            decimal FlavourSixCalc = (data.FlavourSixWeight * data.FlavourSixPercent);

            // Calculate flavour amount.
            calcModel.FlavourOne = Math.Round((data.JuiceAmount / 100) * FlavourOneCalc, 2);
            calcModel.FlavourTwo = Math.Round((data.JuiceAmount / 100) * FlavourTwoCalc, 2);
            calcModel.FlavourThree = Math.Round((data.JuiceAmount / 100) * data.FlavourThreePercent, 2);
            calcModel.FlavourFour = Math.Round((data.JuiceAmount / 100) * data.FlavourFourPercent, 2);
            calcModel.FlavourFive = Math.Round((data.JuiceAmount / 100) * data.FlavourFivePercent, 2);
            calcModel.FlavourSix = Math.Round((data.JuiceAmount / 100) * data.FlavourSixPercent, 2);

            //Calculate PG and VG
            var PGPercent = data.PGPercent - data.FlavourOnePercent - data.FlavourTwoPercent - data.FlavourThreePercent 
                - data.FlavourFourPercent - data.FlavourFivePercent - data.FlavourSixPercent;

            calcModel.PG = Math.Round((data.JuiceAmount / 100) * (PGWeight * PGPercent), 2);
            calcModel.VG = Math.Round((data.JuiceAmount / 100) * (VGWeight * data.VGPercent), 2);

            // Calculate nicotine amount and subtract from PG or VG.
            calcModel.Nic = Math.Round((data.JuiceAmount / 100) * (NicWeight * data.NicPercent), 2);
            if (data.NicType == "PG")
            {
                calcModel.PG = calcModel.PG - calcModel.Nic;
            }
            else
            {
                calcModel.VG = calcModel.VG - calcModel.Nic;
            }

            calcModel.TotalWeight = calcModel.Nic + 
                calcModel.PG + 
                calcModel.VG + 
                calcModel.FlavourOne + 
                calcModel.FlavourTwo + 
                calcModel.FlavourThree + 
                calcModel.FlavourFour + 
                calcModel.FlavourFive + 
                calcModel.FlavourSix;

            return calcModel;
        }
    }
}
