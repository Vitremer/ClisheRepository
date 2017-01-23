namespace KlisheNamespace
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.button1 = new System.Windows.Forms.Button();
            this.vestF = new System.Windows.Forms.CheckBox();
            this.FaceConditionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ConditionsFaceContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.кариесToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.povcar_pov = new System.Windows.Forms.ToolStripMenuItem();
            this.car_sred = new System.Windows.Forms.ToolStripMenuItem();
            this.car_glub = new System.Windows.Forms.ToolStripMenuItem();
            this.car_giper = new System.Windows.Forms.ToolStripMenuItem();
            this.contact = new System.Windows.Forms.ToolStripMenuItem();
            this.дефектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defect_pov = new System.Windows.Forms.ToolStripMenuItem();
            this.defect_sred = new System.Windows.Forms.ToolStripMenuItem();
            this.defect_glub = new System.Windows.Forms.ToolStripMenuItem();
            this.defect_giper = new System.Windows.Forms.ToolStripMenuItem();
            this.plomb = new System.Windows.Forms.ToolStripMenuItem();
            this.plomb_pov = new System.Windows.Forms.ToolStripMenuItem();
            this.plomb_sred = new System.Windows.Forms.ToolStripMenuItem();
            this.plomb_glub = new System.Windows.Forms.ToolStripMenuItem();
            this.plomb_giper = new System.Windows.Forms.ToolStripMenuItem();
            this.клиновидныйДефектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klinDef_pov = new System.Windows.Forms.ToolStripMenuItem();
            this.klinDef_sred = new System.Windows.Forms.ToolStripMenuItem();
            this.klinDef_glub = new System.Windows.Forms.ToolStripMenuItem();
            this.CleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NumTooth = new System.Windows.Forms.Label();
            this.AddTooth = new System.Windows.Forms.Button();
            this.numberOfToothText = new System.Windows.Forms.MaskedTextBox();
            this.TabPanel = new System.Windows.Forms.TabControl();
            this.Caries = new System.Windows.Forms.TabPage();
            this.rvg = new System.Windows.Forms.CheckBox();
            this.deleteNumber = new System.Windows.Forms.Button();
            this.listOfTooths = new System.Windows.Forms.ListBox();
            this.ToothList = new System.Windows.Forms.Label();
            this.Osmotr = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cervF = new System.Windows.Forms.CheckBox();
            this.erase = new System.Windows.Forms.Button();
            this.addAnestesy = new System.Windows.Forms.Button();
            this.colorLabel = new System.Windows.Forms.Label();
            this.addMaterial = new System.Windows.Forms.Button();
            this.plombBox = new System.Windows.Forms.ComboBox();
            this.colorList = new System.Windows.Forms.ListBox();
            this.plombir = new System.Windows.Forms.Label();
            this.isoFillBox = new System.Windows.Forms.ComboBox();
            this.papilumDistalis = new System.Windows.Forms.CheckBox();
            this.papilumMedialis = new System.Windows.Forms.CheckBox();
            this.healFillBox = new System.Windows.Forms.ComboBox();
            this.ml = new System.Windows.Forms.Label();
            this.volumeAnest = new System.Windows.Forms.MaskedTextBox();
            this.anestesyCheck = new System.Windows.Forms.CheckBox();
            this.applicationCheck = new System.Windows.Forms.CheckBox();
            this.isoCheck = new System.Windows.Forms.CheckBox();
            this.healCheck = new System.Windows.Forms.CheckBox();
            this.anestBox = new System.Windows.Forms.ComboBox();
            this.applicationBox = new System.Windows.Forms.ComboBox();
            this.ruinLessHalf = new System.Windows.Forms.CheckBox();
            this.ruinMoreHalf = new System.Windows.Forms.CheckBox();
            this.depthLabel = new System.Windows.Forms.Label();
            this.orF = new System.Windows.Forms.CheckBox();
            this.medF = new System.Windows.Forms.CheckBox();
            this.distF = new System.Windows.Forms.CheckBox();
            this.okklF = new System.Windows.Forms.CheckBox();
            this.conVO = new System.Windows.Forms.CheckBox();
            this.ConnectionsCondContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conVD = new System.Windows.Forms.CheckBox();
            this.conVM = new System.Windows.Forms.CheckBox();
            this.conDN = new System.Windows.Forms.CheckBox();
            this.conMN = new System.Windows.Forms.CheckBox();
            this.conMO = new System.Windows.Forms.CheckBox();
            this.conOD = new System.Windows.Forms.CheckBox();
            this.conON = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ConditionsFaceContextMenu.SuspendLayout();
            this.TabPanel.SuspendLayout();
            this.Caries.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 483);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Собрать клише";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // vestF
            // 
            this.vestF.AllowDrop = true;
            this.vestF.Appearance = System.Windows.Forms.Appearance.Button;
            this.vestF.AutoSize = true;
            this.vestF.BackColor = System.Drawing.Color.Transparent;
            this.vestF.ContextMenuStrip = this.FaceConditionsMenu;
            this.vestF.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.vestF.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.vestF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.vestF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.vestF.Location = new System.Drawing.Point(137, 24);
            this.vestF.Name = "vestF";
            this.vestF.Size = new System.Drawing.Size(94, 23);
            this.vestF.TabIndex = 8;
            this.vestF.Text = "Вестибулярная";
            this.vestF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.vestF.UseVisualStyleBackColor = false;
            this.vestF.MouseEnter += new System.EventHandler(this.anyFace_MouseEnter);
            this.vestF.DragDrop += new System.Windows.Forms.DragEventHandler(this.face_DragDrop);
            this.vestF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.facePress_MouseDown);
            this.vestF.CheckedChanged += new System.EventHandler(this.vestF_CheckedChanged);
            this.vestF.MouseHover += new System.EventHandler(this.anyFace_MouseHover);
            this.vestF.DragEnter += new System.Windows.Forms.DragEventHandler(this.face_DragEnter);
            // 
            // FaceConditionsMenu
            // 
            this.FaceConditionsMenu.Name = "FaceConditionsMenu";
            this.FaceConditionsMenu.Size = new System.Drawing.Size(61, 4);
            this.FaceConditionsMenu.Opened += new System.EventHandler(this.ConditionsMenuItem_Opened);
            this.FaceConditionsMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ConditionsFaceContextMenu
            // 
            this.ConditionsFaceContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кариесToolStripMenuItem,
            this.contact,
            this.дефектToolStripMenuItem,
            this.plomb,
            this.клиновидныйДефектToolStripMenuItem,
            this.CleanToolStripMenuItem});
            this.ConditionsFaceContextMenu.Name = "contextMenuStrip1";
            this.ConditionsFaceContextMenu.Size = new System.Drawing.Size(201, 136);
            this.ConditionsFaceContextMenu.Opened += new System.EventHandler(this.ConditionsMenuItem_Opened);
            this.ConditionsFaceContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // кариесToolStripMenuItem
            // 
            this.кариесToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.povcar_pov,
            this.car_sred,
            this.car_glub,
            this.car_giper});
            this.кариесToolStripMenuItem.Name = "кариесToolStripMenuItem";
            this.кариесToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.кариесToolStripMenuItem.Text = "Кариес";
            // 
            // povcar_pov
            // 
            this.povcar_pov.Name = "povcar_pov";
            this.povcar_pov.Size = new System.Drawing.Size(180, 22);
            this.povcar_pov.Text = "Поверхностный";
            this.povcar_pov.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // car_sred
            // 
            this.car_sred.Name = "car_sred";
            this.car_sred.Size = new System.Drawing.Size(180, 22);
            this.car_sred.Text = "Средний";
            this.car_sred.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // car_glub
            // 
            this.car_glub.Name = "car_glub";
            this.car_glub.Size = new System.Drawing.Size(180, 22);
            this.car_glub.Text = "Глубокий";
            this.car_glub.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // car_giper
            // 
            this.car_giper.Name = "car_giper";
            this.car_giper.Size = new System.Drawing.Size(180, 22);
            this.car_giper.Text = "Гиперемия пульпы";
            this.car_giper.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // contact
            // 
            this.contact.Name = "contact";
            this.contact.Size = new System.Drawing.Size(200, 22);
            this.contact.Text = "Несост.контакт";
            this.contact.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // дефектToolStripMenuItem
            // 
            this.дефектToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defect_pov,
            this.defect_sred,
            this.defect_glub,
            this.defect_giper});
            this.дефектToolStripMenuItem.Name = "дефектToolStripMenuItem";
            this.дефектToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.дефектToolStripMenuItem.Text = "Дефект(пломбы, скол)";
            // 
            // defect_pov
            // 
            this.defect_pov.Name = "defect_pov";
            this.defect_pov.Size = new System.Drawing.Size(207, 22);
            this.defect_pov.Text = "В эмали";
            this.defect_pov.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // defect_sred
            // 
            this.defect_sred.Name = "defect_sred";
            this.defect_sred.Size = new System.Drawing.Size(207, 22);
            this.defect_sred.Text = "В плащевом дентине";
            this.defect_sred.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // defect_glub
            // 
            this.defect_glub.Name = "defect_glub";
            this.defect_glub.Size = new System.Drawing.Size(207, 22);
            this.defect_glub.Text = "Околопульпарный";
            this.defect_glub.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // defect_giper
            // 
            this.defect_giper.Name = "defect_giper";
            this.defect_giper.Size = new System.Drawing.Size(207, 22);
            this.defect_giper.Text = "Сообщение с полостью";
            this.defect_giper.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // plomb
            // 
            this.plomb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plomb_pov,
            this.plomb_sred,
            this.plomb_glub,
            this.plomb_giper});
            this.plomb.Name = "plomb";
            this.plomb.Size = new System.Drawing.Size(200, 22);
            this.plomb.Text = "Пломба";
            // 
            // plomb_pov
            // 
            this.plomb_pov.Name = "plomb_pov";
            this.plomb_pov.Size = new System.Drawing.Size(234, 22);
            this.plomb_pov.Text = "В эмали";
            this.plomb_pov.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // plomb_sred
            // 
            this.plomb_sred.Name = "plomb_sred";
            this.plomb_sred.Size = new System.Drawing.Size(234, 22);
            this.plomb_sred.Text = "В плащевом дентине";
            this.plomb_sred.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // plomb_glub
            // 
            this.plomb_glub.Name = "plomb_glub";
            this.plomb_glub.Size = new System.Drawing.Size(234, 22);
            this.plomb_glub.Text = "В околопульпарном дентине";
            this.plomb_glub.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // plomb_giper
            // 
            this.plomb_giper.Name = "plomb_giper";
            this.plomb_giper.Size = new System.Drawing.Size(234, 22);
            this.plomb_giper.Text = "Сообщение с полостью";
            this.plomb_giper.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // клиновидныйДефектToolStripMenuItem
            // 
            this.клиновидныйДефектToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.klinDef_pov,
            this.klinDef_sred,
            this.klinDef_glub});
            this.клиновидныйДефектToolStripMenuItem.Name = "клиновидныйДефектToolStripMenuItem";
            this.клиновидныйДефектToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.клиновидныйДефектToolStripMenuItem.Text = "Клиновидный дефект";
            this.клиновидныйДефектToolStripMenuItem.Visible = false;
            // 
            // klinDef_pov
            // 
            this.klinDef_pov.Name = "klinDef_pov";
            this.klinDef_pov.Size = new System.Drawing.Size(127, 22);
            this.klinDef_pov.Text = "В эмали";
            this.klinDef_pov.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // klinDef_sred
            // 
            this.klinDef_sred.Name = "klinDef_sred";
            this.klinDef_sred.Size = new System.Drawing.Size(127, 22);
            this.klinDef_sred.Text = "Средний";
            this.klinDef_sred.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // klinDef_glub
            // 
            this.klinDef_glub.Name = "klinDef_glub";
            this.klinDef_glub.Size = new System.Drawing.Size(127, 22);
            this.klinDef_glub.Text = "Глубокий";
            this.klinDef_glub.Click += new System.EventHandler(this.AnyToolStripMenuItem_Clicked);
            // 
            // CleanToolStripMenuItem
            // 
            this.CleanToolStripMenuItem.Name = "CleanToolStripMenuItem";
            this.CleanToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.CleanToolStripMenuItem.Text = "Очистить поверхность";
            this.CleanToolStripMenuItem.Click += new System.EventHandler(this.CleanToolStripMenuItem_Click);
            // 
            // NumTooth
            // 
            this.NumTooth.AutoSize = true;
            this.NumTooth.Location = new System.Drawing.Point(3, 3);
            this.NumTooth.Name = "NumTooth";
            this.NumTooth.Size = new System.Drawing.Size(67, 13);
            this.NumTooth.TabIndex = 14;
            this.NumTooth.Text = "Номер зуба";
            // 
            // AddTooth
            // 
            this.AddTooth.Location = new System.Drawing.Point(32, 19);
            this.AddTooth.Name = "AddTooth";
            this.AddTooth.Size = new System.Drawing.Size(71, 23);
            this.AddTooth.TabIndex = 15;
            this.AddTooth.Text = "добавить";
            this.AddTooth.UseVisualStyleBackColor = true;
            this.AddTooth.Click += new System.EventHandler(this.AddTooth_Click);
            // 
            // numberOfToothText
            // 
            this.numberOfToothText.Location = new System.Drawing.Point(6, 21);
            this.numberOfToothText.Mask = "##";
            this.numberOfToothText.Name = "numberOfToothText";
            this.numberOfToothText.Size = new System.Drawing.Size(20, 20);
            this.numberOfToothText.TabIndex = 16;
            this.numberOfToothText.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.numberOfToothText_MaskInputRejected);
            this.numberOfToothText.TextChanged += new System.EventHandler(this.numberOfToothText_TextChanged);
            // 
            // TabPanel
            // 
            this.TabPanel.Controls.Add(this.Caries);
            this.TabPanel.Controls.Add(this.tabPage2);
            this.TabPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TabPanel.ItemSize = new System.Drawing.Size(50, 18);
            this.TabPanel.Location = new System.Drawing.Point(12, 9);
            this.TabPanel.Name = "TabPanel";
            this.TabPanel.SelectedIndex = 0;
            this.TabPanel.Size = new System.Drawing.Size(374, 472);
            this.TabPanel.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabPanel.TabIndex = 17;
            this.TabPanel.TabStop = false;
            // 
            // Caries
            // 
            this.Caries.AutoScroll = true;
            this.Caries.BackColor = System.Drawing.Color.White;
            this.Caries.Controls.Add(this.rvg);
            this.Caries.Controls.Add(this.deleteNumber);
            this.Caries.Controls.Add(this.listOfTooths);
            this.Caries.Controls.Add(this.ToothList);
            this.Caries.Controls.Add(this.Osmotr);
            this.Caries.Controls.Add(this.numberOfToothText);
            this.Caries.Controls.Add(this.NumTooth);
            this.Caries.Controls.Add(this.AddTooth);
            this.Caries.Controls.Add(this.panel1);
            this.Caries.Location = new System.Drawing.Point(4, 22);
            this.Caries.Name = "Caries";
            this.Caries.Padding = new System.Windows.Forms.Padding(3);
            this.Caries.Size = new System.Drawing.Size(366, 446);
            this.Caries.TabIndex = 0;
            this.Caries.Text = "Кариес";
            // 
            // rvg
            // 
            this.rvg.Appearance = System.Windows.Forms.Appearance.Button;
            this.rvg.AutoSize = true;
            this.rvg.Location = new System.Drawing.Point(228, 23);
            this.rvg.Name = "rvg";
            this.rvg.Size = new System.Drawing.Size(56, 23);
            this.rvg.TabIndex = 39;
            this.rvg.Text = "Снимок";
            this.rvg.UseVisualStyleBackColor = true;
            this.rvg.CheckedChanged += new System.EventHandler(this.rvg_CheckedChanged);
            // 
            // deleteNumber
            // 
            this.deleteNumber.Location = new System.Drawing.Point(134, 18);
            this.deleteNumber.Name = "deleteNumber";
            this.deleteNumber.Size = new System.Drawing.Size(24, 23);
            this.deleteNumber.TabIndex = 23;
            this.deleteNumber.Text = "-";
            this.deleteNumber.UseVisualStyleBackColor = true;
            this.deleteNumber.Click += new System.EventHandler(this.deleteNumber_Click);
            // 
            // listOfTooths
            // 
            this.listOfTooths.FormattingEnabled = true;
            this.listOfTooths.Location = new System.Drawing.Point(164, 3);
            this.listOfTooths.Name = "listOfTooths";
            this.listOfTooths.Size = new System.Drawing.Size(41, 43);
            this.listOfTooths.TabIndex = 22;
            this.listOfTooths.SelectedIndexChanged += new System.EventHandler(this.listOfTooths_SelectedIndexChanged);
            // 
            // ToothList
            // 
            this.ToothList.AutoSize = true;
            this.ToothList.Location = new System.Drawing.Point(109, 3);
            this.ToothList.Name = "ToothList";
            this.ToothList.Size = new System.Drawing.Size(36, 13);
            this.ToothList.TabIndex = 21;
            this.ToothList.Text = "Зубы:";
            // 
            // Osmotr
            // 
            this.Osmotr.Appearance = System.Windows.Forms.Appearance.Button;
            this.Osmotr.AutoSize = true;
            this.Osmotr.Location = new System.Drawing.Point(290, 23);
            this.Osmotr.Name = "Osmotr";
            this.Osmotr.Size = new System.Drawing.Size(56, 23);
            this.Osmotr.TabIndex = 20;
            this.Osmotr.Text = "Осмотр";
            this.Osmotr.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.cervF);
            this.panel1.Controls.Add(this.erase);
            this.panel1.Controls.Add(this.addAnestesy);
            this.panel1.Controls.Add(this.colorLabel);
            this.panel1.Controls.Add(this.addMaterial);
            this.panel1.Controls.Add(this.plombBox);
            this.panel1.Controls.Add(this.colorList);
            this.panel1.Controls.Add(this.plombir);
            this.panel1.Controls.Add(this.isoFillBox);
            this.panel1.Controls.Add(this.papilumDistalis);
            this.panel1.Controls.Add(this.papilumMedialis);
            this.panel1.Controls.Add(this.healFillBox);
            this.panel1.Controls.Add(this.ml);
            this.panel1.Controls.Add(this.volumeAnest);
            this.panel1.Controls.Add(this.anestesyCheck);
            this.panel1.Controls.Add(this.applicationCheck);
            this.panel1.Controls.Add(this.isoCheck);
            this.panel1.Controls.Add(this.healCheck);
            this.panel1.Controls.Add(this.anestBox);
            this.panel1.Controls.Add(this.applicationBox);
            this.panel1.Controls.Add(this.ruinLessHalf);
            this.panel1.Controls.Add(this.ruinMoreHalf);
            this.panel1.Controls.Add(this.depthLabel);
            this.panel1.Controls.Add(this.orF);
            this.panel1.Controls.Add(this.medF);
            this.panel1.Controls.Add(this.distF);
            this.panel1.Controls.Add(this.okklF);
            this.panel1.Controls.Add(this.vestF);
            this.panel1.Controls.Add(this.conVO);
            this.panel1.Controls.Add(this.conVD);
            this.panel1.Controls.Add(this.conVM);
            this.panel1.Controls.Add(this.conDN);
            this.panel1.Controls.Add(this.conMN);
            this.panel1.Controls.Add(this.conMO);
            this.panel1.Controls.Add(this.conOD);
            this.panel1.Controls.Add(this.conON);
            this.panel1.Location = new System.Drawing.Point(3, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 393);
            this.panel1.TabIndex = 0;
            // 
            // cervF
            // 
            this.cervF.AllowDrop = true;
            this.cervF.Appearance = System.Windows.Forms.Appearance.Button;
            this.cervF.AutoSize = true;
            this.cervF.BackColor = System.Drawing.Color.Transparent;
            this.cervF.ContextMenuStrip = this.FaceConditionsMenu;
            this.cervF.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cervF.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.cervF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.cervF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cervF.Location = new System.Drawing.Point(139, 0);
            this.cervF.Name = "cervF";
            this.cervF.Size = new System.Drawing.Size(80, 23);
            this.cervF.TabIndex = 39;
            this.cervF.Text = "Пришеечная";
            this.cervF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cervF.UseVisualStyleBackColor = false;
            this.cervF.MouseEnter += new System.EventHandler(this.anyFace_MouseEnter);
            this.cervF.DragDrop += new System.Windows.Forms.DragEventHandler(this.face_DragDrop);
            this.cervF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.facePress_MouseDown);
            this.cervF.MouseHover += new System.EventHandler(this.anyFace_MouseHover);
            this.cervF.DragEnter += new System.Windows.Forms.DragEventHandler(this.face_DragEnter);
            // 
            // erase
            // 
            this.erase.Location = new System.Drawing.Point(3, 16);
            this.erase.Name = "erase";
            this.erase.Size = new System.Drawing.Size(46, 23);
            this.erase.TabIndex = 38;
            this.erase.Text = "Сброс";
            this.erase.UseVisualStyleBackColor = true;
            this.erase.Click += new System.EventHandler(this.erase_Click);
            // 
            // addAnestesy
            // 
            this.addAnestesy.Location = new System.Drawing.Point(181, 199);
            this.addAnestesy.Name = "addAnestesy";
            this.addAnestesy.Size = new System.Drawing.Size(160, 23);
            this.addAnestesy.TabIndex = 37;
            this.addAnestesy.Text = "Редактировать анестетики";
            this.addAnestesy.UseVisualStyleBackColor = true;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Enabled = false;
            this.colorLabel.Location = new System.Drawing.Point(3, 319);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(49, 13);
            this.colorLabel.TabIndex = 31;
            this.colorLabel.Text = "Оттенки";
            // 
            // addMaterial
            // 
            this.addMaterial.Location = new System.Drawing.Point(247, 334);
            this.addMaterial.Name = "addMaterial";
            this.addMaterial.Size = new System.Drawing.Size(94, 48);
            this.addMaterial.TabIndex = 36;
            this.addMaterial.Text = "Редактировать материалы";
            this.addMaterial.UseVisualStyleBackColor = true;
            this.addMaterial.Click += new System.EventHandler(this.addMaterial_Click);
            // 
            // plombBox
            // 
            this.plombBox.FormattingEnabled = true;
            this.plombBox.Location = new System.Drawing.Point(152, 287);
            this.plombBox.Name = "plombBox";
            this.plombBox.Size = new System.Drawing.Size(162, 21);
            this.plombBox.TabIndex = 30;
            this.plombBox.SelectedIndexChanged += new System.EventHandler(this.plombBox_SelectedIndexChanged);
            // 
            // colorList
            // 
            this.colorList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorList.ColumnWidth = 75;
            this.colorList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.colorList.FormattingEnabled = true;
            this.colorList.ItemHeight = 15;
            this.colorList.Location = new System.Drawing.Point(58, 315);
            this.colorList.MultiColumn = true;
            this.colorList.Name = "colorList";
            this.colorList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.colorList.Size = new System.Drawing.Size(183, 77);
            this.colorList.TabIndex = 10;
            this.colorList.SelectedIndexChanged += new System.EventHandler(this.testColorList_SelectedIndexChanged);
            // 
            // plombir
            // 
            this.plombir.AutoSize = true;
            this.plombir.Location = new System.Drawing.Point(17, 290);
            this.plombir.Name = "plombir";
            this.plombir.Size = new System.Drawing.Size(96, 13);
            this.plombir.TabIndex = 29;
            this.plombir.Text = "Пломбировочный";
            // 
            // isoFillBox
            // 
            this.isoFillBox.Enabled = false;
            this.isoFillBox.FormattingEnabled = true;
            this.isoFillBox.Location = new System.Drawing.Point(152, 259);
            this.isoFillBox.Name = "isoFillBox";
            this.isoFillBox.Size = new System.Drawing.Size(162, 21);
            this.isoFillBox.TabIndex = 28;
            this.isoFillBox.SelectedIndexChanged += new System.EventHandler(this.isoFillBox_SelectedIndexChanged);
            // 
            // papilumDistalis
            // 
            this.papilumDistalis.Appearance = System.Windows.Forms.Appearance.Button;
            this.papilumDistalis.AutoSize = true;
            this.papilumDistalis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.papilumDistalis.Location = new System.Drawing.Point(268, 95);
            this.papilumDistalis.Name = "papilumDistalis";
            this.papilumDistalis.Size = new System.Drawing.Size(59, 23);
            this.papilumDistalis.TabIndex = 27;
            this.papilumDistalis.Text = "Сосочек";
            this.papilumDistalis.UseVisualStyleBackColor = true;
            this.papilumDistalis.CheckedChanged += new System.EventHandler(this.papilumDistalis_CheckedChanged);
            // 
            // papilumMedialis
            // 
            this.papilumMedialis.Appearance = System.Windows.Forms.Appearance.Button;
            this.papilumMedialis.AutoSize = true;
            this.papilumMedialis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.papilumMedialis.Location = new System.Drawing.Point(38, 95);
            this.papilumMedialis.Name = "papilumMedialis";
            this.papilumMedialis.Size = new System.Drawing.Size(59, 23);
            this.papilumMedialis.TabIndex = 27;
            this.papilumMedialis.Text = "Сосочек";
            this.papilumMedialis.UseVisualStyleBackColor = true;
            this.papilumMedialis.CheckedChanged += new System.EventHandler(this.papilumMedialis_CheckedChanged);
            // 
            // healFillBox
            // 
            this.healFillBox.Enabled = false;
            this.healFillBox.FormattingEnabled = true;
            this.healFillBox.Location = new System.Drawing.Point(152, 232);
            this.healFillBox.Name = "healFillBox";
            this.healFillBox.Size = new System.Drawing.Size(162, 21);
            this.healFillBox.TabIndex = 25;
            this.healFillBox.SelectedIndexChanged += new System.EventHandler(this.healFillBox_SelectedIndexChanged);
            // 
            // ml
            // 
            this.ml.AutoSize = true;
            this.ml.Location = new System.Drawing.Point(320, 181);
            this.ml.Name = "ml";
            this.ml.Size = new System.Drawing.Size(21, 13);
            this.ml.TabIndex = 24;
            this.ml.Text = "мл";
            // 
            // volumeAnest
            // 
            this.volumeAnest.Location = new System.Drawing.Point(288, 174);
            this.volumeAnest.Mask = "0/0";
            this.volumeAnest.Name = "volumeAnest";
            this.volumeAnest.Size = new System.Drawing.Size(26, 20);
            this.volumeAnest.TabIndex = 23;
            this.volumeAnest.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.volumeAnest_MaskInputRejected);
            // 
            // anestesyCheck
            // 
            this.anestesyCheck.AutoSize = true;
            this.anestesyCheck.Location = new System.Drawing.Point(6, 176);
            this.anestesyCheck.Name = "anestesyCheck";
            this.anestesyCheck.Size = new System.Drawing.Size(80, 17);
            this.anestesyCheck.TabIndex = 21;
            this.anestesyCheck.Text = "Анестезия";
            this.anestesyCheck.UseVisualStyleBackColor = true;
            this.anestesyCheck.CheckedChanged += new System.EventHandler(this.anestesy_CheckedChanged);
            // 
            // applicationCheck
            // 
            this.applicationCheck.AutoSize = true;
            this.applicationCheck.Location = new System.Drawing.Point(6, 149);
            this.applicationCheck.Name = "applicationCheck";
            this.applicationCheck.Size = new System.Drawing.Size(111, 17);
            this.applicationCheck.TabIndex = 20;
            this.applicationCheck.Text = "Аппликационная";
            this.applicationCheck.UseVisualStyleBackColor = true;
            this.applicationCheck.CheckedChanged += new System.EventHandler(this.application_CheckedChanged);
            // 
            // isoCheck
            // 
            this.isoCheck.AutoSize = true;
            this.isoCheck.Location = new System.Drawing.Point(-1, 263);
            this.isoCheck.Name = "isoCheck";
            this.isoCheck.Size = new System.Drawing.Size(155, 17);
            this.isoCheck.TabIndex = 19;
            this.isoCheck.Text = "Изолирующая подкладка";
            this.isoCheck.UseVisualStyleBackColor = true;
            this.isoCheck.CheckedChanged += new System.EventHandler(this.isolation_CheckedChanged);
            // 
            // healCheck
            // 
            this.healCheck.AutoSize = true;
            this.healCheck.Location = new System.Drawing.Point(-1, 236);
            this.healCheck.Name = "healCheck";
            this.healCheck.Size = new System.Drawing.Size(132, 17);
            this.healCheck.TabIndex = 18;
            this.healCheck.Text = "Лечебная подкладка";
            this.healCheck.UseVisualStyleBackColor = true;
            this.healCheck.CheckedChanged += new System.EventHandler(this.heal_CheckedChanged);
            // 
            // anestBox
            // 
            this.anestBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.anestBox.DropDownWidth = 200;
            this.anestBox.Enabled = false;
            this.anestBox.FormattingEnabled = true;
            this.anestBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.anestBox.Location = new System.Drawing.Point(135, 172);
            this.anestBox.MaxDropDownItems = 10;
            this.anestBox.Name = "anestBox";
            this.anestBox.Size = new System.Drawing.Size(121, 21);
            this.anestBox.TabIndex = 17;
            this.anestBox.SelectedIndexChanged += new System.EventHandler(this.anestBox_SelectedIndexChanged);
            // 
            // applicationBox
            // 
            this.applicationBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.applicationBox.Enabled = false;
            this.applicationBox.FormattingEnabled = true;
            this.applicationBox.Location = new System.Drawing.Point(135, 147);
            this.applicationBox.Name = "applicationBox";
            this.applicationBox.Size = new System.Drawing.Size(121, 21);
            this.applicationBox.TabIndex = 16;
            this.applicationBox.SelectedIndexChanged += new System.EventHandler(this.applicationBox_SelectedIndexChanged);
            // 
            // ruinLessHalf
            // 
            this.ruinLessHalf.AutoSize = true;
            this.ruinLessHalf.Location = new System.Drawing.Point(159, 124);
            this.ruinLessHalf.Name = "ruinLessHalf";
            this.ruinLessHalf.Size = new System.Drawing.Size(58, 17);
            this.ruinLessHalf.TabIndex = 15;
            this.ruinLessHalf.Text = "до 1/2";
            this.ruinLessHalf.UseVisualStyleBackColor = true;
            this.ruinLessHalf.CheckedChanged += new System.EventHandler(this.ruinLessHalf_CheckedChanged);
            // 
            // ruinMoreHalf
            // 
            this.ruinMoreHalf.AutoSize = true;
            this.ruinMoreHalf.Location = new System.Drawing.Point(6, 124);
            this.ruinMoreHalf.Name = "ruinMoreHalf";
            this.ruinMoreHalf.Size = new System.Drawing.Size(149, 17);
            this.ruinMoreHalf.TabIndex = 14;
            this.ruinMoreHalf.Text = "Зуб разрушен более 1/2";
            this.ruinMoreHalf.UseVisualStyleBackColor = true;
            this.ruinMoreHalf.CheckedChanged += new System.EventHandler(this.ruinMoreHalf_CheckedChanged);
            // 
            // depthLabel
            // 
            this.depthLabel.AutoSize = true;
            this.depthLabel.Location = new System.Drawing.Point(0, 0);
            this.depthLabel.Name = "depthLabel";
            this.depthLabel.Size = new System.Drawing.Size(51, 13);
            this.depthLabel.TabIndex = 9;
            this.depthLabel.Text = "Глубина:";
            // 
            // orF
            // 
            this.orF.AllowDrop = true;
            this.orF.Appearance = System.Windows.Forms.Appearance.Button;
            this.orF.ContextMenuStrip = this.FaceConditionsMenu;
            this.orF.Location = new System.Drawing.Point(137, 95);
            this.orF.Name = "orF";
            this.orF.Size = new System.Drawing.Size(91, 23);
            this.orF.TabIndex = 4;
            this.orF.Text = "     Оральная    ";
            this.orF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.orF.UseVisualStyleBackColor = true;
            this.orF.DragDrop += new System.Windows.Forms.DragEventHandler(this.face_DragDrop);
            this.orF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.facePress_MouseDown);
            this.orF.MouseHover += new System.EventHandler(this.anyFace_MouseHover);
            this.orF.DragEnter += new System.Windows.Forms.DragEventHandler(this.face_DragEnter);
            // 
            // medF
            // 
            this.medF.AllowDrop = true;
            this.medF.Appearance = System.Windows.Forms.Appearance.Button;
            this.medF.AutoSize = true;
            this.medF.ContextMenuStrip = this.FaceConditionsMenu;
            this.medF.Location = new System.Drawing.Point(37, 60);
            this.medF.Name = "medF";
            this.medF.Size = new System.Drawing.Size(80, 23);
            this.medF.TabIndex = 3;
            this.medF.Text = "Медиальная";
            this.medF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.medF.UseVisualStyleBackColor = true;
            this.medF.DragDrop += new System.Windows.Forms.DragEventHandler(this.face_DragDrop);
            this.medF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.facePress_MouseDown);
            this.medF.MouseHover += new System.EventHandler(this.anyFace_MouseHover);
            this.medF.DragEnter += new System.Windows.Forms.DragEventHandler(this.face_DragEnter);
            // 
            // distF
            // 
            this.distF.AllowDrop = true;
            this.distF.Appearance = System.Windows.Forms.Appearance.Button;
            this.distF.AutoSize = true;
            this.distF.ContextMenuStrip = this.FaceConditionsMenu;
            this.distF.Location = new System.Drawing.Point(248, 60);
            this.distF.Name = "distF";
            this.distF.Size = new System.Drawing.Size(79, 23);
            this.distF.TabIndex = 2;
            this.distF.Text = "Дистальная";
            this.distF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.distF.UseVisualStyleBackColor = true;
            this.distF.DragDrop += new System.Windows.Forms.DragEventHandler(this.face_DragDrop);
            this.distF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.facePress_MouseDown);
            this.distF.CheckedChanged += new System.EventHandler(this.distF_CheckedChanged);
            this.distF.MouseHover += new System.EventHandler(this.anyFace_MouseHover);
            this.distF.DragEnter += new System.Windows.Forms.DragEventHandler(this.face_DragEnter);
            // 
            // okklF
            // 
            this.okklF.AllowDrop = true;
            this.okklF.Appearance = System.Windows.Forms.Appearance.Button;
            this.okklF.ContextMenuStrip = this.FaceConditionsMenu;
            this.okklF.Location = new System.Drawing.Point(137, 60);
            this.okklF.Name = "okklF";
            this.okklF.Size = new System.Drawing.Size(93, 23);
            this.okklF.TabIndex = 1;
            this.okklF.Text = "Окклюзионная";
            this.okklF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.okklF.UseVisualStyleBackColor = true;
            this.okklF.DragDrop += new System.Windows.Forms.DragEventHandler(this.face_DragDrop);
            this.okklF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.facePress_MouseDown);
            this.okklF.MouseHover += new System.EventHandler(this.anyFace_MouseHover);
            this.okklF.DragEnter += new System.Windows.Forms.DragEventHandler(this.face_DragEnter);
            // 
            // conVO
            // 
            this.conVO.Appearance = System.Windows.Forms.Appearance.Button;
            this.conVO.AutoSize = true;
            this.conVO.ContextMenuStrip = this.ConnectionsCondContextMenu;
            this.conVO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conVO.Location = new System.Drawing.Point(168, 40);
            this.conVO.Name = "conVO";
            this.conVO.Size = new System.Drawing.Size(26, 23);
            this.conVO.TabIndex = 12;
            this.conVO.Text = "   ";
            this.conVO.UseVisualStyleBackColor = true;
            this.conVO.CheckedChanged += new System.EventHandler(this.conAny_CheckedChanged);
            // 
            // ConnectionsCondContextMenu
            // 
            this.ConnectionsCondContextMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ConnectionsCondContextMenu.Name = "ConnectionsCondContextMenu";
            this.ConnectionsCondContextMenu.Size = new System.Drawing.Size(153, 26);
            this.ConnectionsCondContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ConnectionsCondContextMenu_Opening);
            // 
            // conVD
            // 
            this.conVD.Appearance = System.Windows.Forms.Appearance.Button;
            this.conVD.AutoSize = true;
            this.conVD.ContextMenuStrip = this.ConnectionsCondContextMenu;
            this.conVD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conVD.Location = new System.Drawing.Point(234, 31);
            this.conVD.Name = "conVD";
            this.conVD.Size = new System.Drawing.Size(26, 23);
            this.conVD.TabIndex = 11;
            this.conVD.Text = "   ";
            this.conVD.UseVisualStyleBackColor = true;
            this.conVD.CheckedChanged += new System.EventHandler(this.conAny_CheckedChanged);
            // 
            // conVM
            // 
            this.conVM.Appearance = System.Windows.Forms.Appearance.Button;
            this.conVM.AutoSize = true;
            this.conVM.ContextMenuStrip = this.ConnectionsCondContextMenu;
            this.conVM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conVM.Location = new System.Drawing.Point(105, 31);
            this.conVM.Name = "conVM";
            this.conVM.Size = new System.Drawing.Size(26, 23);
            this.conVM.TabIndex = 13;
            this.conVM.Text = "   ";
            this.conVM.UseVisualStyleBackColor = true;
            this.conVM.CheckedChanged += new System.EventHandler(this.conAny_CheckedChanged);
            // 
            // conDN
            // 
            this.conDN.Appearance = System.Windows.Forms.Appearance.Button;
            this.conDN.AutoSize = true;
            this.conDN.ContextMenuStrip = this.ConnectionsCondContextMenu;
            this.conDN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conDN.Location = new System.Drawing.Point(234, 95);
            this.conDN.Name = "conDN";
            this.conDN.Size = new System.Drawing.Size(26, 23);
            this.conDN.TabIndex = 13;
            this.conDN.Text = "   ";
            this.conDN.UseVisualStyleBackColor = true;
            this.conDN.CheckedChanged += new System.EventHandler(this.conAny_CheckedChanged);
            // 
            // conMN
            // 
            this.conMN.Appearance = System.Windows.Forms.Appearance.Button;
            this.conMN.AutoSize = true;
            this.conMN.ContextMenuStrip = this.ConnectionsCondContextMenu;
            this.conMN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conMN.Location = new System.Drawing.Point(105, 95);
            this.conMN.Name = "conMN";
            this.conMN.Size = new System.Drawing.Size(26, 23);
            this.conMN.TabIndex = 13;
            this.conMN.Text = "   ";
            this.conMN.UseVisualStyleBackColor = true;
            this.conMN.CheckedChanged += new System.EventHandler(this.conAny_CheckedChanged);
            // 
            // conMO
            // 
            this.conMO.Appearance = System.Windows.Forms.Appearance.Button;
            this.conMO.AutoSize = true;
            this.conMO.ContextMenuStrip = this.ConnectionsCondContextMenu;
            this.conMO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conMO.Location = new System.Drawing.Point(116, 60);
            this.conMO.Name = "conMO";
            this.conMO.Size = new System.Drawing.Size(26, 23);
            this.conMO.TabIndex = 13;
            this.conMO.Text = "   ";
            this.conMO.UseVisualStyleBackColor = true;
            this.conMO.CheckedChanged += new System.EventHandler(this.conAny_CheckedChanged);
            // 
            // conOD
            // 
            this.conOD.Appearance = System.Windows.Forms.Appearance.Button;
            this.conOD.AutoSize = true;
            this.conOD.ContextMenuStrip = this.ConnectionsCondContextMenu;
            this.conOD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conOD.Location = new System.Drawing.Point(225, 60);
            this.conOD.Name = "conOD";
            this.conOD.Size = new System.Drawing.Size(26, 23);
            this.conOD.TabIndex = 13;
            this.conOD.Text = "   ";
            this.conOD.UseVisualStyleBackColor = true;
            this.conOD.CheckedChanged += new System.EventHandler(this.conAny_CheckedChanged);
            // 
            // conON
            // 
            this.conON.Appearance = System.Windows.Forms.Appearance.Button;
            this.conON.AutoSize = true;
            this.conON.ContextMenuStrip = this.ConnectionsCondContextMenu;
            this.conON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conON.Location = new System.Drawing.Point(168, 79);
            this.conON.Name = "conON";
            this.conON.Size = new System.Drawing.Size(26, 23);
            this.conON.TabIndex = 13;
            this.conON.Text = "   ";
            this.conON.UseVisualStyleBackColor = true;
            this.conON.CheckedChanged += new System.EventHandler(this.conAny_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.AutoScrollMargin = new System.Drawing.Size(0, 3);
            this.tabPage2.AutoScrollMinSize = new System.Drawing.Size(50, 100);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(366, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Кариес депульпированного зуба";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.EnableAutoDragDrop = true;
            this.richTextBox2.Location = new System.Drawing.Point(425, 9);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(403, 468);
            this.richTextBox2.TabIndex = 19;
            this.richTextBox2.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 524);
            this.splitter1.TabIndex = 20;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(3, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 524);
            this.splitter2.TabIndex = 21;
            this.splitter2.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 524);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.TabPanel);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "Клише 0.1prePreAlfa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ConditionsFaceContextMenu.ResumeLayout(false);
            this.TabPanel.ResumeLayout(false);
            this.Caries.ResumeLayout(false);
            this.Caries.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox vestF;
        private System.Windows.Forms.Label NumTooth;
        private System.Windows.Forms.Button AddTooth;
        private System.Windows.Forms.MaskedTextBox numberOfToothText;
        private System.Windows.Forms.TabControl TabPanel;
        private System.Windows.Forms.TabPage Caries;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox Osmotr;
        private System.Windows.Forms.ContextMenuStrip ConditionsFaceContextMenu;
        private System.Windows.Forms.ToolStripMenuItem кариесToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem povcar_pov;
        private System.Windows.Forms.ToolStripMenuItem car_sred;
        private System.Windows.Forms.ToolStripMenuItem car_glub;
        private System.Windows.Forms.ToolStripMenuItem car_giper;
        private System.Windows.Forms.ToolStripMenuItem plomb;
        private System.Windows.Forms.ToolStripMenuItem клиновидныйДефектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klinDef_pov;
        private System.Windows.Forms.ToolStripMenuItem klinDef_sred;
        private System.Windows.Forms.ToolStripMenuItem klinDef_glub;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.CheckBox orF;
        private System.Windows.Forms.CheckBox medF;
        private System.Windows.Forms.CheckBox distF;
        private System.Windows.Forms.CheckBox okklF;
        private System.Windows.Forms.Label ToothList;
        private System.Windows.Forms.ListBox listOfTooths;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ToolStripMenuItem contact;
        private System.Windows.Forms.ToolStripMenuItem дефектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defect_sred;
        private System.Windows.Forms.ToolStripMenuItem defect_glub;
        private System.Windows.Forms.ToolStripMenuItem defect_giper;
        private System.Windows.Forms.ToolStripMenuItem defect_pov;
        private System.Windows.Forms.ToolStripMenuItem plomb_pov;
        private System.Windows.Forms.ToolStripMenuItem plomb_sred;
        private System.Windows.Forms.ToolStripMenuItem plomb_glub;
        private System.Windows.Forms.ToolStripMenuItem plomb_giper;
        private System.Windows.Forms.ToolStripMenuItem CleanToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label depthLabel;
        private System.Windows.Forms.Button deleteNumber;
        private System.Windows.Forms.CheckBox conVD;
        private System.Windows.Forms.CheckBox conVO;
        private System.Windows.Forms.CheckBox conVM;
        private System.Windows.Forms.CheckBox conDN;
        private System.Windows.Forms.CheckBox conMN;
        private System.Windows.Forms.CheckBox conMO;
        private System.Windows.Forms.CheckBox conOD;
        private System.Windows.Forms.CheckBox conON;
        private System.Windows.Forms.CheckBox ruinLessHalf;
        private System.Windows.Forms.CheckBox ruinMoreHalf;
        private System.Windows.Forms.ComboBox anestBox;
        private System.Windows.Forms.ComboBox applicationBox;
        private System.Windows.Forms.CheckBox isoCheck;
        private System.Windows.Forms.CheckBox healCheck;
        private System.Windows.Forms.MaskedTextBox volumeAnest;
        private System.Windows.Forms.CheckBox anestesyCheck;
        private System.Windows.Forms.CheckBox applicationCheck;
        private System.Windows.Forms.Label ml;
        private System.Windows.Forms.ComboBox healFillBox;
        private System.Windows.Forms.ComboBox isoFillBox;
        private System.Windows.Forms.CheckBox papilumMedialis;
        private System.Windows.Forms.CheckBox papilumDistalis;
        private System.Windows.Forms.ComboBox plombBox;
        private System.Windows.Forms.Label plombir;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Button addMaterial;
        private System.Windows.Forms.Button addAnestesy;
        private System.Windows.Forms.ListBox colorList;
        private System.Windows.Forms.ContextMenuStrip FaceConditionsMenu;
        private System.Windows.Forms.Button erase;
        private System.Windows.Forms.CheckBox rvg;
        private System.Windows.Forms.CheckBox cervF;
        private System.Windows.Forms.ContextMenuStrip ConnectionsCondContextMenu;
    }
}

