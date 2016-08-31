using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace KlisheNamespace
{[Serializable]
    class Diagnos
    {
        string _name;
        int _layer;//слой к которому относится диагноз(слой кариесов, например)
        int _majority;//важность диагноза в своем слое - чем меньше цифра тем он важнее и перекрывает собой все диагнозы с большей цифрой в том же слое

        List<Condition> _conditionsForDiagnos = new List<Condition>();
        List<Type> _typesOfObjectsForDiagnos = new List<Type>();
       
        List<DentistrySection.Section> _dentistrySections = new List<DentistrySection.Section>();

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int layer
        {
            get
            {
                return _layer;
            }
           
        }
        public int majority
        {
            get
            {
                return _majority;
            }

        }


        public int[] identity
        {
            get
            {
                int[] id = new int []{ layer, majority };
                return id;
            }
        }
        public string identityString
        {
            get
            {
                string id = "" + layer + majority;
                return id;
            }
        }
        public List<Type> TypeOfObjectForDiagnos
        {
            get { return _typesOfObjectsForDiagnos; }
        }
        public List<DentistrySection.Section> SectionOfDentistry
        {
            get { return _dentistrySections; }
        }
        public List<Condition> GetConditions
        {
            get
            {
                return _conditionsForDiagnos;
            }
        }

        public Diagnos(string name, int Layer,int Majority, string[] namesOfConditions, List<Type> typesOfObjForDiag, List<DentistrySection.Section> Sections)
        {
            _name = name;
            _layer = Layer;
            _majority = Majority;
            _typesOfObjectsForDiagnos = typesOfObjForDiag;
            _dentistrySections = Sections;
            foreach (string nameOfCon in namesOfConditions)
            {
                _conditionsForDiagnos.Add (KlisheParams.conditionOfFaceList.Find(c => c.Name == nameOfCon));

            }

        }
        public Diagnos(string name, int Layer, int Majority, string[] namesOfConditions, Type typesOfObjForDiag, DentistrySection.Section Sections)
        {
            _name = name;
            _layer = Layer;
            _majority = Majority;
            _typesOfObjectsForDiagnos.Add(  typesOfObjForDiag);
            _dentistrySections.Add( Sections);
            foreach (string nameOfCon in namesOfConditions)
            {
                _conditionsForDiagnos.Add(KlisheParams.conditionOfFaceList.Find(c => c.Name == nameOfCon));

            }
        }
    }
}
