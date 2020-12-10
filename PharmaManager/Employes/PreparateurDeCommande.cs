using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Employes
{
    class PreparateurDeCommande : Employe
    {
        private int anciennete;
        private double tauxHoraire;
        private double heures;
        private SalairePreparateurDeCommande salairePrepaCommande;

        public PreparateurDeCommande(int anciennete, double tauxHoraire, double heures, string nom, string prenom, string adresse, double salaire) : base(nom, prenom, adresse, salaire)
        {
            Anciennete = anciennete;
            TauxHoraire = tauxHoraire;
            Heures = heures;
        }

        public int Anciennete { get => anciennete; set => anciennete = value; }
        public double TauxHoraire { get => tauxHoraire; set => tauxHoraire = value; }
        public double Heures { get => heures; set => heures = value; }
    }
}
