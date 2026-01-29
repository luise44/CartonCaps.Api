using CartonCaps.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonCaps.Application.Interfaces
{
    public interface IReferralService
    {
        IReadOnlyList<ReferralDto> GetReferralsByReferrerId(Guid referrerId, int page, int size);
    }
}
