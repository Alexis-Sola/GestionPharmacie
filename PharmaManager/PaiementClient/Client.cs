using PharmaManager.PaiementClient;
using PharmaManager.Pharmacies;
using PharmaManager.Produits;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Transactions
{
    class Client
    {
        private string nom;
        private string prenom;
        private string refClient;
        private CarteClassique cbCla;
        private CartePharmacie cbPh;
        private List<Produit> pds = new List<Produit>();

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string RefClient { get => refClient; set => refClient = value; }
        internal CarteClassique CbCla { get => cbCla; set => cbCla = value; }
        internal CartePharmacie CbPh { get => cbPh; set => cbPh = value; }

        public Client(string nom, string prenom, string refClient, CarteClassique cbCla, CartePharmacie cbPh)
        {
            Nom = nom;
            Prenom = prenom;
            RefClient = refClient;
            CbCla = cbCla;
            CbPh = cbPh;
        }

        /// <summary>
        /// Permet d'acheter un produit de façon classique
        /// </summary>
        /// <param name="p"></param>
        /// <param name="c"></param>
        public void AchatProduitCarteClassique(Produit p, Compte c)
        {
            //On test si le client peut payer
            //Si oui son vompte est débiter
            if(p.Quantite > 0 && CbCla.Payer(p.PrixVente))
            {
                //On diminue la quantité initiale du du produit
                p.Quantite -= 1;

                //On copie le produit car on le sort des stock
                Produit newProd = p;
                newProd.Quantite = 1;
                pds.Add(newProd);

                //On crédite le compte de la pharmacie
                c.Crediter(p.PrixVente);

                //On créer la transaction
                new TransactionPharma(new TransactionValidee(), p.PrixVente, DateTime.Now, DateTime.Now, true, c.Ph.Nom, Nom);
                DisplayVenteClassique(p, c);
            }
            else
                new TransactionPharma(new TransactionRefusee(), p.PrixVente, DateTime.Now, DateTime.Now, true, c.Ph.Nom, Nom);
        }

        /// <summary>
        /// Permet d'acheter un produit et de ne payer qu'a la fin du mois
        /// Un tache sera lancéee tous les mois qui va parcourir les transactions en cours
        /// et validera la transaction qui doivent être payé
        /// </summary>
        /// <param name="p"></param>
        /// <param name="c"></param>
        public void AchatProduitCartePharmacie(Produit p, Compte c)
        {
            //On regarde si le produit est dispo et si le client à les moyens
            if (p.Quantite > 0 && CbPh.AuthorizePayment(p.PrixVente))
            {
                //On decremente la quantite
                p.Quantite -= 1;

                //On créer le produit client
                Produit newProd = p;
                newProd.Quantite = 1;
                pds.Add(newProd);

                //On créer la transaction et on set la date à la fin du mois 
                new TransactionPharma(new TransactionEnCours(), p.PrixVente, DateTime.Now, new DateTime(2020, 12, 31, 23, 59, 59), false, c.Ph.Nom, Nom);
                DisplayVenteRetardee(p);
            }
            else
                new TransactionPharma(new TransactionRefusee(), p.PrixVente, DateTime.Now, DateTime.Now, true, c.Ph.Nom, Nom);
        }

        private void DisplayVenteRetardee(Produit p )
        {
            Console.WriteLine($"Une vente vient d'être effectuée. La transaction d'un montant de {p.PrixVente} sera effectuée à la fin du mois.");
        }

        private void DisplayVenteClassique(Produit p, Compte c)
        {
            Console.WriteLine($"Une vente vient d'être effectuée. Le compte de la pharmacie {c.Ph.Nom} est créditer de {p.PrixVente}euro");
        }


        /// <summary>
        /// Remboursement du client quand il conteste son achat
        /// </summary>
        /// <param name="t"></param>
        public void Constester(TransactionPharma t)
        {
            throw new NotImplementedException();
        }
    }
}
