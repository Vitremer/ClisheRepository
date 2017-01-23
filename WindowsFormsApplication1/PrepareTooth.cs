using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class PrepareTooth
    {
        string _mainText;
        string _multiText;
        public List<AdditionalMean> _additionList = new List<AdditionalMean>();
        public bool _kof;
        public bool _optra;
        public bool _clean = true;


        public string GetText(bool multiple)
        {
            if (_optra) _mainText += KlisheParams.GetBlock("treatment_prepare_optra");
            if (_kof) _mainText += KlisheParams.GetBlock("treatment_prepare_kof");
            if (_clean) _mainText += KlisheParams.GetBlock("treatment_prepare_clean"+(multiple?"_multi":""));
       
            
            //Добавить еще реализацию добавления дополнительных средств из листа
      

            return _mainText;
        }

       
    }
}
