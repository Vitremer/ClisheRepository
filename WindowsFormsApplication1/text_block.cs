using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class text_block
    {
        public int layer;
        public List<Object> analogObjectsList = new List<Object>();
        public Object comparer = new Object();
        public string analogObjects="";
        public string textOfBlock = "";
         public string allText = "";
        public bool multi = false;
         string[] _changerTextBlocks;
        string _changerText = "";


        public string[] changerTextBlocks
    {
        get{
            if (_changerText != "")
            {
                if (_changerTextBlocks == null)
                {
                    List<string> finParts = new List<string>();
                    string[] parts = _changerText.Split('|');
                    foreach (string part in parts)
                    {
                        string[] splited = part.Split('_');
                        if (splited.Length == 2)

                            finParts.AddRange(splited);
                    }
                    _changerTextBlocks = finParts.ToArray();

                }
            }
               return _changerTextBlocks;
    }

    }


        public string changerText
        {
            get
            {
                //if (_changerText == " _ ")
                //{
                //    if (changerTextBlocks.Length >= 2)
                //    {
                //        _changerText = "";
                //        for (int i = 0; i < changerTextBlocks.Length; i += 2)
                //        {
                //            try
                //            {
                //                _changerText += changerTextBlocks[i] + '_' + changerTextBlocks[i + 1] + "|";
                //            }
                //            catch { }
                //        }
                //        if (_changerText != "") _changerText = _changerText.Remove(_changerText.Length - 1);
                //        else _changerText = " _ ";
                //    }
                //}
               return _changerText ;
              
            }
            set
            { 
                    string[] parts = value.Split('|');
                    if (parts != null)
                    {
                        _changerText = "";
                        foreach (string part in parts)
                        {
                            string[] splited = part.Split('_');
                            if (splited.Length == 2)
                                _changerText += part + "|";
                        }
                    }
                if (_changerText != null && _changerText!="") _changerText = _changerText.Remove(_changerText.Length - 1);
                else _changerText = " _ ";
            }
        }


        public void ToUpperFirstChar(string textToJoin)
        {
           
            int indexOFPoint = textToJoin.LastIndexOf('.') + 1;//ищем индекс последней точки в тексте
            if (indexOFPoint != 0)//если точка есть в тексте, тогда..
            {
                bool onlySpacesAtTheEnd = true;//...по умолчанию ставим что после точки пустота(только пробелы)

                foreach (char ch in textToJoin.Substring(indexOFPoint, textToJoin.Length - indexOFPoint).ToCharArray())//и проверяем 
                {

                    if (ch != ' ')
                    {
                        onlySpacesAtTheEnd = false;
                        break;
                    }
                }

                if (onlySpacesAtTheEnd)
                    allText = allText[0].ToString().ToUpper() + allText.Substring(1, allText.Length - 1);
            }

         

        }
        /// <summary>
        /// Метод возвращает мультиплифицированный текст(textOfBlock) блока.
        /// </summary>
        /// <returns></returns>
        public string MultiplyText()
        {
           
                string multiText = "";
                string currentText = textOfBlock;

                int currentPosition = 0;
                int currentLenght = 0;
                for (int i = 0; i < changerTextBlocks.Length; i += 2)
                {
                    if (!currentText.Substring(currentPosition).Contains(changerTextBlocks[i])) continue;
                        currentLenght = currentText.Substring(currentPosition).IndexOf(changerTextBlocks[i]) + changerTextBlocks[i].Length;
                    if ((currentPosition + currentLenght) <= currentText.Length)
                        multiText += currentText.Substring(currentPosition, currentLenght).Replace(changerTextBlocks[i], changerTextBlocks[i + 1]);

                    currentPosition = currentPosition + currentLenght;
                }
                if (currentPosition  <= currentText.Length) multiText += currentText.Substring(currentPosition);
               return multiText;
            
        }
       

    }
}
