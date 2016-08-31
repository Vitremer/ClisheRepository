using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class DSText
    {
         string mainText;
    
        List<Tooth> allTooths;
        public DSText(Klishe klishe)
        {
           allTooths = klishe.GetAllTooths().ToList() ;

           mainText = GetTextFromGroups(klishe.GetAnalogGroupsFromDiagnosis());


        }

        public string GetText()
        {
            return mainText;
        }
       
        string GetTextFromGroups(List<GroupOfTooth> groups)
        {


             string text = "Диагноз: ";
           
           
                 foreach (GroupOfTooth group in groups)//создание блоков текста сколько и как беспокоит
            {
                text +=group.GetToothsText(true)+" - "+ group.MainDs.Name+"\n";
          


            //    bool alreadyHaveOne = false;
            //    foreach (text_block block in text_blocks)
            //    {
            //        if (block.textOfBlock == textOfGroup)
            //        {
            //            block.analogObjects = toothsNumbers + ", " + block.analogObjects;
            //            block.multi = true;
            //            alreadyHaveOne = true;
            //            break;
            //        }

            //    }

            //    if (!alreadyHaveOne)
            //    {
            //        text_block newBlock = new text_block();
            //        newBlock.textOfBlock = textOfGroup;
            //        newBlock.analogObjects = toothsNumbers;
                    
            //        if (group.ToothsInGroup.Count > 1) newBlock.multi = true;

            //        text_blocks.Add(newBlock);

            //    }
                
            //}//end of foreach for groups

            //     foreach (text_block tblock in text_blocks)// теперь все блоки собираем вместе
            //     {
            //         tblock.allText += tblock.textOfBlock;


            //         if (tblock.multi) tblock.allText += KlisheParams.GetBlock("jaloby_zubMany");
            //             else tblock.allText += KlisheParams.GetBlock("jaloby_zubOne");
            //             tblock.allText += tblock.analogObjects + ".";
                     
                 
                    
            //         text += tblock.allText;
                    
                }//end of foreach for blocks

                 return text;

        }













    }
}
