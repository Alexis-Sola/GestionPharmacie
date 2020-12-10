using PharmaManager.Employes;
using PharmaManager.Produits;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Pharmacies
{
    abstract class Pharmacie
    {
        private string nom;
        private List<Produit> stock = new List<Produit>();
        private double chiffreAffaireMois;
        private string siret;
        Responsable responsable;
        List<Employe> employes = new List<Employe>();

        /// <summary>
        /// Constructeur de Pharmacie
        /// On créer des stocks initiaux pour faciler les tests
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="chiffreAffaireMois"></param>
        /// <param name="siret"></param>
        /// <param name="responsable"></param>
        protected Pharmacie(string nom, double chiffreAffaireMois, string siret, Responsable responsable)
        {
            Nom = nom;
            ChiffreAffaireMois = chiffreAffaireMois;
            Siret = siret;
            Responsable = responsable;
            employes.Add(Responsable);

            //On définis les stocks des pharmacies de base
            Medicament m1 = new Medicament(1, "", "Doliprane", 12, 16, DateTime.Now, 15, "Medicament", "#Doli");
            Vaccin v1 = new Vaccin("", "notice", "Covid-19 vaccin", 95, 500, 1000, DateTime.Now, 50, "Vaccin", "#VacccinCovid");
            ProduitBeaute p1 = new ProduitBeaute(5, "Effaclar", 10, 20, DateTime.Now, 100, "ProduitBeaute", "#Effaclar");
            p1.Avis.Add("Simplement génial.");

            stock.Add(m1);
            stock.Add(v1);
            stock.Add(p1);
        }

        public string Nom { get => nom; set => nom = value; }
        public double ChiffreAffaireMois { get => chiffreAffaireMois; set => chiffreAffaireMois = value; }
        public string Siret { get => siret; set => siret = value; }
        internal List<Produit> Stock { get => stock; set => stock = value; }
        internal Responsable Responsable { get => responsable; set => responsable = value; }

        /// <summary>
        /// Méthode qui change de comportement dans les classes filles
        /// </summary>
        /// <param name="p"></param>
        public abstract void AchatProduit(Produit p);
    }
}
