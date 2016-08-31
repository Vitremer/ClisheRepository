using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace KlisheNamespace
{
    interface IAffiction
    {
        void Apply(Tooth tooth);
     
    }
    [Serializable]

    class Affiction : IAffiction
    {
        string _param;
        byte _value;
        public void Apply(Tooth tooth)
        {
            
            byte toothValue = 0;
           try { toothValue =(byte)tooth.GetType().GetProperty(_param).GetValue(tooth,null) ;
           }
            catch{
            }

           if (_value > toothValue)
            tooth.GetType().GetProperty(_param).SetValue(tooth,_value,null);

             
        }

        public Affiction(string param, byte value)
        {
            _param = param;
            _value = value;
        }
    }
    
}
