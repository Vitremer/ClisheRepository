using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlisheNamespace
{
    class Anamnes
    {
        string firstWord = " \nАнамнез: ";
        string mainText ;
       
        List<Tooth> allTooths;

        public Anamnes(Klishe klishe)
        {
            allTooths = klishe.GetAllTooths().ToList();
            mainText = firstWord + GetTextFromTooths(klishe.GetAnalogGroupsFromPretreat(), klishe.GetAnalogGroupsFromDiagnosis());


        }


        public string GetText()
        {

            return mainText;
        }




        string GetTextFromTooths(List<GroupOfTooth> groupsOfPretreat, List<GroupOfTooth> groupsOfDiag)
        {


            string text = "";
            string textPretreat = "";
            string textHealedEasy = "";
            string textHealedHard = "";
            string textNotHealed = "";
            foreach (GroupOfTooth group in groupsOfPretreat) //сборка блоков текста лечен или не лечен
            {
                text_block curBlock = new text_block();

                foreach (Tooth tooth in group.ToothsInGroup)
                {

                    curBlock.analogObjects += tooth.number + ", ";
                }
                curBlock.analogObjects = curBlock.analogObjects.Remove(curBlock.analogObjects.Length - 2);
                curBlock.analogObjects += " зуб";
                string key = "anamnes_pretreat_" + group.pretreat;
                curBlock.textOfBlock = KlisheParams.GetBlock(key);
                if (group.ToothsInGroup.Count > 1)
                {
                    curBlock.multi = true;
                    curBlock.analogObjects += "ы";
                    curBlock.textOfBlock = curBlock.textOfBlock.Replace("лечен", "лечены");

                }
                curBlock.allText = curBlock.analogObjects  + curBlock.textOfBlock;
                switch (group.pretreat)
                {
                    case 0: textNotHealed = curBlock.allText;
                        break;
                    case 1: textHealedEasy = curBlock.allText;
                        break;
                    case 2: textHealedHard = curBlock.allText;
                        break;
                }
                textPretreat = textNotHealed + textHealedEasy + textHealedHard;

            }//end of foreach state


            //List<byte> tooths = new List<byte>();



            string textTrouble = "";
            string textOfGroup = "";
            string toothsNumbers = "";
            List<text_block> text_blocks = new List<text_block>();

            foreach (GroupOfTooth group in groupsOfDiag)//создание блоков текста сколько и как беспокоит
            {
              
                textOfGroup = KlisheParams.GetBlock("anamnes_trouble_" + group.MainDs.identityString);
                if (textOfGroup == "ERROR") textOfGroup = KlisheParams.GetBlock("anamnes_trouble_" + group.MainDs.layer);


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
                    try
                    {
                        newBlock.changerText = KlisheParams.GetBlock("anamnes_trouble_multi_" + group.MainDs.identityString);
                      
                    }
                    catch
                    {

                    
                    }
                    try
                    {
                        if (newBlock.changerText == " _ " || newBlock.changerText == "") newBlock.changerText = KlisheParams.GetBlock("anamnes_trouble_multi_" + group.MainDs.layer);
                    }
                    catch
                    {
                    }
                    if (group.ToothsInGroup.Count > 1) newBlock.multi = true;


                    text_blocks.Add(newBlock);

                }
                
            }//end of foreach for groups


            foreach (text_block block in text_blocks)// теперь все блоки собираем вместе
            {
                if (text_blocks.Count > 1)
                {
                    block.allText += block.analogObjects;

                    if (block.multi) block.allText += " зубы - ";
                    else block.allText += " зуб - ";
                }
                    block.allText += block.textOfBlock;
                    if (block.multi)
                    {
                        if (!ClisheTextManipulations.MultiplyText(ref block.allText, block.changerText))
                        {
                            block.allText = block.allText.Replace("оит", "оят");
                        }
                    }
                    textTrouble += block.allText;
                    if (text_blocks.IndexOf(block)+1 == text_blocks.Count) textTrouble += ". ";
                    else textTrouble += ", ";
               
            }//end of foreach for blocks

            text = textPretreat  + textTrouble;
            return text;
        }//end of GetText method





    }//end of class
}//end of namespace
