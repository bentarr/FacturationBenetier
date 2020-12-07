using System;
using System.Collections.Generic;
using System.Text;

namespace Facturation.Shared
{
    public interface IBusinessData
    {
       List<Facture> Factures { get; }
    }
}