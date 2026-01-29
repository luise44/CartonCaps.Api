using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonCaps.Dto
{
    public record MessageTemplate(string messageBody, string? messageSubject = null);
}
