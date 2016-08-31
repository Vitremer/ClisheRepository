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
