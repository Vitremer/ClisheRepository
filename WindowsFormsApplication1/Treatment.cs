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
        public bool heal;
        public bool iso;
        public bool otsroch;
        public bool temporalPlomb;
        //public Anesthetics usingAnestetic = new Anesthetics();
        //public float mlOfAnest;
        //public Anesthetics usingApplication = new Anesthetics();
        public Materials usingHealFill = new Materials();
        public Materials usingIsoFill = new Materials();
        public Materials usingPlomb = new Materials();
        private string defaultIsoFill;
        public  List <string> usingColors = new List<string>();


        public string defIsoFill
        {
            get {
                if (usingPlomb.lightCured && heal) return "Витремер";
                else if (usingPlomb.lightCured && !heal) return "SDR";
                else return "Глассин";
            }
            set { defaultIsoFill = value; }
        }

        //public static bool operator ==(Treatment firstTreat, Treatment secondTreat)
        //{

           

        //}

        public void Copy(Treatment copyTreat)
        {
            anest = copyTreat.anest.Copy();
            //applica = copyTreat.applica;
            anest = copyTreat.anest;
            heal = copyTreat.heal;
            iso = copyTreat.iso;
            otsroch = copyTreat.otsroch;
            temporalPlomb = copyTreat.temporalPlomb;
            //usingAnestetic = copyTreat.usingAnestetic;
            //usingApplication = copyTreat.usingApplication;
            //mlOfAnest = copyTreat.mlOfAnest;
            usingHealFill = copyTreat.usingHealFill;
            usingIsoFill = copyTreat.usingIsoFill;
            
            usingPlomb.Copy(copyTreat.usingPlomb);
            usingColors.Clear();
            foreach (string col in copyTreat.usingColors)
            {
                usingColors.Add(col);
            }
            


        }



    }
}
