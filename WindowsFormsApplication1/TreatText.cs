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
            mainText = " \nЛечение: " + GetTextAnestesy(klishe.GetAnalogGroupsFromToothAnestesy())+GetTextConditionsTreatment(klishe.GetAnalogGroupsFromCondition())+GetTextPlombing(klishe.GetAnalogGroupsFromTreatment())+GetTextRecomendation(klishe.GetAnalogGroupsFromDiagnosis());


        }


        public string GetText()
        {

            return mainText;
        }

        string GetTextAnestesy(List<GroupOfTooth> groups)
        {
            string text = "";

            return text;

        }
    }
}
