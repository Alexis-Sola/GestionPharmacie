using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.PaiementClient
{
    class Visa : ReseauCarte
    {
        /// <summary>
        /// Définis le pourcentage retenu
        /// </summary>
        public Visa()
        {
            PourcentageRetenu = 0.25;
        }

        /// <summary>
        /// Renvoie un pourcentage en fonction du pays 
        /// Ici c'est un random pour simuler des achats dans des pays
        /// </summary>
        /// <returns></returns>
        public double GetPoucentagePays()
        {
            List<double> pourcent = new List<double>();
            pourcent.Add(0.1);
            pourcent.Add(0.2);
            pourcent.Add(0.15);
            pourcent.Add(0.25);
            pourcent.Add(0.30);

            Random rnd = new Random();

            return (pourcent[rnd.Next(0, 4)]);
        }
    }
}
