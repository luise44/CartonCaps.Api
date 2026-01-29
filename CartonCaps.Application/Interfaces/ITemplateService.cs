using CartonCaps.Dto;
using CartonCaps.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonCaps.Application.Interfaces
{
    public interface ITemplateService
    {
        MessageTemplate GetMessageTemplateByChannel(ReferralChannel channel);
    }
}
