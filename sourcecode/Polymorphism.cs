//=======================================================================
// Titel : C#-Vertiefung, Aufgabe 1: Dynamic- und Static-Binding
// Datei :Polymorphism.cs
// Autor : J.Jucker
//=======================================================================

using System;
using System.Collections.Generic;

namespace Polymorphism
{
    public interface IGObject
    {
        void Draw();
        void WhoAreYou();
    }

    class Kreis : IGObject
    {
        protected string name;

        public Kreis(string name) { this.name = name; }

        public void Draw()
        {
            Console.WriteLine("Kreis: {0}", name);
        }
        
        public void WhoAreYou()
        {
            Console.WriteLine("Kreis: {0}", name);
        }
    }

    class Rechteck : IGObject
    {
        protected string name;

        public Rechteck(string name) { this.name = name; }
    
        public void Draw()
        {
            Console.WriteLine("Rechteck: {0}", name);
        }
      
        public void WhoAreYou()
        {
            Console.WriteLine("Rechteck: {0}", name);
        }
    }

    class Kreiseck : IGObject
    {
        protected string name;

        public Kreiseck(string name) { this.name = name; }

        public void Draw()
        {
            Console.WriteLine("Kreiseck: {0}", name);
        }

        public void WhoAreYou()
        {
            Console.WriteLine("Kreiseck: {0}", name);
        }
    }

    class Compound : IGObject
    {
        protected string name;
        List<IGObject> objList = new List<IGObject>();

        public Compound(string name) { this.name = name; }

        public void Draw()
        {
            Console.WriteLine("Compound: {0}", name);
            foreach (IGObject g in objList)
            {
                g.Draw();
            }
            Console.WriteLine("End Compound: {0}", name);
        }

        public void WhoAreYou()
        {
            Console.WriteLine("Compound: {0}", name);
            foreach (IGObject g in objList)
            {
                g.WhoAreYou();
            }
            Console.WriteLine("End Compound: {0}", name);
        }

        public void Add(IGObject g)
        {
            objList.Add(g);
        }
    }

    class Test
    {
        static void Main()
        {
            Compound g = new Compound("C1");
            g.Add(new Kreis("K1"));

            Compound g1 = new Compound("C2");
            g1.Add(new Rechteck("R21"));
            g1.Add(new Kreis("K21"));
            g.Add(g1);
            g.Add(new Kreiseck("KE2"));

            Console.WriteLine("Drawing ... (dynamic binding)");
            g.Draw();
            Console.WriteLine("press enter to continue");
            Console.ReadLine();

            Console.WriteLine("calling \"who are you\" (static binding)");
            g.WhoAreYou();
            Console.ReadLine();
            Console.WriteLine("press enter to continue");

        }
    }
}
