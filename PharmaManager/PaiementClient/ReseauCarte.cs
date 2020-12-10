using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.PaiementClient
{
    abstract class ReseauCarte
    {
        private double pourcentageRetenu;

        public double PourcentageRetenu { get => pourcentageRetenu; set => pourcentageRetenu = value; }
    }
}
