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
            mainText = " \nЛечение: " + GetText(klishe.GetAnalogGroupsFromToothIdentity());


        }


        public string GetText()
        {

            return mainText;
        }

        string GetText(List<GroupOfTooth> groups)
        {
            string text = "";

            return text;

        }
    }
}
