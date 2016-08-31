using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class Parodontal
    {
        public bool medialisPapillum;
        public bool distalisPapillum;
        byte parodontalPocketDistal;
        byte parodontalPocketMedial;


        public byte parPocketDist
        {
            get { return parodontalPocketDistal; }
            set
            {
                if (value >= 0 && value <= 3) parodontalPocketDistal = value;
                else parodontalPocketDistal = 0;
            }
        }
        public byte parPocketMed
        {
            get { return parodontalPocketMedial; }
            set
            {
                if (value >= 0 && value <= 3) parodontalPocketMedial = value;
                else parodontalPocketMedial = 0;
            }
        }
    }
}
