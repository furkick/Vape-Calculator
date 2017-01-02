using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeCalculator.Models
{
    public class ValidationResult
    {
            public bool Passed { get; set; }
            public string ErrorMessage { get; set; } = "";
    }
}
