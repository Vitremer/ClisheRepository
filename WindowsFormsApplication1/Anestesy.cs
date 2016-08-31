using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class Anestesy
    {
       public  bool applica;
        public bool carpul;
        public enum KindOfAnestesy {infiltration, conduction, intraseptal, intrapulpar, intraligamental };

        public KindOfAnestesy kindOfAnest;
        public Anesthetics usingAnestetic = new Anesthetics();
        public Anesthetics usingApplication = new Anesthetics();

        public static bool operator ==(Anestesy firstAnest, Anestesy secondAnest)
        {
            if (ReferenceEquals(secondAnest, null)) { if (ReferenceEquals(firstAnest, null)) return true; else return false; }

            if (firstAnest.applica==secondAnest.applica&& firstAnest.carpul==secondAnest.carpul&&) return false;


            return true;


        }
        public static bool operator !=(Condition firstCond, Condition secondCond)
        {
            if (ReferenceEquals(secondCond, null)) { if (ReferenceEquals(firstCond, null)) return false; else return true; }

            if (firstCond.Name != secondCond.Name || firstCond.Depth != secondCond.Depth) return true;


            return false;


        }
        public Anestesy Copy()
        {
            Anestesy newAnest = new Anestesy();
            newAnest.applica = this.applica;
            newAnest.carpul = this.carpul;
            if (carpul) newAnest.kindOfAnest = this.kindOfAnest;
            newAnest.usingAnestetic = this.usingAnestetic;
            newAnest.usingApplication = this.usingApplication;
            return newAnest;

        }

    }
}
