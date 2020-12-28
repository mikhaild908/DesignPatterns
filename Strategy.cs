/*******************************************************************************
 * Strategy Pattern 
 * Defines a family of algorithms, encapsulates each one, and makes them
 * interchangeable.  Strategy lets the algorithm vary independently from clients
 * that use it.
 ******************************************************************************/

using System;
using System.Collections.Generic;

namespace DesignPatterns.Lib
{
    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            throw new NotImplementedException();
        }
    }

    class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            throw new NotImplementedException();
        }
    }

    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            throw new NotImplementedException();
        }
    }

    class SortedList
    {
        private List<string> _list = new List<string>();
        private SortStrategy _sortStrategy;

        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            this._sortStrategy = sortStrategy;
        }

        public void Add(string name)
        {
            _list.Add(name);
        }

        public void Sort()
        {
            _sortStrategy.Sort(_list);
        }
    }
}
