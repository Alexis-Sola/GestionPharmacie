using PharmaManager.Employes;
using PharmaManager.PaiementClient;
using PharmaManager.Pharmacies;
using PharmaManager.Produits;
using PharmaManager.Transactions;
using System;
using System.Transactions;

namespace PharmaManager
{
    class Program
    {
        static void Main(string[] args)
        {
            PharmacieInde phI1 = new PharmacieInde("phI1", 200000, "6", new CompteInde(0), new Responsable("Alexis", "", "", 10000, 0));

            //Exemple composite
            PharmacieFranchise phF1 = new PharmacieFranchise("phF1", 100000, "1", new CompteFranchise(10000), new Responsable("Alexis", "", "", 10000, 0));
            PharmacieFranchise phF2 = new PharmacieFranchise("phF2", 50000, "2", new CompteFranchise(10000), new Responsable("Alexis", "", "", 10000, 0));
            PharmacieFranchise phF3 = new PharmacieFranchise("phF3", 40000, "3", new CompteFranchise(10000), new Responsable("Alexis", "", "", 10000, 0));
            PharmacieFranchise phF4 = new PharmacieFranchise("phF4", 30000, "4", new CompteFranchise(10000), new Responsable("Alexis", "", "", 10000, 0));
            PharmacieFranchise phF5 = new PharmacieFranchise("phF5", 520000, "5", new CompteFranchise(10000), new Responsable("Alexis", "", "", 10000, 0));

            phF1.PharmasF.Add(phF2);
            phF1.PharmasF.Add(phF3);
            phF1.PharmasF.Add(phF4);
            phF1.PharmasF.Add(phF5);

            //Nous sommes en fin de moi les PharmaciesFranchisées perçoivent et payent leurs royalties
            phF1.MajRoyalties();

            //Achat de produits pour les pharmacies avec l'application des réductions
            Vaccin vVIH = new Vaccin("vaccin contre le VIH", "", "VaccinVIH", 98.0, 100, 500, DateTime.Now, 2, "", "#vVIH");
            phF1.AchatProduit(vVIH);
            phF2.AchatProduit(vVIH);
            phI1.AchatProduit(vVIH);

            //Ce client achete avec ses deux cartes
            Client bobby = new Client("bobby", "bob", "#refBob", new CarteClassique("", "Bobby", "", 1000, new MasterCard()), new CartePharmacie("", "Bobby","", 1500, new Visa()));
            bobby.AchatProduitCarteClassique(phF2.Stock[0], phF2.Compte);
            bobby.AchatProduitCartePharmacie(phF2.Stock[1], phF2.Compte);
        }
    }
}
