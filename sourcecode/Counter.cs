//=======================================================================
// Titel : Übung 2, C#-Advanced: Counter
// Datei : Counter.cs
// Autor : C.Mauchle
//=======================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Counter
{
    public delegate void CountChangedHandler(CountChangedEventArgs e);


    class Counter
    {
        private int count;

        public event CountChangedHandler countChange;

        public int Count
        {
            set
            {
                CountChangedEventArgs e = new CountChangedEventArgs(count, value);
                countChange(e);
                count = value;
            }
            get { return count; }
        }

        public void Increment()
        {
            Count++;
        }

        public void Decrement()
        {
            Count--;
        }

        public void Reset()
        {
            Count = 0;
        }


    }

    public class CountChangedEventArgs : EventArgs
    {
        private int mOldValue;
        private int mNewValue;

        public CountChangedEventArgs(int oldValue, int newValue)
        {
            mOldValue = oldValue;
            mNewValue = newValue;
        }

        public int OldValue
        {
            get { return mOldValue; }
        }

        public int NewValue
        {
            get { return mNewValue; }
        }
    }

    class Program
    {

        public static void CountChangeListener(CountChangedEventArgs e)
        {
            Console.WriteLine("Counter Value changed from {0} to {1}", e.OldValue, e.NewValue);
        }

        static void Main(string[] args)
        {

            Counter myCount = new Counter();
            myCount.countChange += CountChangeListener;

            myCount.Count = 5;

            myCount.Increment();
            myCount.Decrement();

//            myCount.countChange();

            myCount.Reset();

            Console.ReadLine();
        }
    }
}
