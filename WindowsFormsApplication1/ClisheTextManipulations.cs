using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class  ClisheTextManipulations
    {
       
        /// <summary>
        /// Заменяет слова в text из multiplicator и мультиплицированный текст(во множественном числе) возвращает через out параметр multiText.
        /// </summary>
        /// <param name="text">Текст требущий перевода во множественное число. </param>
        /// <param name="multipicator">Мультипликатор текста вида - "изначальное слово_слово во множественом числе|следующее по порядку в тексте слово_следущее слово во множественном числе|и т.д.". Слова должны стоять в том порядке, в котором они встречаются в text. Мультипликатор нарезается в массив string.</param>
        /// <param name="multiText">Текст во множественном числе - если не удается перевести во множественное число вовзращает text без изменений</param>
        /// <returns>В случае успеха возвращает true, неудачи - false.</returns>
        public  static bool MultiplyText(string text, string multipicator,out string multiText)
        {
            multiText = text;
            if (multipicator != "")
            {
                string[] changerTextBlocks;

                    List<string> finParts = new List<string>();
                    string[] parts = multipicator.Split('|');
                    foreach (string part in parts)
                    {
                        string[] splited = part.Split('_');
                        if (splited.Length == 2)

                            finParts.AddRange(splited);
                    }
                    if (finParts.Count >= 2)
                        changerTextBlocks = finParts.ToArray();
                    else return false;

                



                 
                string currentText = text;
                multiText = "";
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
                if (currentPosition <= currentText.Length) multiText += currentText.Substring(currentPosition);
                return true;

            }
            else return false;
        }
    }
}
