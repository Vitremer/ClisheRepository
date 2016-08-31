using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class Objective
    {
        string firstWord = " \nОбъективно: ";
         string mainText;
      
        List<Tooth> allTooths;

        public Objective(Klishe klishe)
        {
            allTooths = klishe.GetAllTooths().ToList();
            mainText =  firstWord+ GetTextFromTooths(klishe.GetAnalogGroupsFromToothIdentity());


        }


        public string GetText()
        {

            return mainText;
        }

        string GetTextFromTooths(List<GroupOfTooth> groups)
        {
            string text = "";
            List<text_block> text_blocks = new List<text_block>();
            foreach (GroupOfTooth group in groups)
            {
                text_block curBlock = new text_block();

                curBlock.analogObjects = group.GetToothsText(true);
                curBlock.analogObjectsList.AddRange(group.ToothsInGroup.ToArray());

                curBlock.allText = GetFacesObjective(group.ToothsInGroup[0]) + GetToothObjective(group.ToothsInGroup[0]);
                text_blocks.Add(curBlock);
            }

            foreach (text_block tb in text_blocks)
            {
               
                   

               
                text +=   tb.analogObjects+ " - " + tb.allText;
            }
             
            return text;
        }


        string GetToothObjective(Tooth tooth)
        {

            string text = "";
            if (tooth.ruin > 0) text += KlisheParams.GetBlock("objectivno_ruin_" + tooth.ruin);
            if (tooth.distpapil)
            {
                text += KlisheParams.GetBlock("objectivno_mukosapapil") + KlisheParams.GetBlock("objectivno_distpapil");
                if (tooth.medpapil)
                {
                    text += "и" + KlisheParams.GetBlock("objectivno_medpapil");
                    text += KlisheParams.MultiplyText(KlisheParams.GetBlock("objectivno_textpapil"), KlisheParams.GetBlock("objectivno_papil_multi"));
                }
                else text += KlisheParams.GetBlock("objectivno_textpapil");
            }
            else if (tooth.medpapil)
            {
                text += KlisheParams.GetBlock("objectivno_mukosapapil") + KlisheParams.GetBlock("objectivno_medpapil")+KlisheParams.GetBlock("objectivno_textpapil");
            }

            if(tooth.percus>0)
            text += KlisheParams.GetBlock("objectivno_percus_" + tooth.percus);
      
            text += KlisheParams.GetBlock("objectivno_termotest_" + tooth.termotest);
            text += " ЭОД- " + tooth.eod + " мкА."+"\n";

            return text;
        }
        string GetFacesObjective(Tooth tooth)
        {
            string text ="";
            List<text_block> text_blocks = new List<text_block>();
            bool haveOne = false;







            foreach (Face face in tooth.GetAllFaces())
            {

                foreach (Condition cond in face.GetConditionsOfFace())
                {
                    foreach(text_block tb in  text_blocks){
                        if (((Condition)tb.comparer).Name == cond.Name)
                        {
                            haveOne = true;
                            bool alreadyConnected = false;
                            foreach (Face fc in tb.analogObjectsList)//проверяем нет ли среди поверхностей с таким же диагнозом, таких с которым эта поверхность уже соединена
                            {
                               
                                    if (face.GetConnections().Contains(fc))
                                    {
                                        
                                    
                                        if (((Condition)tb.comparer).Depth<cond.Depth)
                                        {
                                   
                                            tb.comparer = cond;
                                        }
                                        alreadyConnected = true;
                                        break;
                                    }

                                
                            }
                            if (!alreadyConnected)//если присоединенных поверхностей нет тогда она будет описываться отдельно.
                            {
                                tb.analogObjectsList.Add(face);
                                tb.multi = true;
                            }
                            break;
                        }
                    

                    }

                    if (!haveOne)
                    {
                        text_block tb = new text_block();
                        tb.analogObjectsList.Add(face);
                        tb.layer = cond.layerForDiscription;
                        tb.comparer = cond;
                        tb.textOfBlock =  cond.Description;
                        tb.changerText = cond.multiDiscription;
                        text_blocks.Add(tb);

                    }
                    haveOne = false;

                }




            }

            text_blocks = text_blocks.OrderBy(t => t.layer).ToList();//упорядочиваем список блоков текста по слоям (первые слои наиболее важные - кариес и тому подобное, потом уже идет описание остальных слоев)

            foreach (text_block tb in text_blocks)
            {


                

                bool edge = false;
               bool onlyEdge = false;
             
                foreach (Face fc in tb.analogObjectsList)
                {
                    if (fc.faceName != Face.faceSide.edge)//если это не режущий край тогда
                    {
                        tb.allText += "на " + KlisheParams.GetBlock("face_name_" + fc.faceName.ToString()) + "о";//записываем в текст имя поверхности


                        if (fc.GetConnections().Length > 0)//если есть присоединенные поверхности тогда добавляем их
                        {
                            foreach (Face connectedFace in fc.GetConnections())
                            {
                                if (connectedFace.faceName != Face.faceSide.edge) tb.allText += "-" + KlisheParams.GetBlock("face_name_" + connectedFace.faceName.ToString()) + "о";
                                else edge = true;
                            }
                        }
                        tb.allText += "й и ";
                    }
            //        
            //            if (tb.allText == "") tb.allText += "на " + KlisheParams.GetBlock("face_name_" + fc.faceName.ToString()) + "о";
            //            else tb.allText += "-" + KlisheParams.GetBlock("face_name_" + fc.faceName.ToString()) + "о";
            //        }
                    else
                    {
                        if (tb.allText == "" && tb.analogObjectsList.Count == 1)
                        {
                            onlyEdge = true;
                            tb.allText += "по " + KlisheParams.GetBlock("face_name_" + fc.faceName.ToString() + "_onthe") + " ";
                        }
                        else edge = true;
                    }
                }
                if (!onlyEdge) tb.allText = tb.allText.Remove(tb.allText.Length-2)+ " поверхности ";
                if (edge) tb.allText += " с выходом на режущий край ";
                if (tb.multi)
                {
                   
                    tb.allText += tb.MultiplyText();                             
                }
                else tb.allText += tb.textOfBlock;

                tb.ToUpperFirstChar(text);

                text += tb.allText;
            }//end of foreach text_block


         
            return text;
        }
    }
}
