using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class Treatment
    {
        public Anestesy anest = new Anestesy();
        public PrepareTooth prepare = new PrepareTooth();
        public ConditionTreatment condiTreat = new ConditionTreatment();
        public Plombing plombing = new Plombing();
        public PostHealing postHeal = new PostHealing();
        public Recomendation recomend = new Recomendation();

        //public bool applica;
        //public bool anest;
     
        //public Anesthetics usingAnestetic = new Anesthetics();
        //public float mlOfAnest;
        //public Anesthetics usingApplication = new Anesthetics();
       

     

        //public static bool operator ==(Treatment firstTreat, Treatment secondTreat)
        //{

           

        //}

        public void Copy(Treatment copyTreat)
        {
            plombing.Copy(copyTreat.plombing);
            anest = copyTreat.anest.Copy();
            //applica = copyTreat.applica;
            anest = copyTreat.anest;
            //heal = copyTreat.heal;
            //iso = copyTreat.iso;
            //otsroch = copyTreat.otsroch;
            //temporalPlomb = copyTreat.temporalPlomb;
            //usingAnestetic = copyTreat.usingAnestetic;
            //usingApplication = copyTreat.usingApplication;
            //mlOfAnest = copyTreat.mlOfAnest;
            //usingHealFill = copyTreat.usingHealFill;
            //usingIsoFill = copyTreat.usingIsoFill;
            
            //usingPlomb.Copy(copyTreat.usingPlomb);
            //usingColors.Clear();
            //foreach (string col in copyTreat.usingColors)
            //{
            //    usingColors.Add(col);
            //}
            


        }



    }
}
