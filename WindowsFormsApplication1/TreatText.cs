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
            mainText = " \nЛечение: " + GetTextAnestesy(klishe.GetAnalogGroupsFromAnestesy())+GetTextConditionsTreatment(klishe.GetAnalogGroupsFromCondition())+GetTextPlombing(klishe.GetAnalogGroupsFromTreatment())+GetTextRecomendation(klishe.GetAnalogGroupsFromDiagnosis());


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
        string GetTextConditionsTreatment(List<GroupOfTooth> groups)
        {
            string text = "";

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
