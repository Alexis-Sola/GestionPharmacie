using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Employes
{
    class SalairePreparateurDeCommande : IObserver
    {
        public PreparateurDeCommande prepa;

        public SalairePreparateurDeCommande(PreparateurDeCommande prepa)
        {
            this.prepa = prepa;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
