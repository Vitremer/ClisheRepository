using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace KlisheNamespace
{
   
    class Osmotr
    {

    }

    class Stomatology
    {
        byte openMouth;
        byte gigiene;
        byte mucos;
        byte kvadrant;


        public byte openingMouth//свойство открывание рта - 0 - в норме, 1 - затруднено
        {
            get
            {
                if (openMouth <= 1 && openMouth >= 0) return openMouth;
                else return 0;
            }
            set
            {
                if (value >= 0 && value <= 1) openMouth = value;
                else openMouth = 0;
            }
        }
        public byte gigiena//свойство гигиена полости рта - 0 - удовлетворительная, 1 - неудовлетворительная, 2 - плохая
        {
            get
            {
                if (gigiene <= 2 && gigiene >= 0) return gigiene;
                else return 0;
            }
            set
            {
                if (value >= 0 && value <= 2) gigiene = value;
                else gigiene = 0;
            }
        }
        byte mucosa //свойство слизистая - 0 - бледно-розовая, 1- гиперемия маргинальной десны, 2- гиперемися отечность маргинальной десны и межзубных сосочков, 3 - гиперемия, отек слизистой преходной складки
        {
            get
            {
                if (mucos<= 3 && mucos >= 0) return mucos;
                else return 0;
            }
            set
            {
                if (value >= 0 && value <= 3) mucos = value;
                else mucos = 0;
            }
        }
    }




    
    //класс поверхностей
   

    



   
}
