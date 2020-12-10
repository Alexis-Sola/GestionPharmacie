using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Employes
{
    class SalairePharmacien : IObserver
    {
        public Pharmacien pharmacien;

        public SalairePharmacien(Pharmacien pharmacien)
        {
            this.pharmacien = pharmacien;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
