using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaManager.Employes
{
    abstract class Subject
    {
        protected List<IObserver> observers = new List<IObserver>();

        public abstract void Notify();

        public void Add(IObserver obs)
        {
            observers.Add(obs);
        }

        public void Delete(IObserver obs)
        {
            observers.Remove(obs);
        }
    }
}
