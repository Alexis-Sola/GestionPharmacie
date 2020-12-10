using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.PaiementClient
{
    class MasterCard : ReseauCarte
    {
        /// <summary>
        /// Definit le pourcentage retenu
        /// </summary>
        public MasterCard()
        {
            PourcentageRetenu = 0.5;
        }
    }
}
