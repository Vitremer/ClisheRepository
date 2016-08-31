using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class Complaints
    {
        string firstWord = "Жалобы: ";
        string mainText;
    
        List<Tooth> allTooths;
        public Complaints(Klishe klishe)
        {
           allTooths = klishe.GetAllTooths().ToList() ;

           mainText = firstWord+ GetTextFromGroups(klishe.GetAnalogGroupsFromCondition());


        }

        public string GetText()
        {
            return mainText;
        }
       
        string GetTextFromGroups(List<GroupOfTooth> groups)
        {


             string text = "";
            string textOfGroup = "";
            string toothsNumbers = "";
            List<text_block> text_blocks = new List<text_block>();
           
                 foreach (GroupOfTooth group in groups)//создание блоков текста сколько и как беспокоит
            {
                textOfGroup = KlisheParams.GetBlock("jaloby_" + group.MainCondition.Name + "_" + group.MainCondition.Depth.ToString());
                if (textOfGroup == "ERROR") textOfGroup = KlisheParams.GetBlock("jaloby_" + group.MainCondition.Name);
                    
                toothsNumbers = group.GetToothsText(false);
                bool alreadyHaveOne = false;
                foreach (text_block block in text_blocks)
                {
                    if (block.textOfBlock == textOfGroup)
                    {
                        block.analogObjects = toothsNumbers + ", " + block.analogObjects;
                        block.multi = true;
                        alreadyHaveOne = true;
                        break;
                    }

                }

                if (!alreadyHaveOne)
                {
                    text_block newBlock = new text_block();
                    newBlock.textOfBlock = textOfGroup;
                    newBlock.analogObjects = toothsNumbers;
                    
                    if (group.ToothsInGroup.Count > 1) newBlock.multi = true;

                    text_blocks.Add(newBlock);

                }
                
            }//end of foreach for groups

                 foreach (text_block tblock in text_blocks)// теперь все блоки собираем вместе
                 {
                     tblock.allText += tblock.textOfBlock;


                     if (tblock.multi) tblock.allText += KlisheParams.GetBlock("jaloby_zubMany");
                         else tblock.allText += KlisheParams.GetBlock("jaloby_zubOne");
                         tblock.allText += tblock.analogObjects + ".";



                         text += tblock.allText;
                         if (text_blocks.IndexOf(tblock)+1 != text_blocks.Count) text += "\n";
                    
                 }//end of foreach for blocks

                 return text;





















           // string text = "Жалобы: ";
           // string textOfGroup = "";
           // string numbersOfTeeth = "";

            
           //int first = 0;
           //List<int> analogIndicies = new List<int>();
           //     foreach (GroupOfTooth group in groups)
           // {



           //                         //if (textOfGroup == "")
           //                         //{
           //                         //                textOfGroup = blocks.GetBlock("jaloby_" + group.MainDs.ToString());
           //                         //                numbersOfTeeth = group.GetToothsText(false);
           //                         //                if (group.ToothsInGroup.Count == 1)
           //                         //                {
           //                         //                    text += textOfGroup + blocks.GetBlock("jaloby_zubOne") + numbersOfTeeth + ". \n";
           //                         //                }
           //                         //                else
           //                         //                {
           //                         //                    text += textOfGroup + blocks.GetBlock("jaloby_zubMany") + numbersOfTeeth + ". \n";


           //                         //                }
           //                         //}

           //                         //else 
           //     if (!analogIndicies.Contains(first))
           //     {
           //         textOfGroup = blocks.GetBlock("jaloby_" + group.MainDs.ToString());
           //         numbersOfTeeth = group.GetToothsText(false);
           //         if (group.ToothsInGroup.Count == 1)
           //         {
           //             text += textOfGroup + blocks.GetBlock("jaloby_zubOne") + numbersOfTeeth + ". \n";
           //         }
           //         else
           //         {
           //             text += textOfGroup + blocks.GetBlock("jaloby_zubMany") + numbersOfTeeth + ". \n";


           //         }
           //     }
           //      if (textOfGroup != "null"&&!analogIndicies.Contains(first))
           //         {
           //             int second = 0;

           //             foreach (GroupOfTooth insideGroup in groups)
           //             {
           //                 if (second > first && textOfGroup == blocks.GetBlock("jaloby_" + insideGroup.MainDs.ToString()))
           //                 {

           //                     text = text.Replace("зуба " + numbersOfTeeth, "зубов " + insideGroup.GetToothsText(false) + ", " + numbersOfTeeth);
           //                     text = text.Replace("зубов " + numbersOfTeeth, "зубов " + insideGroup.GetToothsText(false) + ", " + numbersOfTeeth);
           //                     numbersOfTeeth = insideGroup.GetToothsText(false);
           //                     analogIndicies.Add(second);

           //                 }
           //                 second++;

           //             }
           //             textOfGroup = "null";
           //         }


                                                  
                                    
           //          first++;
           //     }
              
            
           // return text;

        }



       

       
        
    }
}
