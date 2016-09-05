using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace KlisheNamespace
{
    public delegate void RenewMat();
    public partial class mainForm : Form
    {
        
        Tooth currentFormTooth = new Tooth();
        Klishe currentClishe= new Klishe();
       
        List<Materials> healList = new List<Materials>();
        List<Materials> isoList = new List<Materials>();
        List<Materials> plombList = new List<Materials>();
        Treatment currentTreatment = new Treatment();
      
        CheckBox currentChckBx;
        Face faceWhichDragged = new Face();
        bool connection = false;
       
        List<CheckBox> poverhnosties = new List<CheckBox>();
        List<CheckBox> connectButtons = new List<CheckBox>();
        

        #region klisheParams methods

        /// <summary>
        /// Добавляет материал в основной лист материалов, используя для сверки только имя материала, через метод класса KlisheParams, записывая изменения во внешний файл .bin.
        /// </summary>
        /// <param name="mat">Материал для добавления</param>
        /// <returns>Удалось ли добавить, или материал с таким именем уже есть в списке.</returns>
        public bool AddMat(Materials mat)
        {
            if (KlisheParams.AddMaterial(mat))
            {
                
                return true;
            }
            else return false;


        }
        /// <summary>
        /// Удаляет материал из основного листа материалов, находя его только по имени, через метод класса KlisheParams, записывая изменения во внешний файл .bin.
        /// </summary>
        /// <param name="mat">Материал для удаления</param>
        /// <returns>Удалось ли удалить, или такого материала в списке нет.</returns>
        public bool RemoveMat(Materials mat)
        {
            if (KlisheParams.RemoveMaterial(mat, false))
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Создает независимую копию основного листа материалов, при этом основной лист никак не меняется в дальнейшем.
        /// </summary>
        /// <returns>Копия основного листа материалов</returns>
        public List<Materials> GetMainMatList()
        {
            return KlisheParams.CopyMainMaterialList();
        }

        /// <summary>
        /// Сбрасывает список материалов на список по умолчанию обращаясь к классу KlisheParams, возвращает список материалов по умолчанию.
        /// </summary>
        /// <returns>Список материалов по умолчанию.</returns>
        public List<Materials> SetDefaultsMaterials()
        {
            KlisheParams.ResetMaterialList();           
           
            return KlisheParams.CopyMainMaterialList();
        }

        /// <summary>
        /// Сохраняет лист материалов по умолчанию во внешний файл, через метод класса KlisheParams
        /// </summary>
        /// <param name="matListToSave">Лист который сохранить.</param>
        public void SaveToDefaultMatList(List<Materials> matListToSave)
        {
            KlisheParams.SaveDefaultMaterialList(matListToSave);
        }
        /// <summary>
        /// Сохраняет активный лист материалов(используемых в данный момент) во внешний файл, через метод класса KlisheParams
        /// </summary>
        /// <param name="matListToSave">Лист который сохранить.</param>
        public void SaveCurrentMaterialList(List<Materials> matListToSave)
        {
            KlisheParams.SaveCurrentMaterialList(matListToSave);
            RenewMaterals();
        }

        public void CancelChangesMaterialList()
        {
            KlisheParams.CancelChangesMaterialList();

        }
        #endregion

        /// <summary>
        /// Обновляет все ListBox на форме, используется если были внесены какие либо изменения в списки анестетиков или материалов.
        /// </summary>
        public  void  RenewMaterals()
        {
            healList.Clear();
            isoList.Clear();
            plombList.Clear();
            anestBox.DataSource = null;
      
            foreach (Materials mat in KlisheParams.mainMatList)
            {
                if (mat.healable) healList.Add(mat);
                else if (mat.isolation) isoList.Add(mat);
                else plombList.Add(mat);
            }
            
             plombBox.DataSource = null;
            plombBox.DataSource = plombList;
            plombBox.DisplayMember = "Name";
            plombBox.ValueMember = "Name";

            healFillBox.DataSource = null;
            healFillBox.DataSource = healList;
            healFillBox.DisplayMember = "Name";
            healFillBox.ValueMember = "Name";


            isoFillBox.DataSource = null;
            isoFillBox.DataSource = isoList;
            isoFillBox.DisplayMember = "Name";
            isoFillBox.ValueMember = "Name";
            
            anestBox.DataSource = KlisheParams.anesteticsList;
            anestBox.DisplayMember = "Name";
            anestBox.ValueMember = "Name";
           

            applicationBox.DataSource = null;
            applicationBox.DataSource = KlisheParams.applicationList;
            applicationBox.DisplayMember = "Name";
            applicationBox.ValueMember = "Name";




        }
       
        
        
        
        
        public mainForm()
        {
         
            InitializeComponent();

            RenewMaterals();  
                 
               foreach(Condition cond in KlisheParams.conditionOfFaceList)
               {
                   if(cond.availableDepths.Length>1)
                   {
                       ToolStripDropDownItem menuItem = new System.Windows.Forms.ToolStripMenuItem();
                       menuItem.Text = cond.Name;
                       FaceConditionsMenu.Items.Add(menuItem);
                       foreach (Condition.DepthOfCondition depth in cond.availableDepths)
                       {
                           ToolStripMenuItem depthItem = new System.Windows.Forms.ToolStripMenuItem();
                           depthItem.Text = cond.GetDepth(depth);
                           menuItem.DropDownItems.Add(depthItem);
                           depthItem.Click += new EventHandler(AnyToolStripMenuItem_Clicked); 
                       }

                   }
                   else{
                       ToolStripItem menuItem = new System.Windows.Forms.ToolStripMenuItem();
                       menuItem.Text = cond.Name;
                       FaceConditionsMenu.Items.Add(menuItem);
                 
                     
                      menuItem.Click += new EventHandler(AnyToolStripMenuItem_Clicked);  
                   }
                   
             }
            
              
            toolTip1.SetToolTip(vestF, "");
            toolTip1.SetToolTip(okklF, "");
            toolTip1.SetToolTip(distF, "");
            toolTip1.SetToolTip(medF, "");
            toolTip1.SetToolTip(orF, "");

            poverhnosties.Add(vestF);
            poverhnosties.Add(okklF);
            poverhnosties.Add(distF);
            poverhnosties.Add(medF);
            poverhnosties.Add(orF);
            connectButtons.Add(conDN);
            connectButtons.Add(conMN);
            connectButtons.Add(conMO);
            connectButtons.Add(conOD);
            connectButtons.Add(conON);
            connectButtons.Add(conVD);
            connectButtons.Add(conVM);
            connectButtons.Add(conVO);
        }
      
        public void Form1_Load(object sender, EventArgs e)
        {
            

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = false;
            

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }






        private void numberOfToothText_TextChanged(object sender, EventArgs e)//изменение текста окна ввода номера зубов
        {
            if (numberOfToothText.Text.Length > 0)//проверяем не равна ли длина нулю(при стирании первого символа например)
            {
                byte number = Byte.Parse(numberOfToothText.Text);//переводим текст в цифру

                if (((int)Math.Log10(number) + 1) == 2)//проверяем имеет ли номер зуба две цифры
                {
                    if (number >= 11 && number <= 48)//проверяем входит ли зуб в диапозон взрослых зубов
                    {
                        if (number % 10 < 1 || number % 10 > 8)//проверяем не имеет ли зуб вторую цифру меньше 1 или больше 8
                            numberOfToothText.Text = numberOfToothText.Text.Remove(1);//если имеет тогда удаляем второй символ - Текст - ссылочный тип поэтому не забываем присуждать его основному тексту
                        else { if(currentClishe.GetTooth(number) !=null) 
                        {
                           currentFormTooth = currentClishe.GetTooth(number);
                        }
                        else {
                            
                           //currentFormTooth = currentFormTooth.Copy() ;
                            currentFormTooth = currentFormTooth.CopyWithNewNumber(number);
                            
                         
                        }
                        UpdateColor();
                        UpdateTreatment();
                      
                        }

                    }
                    else if (number >= 51 && number <= 85)//проверяем входит ли зуба в диапозон детских зубов
                    {
                        if (number % 10 < 1 || number % 10 > 5)//проверяем не имеет ли зуб вторую цифру меньше 1 и больше 5 при детском прикусе
                            numberOfToothText.Text = numberOfToothText.Text.Remove(1);
                        else
                        {
                            if (currentClishe.GetTooth(number) != null)
                            {
                                currentFormTooth = currentClishe.GetTooth(number);

                            }
                            else
                            {

                                currentFormTooth = currentFormTooth.CopyWithNewNumber(number);
                            
                            }
                            UpdateColor();
                            UpdateTreatment();
                        }

                    }
                    else numberOfToothText.Text = numberOfToothText.Text.Remove(1);


                }
                else
                {
                    if (number  < 1 || number > 8)//проверяем не имеет ли зуб первую цифру меньше 1 или больше 8
                        numberOfToothText.Text = numberOfToothText.Text.Remove(0); //удаляем если имеет

                }
            }
            if (currentFormTooth.isFront) okklF.Text = "Режущий край";
            else okklF.Text = "Окклюзионная";

            if (currentFormTooth.kvadrantNumb == 1 || currentFormTooth.kvadrantNumb == 2)
                orF.Text = "Небная";
            else orF.Text = "Язычная";

            UpdateTooth();
            //UpdateColor();
            //UpdateTreatment();

        }


        private void volumeAnest_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            currentFormTooth.Treat.anest.mlOfAnest = float.Parse(volumeAnest.Text);
        }

     

       

       

 

       
#region Connections

        private void facePress_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CheckBox chkb = (CheckBox)sender;
                faceWhichDragged.faceName = GetFaceNameFromCheckBox(chkb);
               
                chkb.DoDragDrop(chkb.Name, DragDropEffects.Link);
            }



        }


        private void face_DragDrop(object sender, DragEventArgs e)
        {
            
                CheckBox checkBoxSender = (CheckBox)sender;
            Face.faceSide faceConnectName = GetFaceNameFromCheckBox(checkBoxSender);
           
                List<Face.faceSide> connectedFaces = new List<Face.faceSide>();
                connectedFaces.Add(GetFaceNameFromCheckBox(checkBoxSender));
                connectedFaces.Add(faceWhichDragged.faceName);
               Tooth.connect con =  GetConnection(connectedFaces);
               if (con != Tooth.connect.empty)
               {
                   currentFormTooth.SwitchConnection(con);
               }
                UpdateConnections();
                
           
         
        }

        private void face_DragEnter(object sender, DragEventArgs e)
        {
           
            
            if(e.Data.GetDataPresent(DataFormats.StringFormat))
            {                      
           CheckBox checkBoxSender = (CheckBox)sender;
                if(GetFaceNameFromCheckBox(checkBoxSender) != faceWhichDragged.faceName&& !NotAvailableConnections(faceWhichDragged.faceName).Contains(GetFaceNameFromCheckBox(checkBoxSender)))
                     e.Effect = DragDropEffects.Link;
             }
        }

        List<Face.faceSide> NotAvailableConnections(Face.faceSide faceToKnow)
        {
            List<Face.faceSide> notAvailableCon = new List<Face.faceSide>();
            switch (faceToKnow)
            {
                case Face.faceSide.distal:
                    notAvailableCon.Add(Face.faceSide.medial);
                    break;
                case Face.faceSide.edge:
                    notAvailableCon.Add(Face.faceSide.okklusion);
                    break;
                case Face.faceSide.lingual:
                    notAvailableCon.Add(Face.faceSide.palatinal);
                    notAvailableCon.Add(Face.faceSide.vestibular);
                    break;
                case Face.faceSide.medial:
                    notAvailableCon.Add(Face.faceSide.distal);
                    break;
                case Face.faceSide.okklusion:
                    notAvailableCon.Add(Face.faceSide.edge);
                    break;
                case Face.faceSide.palatinal:
                    notAvailableCon.Add(Face.faceSide.lingual);
                    notAvailableCon.Add(Face.faceSide.vestibular);
                    break;
                case Face.faceSide.vestibular:
                    notAvailableCon.Add(Face.faceSide.lingual);
                    notAvailableCon.Add(Face.faceSide.palatinal);
                    break;
            }
            return notAvailableCon;
        }

        Tooth.connect GetConnection(List<Face.faceSide> con)
        {
            if (con.Contains(Face.faceSide.vestibular))
            {
                if (con.Contains(Face.faceSide.medial))
                    return Tooth.connect.VM;
                if (con.Contains(Face.faceSide.okklusion) || con.Contains(Face.faceSide.edge))
                    return Tooth.connect.VO;
                if (con.Contains(Face.faceSide.distal))
                    return Tooth.connect.VD;
            }
            if (con.Contains(Face.faceSide.palatinal) || con.Contains(Face.faceSide.lingual))
            {
                if (con.Contains(Face.faceSide.medial))
                    return Tooth.connect.MN;
                if (con.Contains(Face.faceSide.okklusion) || con.Contains(Face.faceSide.edge))
                    return Tooth.connect.ON;
                if (con.Contains(Face.faceSide.distal))
                    return Tooth.connect.DN;
            }
            if (con.Contains(Face.faceSide.okklusion) || con.Contains(Face.faceSide.edge))
            {
                if (con.Contains(Face.faceSide.medial))
                    return Tooth.connect.MO;
                if (con.Contains(Face.faceSide.distal))
                    return Tooth.connect.OD;
            }

            return Tooth.connect.empty;

        }

        void UpdateConnections()
        {

            foreach (CheckBox conBut in connectButtons)
            {
                string name = conBut.Name.Substring(3, 2);

                if (currentFormTooth.Connections.Contains((Tooth.connect)Enum.Parse(typeof(Tooth.connect), name)))
                    conBut.BackColor = Color.Red;
                else conBut.BackColor = Color.Transparent;

            }
        }



#endregion

#region methodsOfFormUpdating
        void UpdateToothList()
        {

            listOfTooths.Items.Clear();//если добавился зуб тогда переписываем по новой список всех зубов в клише
            string[] alltooths = currentClishe.GetAllToothsNumbers();//извлекаем номера зубов  из клише через метод в массив строк с номерами зубов 
            foreach (string numt in alltooths)//перебираем массив с номерами зубов и 
            {
                listOfTooths.Items.Add(numt);//добавляем по порядку все зубы в список

            }

        }

        void UpdateTooth()
        {
            UpdateColor();
            UpdateTreatment();
        }
        void UpdatePapil()
        {
            if (currentFormTooth.distpapil) papilumDistalis.Checked = true;
            else papilumDistalis.Checked = false;
            if (currentFormTooth.medpapil) papilumMedialis.Checked = true;
            else papilumMedialis.Checked = false;

        }
        void UpdateTreatment()
        {

            applicationCheck.Checked = currentFormTooth.Treat.anest.applica;
            anestesyCheck.Checked = currentFormTooth.Treat.anest.carpul;
            applicationBox.SelectedItem = currentFormTooth.Treat.anest.usingApplication;
            anestBox.SelectedItem = currentFormTooth.Treat.anest.usingAnestetic;
            volumeAnest.Text = currentFormTooth.Treat.anest.mlOfAnest.ToString();
            healCheck.Checked = currentFormTooth.Treat.heal;
            isoCheck.Checked = currentFormTooth.Treat.iso;
           
            healFillBox.SelectedItem = currentFormTooth.Treat.usingHealFill;
            isoFillBox.SelectedItem = currentFormTooth.Treat.usingIsoFill;
            plombBox.SelectedItem = currentFormTooth.Treat.usingPlomb;
            string[] tempArray = currentFormTooth.Treat.usingColors.ToArray();
            colorList.SelectedItem = null;
            foreach (string col in tempArray)
            {
                colorList.SelectedItem = col;
            }

        }

        void UpdateUsingColors()
        {
            colorList.DataSource = null;
            colorList.DataSource = ((Materials)plombBox.SelectedItem).colors;
            colorList.DisplayMember = "Name";
        }
      
        /// <summary>
        /// Метод возвращает имя поверхности с нужным названием по чекбоксу
        /// </summary>
        /// <param name="chkb">Чекбокс который нажали</param>
        /// <returns>Имя поверхности</returns>
        Face.faceSide GetFaceNameFromCheckBox(CheckBox chkb)
        {

            switch (chkb.Name)//проверяем имя чекбокса (чекбокс отлавливается еще на событии открытия меню) на котором кликнули и по имени выбираем какую поверхность будем менять(диагноз выставлять)
            {
                case "vestF": return Face.faceSide.vestibular;//у каждой поверхности (отдельный класс поверхностей Faces), есть поле называемое Имя - оно является типом данных enum faceSide

                case "medF": return Face.faceSide.medial;

                case "distF": return Face.faceSide.distal;

                case "okklF":
                    if (currentFormTooth.isFront) return Face.faceSide.edge;//если зуб с которым сейчас работаем передний то окклюзионная поверхность меняется на режущий край
                    else return Face.faceSide.okklusion;

                case "orF": if (currentFormTooth.kvadrantNumb == 1 || currentFormTooth.kvadrantNumb == 2) return Face.faceSide.palatinal;//если же зуб верхний - тогда оральную поверхность называем небной, а нижние зубы -язычной
                    else return Face.faceSide.lingual;

                default: return Face.faceSide.okklusion;

            }
        }
      /// <summary>
      /// Получаем цвет для кнопки, в зависимости от глубины заболевания на данной поверхности.
      /// </summary>
      /// <param name="chkb">Кнопка(поверхность)</param>
      /// <returns>Цвет для кнопки </returns>
         Color GetColorForButton(CheckBox chkb)
        {
            Color col = Color.Transparent;//цвет
            
            Face.faceSide faceName = GetFaceNameFromCheckBox(chkb);//получаем название поверхности от кнопки
            Face face = currentFormTooth.GetFace(faceName, false);//создаем поверхность и находим ее у зуба, в случае если у зуба такая поверхность еще не создана и не описана, возвращает NULL
            if (face == null || face.GetConditionsOfFace().Count == 0) col = Color.Transparent;//если поверхностей еще нет у зуба, тогда оставляем цвет прозрачным и три линии перпендикулярны друг другу.
            else
            {
                int minLayer = face.GetConditionsOfFace().Min(f => f.layer);
                List<Condition> minLayerCondiList = face.GetConditionsOfFace().Where(c => c.layer == minLayer).ToList();
                List<Condition> maxDepthCondiList = minLayerCondiList.Where(c => c.Depth == (minLayerCondiList.Max(g => g.Depth))).ToList();

                col = maxDepthCondiList[0].colorOfCondition;
            }

            //else {
            //    Condition.conditionOfFace ds = new Condition.conditionOfFace();//создаем переменную Диагноз  поверхности.
            //    foreach (Condition ill in face.GetConditionsOfFace())//перебираем все заболевания поверхности
            //    {
            //        if (ds < ill.NameOfIll) ds = ill.NameOfIll;
            //    }

            //    switch (ds)// определяем цвет кнопки по диагнозу
            //    {
                
            //        case Condition.conditionOfFace.car: col = Color.Red;
            //            break;

            //        case Condition.conditionOfFace.plomb: col = Color.Gold;
            //            break;

            //        case Condition.conditionOfFace.defect: col = Color.DarkGray;
            //            break;


            //        case Condition.conditionOfFace.contact: col = Color.Cyan;
            //            break;

            //        case Condition.conditionOfFace.klinDef: col = Color.LimeGreen;
            //            break;
            //        default: col = Color.Transparent;
            //            break;

            //    }
             //}

            
           

        
            return col;
        }
        /// <summary>
        /// Получить цвет для окаршивания панели в зависимости от глубины поражения всего зуба.
        /// </summary>
        /// <param name="tooth">Зуб для которого получить цвет.</param>
        /// <returns>Возвращает 4 варианта цвета</returns>
         Color GetColorForCariesTab(Tooth tooth)
        {

            Color col = Color.Transparent;
            
                switch (tooth.GetToothIllDepth())
                {
                    case Condition.DepthOfCondition.pov: col = Color.WhiteSmoke;
                        depthLabel.Text = "Глубина: поверхностный";
                        break;
                    case Condition.DepthOfCondition.sred: col = Color.Gainsboro;
                        depthLabel.Text = "Глубина: средний";
                        break;
                    case Condition.DepthOfCondition.glub: col = Color.Silver;
                        depthLabel.Text = "Глубина: глубокий";
                        break;
                    case Condition.DepthOfCondition.giper: col = Color.RosyBrown;
                        depthLabel.Text = "Глубина: гиперемия пульпы";
                        break;
                    case Condition.DepthOfCondition.none: col = Color.Transparent;
                        depthLabel.Text = "Глубина: ";
                        break;
                }
            
            return col;
        }


         void UpdateColor()
         {
             panel1.BackColor = GetColorForCariesTab(currentFormTooth);
             foreach (CheckBox chkb in poverhnosties)
             {
                 chkb.BackColor = GetColorForButton(chkb);
                 
             }
             UpdateConnections();
             UpdatePapil(); 
         }

        
#endregion

#region faceMethods
         private void AnyToolStripMenuItem_Clicked(object sender, EventArgs e)//событие происходит при нажатии любого пункта выпадающего меню
         {
             Face currFace = currentFormTooth.GetFace(GetFaceNameFromCheckBox(currentChckBx), true);//получаем поверхность у зуба
             ToolStripMenuItem item = (ToolStripMenuItem)sender;
            
             string firstItem = item.Text;//получаем имя item которое мы кликнули(они называются точь в точь так же как и названия заболеваний в классе enum - должны совпадать!!!)
             Condition currConditionForFace = KlisheParams.conditionOfFaceList.Find(c => c.Name == firstItem.ToString());//у каждой поверхности есть список заболеваний которые она в себе несет - все заболевания вынесены в класс Illness
             if (currConditionForFace == null)
             {
              
                 string secondItem = ((ToolStripMenuItem)sender).OwnerItem.Text;
                 currConditionForFace = KlisheParams.conditionOfFaceList.Find(c => c.Name == secondItem.ToString());
                 currConditionForFace.SetDepth(firstItem);
             }


             currFace.SwitchCondition(currConditionForFace);//и назначаем данной поверхности данное заболевание

             currentFormTooth.AddFace(currFace, false);//и добавляем(или заменяем если уже есть такая) поверхность к зубу с которым в данный момент работаем
             UpdateColor();
            
            

         }



         private void contextMenuStrip1_Opened(object sender, EventArgs e)
         {

             currentChckBx = (CheckBox)((ContextMenuStrip)sender).SourceControl;
             Face.faceSide clickedFace = GetFaceNameFromCheckBox(currentChckBx);

             Face currFace = currentFormTooth.GetFace(GetFaceNameFromCheckBox(currentChckBx), true);//получаем поверхность у зуба
             //foreach (Condition cond in currFace.GetConditionsOfFace())
             //{
                 
             //}
             //List<ToolStripItem> needToCheckItems = new List<ToolStripItem>();
               
             foreach (ToolStripMenuItem tsmi in FaceConditionsMenu.Items)
             {
                 Condition condWhichHaveOnFace=currFace.GetConditionsOfFace().Find(c => c.Name == tsmi.Text);

                 if (condWhichHaveOnFace == null)
                 {
                     tsmi.Checked = false;
                     if (tsmi.DropDownItems.Count > 0)
                     {
                         foreach (ToolStripMenuItem ts in tsmi.DropDownItems)
                         {
                             ts.Checked = false;
                         }
                     }
                 }
                 else
                 {
                     tsmi.Checked = true;

                     if (tsmi.DropDownItems.Count > 0)
                     {
                         foreach (ToolStripMenuItem ts in tsmi.DropDownItems)
                         {
                             //condWhichHaveOnFace = currFace.GetConditionsOfFace().Find(c => c.GetCurrentDepth() == ts.Text);
                             if (condWhichHaveOnFace.GetCurrentDepth() == ts.Text) ts.Checked = true;
                             else ts.Checked = false;
                         }
                     }

                 }
                 Condition cond = KlisheParams.conditionOfFaceList.Find(c => c.Name == tsmi.Text);
                 

                 if (cond != null)
                 {
                    
                     if (cond.availableFaces.Contains(clickedFace)||cond.availableFaces.Contains(Face.faceSide.all))
                     {
                         tsmi.Visible = true;
                     }
                     else
                     {
                         tsmi.Visible = false;
                     }
                 }
             }
       

         }

        
         private void anyFace_MouseEnter(object sender, EventArgs e)
         {
             //currentChckBx = (CheckBox)((ContextMenuStrip)sender).SourceControl;

         }

         private void anyFace_MouseHover(object sender, EventArgs e)
         {
             currentChckBx = (CheckBox)sender;

             Face currFace = currentFormTooth.GetFace(GetFaceNameFromCheckBox(currentChckBx), false);
             string info = "";
             if (currFace != null)
             {


                 List<Condition> curFaceCond = currFace.GetConditionsOfFace();
                 int indexer = curFaceCond.Count;
                 foreach (Condition cond in curFaceCond)
                 {
                     info += cond.Name + " " + cond.GetCurrentDepth();
                     if (indexer > 1) info += "\n";
                     indexer--;
                 }


             }
             toolTip1.SetToolTip(currentChckBx, info);

         }

         private void toolTip1_Popup(object sender, PopupEventArgs e)
         {

         }


#endregion

       

     
#region checkedChanged code

        private void conAny_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxSender = (CheckBox)sender;
            string name = checkBoxSender.Name.Substring(3, 2);
            Tooth.connect con = (Tooth.connect)Enum.Parse(typeof(Tooth.connect), name);
            currentFormTooth.SwitchConnection(con);
            if (!currentFormTooth.Connections.Contains(con))
            {
               
                checkBoxSender.BackColor = Color.Transparent;
            }
            else
            {
                
                checkBoxSender.BackColor = Color.Red;
            }

        }

        private void ruinMoreHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (ruinMoreHalf.Checked)
            {
                ruinLessHalf.Enabled = false;
                currentFormTooth.ruin = 2;
            }
            else
            {
                ruinLessHalf.Enabled = true;
                currentFormTooth.ruin = 0;
            }
        }

        private void ruinLessHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (ruinLessHalf.Checked)
            {
                ruinMoreHalf.Enabled = false;
                currentFormTooth.ruin = 1;
            }
            else
            {
                ruinMoreHalf.Enabled = true;
                currentFormTooth.ruin = 0;
            }
        }

        private void papilumMedialis_CheckedChanged(object sender, EventArgs e)
        {
            currentFormTooth.medpapil = papilumMedialis.Checked;
            if (papilumMedialis.Checked == true) papilumMedialis.BackColor = Color.Red;
            else papilumMedialis.BackColor = Color.Transparent;
        }

        private void papilumDistalis_CheckedChanged(object sender, EventArgs e)
        {
            currentFormTooth.distpapil = papilumDistalis.Checked;
            if (papilumDistalis.Checked == true) papilumDistalis.BackColor = Color.Red;
            else papilumDistalis.BackColor = Color.Transparent;
        }

        private void application_CheckedChanged(object sender, EventArgs e)
        {
            applicationBox.Enabled = applicationCheck.Checked;
            currentFormTooth.Treat.anest.applica = applicationCheck.Checked;
        }

        private void anestesy_CheckedChanged(object sender, EventArgs e)
        {
            anestBox.Enabled = anestesyCheck.Checked;
            currentFormTooth.Treat.anest.carpul = anestesyCheck.Checked;
        }

        private void heal_CheckedChanged(object sender, EventArgs e)
        {
            healFillBox.Enabled = healCheck.Checked;
            currentFormTooth.Treat.heal = healCheck.Checked;
        }

        private void isolation_CheckedChanged(object sender, EventArgs e)
        {
            isoFillBox.Enabled = isoCheck.Checked;
            currentFormTooth.Treat.iso = isoCheck.Checked;
        }

        #endregion


    


#region selectedIndexChanged code

        private void listOfTooths_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listOfTooths.SelectedItem != null) numberOfToothText.Text = listOfTooths.SelectedItem.ToString();


        }


        private void plombBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (plombBox.DataSource != null)
            {
                currentFormTooth.Treat.usingPlomb = KlisheParams.findMaterial(((Materials)plombBox.SelectedItem).Name);
                isoFillBox.SelectedValue = currentFormTooth.Treat.defIsoFill;


                if (((Materials)plombBox.SelectedItem) != null)
                {
                    if ((((Materials)plombBox.SelectedItem).colors).Count > 0)
                    {
                        colorList.Enabled = true;
                        colorLabel.Enabled = true;
                        UpdateUsingColors();

                    }
                    else
                    {

                        colorList.Enabled = false;
                        colorLabel.Enabled = false;
                    }
                }
            }
        }



        private void applicationBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFormTooth.Treat.anest.usingApplication = (Anesthetics)applicationBox.SelectedItem;
        }

        private void anestBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFormTooth.Treat.anest.usingAnestetic = (Anesthetics)applicationBox.SelectedItem;
        }

        private void testColorList_SelectedIndexChanged(object sender, EventArgs e)
        {


            currentFormTooth.Treat.usingColors.Clear();
            foreach (string col in colorList.SelectedItems)
            {

                currentFormTooth.Treat.usingColors.Add(col);
            }

        }

        private void healFillBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFormTooth.Treat.usingHealFill = (Materials)healFillBox.SelectedItem;
        }

        private void isoFillBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFormTooth.Treat.usingIsoFill = (Materials)isoFillBox.SelectedItem;

        }
        #endregion

#region Clicks
        

        private void AddTooth_Click(object sender, EventArgs e)//нажатие кнопки Добавить зуб
        {

            if (numberOfToothText.Text.Length == 2)//если цифра в окне введения номера зуба двузначная тогда добавляем зуб
            {
                Tooth copyTooth = new Tooth(currentFormTooth);
                currentClishe.AddTooth(copyTooth);//в клише добавляем зуб (проверяем добавился ли)

                UpdateToothList();
                
                numberOfToothText.Text = "";

                currentFormTooth = new Tooth();
                UpdateColor();
                UpdateTreatment();
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            richTextBox2.Text = "";
            richTextBox2.Text = currentClishe.GetText();

        }

        private void deleteNumber_Click(object sender, EventArgs e)
        {
            if(listOfTooths.SelectedItem !=null)
            currentClishe.RemoveTooth(Byte.Parse(listOfTooths.SelectedItem.ToString()));
            listOfTooths.Items.Remove(listOfTooths.SelectedItem);
        }

        private void addMaterial_Click(object sender, EventArgs e)
        {
            OptionsForm Form2 = new OptionsForm(2);
            Form2.Owner = this;
            Form2.ShowDialog();
        }

        private void CleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Face currFace = currentFormTooth.GetFace(GetFaceNameFromCheckBox(currentChckBx), false);
            if (currFace != null) currFace.Clean();
            currentFormTooth.RenewDiagnosis();
            UpdateColor();
        }

       

      

        #endregion

      
#region empty code
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void colorList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void distF_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FaceConditionsMenu_Opening(object sender, CancelEventArgs e)
        {

        }
        private void vestF_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void colorBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private void erase_Click(object sender, EventArgs e)
        {
            Tooth tempTooth = new Tooth(currentFormTooth.number);//создаем временный нулевой зуб
            currentFormTooth = currentClishe.GetTooth(currentFormTooth.number);//проверяем есть ли в клише уже такой зуб
            if (currentFormTooth != null) currentClishe.AddTooth(currentFormTooth.number);//если есть, тогда обнуляем его в клише
                currentFormTooth = tempTooth;//и обнуляем в любом случае текущий зуб

            
            //currentClishe.AddTooth(currentFormTooth.number);
            //currentFormTooth = currentClishe.GetTooth(currentFormTooth.number);
            UpdateTooth();
        }

        private void numberOfToothText_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void rvg_CheckedChanged(object sender, EventArgs e)
        {
            currentClishe.haveRvg = rvg.Checked;
        }
       
 
        

       

     
        
    }
}
