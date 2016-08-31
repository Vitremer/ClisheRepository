/*Каждое состояние поверхности лечится по своему. 
 * У клиновидного дефекта пишется препарирование поверхности дефекта, у кариеса - кариозной полости, и тд. 
 * Соответственно у каждого дефекта свое лечение состояния - отдельный класс - лечение состояния. 
 * У зуба в общем лечении есть список лечений поверхностей. 
 * последовательность лечения зуба следующая - сначала анестезия - по анестезии зубы разделяются на группы здесь. 
 * препарирование по определенному классу - 
 * Затем следующая часть лечения зуба - это лечение состояний - у кариеса это препарирование , у клиновидного дефекта пескоструйная обработка или препарирование незначительное но без слов кариозной полости.
 * после лечения состояний идет постановка пломб - пломбы уже ставятся в зависимости от того какие были выбраны на данный зуб - если даже на зубе имеется что-то не глубокое и глубокое но было выбрано постановка пломб с подкладкой лечебной уже не описывается неглубокое - пишется по умолчанию подкладка, поэтому тут идет разделение в зависимости от лечения зуба а не состояний поверхностей.
 * затем идет полировка пломб, покрытие фторлаком
 * затем рекомендательные слова





*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class Klishe // класс самого клише который собирает в себе все зубы
    {
        string mainText = "";

        public bool haveRvg;
        public bool haveExam;


        Complaints jal;
        Anamnes anam;
        Objective obj;
        Rvg rvg;
        DSText diag;

        #region fields
        List<Tooth> Tooths = new List<Tooth>();//список зубов которые будут в клише
        public Tooth currentTooth;
        public Complaints jaloby
        {
            get { return jal = new Complaints(this); }
           

        }
        public Anamnes anamnes
        {
            get { return anam = new Anamnes(this); }


        }
        public Objective objective
        {
            get { return obj = new Objective(this); }
        }
        
        public Rvg rentgen{
         get { return rvg = new Rvg(this); }
    }

        public DSText diagnos
        {
            get { return diag = new DSText(this); }
        }
        #endregion

        #region constructors
        public Klishe()
        {
        }
        public Klishe(byte numberTooth)
        {
            AddTooth(numberTooth);
        }
        #endregion

        #region methods
        

        public bool AddTooth(byte numberOfTooth)//метод добавления зуба в список - если зуба с таким номером нет в списке - то возвращает true и меняет зуб на нулевой, если уже есть, то зуб меняется на новый нулевой и возвращает false - в любом случае обнуляет зуб в списке с таким номером
        {
            bool contain = false;
            int indexOfPair = 0;
            foreach (Tooth listTooth in Tooths)//проверяем есть ли совпадения цифр в списке зубов
            {
                if (listTooth.number == numberOfTooth)
                {
                    contain = true;//если совпадение есть тогда ставим флажок что лист содержит такой зуб
                    break;//выходим из цикла при нахождении совпадения
                }
                indexOfPair++;//поиск индекса зуба в списке который совпадает
            }
            if (!contain)//если совпадений нет - добавляем новый зуб
            {
                currentTooth = new Tooth(numberOfTooth);
                Tooths.Add(currentTooth);
                return true;
            }
            else//если совпадение есть меняем зуб в списке по индексу на новый
            {
                Tooths[indexOfPair] = new Tooth(numberOfTooth);
                currentTooth = Tooths[indexOfPair];
                return false;
            }

        }
        public bool AddTooth(Tooth tooth)
        {
            bool contain = false;
            int indexOfPair = 0;
            foreach (Tooth listTooth in Tooths)//проверяем есть ли совпадения цифр в списке зубов
            {
                if (listTooth.number == tooth.number)
                {
                    contain = true;//если совпадение есть тогда ставим флажок что лист содержит такой зуб
                    break;//выходим из цикла при нахождении совпадения
                }
                indexOfPair++;//поиск индекса зуба в списке который совпадает
            }
            if (!contain)//если совпадений нет - добавляем новый зуб
            {
                currentTooth = tooth;
                Tooths.Add(currentTooth);
                return true;
            }
            else//если совпадение есть меняем зуб в списке по индексу на новый
            {
                Tooths[indexOfPair] = tooth;
                currentTooth = Tooths[indexOfPair];
                return false;
            }
        }//перегруженный метод добавления зуба - принимает в аргумент обьект зуб - работает неправильно - всегда пишет совпадение номеров зубов из списка и того что передается в метод - думаю проблема в ссылочном типе Tooth
        public bool RemoveTooth(byte numberOfTooth)
        {

            foreach (Tooth listTooth in Tooths)//проверяем есть ли совпадения цифр в списке зубов
            {
                if (listTooth.number == numberOfTooth)
                {
                    Tooths.Remove(listTooth);
                    return true;
                }

            }
            return false;


        }
        public bool RemoveTooth(Tooth toothDoDel)
        {

            return Tooths.Remove(toothDoDel);

        }
        public string[] GetAllToothsNumbers()
        {
            string[] numbers = new string[Tooths.Count];
            int indexer = 0;
            foreach (Tooth toothFromList in Tooths)
            {
                numbers[indexer] = toothFromList.number.ToString();
                indexer++;
            }
            return numbers;
        }//возвращает массив номеров зубов в списке
        public Tooth[] GetAllTooths()
        {
            Tooth[] toothsToReturn = new Tooth[Tooths.Count];
            int indexer = 0;
            foreach (Tooth toothInList in Tooths)
            {
                toothsToReturn[indexer] = toothInList;
                indexer++;
            }
            return toothsToReturn;
        }
        /// <summary>
        /// Метод получения зуба по его номеру из всего списка зубов подлежащих описанию.
        /// </summary>
        /// <param name="number"> Номер зуба который нужно получить, если таковой есть в списке, иначе добавляется новый и список проверяется снова на совпадение.</param>
        /// <returns>Возвращает нужный зуб.</returns>
        public Tooth GetTooth(byte number)
        {

            foreach (Tooth oneTooth in Tooths)
            {
                if (oneTooth.number == number)
                {
                    return oneTooth;

                }
            }

            return null;
        }
        public string GetText()
        {
            mainText = "";

            mainText += jaloby.GetText() + anamnes.GetText() + objective.GetText();
                if(haveRvg) mainText += rentgen.GetText();
               mainText += diagnos.GetText();
            
            return mainText;
        }
        #endregion

        #region AnalogGroupsMethods
        public List<GroupOfTooth> GetAnalogGroupsFromToothIdentity()
        {
           
            List<GroupOfTooth> groups = new List<GroupOfTooth>();


            
              
            foreach (Tooth tooth in Tooths)
            { 
               bool haveOne = false;
                  foreach (GroupOfTooth group in groups)
                {
                    if (group.ToothsInGroup.Contains(tooth))
                    {
                        
                        haveOne = true;
                        break;
                    }
                }
                if(!haveOne){
                GroupOfTooth group = new GroupOfTooth();
                //foreach (Tooth t in Tooths)
                //{
                //    if (t == tooth)
                //        group.ToothsInGroup.Add(t);
                //}
                group.ToothsInGroup = Tooths.Where(t => t == tooth).ToList();
                groups.Add(group);
                }

            }

              
            return groups;
        }
        public List<GroupOfTooth> GetAnalogGroupsFromPretreat()
        {
            List<GroupOfTooth> groups = new List<GroupOfTooth>();
            foreach (Tooth tooth in Tooths)
            {
                tooth.ApplyAllAffictions();
                bool haveOne = false;
                foreach (GroupOfTooth group in groups)
                {
                    if (group.pretreat == tooth.pretreat)
                    {
                        group.ToothsInGroup.Add(tooth);
                        haveOne = true;
                        break;
                    }
                }

                if (!haveOne)
                {
                    GroupOfTooth newGroup = new GroupOfTooth();
                    newGroup.pretreat = tooth.pretreat;
                    newGroup.ToothsInGroup.Add(tooth);
                    groups.Add(newGroup);
                }
            }

            return groups;

        }
        public List<GroupOfTooth> GetAnalogGroupsFromCondition()
        {
           
            List<GroupOfTooth> groups = new List<GroupOfTooth>();
            foreach (Tooth tooth in Tooths)
            {
                foreach (Condition cond in tooth.GetConditionsOfTooth())
                {
                   
                    bool haveOne = false;
                    foreach (GroupOfTooth group in groups)
                    {

                        if (group.MainCondition.Name == cond.Name)
                        {
                            group.ToothsInGroup.Add(tooth);
                            haveOne = true;
                            break;

                        }

                    }
                    if (!haveOne)
                    {
                        GroupOfTooth newGroup = new GroupOfTooth();
                        newGroup.MainCondition = cond;
                        newGroup.ToothsInGroup.Add(tooth);
                        groups.Add(newGroup);
                    }
                }

            }

            return groups;

           


        }
        public List<GroupOfTooth> GetAnalogGroupsFromDiagnosis()
        {

            List<GroupOfTooth> groups = new List<GroupOfTooth>();
            foreach (Tooth tooth in Tooths)
            {
                foreach (Diagnos ds in tooth.GetDiagnosisOfTooth())
                {

                    bool haveOne = false;
                    foreach (GroupOfTooth group in groups)
                    {

                        if (group.MainDs.identityString == ds.identityString)
                        {
                            group.ToothsInGroup.Add(tooth);
                            haveOne = true;
                            break;

                        }

                    }
                    if (!haveOne)
                    {
                        GroupOfTooth newGroup = new GroupOfTooth();
                        newGroup.MainDs = ds;
                        newGroup.ToothsInGroup.Add(tooth);
                        groups.Add(newGroup);
                    }
                }

            }

            return groups;




        }
         public List<GroupOfTooth> GetAnalogGroupsFromAnestesy()
        {

            List<GroupOfTooth> groups = new List<GroupOfTooth>();
            foreach (Tooth tooth in Tooths)
            {
                

                    bool haveOne = false;
                    foreach (GroupOfTooth group in groups)
                    {

                        if (group.comparer == tooth.Treat.anest)
                        {
                            group.ToothsInGroup.Add(tooth);
                            haveOne = true;
                            break;

                        }

                    }
                    if (!haveOne)
                    {
                        GroupOfTooth newGroup = new GroupOfTooth();
                        newGroup.comparer = tooth.Treat.anest;
                        newGroup.ToothsInGroup.Add(tooth);
                        groups.Add(newGroup);
                    }
                

            }

            return groups;




        }
        public List<GroupOfTooth> GetAnalogGroupsFromTreatment()
        {

            List<GroupOfTooth> groups = new List<GroupOfTooth>();
            foreach (Tooth tooth in Tooths)
            {
                

                    bool haveOne = false;
                    foreach (GroupOfTooth group in groups)
                    {

                        if (group. == ds.identityString)
                        {
                            group.ToothsInGroup.Add(tooth);
                            haveOne = true;
                            break;

                        }

                    }
                    if (!haveOne)
                    {
                        GroupOfTooth newGroup = new GroupOfTooth();
                        newGroup.MainDs = ds;
                        newGroup.ToothsInGroup.Add(tooth);
                        groups.Add(newGroup);
                    }
                

            }

            return groups;




        }

        #endregion


    }
}
