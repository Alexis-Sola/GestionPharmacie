using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.PaiementClient
{
    /// <summary>
    /// Carte permettant le paiement à la fin du mois
    /// </summary>
    class CartePharmacie : Carte
    {
        public CartePharmacie(string code, string nomClient, string cvc, double solde, ReseauCarte reseau) : base(code, nomClient, cvc, solde, reseau)
        { }

        public override void Rembourser(double montant)
        {
            throw new NotImplementedException();
        }
    }
}
