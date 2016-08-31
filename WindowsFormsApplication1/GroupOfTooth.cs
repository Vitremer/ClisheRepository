using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
     class GroupOfTooth
    {
        public List<Tooth> ToothsInGroup = new List<Tooth>();

        byte pretreatment;

        public byte pretreat
        {
            get
            {
                if (pretreatment >= 0 && pretreatment <= 2) return pretreatment;
                else return 0;
            }
            set
            {
                if (value >= 0 && value <= 2) pretreatment = value;
                else pretreatment = 0;

            }
        }
        //public Tooth.diag MainDs;

        public Diagnos MainDs;
        public Condition MainCondition;

        public string GetToothsText(bool needToothWord)
        {
            string numberOfTooths = "";
            foreach (Tooth tooth in ToothsInGroup)
            {
                numberOfTooths += tooth.number + ", ";
            }
            numberOfTooths = numberOfTooths.Remove(numberOfTooths.Length - 2);
            if (needToothWord)
            {
                if (ToothsInGroup.Count > 1)
                {
                    numberOfTooths += " зубы ";

                }
                else numberOfTooths += " зуб ";
            }
            return numberOfTooths;
        }

       
    }
}
