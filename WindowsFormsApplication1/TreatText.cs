using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class TreatText
    {

            string mainText;
      
        List<Tooth> allTooths;

        public TreatText(Klishe klishe)
        {
            allTooths = klishe.GetAllTooths().ToList();
            mainText = " \nЛечение: " + GetTextAnestesy(klishe.GetAnalogGroupsFromAnestesy()) + GetTextToothPrepare(klishe.GetAnalogGroupsFromPrepare()) + GetTextConditionsTreatment(klishe.GetAnalogGroupsFromCondition()) + GetTextPlombing(klishe.GetAnalogGroupsFromPlombing()) + GetTextRecomendation(klishe.GetAnalogGroupsFromDiagnosis());


        }


        public string GetText()
        {

            return mainText;
        }

        string GetTextAnestesy(List<GroupOfTooth> groups)
        {
            string text = "";

            foreach (GroupOfTooth group in groups)
            {
                if (((Anestesy)group.comparer).applica || ((Anestesy)group.comparer).carpul)
                {
                    text += KlisheParams.GetBlock("treatment_local_anest");
                }
                if (((Anestesy)group.comparer).applica)
                {
                    text += KlisheParams.GetBlock("treatment_application_anest") + " "+ KlisheParams.GetBlock("treatment_anest")+ ((Anestesy)group.comparer).usingApplication.Name + ", ";
                }
                if (((Anestesy)group.comparer).carpul)
                {
                    foreach (Anestesy.KindOfAnestesy koa in ((Anestesy)group.comparer).kindOfAnest)
                    {
                        text += " " + KlisheParams.GetBlock("treatment_" + koa.ToString() + "_anest") +  " и";
                    }
                    text = text.Remove(text.Length - 1);
                    text += " " + KlisheParams.GetBlock("treatment_anest") + " раствором " + ((Anestesy)group.comparer).usingAnestetic.Name + " - " + ((Anestesy)group.comparer).mlOfAnest + "мл, ";
                }
                
            }

            return text;

        }

        string GetTextToothPrepare(List<GroupOfTooth> groups)
        {
                    string text = "";
                List<text_block> text_blocks = new List<text_block>();
                foreach (GroupOfTooth group in groups)
                {
                    text_block tb = new text_block();
                    if (group.ToothsInGroup.Count > 1)
                    {
                        tb.analogObjects = group.GetToothsText(true);
                    }
                    tb.textOfBlock = group.ToothsInGroup[0].Treat.prepare.GetText(group.ToothsInGroup.Count>1);
                    if(text_blocks.Find(t=>t.textOfBlock==tb.textOfBlock)==null)
                    text_blocks.Add(tb);
                }

                foreach (text_block tb in text_blocks)
                {
                    if (text_blocks.Count > 1) text += tb.analogObjects;
                    text += tb.textOfBlock;

                }
                    return text;


        }
        string GetTextConditionsTreatment(List<GroupOfTooth> groups)
        {
            string text = "";


            List<text_block> text_blocks = new List<text_block>();
            foreach (GroupOfTooth group in groups)
            {

                if (group.MainCondition.treatment != "")
                {
                    text_block tb = new text_block();


                    if (groups.Count > 1 || group.ToothsInGroup.Count > 1)
                    {
                        tb.multi = true;

                        foreach (Tooth tooth in group.ToothsInGroup)
                        {
                            tb.analogObjectsList.Add(tooth);

                        }

                    }

                    tb.textOfBlock = group.MainCondition.GetTreatmentText(tb.multi);




                    if (group.MainCondition.treatWithBlack)
                    {

                        if (!tb.multi && group.ToothsInGroup[0].GetClassesOfCondition(group.MainCondition).Count > 1)//если  несколько классов у данного состояния тогда текст нужно мультиплицировать
                        {
                            tb.multi = true;
                        }



                        if (group.ToothsInGroup.Count > 1)
                        {

                            List<GroupOfTooth> classGroups = new List<GroupOfTooth>();

                            bool containAlready = false;
                            foreach (Tooth tooth in group.ToothsInGroup)
                            {

                                foreach (GroupOfTooth grt in classGroups)
                                {
                                    if (tooth.GetClassesOfCondition(group.MainCondition).Count == ((List<byte>)grt.comparer).Count && tooth.GetClassesOfCondition(group.MainCondition).SequenceEqual(((List<byte>)grt.comparer)))
                                    {
                                        grt.ToothsInGroup.Add(tooth);
                                        containAlready = true;
                                        break;
                                    }

                                }

                                if (!containAlready)
                                {

                                    GroupOfTooth gr = new GroupOfTooth();
                                    gr.ToothsInGroup.Add(tooth);
                                    gr.comparer = tooth.GetClassesOfCondition(group.MainCondition);

                                }


                            }

                            foreach (GroupOfTooth grClass in classGroups)
                            {
                                tb.secondTextOfBlock += grClass.ToothsInGroup[0].GetTextOfCondClass(group.MainCondition);

                                if (grClass.ToothsInGroup.Count > 1)
                                {


                                    foreach (Tooth th in grClass.ToothsInGroup)
                                    {
                                        tb.secondTextOfBlock += " " + th.number + ",";
                                    }
                                    tb.secondTextOfBlock = tb.secondTextOfBlock.Remove(tb.secondTextOfBlock.Length - 1) + " зубов,";

                                }

                                else
                                {
                                    tb.secondTextOfBlock += grClass.ToothsInGroup[0].number + " зуба,";

                                }
                            }


                        }//end of IF many tooth in main group

                        else
                        {

                            tb.secondTextOfBlock = group.ToothsInGroup[0].GetTextOfCondClass(group.MainCondition) + group.ToothsInGroup[0].number + " зуба,";
                        }


                    }//end of If treat with black
                    else
                    {
                        tb.secondTextOfBlock = group.GetToothsText(false);
                        if (group.ToothsInGroup.Count > 1) tb.secondTextOfBlock += " зубов,";
                        else tb.secondTextOfBlock += " зуба,";

                    }//end of treat without black classification

                    text_block analogTextBlock = text_blocks.Find(t => t.textOfBlock == tb.textOfBlock);
                    if (analogTextBlock == null)
                    {
                        text_blocks.Add(tb);
                    }
                    else
                    {
                        analogTextBlock.secondTextOfBlock += tb.secondTextOfBlock;
                    }



                }//end of IF treatment is not empty

            }//end of main foreach of groups


            foreach (text_block tb in text_blocks)
            {

                text += tb.textOfBlock;
                if (tb.secondTextOfBlock != "") text += tb.secondTextOfBlock;
            }

            return text;

        }//end of MainMethod

        string GetTextPlombing(List<GroupOfTooth> groups)
        {
            string text = "";


            return text;

        }
        string GetTextRecomendation(List<GroupOfTooth> groups)
        {
            string text = "";

            return text;

        }
    }
}
