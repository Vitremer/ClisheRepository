using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    [Serializable]
    class Anesthetics
    {
        string nameOfAnesthetic;
        float volume;
        public bool isApplicable;
        public bool iscarpul;
        public bool withAdrenalini;
        byte proportion;

        public Anesthetics()
        {
            Name = "N/A";
            DoseVolume = 1.7f;
            iscarpul = true;
            withAdrenalini = false;
        }
        public Anesthetics(string nameOf)
        {
            Name = nameOf;
            DoseVolume = 1.7f;
            iscarpul = true;
            ProportionAdrenalini = 0;
            withAdrenalini = false;
        }
        public Anesthetics(string nameOf, byte proportion)
        {
            Name = nameOf;
            DoseVolume = 1.7f;
            iscarpul = true;          
            ProportionAdrenalini = proportion;
            if (ProportionAdrenalini != 0) withAdrenalini = true; else withAdrenalini = false;
        }
        public Anesthetics(string nameOf, float Dose)
        {
            Name = nameOf;
            DoseVolume = Dose;
            iscarpul = true;
            ProportionAdrenalini = proportion;
            if (ProportionAdrenalini != 0) withAdrenalini = true; else withAdrenalini = false;
        }
        public Anesthetics(string nameOf, float Dose, byte proportion)
        {
            Name = nameOf;
            DoseVolume = Dose;
            iscarpul = true;
            ProportionAdrenalini = proportion;
            if (ProportionAdrenalini != 0) withAdrenalini = true; else withAdrenalini = false;
           
        }
        public Anesthetics(string nameOf, float Dose, bool IsCarp, byte proportion)
        {
            Name = nameOf;
            DoseVolume = Dose;
            iscarpul = IsCarp;
            ProportionAdrenalini = proportion;
            if (ProportionAdrenalini != 0) withAdrenalini = true; else withAdrenalini = false;

        }
     

        public string Name
        {
            get
            {
                return nameOfAnesthetic;
            }
            set
            {
                if (value != null) nameOfAnesthetic = value;
                else nameOfAnesthetic = "N/A";

            }

        }
        public float DoseVolume
        {
            get
            {
                return volume;
            }
            set 
            {
                volume = value;
            }
        }
       
        public byte ProportionAdrenalini
        {
            get
            {
                if (withAdrenalini) return proportion;

                else return 0;
            }
            set { 
                
                if(value >=0 && value <=2) proportion = value;
                else proportion = 0;
            
            }
        }

    }
}
