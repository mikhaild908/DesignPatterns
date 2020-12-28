/*******************************************************************************
 * Observer Pattern
 * Defines a one-to-many dependency between objects so that when one object
 * changes state, all of its dependents are notified and updated automatically
 ******************************************************************************/

using System;
using System.Collections.Generic;

namespace DesignPatterns.Lib
{
    interface Observer
    {
        public void Update();
    }

    interface Subject
    {
        public void RegisterObserver(Observer observer);
        public void RemoveObserver(Observer observer);
        public void NotifyObservers();
    }

    class ConcreteSubject : Subject
    {
        private readonly List<Observer> _observers;

        public ConcreteSubject()
        {
            this._observers = new List<Observer>();
        }

        public void NotifyObservers()
        {
            foreach (var observer in this._observers)
            {
                observer.Update();
            }
        }

        public void RegisterObserver(Observer observer)
        {
            this._observers.Add(observer);
        }

        public void RemoveObserver(Observer observer)
        {
            this._observers.Remove(observer);
        }
    }

    class ConcreteObserver : Observer
    {
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
