using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace KlisheNamespace
{
    [Serializable]
    class Condition//класс состояний поверхностей 
    {
        #region fields
      /// <summary>
      /// Перечисление возможных глубин у всех поражений поверхностей.
      /// </summary>
        public enum DepthOfCondition { none, pov, sred, glub, giper,pulpitis,periodontal };
       
       /// <summary>
        /// какие могут быть глубины у данного вида поражения 
       /// </summary>
       DepthOfCondition[] _availableDepths;
      
        /// <summary>
        /// возможные поверхности для поражения
        /// </summary>
         List<Face.faceSide> _availableFaces;

        /// <summary>
         /// соотносит глубину поражения и какой для данной глубины поражения данного состояния соответствует диагноз по индексу диагноза - у каждого диагноза есть свой индивидуальный индекс из двух цифр.
      /// </summary>
        Dictionary<DepthOfCondition, int[]> _diagnosisOfDepths = new Dictionary<DepthOfCondition,int[]>();

        /// <summary>
        /// Имя поражения
        /// </summary>
        public string Name;

        /// <summary>
        /// Слой поражения.
        /// </summary>
        public int layer;

        /// <summary>
        /// Слой поражения используемый для расстановки в нужной последовательности в описании поверхностей в Объективно.
        /// </summary>
        public int layerForDiscription;
    

        Dictionary<DepthOfCondition, string> _depthTranslator = new Dictionary<DepthOfCondition, string>() { 
        {DepthOfCondition.none," " },
        {DepthOfCondition.pov,"поверхностный"},
        {DepthOfCondition.sred,"средний"},
        {DepthOfCondition.glub,"глубокий"},
        {DepthOfCondition.giper,"гиперемия пульпы"},
        {DepthOfCondition.pulpitis,"пульпит"},
        {DepthOfCondition.periodontal,"периодонтит"}
        };

        /// <summary>
        /// Описание текстовое самого поражения.
        /// </summary>
        string _description = "";   
        /// <summary>
        /// Словарик с описанием глубин поражения - ключом является глубина, значением - сам текст с описанием глубины поражения - текст глубины поражения прибавляется после основного описания поражения
        /// </summary>
        Dictionary<DepthOfCondition, string> _depthDiscriptions;

        /// <summary>
        /// Описание поражения на снимке, общее для всех глубин.
        /// </summary>
        string _rvgDescription = "";
        /// <summary>
        /// Описание для снимков каждой глубины поражения.
        /// </summary>
         Dictionary<DepthOfCondition, string> _rvgDescriptions;

        /// <summary>
        /// Цвет поражения используемый для раскрашивание кнопки поверхности.
        /// </summary>
        public Color colorOfCondition;

      

        /// <summary>
        /// Текст который нужно заменить в  полном собранном описании чтобы число поражения стало множественным - по порядку через символ '|' пишутся блоки которыми нужно заменить в тексте - в каждом блоке вначале пишется то что нужно заменить в единственном числе, затем через символ '_' - пишется то чем заменить - таким образом пройдясь по тексту описания по порядку и заменив в нужном порядке слова он превращается в текст множественного числа.
        /// </summary>
        string _multiDescription=""; 

        /// <summary>
        /// Глубина данного поражения (частность)
        /// </summary>
        DepthOfCondition _depth;

        /// <summary>
        /// Влияния, которые оказывает состояние на зуб в целом своим наличием - например кариес изменяет ЭОД зуба, как и многие другие состояния. 
        /// </summary>
        Dictionary<DepthOfCondition, List<Affiction>> _toothAffictions = new Dictionary<DepthOfCondition, List<Affiction>>();
        
        /// <summary>
        /// Влияния, которые оказывает состояние на зуб в целом своим наличием - например кариес изменяет ЭОД зуба, как и многие другие состояния. 
        /// </summary>
        public List<Affiction> Affictions

        {
            get { 
                return _toothAffictions[Depth]; 
            }
        }

        #endregion

        #region Constructors

        public Condition(string name)
        {
            this._depth = DepthOfCondition.none;
            this.Name = name;

        }
        public Condition(string name, string objectivily)
        {
            this._depth = DepthOfCondition.none;
            this.Name = name;
            this._description = objectivily;

        }
        public Condition(string name, DepthOfCondition[] availableDepths, string objectivily)
        {
            this._availableDepths = availableDepths;
            this.Name = name;
            this._description = objectivily;

        }

        /// <summary>
        /// Самый полный конструктор
        /// </summary>
        /// <param name="name">Имя состояния (отображается в списке)</param>
        /// <param name="availablesFacesForCond">Поверхности на которых может находится состояние.</param>
        /// <param name="availableDepths">Возможные глубины поражения данным состоянием</param>
        /// <param name="DiagnosisOfDepths">Словарь соотносящий глубину состояния с тем какой диагноз вызывает у зуба данная глубина поражения(диагнозы имеют идентификаторы в виде двух цифр - слой и важность - первая цифра массива INT - слой диагноза(у всех кариесов к примеру слой 0), вторая цифра массива - важность диагноза - чем меньше цифра тем важнее диагноз и тогда собой он перекрывает все другие диагнозы в данном слое)</param>
        /// <param name="descriptionForDepths">Словарь текстового описания состояния при той или иной глубине поражения - для каждой глубины свой текст который будет использован при сборе клише в разделе Объективно.</param>
        /// <param name="objectivily">Общее для всех глубин начало описания - ставится вначале всего текста - например - "кариозная полость" или "клиновидный дефект"</param>
        /// <param name="layerN">Номер слоя состояния.</param>
        /// <param name="layerToDescript">Номер слоя состояния используемый для упорядочивания описания поверхностей в Объективно по мере убывания важности состояния. Сначала описываются пломбы, потом кариозные полости под ними, затем клиновидные дефекты и прочая. </param>
        /// <param name="col">Цвет состояния, в который будет окрашиваться иконка поверхности при наличии на ней данного состояния.</param>
        /// <param name="multyDiscr">Строка содержащая в себе блоки слов необходимых для полного преобразования всего описания состояния в версию множественного числа. Записываются по порядку слова в формате - "слово или фраза в единственном числе"_"слово или фраза во множественном числе"||"следующее слово или фраза в единственном числе"_"следующее слово или фраза во множественном числе" - таким образом метод разделяет всю строку на блоки, пробегается по порядку по всему тексту который был получен для описания состояния, и заменяет по порядку все найденные блоки текста в единственном числе блоками текста во множественном числе. ВНИМАНИЕ! Блоки текста должны быть в том порядке, в котором они встречаются в готовом собранном описании!</param>
        /// <param name="Affictions">Влияния, которые оказывает состояние на зуб в целом своим наличием - например кариес изменяет ЭОД зуба, как и многие другие состояния. </param>
        public Condition(string name,//1
            List<Face.faceSide> availablesFacesForCond,//2
            DepthOfCondition[] availableDepths,//3
            Dictionary<DepthOfCondition,int[]> DiagnosisOfDepths,//4
            Dictionary<DepthOfCondition,string> descriptionForDepths,//5
            string objectivily,//6
            Dictionary<DepthOfCondition,string> rvgDescriptions,//7
            string rvgObjectivly,//8
            int layerN,//9
            int layerToDescript,//10
            Color col,//11
            string multyDiscr,//12
            Dictionary<DepthOfCondition, List<Affiction>> Affictions)//13
        {
            this._availableDepths = availableDepths;
            this.Name = name;
            this._diagnosisOfDepths = DiagnosisOfDepths;
            this._description = objectivily;
            this._rvgDescriptions = rvgDescriptions;
            this._rvgDescription = rvgObjectivly;
            this.layer = layerN;
            this.layerForDiscription = layerToDescript;
            this.colorOfCondition = col;
            this._multiDescription = multyDiscr;
            this._depthDiscriptions = descriptionForDepths;
            this._availableFaces = availablesFacesForCond;
            this._toothAffictions = Affictions;

        }
        /// <summary>
        /// Конструктор в случае если нет описания для снимка.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="availablesFacesForCond"></param>
        /// <param name="availableDepths"></param>
        /// <param name="descriptionForDepths"></param>
        /// <param name="objectivily"></param>
        /// <param name="layerN"></param>
        /// <param name="layerToDescript"></param>
        /// <param name="col"></param>
        /// <param name="multyDiscr"></param>
        /// <param name="Affictions"></param>
        public Condition(string name,//1
         List<Face.faceSide> availablesFacesForCond,//2
         DepthOfCondition[] availableDepths,//3
         Dictionary<DepthOfCondition, string> descriptionForDepths,//4
         string objectivily,//5
         int layerN,//6
         int layerToDescript,//7
         Color col,//8
         string multyDiscr,//9
         Dictionary<DepthOfCondition, List<Affiction>> Affictions)
        {
            this.Name = name;
            this._availableFaces = availablesFacesForCond;
            this._availableDepths = availableDepths;
            this._depthDiscriptions = descriptionForDepths;
            this._description = objectivily;
            this.layer = layerN;
            this.layerForDiscription = layerToDescript;
            this.colorOfCondition = col;
            this._multiDescription = multyDiscr;
            this._toothAffictions = Affictions;

        }//10

        /// <summary>
        /// Конструктор в случае если есть описание для снимка, но нет диагнозов для данного состояния.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="availablesFacesForCond"></param>
        /// <param name="availableDepths"></param>
        /// <param name="descriptionForDepths"></param>
        /// <param name="objectivily"></param>
        /// <param name="rvgDescriptions"></param>
        /// <param name="rvgObjectivly"></param>
        /// <param name="layerN"></param>
        /// <param name="layerToDescript"></param>
        /// <param name="col"></param>
        /// <param name="multyDiscr"></param>
        /// <param name="Affictions"></param>
        public Condition(string name,//1
            List<Face.faceSide> availablesFacesForCond,//2
            DepthOfCondition[] availableDepths,//3
            Dictionary<DepthOfCondition, string> descriptionForDepths,//4
            string objectivily,//5
            Dictionary<DepthOfCondition, string> rvgDescriptions,//6
            string rvgObjectivly,//7
            int layerN,//8
            int layerToDescript,//9
            Color col,//10
            string multyDiscr,//11
            Dictionary<DepthOfCondition, List<Affiction>> Affictions)
        {
            this.Name = name;
            this._availableFaces = availablesFacesForCond;
            this._availableDepths = availableDepths;
            this._depthDiscriptions = descriptionForDepths;
            this._description = objectivily;
            this._rvgDescriptions = rvgDescriptions;
            this._rvgDescription = rvgObjectivly;
            this.layer = layerN;
            this.layerForDiscription = layerToDescript;
            this.colorOfCondition = col;
            this._multiDescription = multyDiscr;
            this._toothAffictions = Affictions;

        }//12


        /// <summary>
        /// Полный но не используемый конструктор.
        /// </summary>
        /// <param name="name">Имя состояния</param>
        /// <param name="availablesFacesForCond">Поверхности на которых может находится состояние</param>
        /// <param name="availableDepths">Возможные глубины поражения для состояния</param>
        /// <param name="DiagnosisOfDepths">Список диагнозов (индексов) соответствующих определенной глубине поражения</param>
        /// <param name="descriptionForDepths">Описания каждой глубины поражения</param>
        /// <param name="objectivily">текст который пишется в Объективно в самом начале и является общим для каждой глубины поражения.</param>
        /// <param name="layerN">Номер слоя поражения</param>
        /// <param name="layerToDescript">Слой поражения для описания(в порядке слоев по возрастанию происходит описание поражений в тексте Объективно)</param>
        /// <param name="col">Цвет поражения используемый для раскраски кнопок поверхностей.</param>
        /// <param name="multyDiscr">Текст необходимый для замены описания поражения в единственном числе на множественный - состоит из пар блоков текста разделенных вертикальной чертой | -каждая пара являет собой текст в единственном числе и через нижнее подчеркивание _ текст во множественном числе. Пары для замены текста расположены в том же порядке в каком они встречаются в тексте описания.</param>
        /// <param name="Affictions">Влияния которые оказывает данное состояние на зуб в целом - например изменяет ЭОД, перкуссию и тому подобное.</param>
        /// <param name="depthTranslator"></param>
        public Condition(string name, //1
            List<Face.faceSide> availablesFacesForCond, //2
            DepthOfCondition[] availableDepths, //3
            Dictionary<DepthOfCondition,int[]> DiagnosisOfDepths, //4
            Dictionary<DepthOfCondition, string> descriptionForDepths, //5
            string objectivily, //6
            int layerN,//7
            int layerToDescript, //8
            Color col, //9
            string multyDiscr, //10
            Dictionary<DepthOfCondition,List<Affiction>> Affictions,//11
            Dictionary<DepthOfCondition, string> depthTranslator)
        {
            this._availableDepths = availableDepths;
            this.Name = name;
            this._diagnosisOfDepths = DiagnosisOfDepths;
            this._description = objectivily;
            this.layer = layerN;
            this.layerForDiscription = layerToDescript;
            this.colorOfCondition = col;
            this._multiDescription = multyDiscr;
            this._depthDiscriptions = descriptionForDepths;
            this._availableFaces = availablesFacesForCond;
            this._toothAffictions = Affictions;
            this._depthTranslator = depthTranslator;

        }//12 


        public Condition(string name,
            DepthOfCondition[] availableDepths,
            string objectivily,
            int layerN,
            int layerToDescript,
            string multyDiscr)
        {
            this._availableDepths = availableDepths;
            this.Name = name;
            this._description = objectivily;
            this.layer = layerN;
            this.layerForDiscription = layerToDescript;
            this._multiDescription = multyDiscr;

        }
       
        #endregion

        #region properties
        public Dictionary<DepthOfCondition, string> depthDiscriptions
        {
            get
            {
                return _depthDiscriptions;
            }
        }
        public Dictionary<DepthOfCondition, string> rvgDiscriptions
        {
            get
            {
                return _rvgDescriptions;
            }
        }
        public DepthOfCondition[] availableDepths
        {
            get
            {
                return _availableDepths;
            }
        }

        public List<Face.faceSide> availableFaces
        {
            get { return _availableFaces; }
        }
        public string multiDiscription
        {
            get
            {
                return _multiDescription;
            }
        }
        public string rvgDescription
        {
            get
            {
                string text = _rvgDescription;
                try
                {
                    text += " " + _rvgDescriptions[Depth];
                }
                catch
                {
                }
                return text;
            }
        }
        public string Description
        {
            get
            {
                string text = _description;
                try
                {
                    text += " " + depthDiscriptions[Depth];
                }
                catch
                {
                }
                return text ;
            }
          
        }

        public Diagnos Diag
        {
            get
            {
                if (_diagnosisOfDepths!=null && _diagnosisOfDepths.Count > 0)//если данное состояние поверхности содержит в себе какие либо диагнозы тогда ищем его
                {
                    int[] DSid = _diagnosisOfDepths[Depth];//получаем идентификатор данной глубины диагноза который состоит из слоя и важности диагноза - первая и вторая цифра массива

                    Diagnos ds = KlisheParams.defaultDiagnosList.FirstOrDefault(d => (d.layer == DSid[0]) && (d.majority == DSid[1])); //из всех диагнозов которые могут быть, по идентификатору ищем тот у которого совпадает слой и важность(глубина)
                    return ds;
                }
                else return null;
            }
        }
        
        public DepthOfCondition Depth
        {
            get
            {
                
                    return _depth;
               
            }
            set { _depth = value; }

        }//свойство глубины заболевания



        #endregion

        #region methods
        void SetDefaultDescriptionForDepths()
        {
            _depthDiscriptions.Add(DepthOfCondition.none, "");
            _depthDiscriptions.Add(DepthOfCondition.pov, "поверхностный");
            _depthDiscriptions.Add(DepthOfCondition.sred, "средний");
            _depthDiscriptions.Add(DepthOfCondition.glub, "глубокий");
            _depthDiscriptions.Add(DepthOfCondition.giper, "гиперемия пульпы");
            _depthDiscriptions.Add(DepthOfCondition.pulpitis, "пульпит");
            _depthDiscriptions.Add(DepthOfCondition.periodontal, "периодонтит");



        }

        public bool SetDepth(string depthName)
        {
           if(availableDepths.Contains( GetDepth(depthName)))
           {
            Depth =   GetDepth(depthName) ;
            return true;
           }
            //foreach (KeyValuePair<DepthOfCondition, string> kvp in depthDiscriptions)
            //{
            //    if (kvp.Key.ToString() == depthName)
            //    {
            //        Depth = kvp.Key;
            //        return true;
            //    }
            //}
            return false;
        }
        public static bool operator ==(Condition firstCond, Condition secondCond)
        {
            if (ReferenceEquals(secondCond, null)) { if (ReferenceEquals(firstCond, null)) return true; else return false; }
               
            if (firstCond.Name != secondCond.Name || firstCond.Depth != secondCond.Depth) return false;
            

            return true;


        }
        public static bool operator !=(Condition firstCond, Condition secondCond)
        {
            if (ReferenceEquals(secondCond, null)) { if (ReferenceEquals(firstCond, null)) return false; else return true; }

            if (firstCond.Name != secondCond.Name || firstCond.Depth != secondCond.Depth) return true;


            return false;


        }
        public DepthOfCondition GetDepth(string dep)
        {
           return _depthTranslator.First(e=> e.Value==dep).Key;
        }
        public string GetDepth(DepthOfCondition dep)
        {
            return _depthTranslator[dep];

        }
        public string GetCurrentDepth()
        {
            return GetDepth(_depth);


        }
        public void ApplyAffictions(Tooth tooth)
        {
            foreach (Affiction aff in Affictions)
            {
                aff.Apply(tooth);
            }
        }

        public Condition Copy()
        {



            Condition cond = new Condition(this.Name, this._availableFaces,this._availableDepths,this._diagnosisOfDepths, this.depthDiscriptions, this._description,this._rvgDescriptions,this._rvgDescription, this.layer,this.layerForDiscription, this.colorOfCondition, this._multiDescription,this._toothAffictions);
            cond.Depth = this.Depth;

            return cond;


        }
      
        #endregion

        #region Obsolete code

        conditionOfFace conditionsOfFace;
        public enum conditionOfFace { car, klinDef, defect, contact, plomb };
        public conditionOfFace NameOfIll
        {
            get { return conditionsOfFace; }
            set { conditionsOfFace = value; }
        }//свойство имени заболевания

        public string GetStringName()
        {
            switch (NameOfIll)
            {


                case conditionOfFace.car: return "кариес";

                case conditionOfFace.contact: return "несостоятельный контакт";

                case conditionOfFace.defect: return "дефект";

                case conditionOfFace.klinDef: return "клиновидный дефект";

                case conditionOfFace.plomb: return "пломба";

                default: return "";

            }

        }

        public void Set(string name)//метод установки имени и глубины заболевания через string
        {
            string[] allDiagnosesInEnum = Enum.GetNames(typeof(conditionOfFace));//все возможные заболевания из enum перечисления диагнозов записываются в массив
            string[] allDepths = Enum.GetNames(typeof(DepthOfCondition));//все возможные глубины записываются в массив
            string[] parts = name.Split('_');//название делится на две либо одну строку(одну если это диагноз "несостоятельный контакт" не имеющий глубины) - первая строка сам диагноз, вторая глубина

            foreach (string diagnosInEnum in allDiagnosesInEnum)//массив диагнозов перебирается по порядку
            {
                if (diagnosInEnum == parts[0])//и проверяется есть ли среди заболеваний, то что мы получили при разрезании строки
                {
                    conditionsOfFace = (conditionOfFace)Enum.Parse(typeof(conditionOfFace), parts[0]);//если есть такое заболевание(существует вообще и совпадает) тогда оно Парсится(переводится) в тип enum, и присуждается имени данного заболевания
                    break;
                }
            }
            if (parts.Length == 2)//если в имени аргумента есть название глубины которое получено при разрезании, тогда ищем какая глубина
            {
                foreach (string glubina in allDepths)//массив глубин также перебирается по порядку
                {
                    if (glubina == parts[1])//и проверяется есть ли среди заболеваний, то что мы получили при разрезании строки
                    {
                        Depth = (DepthOfCondition)Enum.Parse(typeof(DepthOfCondition), parts[1]);//если есть такая глубина(существует вообще и совпадает) тогда оно Парсится(переводится) в тип enum, и присуждается глубине данного заболевания
                        break;
                    }
                }
            }
        }

        //List<diagnosOfFace> diagnosesOfFace = new List<diagnosOfFace>();
        //public void AddDiagnos(diagnosOfFace ds)
        //{
        //    if(!diagnosesOfFace.Contains(ds))
        //    diagnosesOfFace.Add(ds);
        //}

        //public void AddDiagnos(string ds)
        //{
        //    string[] allDiagnosesInEnum = Enum.GetNames(typeof(diagnosOfFace));
        //    foreach (string diagnosInEnum in allDiagnosesInEnum)
        //    {
        //        if (diagnosInEnum == ds)
        //        {
        //            diagnosOfFace currentDs = (diagnosOfFace)Enum.Parse(typeof(diagnosOfFace), ds);

        //        }
        //    }
        //}

        //public void RemoveDiagnos(diagnosOfFace ds)
        //{
        //    diagnosesOfFace.Remove(ds);
        //}
        #endregion


    }

}
