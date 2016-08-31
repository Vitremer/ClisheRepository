using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class  ClisheTextManipulations
    {
        public static bool MultiplyText(ref string original, string multyChangeText)
        {
           
            try
            {
                 
                string[] textChangeBlocks = multyChangeText.Split('_');
                original = original.Replace(textChangeBlocks[0], textChangeBlocks[1]);
                return true;
            }
            catch
            {
                return false;

            }
            

        }
    }
}
