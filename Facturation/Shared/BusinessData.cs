using System;
using System.Collections.Generic;
using System.Text;

namespace Facturation.Shared
{
    public class BusinessData : IBusinessData
    {
        public List<Facture> factures;

        public List<Facture> Factures => throw new NotImplementedException();

        private double montantDu { get; set; }

        private double montantRegle { get; set; }



        public void addFacture(Facture newFacture)
        {
            factures.Add(newFacture);
            foreach (Facture facture in factures)
            {
                montantDu += facture.getMontantDu();
                montantRegle += facture.getMontantRegle();
            }
        }

    }
}