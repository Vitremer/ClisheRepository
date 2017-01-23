using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
     class Tooth : Stomatology
    {
        #region fields
        byte numberOfTeeth;
        public enum connect { VM, VO, VD, MO, MN, ON, OD, DN, empty };
      List<diag> _diagnosis1 = new List<diag>();
         List<Diagnos> _diagnosis = new List<Diagnos>();
        List<connect> _connections = new List<connect>();
        List<Face> _facesOfTeeth = new List<Face>();
        Dictionary<string, List<connect>> _connectDictionary = new Dictionary<string, List<connect>>();//ключ - имя Состояния поверхности без глубины (Condition.Name), значения - список всех соединений этих состояний.
        Dictionary<string, List<List<Face>>> _condNameConnectBlocksDictionary = new Dictionary<string, List<List<Face>>>();//ключ - имя Состояния поверхности без глубины (Condition.Name), значения - список  соединений этих состояний обьединенных в блоки
        Dictionary<Condition, List<List<Face>>> _condConnectBlocksDictionary = new Dictionary<Condition, List<List<Face>>>();//ключ - само Состояние поверхности с глубиной (Condition), значения - список  соединений этих состояний обьединенных в блоки
         
         public Treatment Treat = new Treatment();

           public void RenewDiagnosis()
        {

            GetDiagnosisOfTooth();
            //_diagnosis.Clear();
            //   foreach (Face face in this.GetAllFaces())
            //   {
            //       foreach (Condition ill in face.GetConditionsOfFace())
            //       {
            //           string diagToParse = "";
            //           if (ill.NameOfIll == Condition.conditionOfFace.car && ill.Depth == Condition.DepthOfCondition.pov) diagToParse += ill.Depth.ToString() + '_';
            //           diagToParse += ill.NameOfIll.ToString();
            //           if (!_diagnosis.Contains((diag)Enum.Parse(typeof(diag), diagToParse)))
            //           {
            //               _diagnosis.Add((diag)Enum.Parse(typeof(diag), diagToParse));
            //           }
            //       }
            //   }
           }

         public static bool operator == (Tooth firstTooth, Tooth secondTooth)
         {

             if (ReferenceEquals(secondTooth, null)) { if (ReferenceEquals(firstTooth, null)) return true; else return false; }
             //проверяем равны ли соединения поверхностей у двух зубов
             if (!firstTooth.Connections.SequenceEqual(secondTooth.Connections)) return false ;
             
             //выбираем в качестве первого тот зуб у которого больше поверхностей, либо если количество равно оставляем в том же порядке
             Tooth tempTooth1;
             Tooth tempTooth2;
             if (secondTooth.GetAllFaces().Length < firstTooth.GetAllFaces().Length)//проверяем у какого из зубов поверхностей больше - у того первого будет за основу браться поверхности для сравнения
             {
                 tempTooth1 = firstTooth;
                 tempTooth2 = secondTooth;
             }
             else
             {
                 tempTooth2 = firstTooth;
                 tempTooth1 = secondTooth;
             }
             
             //и перебирая все поверхности проверяем равны ли они у зубов
             foreach (Face fc in tempTooth1.GetAllFaces())
             {
                 bool haveOne = false;
                 foreach (Face fc2 in tempTooth2.GetAllFaces())
                 {
                     if (fc == fc2)
                         haveOne = true;
                 }
                 if (!haveOne) return false;
             }

          
            return true;


         }
         public static bool operator !=(Tooth firstTooth, Tooth secondTooth)
         {
             if (ReferenceEquals(secondTooth, null)) { if (ReferenceEquals(firstTooth, null)) return false; else return true; }
       
            foreach (Face fc in secondTooth.GetAllFaces())
             {
                 bool haveOne = false;
                 foreach (Face fc2 in firstTooth.GetAllFaces())
                 {
                     if (fc == fc2)
                         haveOne = true;
                 }
                 if (!haveOne) return true;
             }


             return false;


         }



         byte _GetClassOfFace(Face fc)
         {
             byte blackClass = 0;

             List<Face> connect = fc.GetConnections();
             if (isFront)
             {


                 if (fc.faceName == Face.faceSide.distal || fc.faceName == Face.faceSide.medial)
                 {
                     blackClass = 3;

                     if (connect.Count > 0)
                         foreach (Face conFc in connect)
                         {
                             if (conFc.faceName == Face.faceSide.edge)
                             {
                                 blackClass = 4;
                             }

                         }
                    
                 }


                 else if (fc.faceName == Face.faceSide.edge)
                 {
                     blackClass = 6;

                     if (connect.Count > 0)
                         foreach (Face conFc in connect)
                         {
                             if (conFc.faceName == Face.faceSide.distal || conFc.faceName == Face.faceSide.medial)
                             {
                                 blackClass = 4;
                             }

                         }


                 }

                 else if (fc.faceName == Face.faceSide.vestibular)
                 {
                     blackClass = 5;
                     if (connect.Count > 0)
                         foreach (Face conFc in connect)
                         {
                             if (conFc.faceName == Face.faceSide.distal || conFc.faceName == Face.faceSide.medial)
                             {
                                 blackClass = 3;
                             }

                         }

                 }
                 else
                 {
                     blackClass = 1;
                     if (connect.Count > 0)
                         foreach (Face conFc in connect)
                         {
                             if (conFc.faceName == Face.faceSide.distal || conFc.faceName == Face.faceSide.medial)
                             {
                                 blackClass = 3;
                             }

                         }
                 }




             }
             else
             {





                 if (fc.faceName == Face.faceSide.distal || fc.faceName == Face.faceSide.medial)
                 {
                     blackClass = 2;

                  }


                 else if (fc.faceName == Face.faceSide.okklusion)
                 {
                     blackClass = 1;

                     if (connect.Count > 0)
                         foreach (Face conFc in connect)
                         {
                             if (conFc.faceName == Face.faceSide.distal || conFc.faceName == Face.faceSide.medial)
                             {
                                 blackClass = 2;
                             }

                         }


                 }

                 else if (fc.faceName == Face.faceSide.vestibular)
                 {
                     blackClass = 5;
                     if (connect.Count > 0)
                         foreach (Face conFc in connect)
                         {
                             if (conFc.faceName == Face.faceSide.distal || conFc.faceName == Face.faceSide.medial)
                             {
                                 blackClass = 2;
                             }
                             else if (conFc.faceName == Face.faceSide.okklusion)
                             {
                                 blackClass = 1;
                             }

                         }

                 }
                 else
                 {
                     blackClass = 1;
                     if (connect.Count > 0)
                         foreach (Face conFc in connect)
                         {
                             if (conFc.faceName == Face.faceSide.distal || conFc.faceName == Face.faceSide.medial)
                             {
                                 blackClass = 2;
                             }

                         }
                 }




             }

            
             return blackClass;
         }


         public string GetTextOfCondClass(Condition cond)
         {
             string resultText = KlisheParams.GetBlock("treatment_blackClass_of");

             foreach (byte cl in GetClassesOfCondition(cond))
             {

                 resultText += KlisheParams.GetBlock("treatment_blackClass_" + cl)+',';
             }
             resultText = resultText.Remove(resultText.Length - 1) + ' ';
             resultText += KlisheParams.GetBlock("treatment_blackClass_main");
             return resultText;

         }
       
         public List<byte> GetClassesOfCondition(Condition cond)
         {
             if (GetConditionsOfTooth().Find(c => c.Name == cond.Name) != null)//если такое состояние есть на зубе вообще, тогда мы начинаем чтото проверять...
             {


                 List<byte> blackClassList = new List<byte>();//список классов по блеку, которые занимает данное состояние на данном зубе

                 List<Face> facesWithCond = new List<Face>();//список поверхностей которые занимает данное состояние

                facesWithCond= GetConditionsDictOfTooth()[cond.Name];//получили все поверхности которые содержат данное состояние
                 

                 foreach (Face fcWithCond in facesWithCond)
                 {
                     byte blCl = _GetClassOfFace(fcWithCond);
                     if (blCl != 0 && !blackClassList.Contains(blCl))

                         blackClassList.Add(blCl);
                 }






                 return blackClassList;


                 
             }
             else return null;

         }

         public Dictionary<String,List<Face>> GetConditionsDictOfTooth()
         {
             Dictionary<String, List<Face>> condiDict = new Dictionary<String, List<Face>>();

             foreach(Condition cond in GetConditionsOfTooth())
             {
                 List<Face> facesContainsCond  = new List<Face>();
                 foreach (Face face in this.GetAllFaces())
                 {
                     if(face.GetConditionsOfFace().Find(c => c.Name == cond.Name)!=null)
                         facesContainsCond.Add(face);

                 }
                 //foreach (Face face in this.GetAllFaces())
                 //{
                 //    if(face.GetConnections().ToList().(facesContainsCond))
                 //    {
                 //        facesContainsCond.Add(face);
                 //    }

                 //}
                 condiDict.Add(cond.Name,facesContainsCond);

             }


           
             return condiDict;
         }


         public List<Condition> GetConditionsOfTooth()
         {
             List<Condition> condiList = new List<Condition>();
             foreach (Face face in this.GetAllFaces())//перебираем все поверхности
             {
                 foreach (Condition cond in face.GetConditionsOfFace())//перебираем все состояния каждой поверхности
                 {
                     Condition analogCondition = condiList.Find(c => c.Name == cond.Name);
                     if (analogCondition == null)
                     {
                         condiList.Add(cond);
                     }
                     else
                     {

                         if (analogCondition.Depth < cond.Depth)
                         {
                             condiList.Remove(analogCondition);
                             condiList.Add(cond);
                         }
                     }

                 }
             }
             return condiList;
         }
        public List<Diagnos> GetDiagnosisOfTooth()
        {
            _diagnosis.Clear();

          
            foreach (Face face in this.GetAllFaces())//перебираем все поверхности
            {
                foreach (Condition cond in face.GetConditionsOfFace())//перебираем все состояния каждой поверхности
                {
                    Diagnos diag = cond.Diag;
                    if (diag != null)//и проверяем - если данное состояние имеет под собой какой-то диагноз тогда...
                    {
                        Diagnos analogLayerDiag = _diagnosis.Find(d => d.layer == diag.layer);//...проверяем есть ли среди ранее добавленных в список диагнозов(если этот цикл идет уже не первый раз) такие диагнозы у которых совпадает слой с обрабатываемым диагнозом 
                        if (analogLayerDiag == null)//если с таким же слоем диагнозов нет...
                        {
                            _diagnosis.Add(diag);//...добавляем диагноз в список лиагнозов зуба
                        }
                        else// иначе если есть уже диагноз с таким же слоем...
                        {
                            if (analogLayerDiag.majority > diag.majority)//...проверяем перекроет ли новый диагноз по своей важности ранее добавленный
                            {
                                _diagnosis.Remove(analogLayerDiag);//если перекрывает то удаляем старый диагноз
                                _diagnosis.Add(diag);//и добавляем новый
                            }
                            //если не перекрывает тогда оставляем тот же диагноз из этого слоя, что был раньше
                        }
                    }
                    
                }
                






                //    List<diag> diagOfFace = new List<diag>();
                //    foreach (Condition cond in face.GetConditionsOfFace())
                //    {

                //        string diagToParse= "";
                //        if (cond.NameOfIll == Condition.conditionOfFace.car && cond.Depth == Condition.DepthOfCondition.pov) diagToParse += cond.Depth.ToString() + '_';
                //        diagToParse += cond.NameOfIll.ToString();
                //        if(!diagOfFace.Contains((diag) Enum.Parse(typeof (diag),diagToParse)))
                //        {
                //            diagOfFace.Add((diag)Enum.Parse(typeof(diag), diagToParse));
                //        }
                //    }

                //    if (diagOfFace.Contains(diag.defect) && diagOfFace.Contains(diag.plomb))
                //    {
                //        diagOfFace.Remove(diag.plomb);
                //        diagOfFace.Remove(diag.defect);
                //        diagOfFace.Add(diag.plombDef);
                //        if (diagOfFace.Contains(diag.defect)) diagOfFace.Remove(diag.defect);
                //    }
                //    if (diagOfFace.Contains(diag.car) && diagOfFace.Contains(diag.plomb))
                //    {
                //        diagOfFace.Remove(diag.plomb);
                //        diagOfFace.Remove(diag.car);
                //        diagOfFace.Add(diag.plombCar);
                //        if (diagOfFace.Contains(diag.defect)) diagOfFace.Remove(diag.defect);
                //    }
                //    if (diagOfFace.Contains(diag.plombDef) && diagOfFace.Contains(diag.car))
                //    {
                //        diagOfFace.Remove(diag.plombDef);
                //        diagOfFace.Remove(diag.car);
                //        diagOfFace.Add(diag.plombDefCar);
                //        if (diagOfFace.Contains(diag.defect)) diagOfFace.Remove(diag.defect);
                //    }
                //    if (diagOfFace.Contains(diag.contact) && diagOfFace.Contains(diag.car))
                //    {
                //        diagOfFace.Remove(diag.car);
                //        diagOfFace.Remove(diag.contact);
                //        diagOfFace.Add(diag.carCont);
                //        if (diagOfFace.Contains(diag.defect)) diagOfFace.Remove(diag.defect);
                //        if (diagOfFace.Contains(diag.plomb)) diagOfFace.Remove(diag.plomb);
                //    }
                //    if (diagOfFace.Contains(diag.defect) && diagOfFace.Contains(diag.car))
                //    {
                //        diagOfFace.Remove(diag.defect);



                //    }
                //    if (diagOfFace.Contains(diag.contact) && diagOfFace.Contains(diag.plomb))
                //    {
                //        diagOfFace.Remove(diag.plomb);
                //        diagOfFace.Remove(diag.contact);
                //        diagOfFace.Add(diag.plombCont);
                //        if (diagOfFace.Contains(diag.defect)) diagOfFace.Remove(diag.defect);
                //    }



                //    foreach (diag diagnos in diagOfFace)
                //    {
                //        if (!_diagnosis.Contains( diagnos))
                //        {
                //            _diagnosis.Add(diagnos);
                //        }
                //    }

                //}
                //if (_diagnosis.Contains(diag.car) && _diagnosis.Contains(diag.pov_car)) 
                //    _diagnosis.Remove(diag.pov_car);



                //if (_diagnosis.Contains(diag.car) && _diagnosis.Contains(diag.plomb)) 
                //    _diagnosis.Remove(diag.plomb);


                //return _diagnosis;
            
            
            }//end of foreach
            return _diagnosis;
        }//end of GetDiagnosisOfFace


        bool _distapapil;
        bool _medipapil;
        byte _podvizhnost;
        byte _pretreatment;
        byte _ruined;
        byte _polostVskrita;
        byte _percussion;
        byte _tempTest;
        byte _mucosa;
        byte _otechnost;
        byte _eod;
        bool _front;
        #endregion

        #region constructors
        public Tooth()
        {
           
        }
        public Tooth(byte numbOfTeeth)
        {
            number = numbOfTeeth;
        }
        public Tooth(Tooth copyTooth,byte newNumberOfTooth)
        {
            number = newNumberOfTooth;
            foreach (connect con in copyTooth.Connections)
            {
                SwitchConnection(con);
            }
            foreach (Face faceCopyed in copyTooth._facesOfTeeth)
            {
                this.AddFace(faceCopyed.Copy(), false);
            }

            foreach (KeyValuePair<string, List<connect>> KvP in copyTooth._connectDictionary)
            {
                List<connect> copyCon = new List<connect>();
                copyCon.AddRange(KvP.Value);
                _connectDictionary.Add(KvP.Key, copyCon);
            }
       

            _diagnosis = copyTooth._diagnosis;
            podv = copyTooth.podv;
            pretreat = copyTooth.pretreat;
            polost = copyTooth.polost;
            percus = copyTooth.percus;
            termotest = copyTooth.termotest;
            otek = copyTooth.otek;
            distpapil = copyTooth.distpapil;
            medpapil = copyTooth.medpapil;
            Treat.Copy(copyTooth.Treat);

        }
        public Tooth(Tooth copyTooth)
        {
            number = copyTooth.number;
            foreach (connect con in copyTooth.Connections)
            {
                SwitchConnection(con);
            }
            foreach (Face faceCopyed in copyTooth._facesOfTeeth)
            {
                this.AddFace(faceCopyed.Copy(),false);
            }


            foreach (KeyValuePair<string, List<connect>> KvP in copyTooth._connectDictionary)
            {
                List<connect> copyCon = new List<connect>();
                copyCon.AddRange(KvP.Value);
                _connectDictionary.Add(KvP.Key, copyCon);
            }
     


            _diagnosis = copyTooth._diagnosis;
            podv = copyTooth.podv;
            pretreat = copyTooth.pretreat;
            polost = copyTooth.polost;
            percus = copyTooth.percus;
            termotest = copyTooth.termotest;
            otek = copyTooth.otek;
            distpapil = copyTooth.distpapil;
            medpapil = copyTooth.medpapil;
            Treat.Copy(  copyTooth.Treat);

        }
        #endregion

        #region properties
        public byte ruin
        {
            get
            {
                if (_ruined <= 3 && _ruined >= 0) return _ruined;
                else return 0;
            }
            set
            {
                if (value >= 0 && value <= 3) _ruined = value;
                else _ruined = 0;
            }
        }
        public bool medpapil
        {
            get
            {
                return _medipapil;
            }
              
            set
            {
               
               _medipapil = value;
                
            }

        }
        public bool distpapil
        {
            get
            {
               return _distapapil;
               
            }
            set
            {
               _distapapil = value;
              
            }

        }


        public List<connect> Connections
        {
            get { return _connections; }
            //set { _connections = value; }
        }
        public bool isFront
        {
            get
            {
                if (numberOfTeeth % 10 > 0 && numberOfTeeth % 10 < 4)
                    return true;
                else return false;
            }
        }//свойство передний ли зуб
        public string kvadrant
        {
            get
            {

                if (kvadrantNumb == 1 || kvadrantNumb == 5) return "верхней челюсти справа";
                else if (kvadrantNumb == 2 || kvadrantNumb == 6) return "верхней челюсти слева";
                else if (kvadrantNumb == 3 || kvadrantNumb == 7) return "нижней челюсти слева";
                else if (kvadrantNumb == 4 || kvadrantNumb == 8) return "нижней челюсти справа";
                else return " ??? челюсти ??? ";
            }
        } // свойство текст квадранта
        public byte kvadrantNumb
        {
            get
            {
               
                    if ((numberOfTeeth - numberOfTeeth % 10) / 10 == 1 || (numberOfTeeth - numberOfTeeth % 10) / 10 == 5) return 1;
                    else if ((numberOfTeeth - numberOfTeeth % 10) / 10 == 2 || (numberOfTeeth - numberOfTeeth % 10) / 10 == 6) return 2;
                    else if ((numberOfTeeth - numberOfTeeth % 10) / 10 == 3 || (numberOfTeeth - numberOfTeeth % 10) / 10 == 7) return 3;
                    else if ((numberOfTeeth - numberOfTeeth % 10) / 10 == 4 || (numberOfTeeth - numberOfTeeth % 10) / 10 == 8) return 4;
                    else return 0;

            }



        }// свойство номер квадранта - определяется по номеру зуба - равно 0 если номер зуба не определен
        public byte number //свойство номер зуба - цифр всегда две, первая цифра может быть от 1 до 8, вторая цифра от 1 до 8 во взрослом прикусе(первая цифра 1-4), и от 1 до 5 в дестком(первая цифра 5-8)
        {
            get
            {
                if (((int)Math.Log10(numberOfTeeth) + 1) == 2)//проверяем имеет ли номер зуба две цифры
                {
                    if (numberOfTeeth >= 11 && numberOfTeeth <= 48)//проверяем входит ли зуб в диапозон взрослых зубов
                    {
                        if (numberOfTeeth % 10 >= 1 && numberOfTeeth % 10 <= 8)//проверяем не имеет ли зуб вторую цифру меньше 1 или больше 8
                            return numberOfTeeth;
                        else return 11;
                    }
                    else if (numberOfTeeth >= 51 && numberOfTeeth <= 85)//проверяем входит ли зуба в диапозон детских зубов
                    {
                        if (numberOfTeeth % 10 >= 1 && numberOfTeeth % 10 <= 5)//проверяем не имеет ли зуб вторую цифру меньше 1 и больше 5 при детском прикусе
                            return numberOfTeeth;
                        else return 51;
                    }
                    else return 11;
                }
                else return 0 
                    ;// во всех случаях неправильного ввода номера зуба возращается значение 11 зуба
            }
            set//тоже самое только наоборот с сеттером
            {

                if (((int)Math.Log10(value) + 1) == 2)
                {
                    if (value >= 11 && value <= 48)
                    {
                        if (value % 10 >= 1 && value % 10 <= 8)
                            numberOfTeeth = value;
                        else numberOfTeeth = 11;
                    }
                    else if (value >= 51 && value <= 85)
                    {
                        if (value % 10 >= 1 && value % 10 <= 5)
                            numberOfTeeth = value;
                        else numberOfTeeth = 51;
                    }
                    else numberOfTeeth = 11;
                }
                else numberOfTeeth = 11;

            }
        }

         //Afficted properties
        public byte podv//свойство подвижности зуба - если 0 то не пишется вообще, остальное до 3 -степени подвижности
        {
            get
            {
                if (_podvizhnost <= 2 && _podvizhnost >= 0) return _podvizhnost;
                else return 0;
            }
            set
            {
                if (value >= 0 && value <= 2) _podvizhnost = value;
                else _podvizhnost = 0;
            }
        }
        public byte pretreat//свойство ранее лечен - 0 - не лечен, 1- по поводу неосложненного кариеса, 2 - по поводу осложненного кариеса
        {
            get
            {
                
                if (_pretreatment >= 0 && _pretreatment <= 2) return _pretreatment;
                else return 0;
            }
            set
            {
                if (value >= 0 && value <= 2) _pretreatment = value;
                else _pretreatment = 0;

            }
        }
        public byte polost//свойство вскрыта ли полость зуба, 0 - не пишется не вскрыта, 1 - вскрыта в одной точке, 2- вскрыта в двух точках
        {
            get
            {
                if (_polostVskrita <= 2 && _polostVskrita >= 0)
                    return _polostVskrita;
                else return 0;

            }
            set
            {
                if (value <= 2 && value >= 0) _polostVskrita = value;
                else _polostVskrita = 0;
            }

        }
        public byte percus //свойство перкуссия - 0 - отрицательная, 1 - слабоболезненная, 2 - болезненная
        {
            get
            {
                if (_percussion >= 0 && _percussion <= 2) return _percussion;
                else return 0;
            }
            set
            {
                if (value >= 0 && value <= 2) _percussion = value;
                else _percussion = 0;

            }
        }
        public byte termotest//свойство температурный тест - 0 - отрицательный, 1-быстропроходящая боль, 2 - долгонепроходящая
        {
            get
            {
                if (_tempTest >= 0 && _tempTest <= 2) return _tempTest;
                else return 0;
            }
            set
            {
                if (value >= 0 && value <= 2) _tempTest = value;
                else _tempTest = 0;

            }
        }
        public byte otek// свойство отек - 0 - отсутсвует, 1- отек маргинальной десны,2 - отек маргинальной и межзубных сосочков, 3 - отек переходной складки, 4 - отек переходной и коллатеральный магких тканей щеки
        {
            get
            {
                if (_otechnost >= 0 && _otechnost <= 4) return _otechnost;
                else return 0;
            }
            set
            {
                if (value >= 0 && value <= 4) _otechnost = value;
                else _otechnost = 0;

            }
        }

        public byte mucosa
        {
            get
            {
                if (_mucosa >= 0 && _mucosa <= 4) return _mucosa;
                else return 0;
            }
            set
            {
                if (value >= 0 && value <= 4) _mucosa = value;
                else _mucosa = 0;

            }
        }
       
        public byte eod
        {
            get
            {
                return _eod;
            }
            set {
                _eod = value;
             }

        }

         void ResetToothProperties()
         {
             podv = 0;
             pretreat = 0;
             polost = 0;
             percus = 0;
             termotest = 0;
             otek = 0;
             eod = 0;
         }
        #endregion

        #region methods

        #region FaceMethods

        /// <summary>
        /// Получить поверхность по имени поверхности.
        /// </summary>
        /// <param name="faceNamed">Имя поверхности из списка имен.</param>
        /// <param name="createNew">Создавать и добавлять ли поверхность в список поверхностей зуба, если таковой еще нет.</param>
        /// <returns>Может возвращать NULL в случае если createNew в состоянии false - если такой поверхности нет у зуба, то он ее не создает и возвращает NULL.</returns>
        /// 
        public Face GetFace(Face.faceSide faceNamed, bool createNew)
        {
            foreach (Face fc in _facesOfTeeth)
            {
                if (fc.faceName == faceNamed) return fc;
            }
            if (createNew)
            {
                Face newFace = new Face();
                newFace.faceName = faceNamed;
                AddFace(newFace, false);
                return newFace;
            }
            else return null;
        }
         /// <summary>
         /// Получить копию поверхности
         /// </summary>
         /// <param name="faceNamed">Имя поверхности которую скопировать</param>
         /// <param name="createNew">Создать ли новую если такой поверхности еще нет у зуба</param>
         /// <returns>Возвращает новую поверхность, либо null в случае если не было отмечено создавать новую поверхность и у зуба еще нет такой поверхности.</returns>
        public Face GetCopyedFace(Face.faceSide faceNamed, bool createNew)
        {
            foreach (Face fc in _facesOfTeeth)
            {
                if (fc.faceName == faceNamed) return fc.Copy();
            }
            if (createNew)
            {
                Face newFace = new Face();
                newFace.faceName = faceNamed;
                AddFace(newFace, false);
                return newFace;
            }
            else return null;
        }

         /// <summary>
         /// Возвращает массив всех созданных поверхностей зуба.
         /// </summary>
         /// <returns>Все поверхности зуба.</returns>
        public Face[] GetAllFaces()
        {
            Face[] faces = new Face[_facesOfTeeth.Count];
            int i = 0;
            foreach (Face face in _facesOfTeeth)
            {
                faces[i] = face;
                i++;
            }
            return faces;
        }
        /// <summary>
        /// Метод добавления поверхности в список
        /// </summary>
        /// <param name="face">Поверхность которую добавить</param>
        /// <param name="changeOld">Заменять ли старую поверхность на новую при совпадении имен</param>
        /// <returns>В случае отсутсвия совпадений и добавления поверхности как новой в список - вовзращает true, в случае замены поверхности - false.</returns>
        public bool AddFace(Face face, bool changeOld)
        {
            Face tempFace = face.Copy();

            if (kvadrantNumb == 1 || kvadrantNumb == 2)
            {
                if (face.faceName == Face.faceSide.lingual)
                {
                    tempFace.faceName = Face.faceSide.palatinal;
                }
            }
            else if (kvadrantNumb == 3 || kvadrantNumb == 4)
            {
                if (face.faceName == Face.faceSide.palatinal)
                {
                    tempFace.faceName = Face.faceSide.lingual;
                }
            }

            if (isFront)
            {
                if (face.faceName == Face.faceSide.okklusion)
                {
                    tempFace.faceName = Face.faceSide.edge;
                }
            }
            else
            {
                if (face.faceName == Face.faceSide.edge)
                {
                    tempFace.faceName = Face.faceSide.okklusion;
                }
            }

            int indexer = 0;
            foreach (Face faceInList in _facesOfTeeth)
            {
                if (faceInList.faceName == face.faceName || faceInList.faceName == tempFace.faceName)
                {
                    if (changeOld)
                    {
                        _facesOfTeeth[indexer] = tempFace;
                        ApplyAllAffictions();
                        return false;
                    }
                    else
                    {
                        _facesOfTeeth[indexer].AddConditionsFromFace(tempFace, true);
                        ApplyAllAffictions();
                        return false;
                    }

                }
                else
                {
                    indexer++;
                }

            }

            _facesOfTeeth.Add(tempFace);
            ApplyAllAffictions();
            return true;

        }

        #region Connections Methods
        /// <summary>
        /// Соединяет и разъединяет поверхности по типу соединения.
        /// </summary>
        /// <param name="con">Соединение из enum, которое содержит две буквы - первые буквы соединяемых поверхностей</param>
        /// <returns>True - если переключение состояния соединения прошло успешно.</returns>
        public bool SwitchConnection(connect con)
        {
            if (!_connections.Contains(con))
            {
                _connections.Add(con);

                Face firstFaceToConnect = _facesOfTeeth.Find(f => f.faceName == _GetFaceNameFromChar(con.ToString()[0]));
                if (firstFaceToConnect == null)
                {
                    firstFaceToConnect = new Face();
                    firstFaceToConnect.faceName = _GetFaceNameFromChar(con.ToString()[0]);
                    _facesOfTeeth.Add(firstFaceToConnect);
                }

                Face secondFaceToConnect = _facesOfTeeth.Find(f => f.faceName == _GetFaceNameFromChar(con.ToString()[1]));
                if (secondFaceToConnect == null)
                {
                    secondFaceToConnect = new Face();
                    secondFaceToConnect.faceName = _GetFaceNameFromChar(con.ToString()[1]);
                    _facesOfTeeth.Add(secondFaceToConnect);
                }

                return _connectFaces(firstFaceToConnect, secondFaceToConnect);


            }
            else
            {
                _connections.Remove(con);

                Face firstFaceToConnect = _facesOfTeeth.Find(f => f.faceName == _GetFaceNameFromChar(con.ToString()[0]));
                Face secondFaceToConnect = _facesOfTeeth.Find(f => f.faceName == _GetFaceNameFromChar(con.ToString()[1]));

                return _disconnectFaces(firstFaceToConnect, secondFaceToConnect);

            }

        }
        
         /// <summary>
         /// Возвращает имя поверхности в зависимости от буквы - используется внутри класса для осуществления соединения поверхностей.
         /// </summary>
         /// <param name="f">Буква по которой определять поверхность</param>
         /// <returns>Имя поверхности из enum</returns>
        Face.faceSide _GetFaceNameFromChar(char f)
        {

            switch (f)//проверяем имя чекбокса (чекбокс отлавливается еще на событии открытия меню) на котором кликнули и по имени выбираем какую поверхность будем менять(диагноз выставлять)
            {
                case 'V': return Face.faceSide.vestibular;//у каждой поверхности (отдельный класс поверхностей Faces), есть поле называемое Имя - оно является типом данных enum faceSide

                case 'M': return Face.faceSide.medial;

                case 'D': return Face.faceSide.distal;

                case 'C': return Face.faceSide.cervical;
                case 'O':
                    if (this.isFront) return Face.faceSide.edge;//если зуб с которым сейчас работаем передний то окклюзионная поверхность меняется на режущий край
                    else return Face.faceSide.okklusion;

                case 'N': if (this.kvadrantNumb == 1 || this.kvadrantNumb == 2) return Face.faceSide.palatinal;//если же зуб верхний - тогда оральную поверхность называем небной, а нижние зубы -язычной
                    else return Face.faceSide.lingual;

                default: return Face.faceSide.okklusion;

            }
        }


        char _GetFaceCharFromName(Face.faceSide fc)
        {

            switch (fc)//проверяем имя чекбокса (чекбокс отлавливается еще на событии открытия меню) на котором кликнули и по имени выбираем какую поверхность будем менять(диагноз выставлять)
            {
                case Face.faceSide.vestibular: return 'V';//у каждой поверхности (отдельный класс поверхностей Faces), есть поле называемое Имя - оно является типом данных enum faceSide

                case Face.faceSide.medial: return 'M';

                case Face.faceSide.distal: return'D' ;

                case Face.faceSide.edge: return 'O';

                case Face.faceSide.okklusion: return 'O';
                case Face.faceSide.cervical: return 'C';


                case Face.faceSide.palatinal: return 'N';

                case Face.faceSide.lingual: return 'N';

                default: return 'O';

            }

        }
        connect _GetConnectionFromFaces(Face firstFace, Face secondface)
        {
            string nameOfCon = ""+_GetFaceCharFromName(firstFace.faceName) + _GetFaceCharFromName(secondface.faceName);
            connect con = (Tooth.connect)Enum.Parse(typeof(Tooth.connect), nameOfCon  );
            return con;
        }
        List<connect> _GetAvealableConnectionsForFace(Face fc)
        {
            connect[] conArray = (connect[])Enum.GetValues(typeof(connect));

            List<connect> conList = conArray.Where(c => _GetFacesFromConnection(c).ToList().Contains(fc)).ToList();

            return conList;
        }
         
         Face[] _GetFacesFromConnection(connect con)
        {
            Face[] faces = new Face[2];

            faces[0] =GetFace( _GetFaceNameFromChar(con.ToString()[0]),false);

            faces[1] =GetFace( _GetFaceNameFromChar(con.ToString()[1]),false);

            return faces;

        }

         /// <summary>
         /// Внутренний метод соединяющий поверхности.
         /// </summary>
         /// <param name="firstFace">Первая поверхность</param>
         /// <param name="secondFace">Вторая поверхность</param>
         /// <returns>True - если соединение прошло успешно.</returns>
        bool _connectFaces(Face firstFace, Face secondFace)
        {
            connect con = _GetConnectionFromFaces(firstFace, secondFace);

            foreach (Condition cond in GetConditionsOfConnection(con,false))
            {
                _connectCondition(cond.Name, con);
            }

            return firstFace.AddConnection(secondFace) | secondFace.AddConnection(firstFace);
        }

        /// <summary>
        /// Внутренний метод рассоединяющий поверхности.
        /// </summary>
        /// <param name="firstFace">Первая поверхность</param>
        /// <param name="secondFace">Вторая поверхность</param>
        /// <returns>True - если рассоединение прошло успешно.</returns>
        bool _disconnectFaces(Face firstFace, Face secondFace)
        {

            connect con = _GetConnectionFromFaces(firstFace, secondFace);

            foreach (Condition cond in GetConditionsOfConnection(con,false))
            {
                _disconnectCondition(cond.Name, con);
            }
            return firstFace.RemoveConnection(secondFace) | secondFace.RemoveConnection(firstFace);
        }
         
        bool _connectCondition(string cond, connect con)
        {
            if (GetConditionsOfConnection(con,false).Find(c => c.Name == cond) != null)
            {
                if (_connectDictionary.ContainsKey(cond))
                {
                    if (_connectDictionary[cond] != null)
                    {
                        if (!_connectDictionary[cond].Contains(con))
                        {
                            _connectDictionary[cond].Add(con);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        _connectDictionary.Add(cond, new List<connect>() { con });
                        return true;
                    }
                }
                else
                {
                    _connectDictionary.Add(cond, new List<connect>() { con });
                    return true;
                }
            }
            return false;

        }

        bool _disconnectCondition(string cond, connect con)
        {
            if (GetConditionsOfConnection(con,false).Find(c => c.Name == cond) != null)
            {
                if (_connectDictionary.ContainsKey(cond))
                {
                    if (_connectDictionary[cond] != null)
                    {
                        if (_connectDictionary[cond].Contains(con))
                        {
                            _connectDictionary[cond].Remove(con);
                            return true;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        _connectDictionary.Add(cond, new List<connect>());
                        return true;
                    }
                }
                else
                {
                    _connectDictionary.Add(cond, new List<connect>());
                    return true;
                }
            }
            return false;

        }

        public bool SwitchConectionsOfCondition(string cond, connect con)
        {
            if (_connectDictionary.ContainsKey(cond))
            {
                if (_connectDictionary[cond].Contains(con))
                {
                    _connectDictionary[cond].Remove(con);

                    RefreshConnections();
                    return false;
                }
                else
                {
                    _connectDictionary[cond].Add(con);
                    if (!Connections.Contains(con)) SwitchConnection(con);
                    RefreshConnections();
                    return true;
                }
            }
            else
            {
                if (!Connections.Contains(con))
                {
                    _connectDictionary.Add(cond, new List<connect>() { con });
                    SwitchConnection(con);
                    RefreshConnections();
                    return true;
                }
                else
                {
                    _connectDictionary.Add(cond, new List<connect>() { con });
                    RefreshConnections();
                    return true;

                }

            }


        }

        List<Face> _GetFacesContainsCondition(Condition cond)
        {
            return GetAllFaces().Where(f => f.GetConditionsOfFace().Contains(cond)).ToList();
        }
        List<Face> _GetFacesContainsCondition(string cond)
        {
            return GetAllFaces().Where(f => f.GetConditionsOfFace().Where(c=>c.Name ==cond).ToList().Count>0).ToList();
        }
        List<Condition> _GetConditionsConnectedToFace(Face fc)
        {

            List<Condition> condiList = new List<Condition>();

            foreach(KeyValuePair<Condition, List<List<Face>>> KvP in condConnectBlocksDictionary)
            {
                if(KvP.Value.Find(f=>f.ToList().Contains(fc))!=null)
                {
                    if(!condiList.Contains(KvP.Key))
                    {
                        condiList.Add(KvP.Key);
                    }
                }

            }

            return condiList;
               //condConnectBlocksDictionary.Keys.Where(k => condConnectBlocksDictionary[k].Contains(
               //Contains(fb => (fb.ToList()).Contains(fc)));
        }
        public List<Condition> GetConditionsOfConnection(connect con,bool chainConnection)
        {
            Face firstFaceOfConnect = _facesOfTeeth.Find(f => f.faceName == _GetFaceNameFromChar(con.ToString()[0]));
            Face secondFaceOfConnect = _facesOfTeeth.Find(f => f.faceName == _GetFaceNameFromChar(con.ToString()[1]));

            List<Condition> condiList = new List<Condition>();
            if (firstFaceOfConnect != null)
            {
                foreach (Condition cond in firstFaceOfConnect.GetConditionsOfFace())
                {
                    if (!condiList.Contains(cond))
                        condiList.Add(cond);
                }

                if(chainConnection)
                    foreach (Condition cond in _GetConditionsConnectedToFace(firstFaceOfConnect))
                {
                    if (!condiList.Contains(cond))
                        condiList.Add(cond);
                }
            }

            if (secondFaceOfConnect != null)
            {
                foreach (Condition cond in secondFaceOfConnect.GetConditionsOfFace())
                {
                    if (!condiList.Contains(cond))
                        condiList.Add(cond);
                }
                if (chainConnection)
                foreach (Condition cond in _GetConditionsConnectedToFace(secondFaceOfConnect))
                {
                    if (!condiList.Contains(cond))
                        condiList.Add(cond);
                }

            }
            return condiList;

        }


       public  List<connect> GetConnectionsOfCondition(string cond)
        {

            List<connect> ddl = new List<connect>();
            _connectDictionary.TryGetValue(cond, out ddl);
            return ddl;
        }
       void RefreshConnections()
       {
           _MakeDictionaryOfConditionsNameFaceBlocks();

           for (int i = 0; i < (int)connect.empty; i++)
           {
               if (_connectDictionary.Values.Where(conList => conList.Contains((connect)i)).ToList().Count>0)
               {
                   if (!Connections.Contains((connect)i)) SwitchConnection((connect)i);

               }
               else
               {
                   if (Connections.Contains((connect)i)) SwitchConnection((connect)i);

               }
           }
       }

     
        List<List<Face>> _GetBlocksOfConnectedFacesOfCondition(string cond)
       {




           List<List<Face>> facesBlocks = new List<List<Face>>();




           List<connect> allConnections = GetConnectionsOfCondition(cond);
           if (allConnections != null)

           foreach (connect con in allConnections)
           {
               Face[] twoFaces = _GetFacesFromConnection(con);
               bool first = false;
               bool second = false;
               List<Face> faces = facesBlocks.Find(fb =>
                   (first = fb.Contains(twoFaces[0])) ^ (second = fb.Contains(twoFaces[1]))
                   );
               if (faces != null)
               {
                  
                   faces.Add(twoFaces[first ? 1 : 0]);
                    
               }
               else if(!first&!second)
               {
                   faces = new List<Face>();
                   faces.AddRange(twoFaces);
                  
                   facesBlocks.Add(faces);
               }


           }

           List<Face> facesContainsCond = _GetFacesContainsCondition(cond);

           foreach (Face fc in facesContainsCond)
           {

               if(facesBlocks.Find(fb=>fb.Contains(fc))==null)
               {
                   List<Face> faces = new List<Face>();
                   faces.Add(fc);
                   facesBlocks.Add(faces);
               }
           }





             List<List<Face>> fbToRemove = new List<List<Face>>();
           foreach (List<Face> fb in facesBlocks)
           {
              
               if (
                   fb.Where(f => f.GetConditionFromName(cond)!=null).ToList().Count==0
                   )
               {
                   fbToRemove.Add(fb);
               }

           }
           foreach (List<Face> fb in fbToRemove)
           {

               facesBlocks.Remove(fb);

              
               foreach (Face fc in fb)
               {
                   foreach (connect cn in
                       (List<connect>)_connectDictionary[cond].Where(c => (_GetFacesFromConnection(c).ToList().Contains(fc))).ToList()
                       )
                   {
                    if(_connectDictionary[cond].Contains(cn))
                       _connectDictionary[cond].Remove(cn);

                   }
               }
              
           }
        

          
           return facesBlocks;
       }

        public Dictionary<Condition,  List<List<Face>>> condConnectBlocksDictionary
        {
            get
            {
               
                    _MakeDictionaryOfConditionsFaceBlocks();
                
                return _condConnectBlocksDictionary;
            }
        }

       public Dictionary<string,  List<List<Face>>> condNameConnectBlocksDictionary
       {
           get
           {
              
                   _MakeDictionaryOfConditionsNameFaceBlocks();
               
               return _condNameConnectBlocksDictionary;
           }
       }

       
       void _MakeDictionaryOfConditionsNameFaceBlocks()
       {

           _condNameConnectBlocksDictionary = new Dictionary<string, List<List<Face>>>();
           foreach (Condition cond in GetConditionsOfTooth())
           {
               _condNameConnectBlocksDictionary.Add(cond.Name, _GetBlocksOfConnectedFacesOfCondition(cond.Name));
           }


       }

       void _MakeDictionaryOfConditionsFaceBlocks()
       {
           _condConnectBlocksDictionary = new Dictionary<Condition, List<List<Face>>>();
           foreach (KeyValuePair<string,  List<List<Face>>> KvP in condNameConnectBlocksDictionary)
           {
               
               foreach (List<Face> fcBlock in KvP.Value)
               {
                   List<Face> fcsContainsCondition = (fcBlock.Where(face => face.GetConditionFromName(KvP.Key) != null)).ToList();
                   Condition.DepthOfCondition maximumDepth = fcsContainsCondition.Max(f => f.GetConditionFromName(KvP.Key).Depth);//находим максимальную глубину поражения среди всех поверхностей в блоке
                   Condition cond = fcsContainsCondition.First(f => f.GetConditionFromName(KvP.Key).Depth == maximumDepth).GetConditionFromName(KvP.Key);//среди всех поверхностей блока находим такую на которой есть поражение с максимальной найденной глубиной, и это состояние присуждаем к искомому самому глубокому состоянию среди всех в данном блоке.
                Condition keyCond = _condConnectBlocksDictionary.Keys.ToList().Find(key=>key==cond);
                   if (keyCond==null)
                       _condConnectBlocksDictionary.Add(cond, new  List<List<Face>> { fcBlock });
                   else
                   {
                       _condConnectBlocksDictionary[keyCond].Add(fcBlock);
                   }

               }

           }


       }
       public List<Face> GetConnectedFacesOfCondition(string cond)
       {
           List<Face> faces = new List<Face>();
           
           foreach (connect con in GetConnectionsOfCondition(cond))
           {
               foreach (Face fc in _GetFacesFromConnection(con))
               {
                   if (!faces.Contains(fc)) faces.Add(fc);
               }
           }
           return faces;
       }
      
       
        #endregion


        #endregion


        #region tooth methods
        /// <summary>
         /// Получить самую максимальную глубину поражения из всех заболеваний что есть на зубе.
         /// </summary>
         /// <returns>Максимальная глубина поражения.</returns>
        public Condition.DepthOfCondition GetToothIllDepth()
        {
            Condition.DepthOfCondition glub = new Condition.DepthOfCondition();
            foreach (Face fc in _facesOfTeeth)
            {

                foreach (Condition ill in fc.GetConditionsOfFace())
                {

                    if (glub < ill.Depth) glub = ill.Depth;

                }

            }
            return glub;
        }


     /// <summary>
     /// Копирует и вовзращает новый зуб меняя только его номер.
     /// </summary>
     /// <param name="newNumberOfTooth">Новый номер для копии зуба.</param>
     /// <returns>Копию зуба с новым номером.</returns>
        public Tooth CopyWithNewNumber(byte newNumberOfTooth)
        {
            ApplyAllAffictions();
            Tooth newTooth = new Tooth(this, newNumberOfTooth);
            return newTooth;
        }

       /// <summary>
       /// Копирует зуб.
       /// </summary>
       /// <returns>Копию зуба</returns>
        public Tooth Copy()
        {
            ApplyAllAffictions();
            Tooth newTooth = new Tooth(this);
            return newTooth;
        }

         /// <summary>
         /// Применить все влияния состояний поверхностей на данный зуб.
         /// </summary>
        public void ApplyAllAffictions()
        {
            ResetToothProperties();
            foreach (Face fc in _facesOfTeeth)
            {
                foreach (Condition cond in fc.GetConditionsOfFace())
                {
                    cond.ApplyAffictions(this);
                
                }
            }

        }

        #endregion

        #endregion

        #region obsoleteCode

        List<Face> _GetChainOfConnectedFacesFromConnections(List<connect> connectionsToCheck)
        {
            List<Face> faces = new List<Face>();
            List<connect> excludeConnections = new List<connect>();
            if (connectionsToCheck != null)
                foreach (connect con in connectionsToCheck)
                {
                    if (faces.Count == 0)
                    {
                        faces.AddRange(_GetFacesFromConnection(con));//если блок соединенных поверхностей еще пустой, тогда смело добавляем в него обе поверхности от соединения
                    }
                    else
                    {
                        //если блок еще не пустой, тогда проверяем присоединены ли данные поверхности к предыдущим
                        bool connected = false;//флажок присоединены ли
                        Face[] fcArray = _GetFacesFromConnection(con); //берем две поверхности данного соединения, которое проверяем

                        foreach (Face fc in fcArray)//перебираем две поверхности 
                        {
                            if (faces.Contains(fc)) connected = true;//если какая-то из них содержится в списке, значит и это соединение присоединено к остальным
                        }


                        if (connected)//если соединение присоединено, тогда мы проверяем...
                        {
                            foreach (Face fc in fcArray)
                            {
                                if (!faces.Contains(fc)) faces.Add(fc);//если среди этих двух поверхностей от соединения, какая либо отсутствует в списке,то мы ее добавляем. Если же они уже ранее были добавлены в список, тогда дублировать их ни к чему.
                            }
                        }
                        else//если же эти поверхности не соединены с предыдущими, мы скидываем их в список соединений, которые будем проверять после полного составления блока всех соединенных в данную цепочку поверхностей, чтобы не происходило прерывания списка данной цепочки.
                        {
                            excludeConnections.Add(con);

                        }

                    }

                }
            connectionsToCheck = excludeConnections;
            return faces;
        }

        public enum diag { pov_car, car, carCont, klinDef, skol, defect, contact, plomb, plombCont, plombDefCar, plombCar, plombDef, carDepZub, hronGranulemPdt, hronFibrPdt, hronGranulirPdt, hronGranulemPdtObostr, hronGranulirPdtObostr, hronFibrPdtObostr, hronFibrPulp, hronGipertrofPulp, hronGangrenosPulp, hronFibrPulpObostr, ostrSerosPulp, ostrGnoyPulp, osrtOchagPulp, ostrDiffPulp, travmatichPulp, depulpPoOrtopPok, depulpPoOrtodPor, depulpPoParodPok };
        
        ///// <summary>
        ///// Соединяет две поверхности(создает ссылки друг на друга в списках соединений у каждой из поверхностей)
        ///// </summary>
        ///// <param name="faceWhichDragged">Поверхность которую перетаскивали</param>
        ///// <param name="faceOnWhichDroped">Поверхность на которую перетащили</param>
        ///// <returns>true, если соединение удалось, и false, если по каким-то причинам не удалось</returns>
        //public bool ConnectFace(Face faceWhichDragged, Face faceOnWhichDroped)
        //{
        //    bool profit = false;
        //    foreach (Face faceInList in _facesOfTeeth)
        //    {
        //        if (faceInList.faceName == faceWhichDragged.faceName)
        //        {
        //            if (faceWhichDragged.AddConnection(faceOnWhichDroped)) profit = true;
        //            else profit = false;
        //        }
        //        if (faceInList.faceName == faceOnWhichDroped.faceName)
        //        {
        //            if (faceOnWhichDroped.AddConnection(faceWhichDragged)) profit = true;
        //            else profit = false;
        //        }
        //    }


        //    return profit;

        //}

        //public Tooth GetCleanTooth()
        //{
        //    return new Tooth(this.number);
        //}

        //public void RenewPretreatment()
        //{
        //    foreach (Face face in _facesOfTeeth)
        //    {
        //        foreach (Condition ill in face.GetConditionsOfFace())
        //        {
        //            if (ill.NameOfIll == Condition.conditionOfFace.plomb)
        //            {
        //                _pretreatment = 1;
        //            }
        //            else _pretreatment = 0;
        //        }
        //    }
        //}

       #endregion

    }
}
