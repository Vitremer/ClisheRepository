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
                  tb.textOfBlock = group.ToothsInGroup[0].Treat.prepare

                }
                    return text;


        }
        string GetTextConditionsTreatment(List<GroupOfTooth> groups)
        {
            string text = "";


            List<text_block> text_blocks = new List<text_block>();
            foreach (GroupOfTooth group in groups)
            {
                text_block tb = new text_block();
                if (groups.Count > 1)
                {
                    foreach (Tooth tooth in group.ToothsInGroup)
                    {
                        tb.analogObjectsList.Add(tooth);
                    }
                }
            }

            return text;

        }
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
