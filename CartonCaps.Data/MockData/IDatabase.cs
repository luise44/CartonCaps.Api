using CartonCaps.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonCaps.Data.MockData
{
    public interface IDatabase
    {
        IList<Referral> Referrals { get; set; }
    }
}
