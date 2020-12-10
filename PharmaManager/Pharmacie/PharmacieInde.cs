using PharmaManager.Employes;
using PharmaManager.Produits;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Pharmacies
{
    class PharmacieInde : Pharmacie
    {
        private CompteInde compte;
        public PharmacieInde(string nom, double chiffreAffaireMois, string siret, CompteInde _compte, Responsable responsable) : base(nom, chiffreAffaireMois, siret, responsable)
        {
            compte = _compte;
            compte.Ph = this;
        }

        /// <summary>
        /// Permet d'acheter un produit sans réductions particulières
        /// </summary>
        /// <param name="p"></param>
        public override void AchatProduit(Produit p)
        {
            compte.AcheterProduit(p);
        }
    }
}
