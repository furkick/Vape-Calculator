using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeCalculator.Models
{
    public class ModelFactory
    {
        JuiceProfile _juiceProfile;
        CalculationValuesModel _calculationValuesModel;

        public ModelFactory()
        {
            _juiceProfile = new JuiceProfile();
            _calculationValuesModel = new CalculationValuesModel();
        }

        public CalculationValuesModel Parse(JuiceProfile data)
        {
            return new CalculationValuesModel()
            {
                JuiceAmount = data.JuiceAmount,
                FlavourOnePercent = data.FlavourOnePercent,
                FlavourTwoPercent = data.FlavourTwoPercent,
                FlavourThreePercent = data.FlavourThreePercent,
                FlavourFourPercent = data.FlavourFourPercent,
                FlavourFivePercent = data.FlavourFivePercent,
                FlavourSixPercent = data.FlavourSixPercent,
                NicPercent = data.NicPercent,
                NicType = data.NicType,
               PGPercent = data.PGPercent,
               VGPercent = data.VGPercent
            };
        }
    }
}
