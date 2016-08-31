using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{

    class Face
    {
        #region fields
        public enum faceSide {all, okklusion, medial, distal, palatinal, vestibular, lingual, edge };
        faceSide side;
        List<Face> connections = new List<Face>();//список сообщений с другими поверхностями
        List<Condition> conditionsOfFace = new List<Condition>();
        Tooth _ownerTooth;
        #endregion

        #region constructors

        public Face()
        {

        }
        public Face(Face copyFace)
        {

            side = copyFace.side;
            foreach (Condition illCopyed in copyFace.conditionsOfFace)
            {
                AddCondition(illCopyed.Copy(), false);
            }
            //foreach (Face connect in copyFace.connections)
            //{
            //    AddConnection(connect.Copy());
            //}

        }


        #endregion

        #region properties

        public bool IsEmpty()
        {
            if (connections.Count == 0 && conditionsOfFace.Count == 0) return true;
            else return false;
        }
        public faceSide faceName
        {
            get
            {
                return side;
            }
            set
            {
                side = value;
            }

        }//свойство названия поверхности

        

       
        #endregion

        #region methods
        /// <summary>
        /// Сравнивает две поверхности
        /// </summary>
        /// <param name="firstFace">левая половина сравнения</param>
        /// <param name="secondFace">правая половина сравнения</param>
        /// <returns>Возвращает true если поверхности равны</returns>
        public static bool operator ==(Face firstFace, Face secondFace)
        {
            if (ReferenceEquals(secondFace, null)) { if (ReferenceEquals(firstFace, null)) return true; else return false; }
            if (firstFace.faceName != secondFace.faceName) return false;
         
            
            foreach (Face fcCon in firstFace.connections)
            {
                bool haveOne = false;
                foreach (Face fcCon2 in secondFace.connections)
                {
                    if (fcCon.faceName == fcCon2.faceName)
                    {
                        haveOne = true;
                    }
                }
                if (!haveOne) return false;
          
            }

            if (secondFace.GetConditionsOfFace().Count != firstFace.GetConditionsOfFace().Count)
            {
                return false;
            }
                    
            foreach (Condition cond in secondFace.GetConditionsOfFace())
            {
                bool haveOne = false;
                foreach (Condition cond2 in firstFace.GetConditionsOfFace())
                {
                    if (cond == cond2)
                        haveOne = true;
                }
                if (!haveOne) return false;
            }


            return true;

        }
        /// <summary>
        /// Сравнивает две поверхности
        /// </summary>
        /// <param name="firstFace">левая половина сравнения</param>
        /// <param name="secondFace">правая половина сравнения</param>
        /// <returns>Возвращает true если поверхности не равны</returns>
        public static bool operator !=(Face firstFace, Face secondFace)
        {
            if (ReferenceEquals(secondFace, null)) { if (ReferenceEquals(firstFace, null)) return false; else return true; }//сравниваем каждую поверхность с null и между собой
            if (firstFace.faceName != secondFace.faceName) return true; //сравниваем имена
           
            foreach (Face fcCon in firstFace.connections)//сравниваем соединения с другими поверхностями только по именам поверхностей
            {
                bool haveOne = false;
                foreach (Face fcCon2 in secondFace.connections)
                {
                    if (fcCon.faceName == fcCon2.faceName)
                    {
                        haveOne = true;
                    }
                }
                if (!haveOne) return true;

            }

            if (secondFace.GetConditionsOfFace().Count == firstFace.GetConditionsOfFace().Count)
            {

                foreach (Condition cond in secondFace.GetConditionsOfFace())//сравниваем состояния поверхностей (сравнения так же перегружены)
                {
                    bool haveOne = false;
                    foreach (Condition cond2 in firstFace.GetConditionsOfFace())
                    {
                        if (cond == cond2)
                            haveOne = true;
                    }
                    if (!haveOne) return true;
                }
            }
            return false;


        }

        public List<Condition> GetConditionsOfFace()//метод возвращает лист всех заболеваний данной поверхности(пломбы, кариесы, клиновидные дефекты)
        {
            List<Condition> newIlls = new List<Condition>();
            foreach (Condition copyedIll in conditionsOfFace)
            {
                newIlls.Add(copyedIll.Copy());
            }
            return newIlls;
        }

        public bool AddConnection(Face faceToConnect)
        {
            if (side != faceToConnect.faceName)
            {
                foreach (Face allreadyConnect in connections)
                {
                    if (allreadyConnect.faceName == faceToConnect.faceName)
                        return false;
                }
                connections.Add(faceToConnect);
                return true;
            }
            else return false;

        }
        public bool RemoveConnection(Face faceToUnconnect)
        {
            if (side != faceToUnconnect.faceName)
            {
                foreach (Face allreadyConnect in connections)
                {
                    if (allreadyConnect.faceName == faceToUnconnect.faceName)
                    {
                        connections.Remove(allreadyConnect);
                        //connections = connections.Where(f => f.faceName != faceToUnconnect.faceName).ToList();
                        return true;
                    }
                }
                
                return false;
            }
            else return false;

        }
        ///<summary>Метод добавления заболевания в список заболеваний поверхности. Булевый аргумент отвечает за замену старого диагноза новым при совпадении таковых.</summary>
        ///<param name="ill"> Заболевание которое добавить.</param>
        ///<param name="changeOld"> Менять ли старое заболевание на новое в случае совпадения их имен.</param>
        public void AddCondition(Condition newCond, bool changeOld)
        {

            int indexer = 0;
            foreach (Condition cond in conditionsOfFace)//перебираем все заболевания которые есть у поверхности
            {
                if (cond.layer==newCond.layer)//если заболевание с таким именем уже есть в списке тогда ставим флажок true
                {
                    if (changeOld)
                    { //если заболевание уже есть и стоит флажок менять старые заболевания changeOld, тогда заменяем его
                        conditionsOfFace[indexer] = newCond.Copy();
                    }
                    return;

                }
                indexer++;
            }
            conditionsOfFace.Add(newCond.Copy()); //если заболевания еще нет в списке, тогда добавляем его

        }
        public void SwitchCondition(Condition newCond)
        {

            int indexer = 0;
            foreach (Condition cond in conditionsOfFace)//перебираем все заболевания которые есть у поверхности
            {
                if (cond.Name == newCond.Name)
                {
                    
                    if (cond == newCond)
                    {

                        conditionsOfFace.Remove(cond);



                        return;

                    }
                    conditionsOfFace[indexer] = newCond.Copy();
                    return;
                }
                indexer++;

            }
            conditionsOfFace.Add(newCond.Copy()); //если заболевания еще нет в списке, тогда добавляем его

        }

        public void AddConditionsFromFace(Face face, bool changeOld)
        {
            List<Condition> newConditions = face.GetConditionsOfFace();

            for (int index = 0; index < newConditions.Count; index++)
            {
                AddCondition(newConditions[index], changeOld);
            }
        }
        public Face[] GetConnections()
        {
            Face[] connect = new Face[connections.Count];
            int i = 0;
            foreach (Face con in connections)
            {
                connect[i] = con;
                i++;
            }
            return connect;
        }

        public Face Copy()
        {
            Face newFace = new Face(this);
            return newFace;

        }
        public void Clean()
        {
            connections.Clear();
            conditionsOfFace.Clear();
        }
        #endregion
    }
}
