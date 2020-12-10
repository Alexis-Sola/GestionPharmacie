using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.PaiementClient
{
    /// <summary>
    /// Carte sans avantages
    /// </summary>
    class CarteClassique : Carte
    {
        public CarteClassique(string code, string nomClient, string cvc, double solde, ReseauCarte reseau) : base(code, nomClient, cvc, solde, reseau)
        { }

        public override void Rembourser(double montant)
        {
            throw new NotImplementedException();
        }
    }
}
