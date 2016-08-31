using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class AdditionalStrings
    {
        public enum Place { beforeComplaints, beforeToothComplaints, afterComplaints, beforeAnamnesis, afterToothAnamnesis, afterAnamnesis, beforeObjective, afterToothObjective, afterFaceObjective, beforeMucosaObjective, afterMucosaObjective, beforePalpationObjective, afterPalpationObjective, beforeEODObjcetive, afterEODObjective, afterObjective, afterObjectiveNewString, beforeDiagnosis, afterToothDiagnosis, afterDiagnosis, afterDiagnosisNewString, treatmentPlane };

        Place _place;
        public Place place
        {
            get
            {
                return _place;

            }

        }

        string _text = "";

        public string text
        {
            get
            {
                return _text;
            }
        }
    }
}
