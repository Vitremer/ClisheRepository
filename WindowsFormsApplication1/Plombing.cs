using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class Plombing
    {
        public bool heal;
        public bool iso;
        public bool otsroch;
        public bool temporalPlomb;
        public Materials usingHealFill = new Materials();
        public Materials usingIsoFill = new Materials();
        public Materials usingPlomb = new Materials();
        private string defaultIsoFill;
        public List<string> usingColors = new List<string>();


        public string defIsoFill
        {
            get
            {
                if (usingPlomb.lightCured && heal) return KlisheParams.findMaterial("Витремер").Name;
                else if (usingPlomb.lightCured && !heal) return KlisheParams.findMaterial("SDR").Name;
                else return KlisheParams.findMaterial("Глассин").Name;
            }
            set { defaultIsoFill = value; }
        }


        public void Copy(Plombing plomb)
        {

            heal = plomb.heal;
            iso = plomb.iso;
            otsroch = plomb.otsroch;
            temporalPlomb = plomb.temporalPlomb;

            usingHealFill = plomb.usingHealFill;
            usingIsoFill = plomb.usingIsoFill;

            usingPlomb.Copy(plomb.usingPlomb);
            usingColors.Clear();
            foreach (string col in plomb.usingColors)
            {
                usingColors.Add(col);
            }
        }

    }
}
