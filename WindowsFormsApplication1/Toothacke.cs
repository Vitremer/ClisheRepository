//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace WindowsFormsApplication1
//{
 
//    class Toothacke
//    {
//        private byte number;

//        public bool front
//        {
//            get
//            {
//                if (number % 10 < 4)
//                {
//                    return true;
//                }
//                else return false;
//            }
//        }


//        public Toothacke()
//        {
//        }
//        public Toothacke(byte numberTooth)
//        {
//            number = numberTooth;

//        }


//        public byte num
//        {
//            set
//            {

//                if ((value % 10 > 0 && value % 10 < 9) && (value / 10 > 0 && value / 10 < 5)) number = value;
//                else Console.WriteLine("таких зубов не бывает, значение не введено");
//            }
//            get
//            {
//                return number;
//            }

//        }
//    }
//    /* Class Caries имеет методы: 
//     * healed() - лечен или нет зуб
//     * diag() - глубина кариеса
//     * facer() - метка пораженных поверхностей
//     * diagnoz() - полный диагноз с номером зуба
//     * facesPlacer() - служит для выведения названия поверхности по индексу поверхности в методе facer()
//     * 
//     * имеет свойства:
//     * ds - обращение к полю diagnos 
//     * pretreat - поле pretreatment - лечен ли раньше зуб или нет
//     * 
//     * 3 перегруженных конструктора Caries(bool [] face, byte diag, byte numberTooth):
//     * первый с параметрами номера зуба
//     * второй с параметрами номер зуба и массив с пораженными поверхностями
//     * третий с параметрами номера зуба, диагнозом(глубина поражения), пораженными поверхностями
//     * 
//     * булевый массив connectSurface содержащий 3 линии по 6 ячеек для обьединенных поверхностей, максимум три группы обьединенных поверхностей. 




//    */

//    class Caries : Toothacke
//    {
//        private bool[] surface = new bool[6];
//        public bool[,] connectSurface = new bool[2, 6];
//        private bool pretreatment;

//        private byte connectGroups;
//        private byte diagnos;

//        public bool truefalse(byte i)
//        {
//            if (i < 1) return false;
//            else return true;
//        }

//        //МЕТОДЫ
//        public string diag()
//        {
//            switch (diagnos)
//            {
//                case 1:
//                    return "средний кариес";
//                case 2:
//                    return "глубокий кариес";
//                case 3:
//                    return "гиперемия пульпы";
//                default:
//                    return "другой кариес";
//            }
//        }
//        public string healed()
//        {
//            if (pretreatment == true) return "ранее лечен по поводу неосложненного кариеса";
//            else return "ранее не лечен";
//        }
//        public bool[] facer()
//        {
//            bool[] face = new bool[6];
//            for (byte i = 0; i < 6; i++)
//            {
//                try
//                {
//                    Console.WriteLine(facesPlacer(i) + ":");
//                    face[i] = truefalse(Convert.ToByte(Console.ReadLine()));
//                }
//                catch
//                {

//                    face[i] = false;
//                }
//            }
//            return face;
//        }

//        public string faceConText(bool[,] connected)
//        {
//            string[] conFace = new string[3];
//            string conF = "";
//            for (byte i = 0; i < 2; i++)
//            {

//                for (byte b = 0; b < 5; b++)
//                {

//                    if (connected[i, b] == true)
//                    {
//                        if (conFace[i] != null) conFace[i] = conFace[i].Replace("ая поверхность, ", "о-");
//                        conFace[i] += facesPlacer(b) + ", ";
//                    }
//                }
//                conF += conFace[i];
//                if (conFace[i] != "" && connectGroups > i + 1) conF += " и ";

//            }

//            return conF;
//        }

//        public bool[,] connectorBool()
//        {

//            Console.WriteLine("Введите количество групп соединенных поверхностей: ");

//            byte i;
//            try
//            {

//                i = Convert.ToByte(Console.ReadLine());
//                if (i > 3) i = 3;
//            }
//            catch
//            {
//                i = 0;
//            }
//            connectGroups = i;
//            bool[,] con = new bool[3, 6];

//            bool[] fac = new bool[6];

//            for (byte n = 0; n < 3; n++)
//            {
//                if (n < i)
//                {
//                    Console.WriteLine((n + 1) + " группа пораженных поверхностей, введите какие поверхности поражены в этой группе");
//                    fac = facer();
//                }
//                for (byte b = 0; b < 6; b++)
//                {
//                    if (n >= i) con[n, b] = false;
//                    else
//                        con[n, b] = fac[b];
//                }
//            }
//            return con;


//        }

//        public string Diagnoz()
//        {
//            return Convert.ToString(num) + " зуб - " + diag();
//        }
//        public string faces(bool[] x)
//        {
//            string all = "";
//            for (byte i = 0; i < x.Length; i++)
//            {
//                if (x[i] == true) all += facesPlacer(i) + ", ";

//            }
//            return all;

//        }
//        public string facesPlacer(byte i)
//        {
//            switch (i)
//            {
//                case 0:

//                    return "жевательная поверхность";


//                case 1:
//                    return "дистальная поверхность";

//                case 2:
//                    return "медиальная поверхность";

//                case 3:
//                    return "вестибулярная поверхность";

//                case 4:
//                    return "оральная поверхность";

//                case 5:
//                    return "режущий край";

//                default:
//                    return " поверхность";

//            }
//        }
//        //СВОЙСТВА
//        //public bool[,] surfaces
//        //{
//        //    get
//        //    {
//        //        return 
//        //    }
//        //    set
//        //    {
//        //    }
//        //}
//        public byte ds
//        {
//            set
//            {
//                if (value <= 3 && value >= 1) diagnos = value;

//            }
//            get
//            {
//                return diagnos;
//            }

//        }

//        public bool pretreat
//        {
//            get
//            {
//                return pretreatment;
//            }
//            set
//            {
//                try
//                {
//                    pretreatment = value;
//                }
//                catch
//                {
//                    pretreatment = false;
//                }
//            }
//        }

//        //КОНСТРУКТОРЫ
//        public Caries()
//        {
//        }
//        public Caries(byte numberTooth)
//            : base(numberTooth)
//        {
//            base.num = numberTooth;
//        }
//        public Caries(bool[] face, byte numberTooth)
//            : base(numberTooth)
//        {
//            surface = face;

//        }
//        public Caries(bool[] face, byte diag, byte numberTooth)
//            : base(numberTooth)
//        {
//            surface = face;
//            if (diag > 0 && diag < 4) diagnos = diag;
//        }
//    }

//    class UsingTooth
//    {

//        //public static void Main()
//        //{


//        //    /*
//        //     Caries carMolar = new Caries(26);


//        //      carMolar.ds = 1;
//        //      carMolar.pretreat = true;
    
//        // Console.WriteLine("зуб с кариесом имеет диагноз:" + carMolar.Diagnoz()+", зуб " +carMolar.healed()+ " и у него поражены поверхности:"+carMolar.faceConText(carMolar.connectorBool()));


        
                
        
        
        
        
        
        
        
        
//        // */

//        //    Console.ReadKey();

//        //}
//    }



//}
