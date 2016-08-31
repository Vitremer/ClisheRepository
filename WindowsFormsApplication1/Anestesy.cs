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

            if (firstAnest.applica == secondAnest.applica && firstAnest.carpul == secondAnest.carpul && firstAnest.kindOfAnest == secondAnest.kindOfAnest)
            {
                if (firstAnest.applica)
                {
                    if (firstAnest.usingApplication.Name != secondAnest.usingApplication.Name) return false;
                }
                if (firstAnest.carpul)
                {
                    if (firstAnest.usingAnestetic.Name != secondAnest.usingAnestetic.Name) return false;
                }
                return true;
            }
                return false;


           


        }
        public static bool operator !=(Anestesy firstAnest, Anestesy secondAnest)
        {
            if (ReferenceEquals(secondAnest, null)) { if (ReferenceEquals(firstAnest, null)) return false; else return true; }

            if (firstAnest.applica == secondAnest.applica && firstAnest.carpul == secondAnest.carpul && firstAnest.kindOfAnest == secondAnest.kindOfAnest)
            {
                if (firstAnest.applica)
                {
                    if (firstAnest.usingApplication.Name != secondAnest.usingApplication.Name) return true;
                }
                if (firstAnest.carpul)
                {
                    if (firstAnest.usingAnestetic.Name != secondAnest.usingAnestetic.Name) return true;
                }
                return false;
            }
            return true;


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
