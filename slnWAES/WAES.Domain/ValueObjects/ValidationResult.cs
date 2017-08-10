using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAES.Domain.ValueObjects
{
    public class ValidationResult
    {
        public int Result { get; set; }
        public string Message { get; set; }
    }
}
