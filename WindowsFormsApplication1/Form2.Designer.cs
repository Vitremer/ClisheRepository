namespace KlisheNamespace
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameOfMatBox = new System.Windows.Forms.TextBox();
            this.lightCuredCheck = new System.Windows.Forms.CheckBox();
            this.healableCheck = new System.Windows.Forms.CheckBox();
            this.isoFillCheck = new System.Windows.Forms.CheckBox();
            this.flowableCheck = new System.Windows.Forms.CheckBox();
            this.colorableCheck = new System.Windows.Forms.CheckBox();
            this.ottenkiLabel = new System.Windows.Forms.Label();
            this.colorsList = new System.Windows.Forms.ListBox();
            this.plusColorButton = new System.Windows.Forms.Button();
            this.minusColorButton = new System.Windows.Forms.Button();
            this.colorBox = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.matList = new System.Windows.Forms.ListBox();
            this.removeMat = new System.Windows.Forms.Button();
            this.setDefaultsButton = new System.Windows.Forms.Button();
            this.SaveChangesButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tabPageMatCreation = new System.Windows.Forms.TabPage();
            this.tabPageAnesteticsCreation = new System.Windows.Forms.TabPage();
            this.tabPageMainProperties = new System.Windows.Forms.TabPage();
            this.tabPageDictBlocks = new System.Windows.Forms.TabPage();
            this.tabOptions.SuspendLayout();
            this.tabPageMatCreation.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(115, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Название материала";
            // 
            // nameOfMatBox
            // 
            this.nameOfMatBox.Location = new System.Drawing.Point(118, 9);
            this.nameOfMatBox.MaxLength = 40;
            this.nameOfMatBox.Name = "nameOfMatBox";
            this.nameOfMatBox.Size = new System.Drawing.Size(190, 20);
            this.nameOfMatBox.TabIndex = 1;
            this.nameOfMatBox.TextChanged += new System.EventHandler(this.nameOfMatBox_TextChanged);
            // 
            // lightCuredCheck
            // 
            this.lightCuredCheck.AutoSize = true;
            this.lightCuredCheck.Location = new System.Drawing.Point(9, 30);
            this.lightCuredCheck.Name = "lightCuredCheck";
            this.lightCuredCheck.Size = new System.Drawing.Size(133, 17);
            this.lightCuredCheck.TabIndex = 2;
            this.lightCuredCheck.Text = "Светоотверждаемый";
            this.lightCuredCheck.UseVisualStyleBackColor = true;
            this.lightCuredCheck.CheckedChanged += new System.EventHandler(this.lightCuredCheck_CheckedChanged);
            // 
            // healableCheck
            // 
            this.healableCheck.AutoSize = true;
            this.healableCheck.Location = new System.Drawing.Point(9, 53);
            this.healableCheck.Name = "healableCheck";
            this.healableCheck.Size = new System.Drawing.Size(132, 17);
            this.healableCheck.TabIndex = 3;
            this.healableCheck.Text = "Лечебная подкладка";
            this.healableCheck.UseVisualStyleBackColor = true;
            this.healableCheck.CheckedChanged += new System.EventHandler(this.healableCheck_CheckedChanged);
            // 
            // isoFillCheck
            // 
            this.isoFillCheck.AutoSize = true;
            this.isoFillCheck.Location = new System.Drawing.Point(9, 76);
            this.isoFillCheck.Name = "isoFillCheck";
            this.isoFillCheck.Size = new System.Drawing.Size(155, 17);
            this.isoFillCheck.TabIndex = 4;
            this.isoFillCheck.Text = "Изолирующая подкладка";
            this.isoFillCheck.UseVisualStyleBackColor = true;
            this.isoFillCheck.CheckedChanged += new System.EventHandler(this.isoFillCheck_CheckedChanged);
            // 
            // flowableCheck
            // 
            this.flowableCheck.AutoSize = true;
            this.flowableCheck.Location = new System.Drawing.Point(9, 99);
            this.flowableCheck.Name = "flowableCheck";
            this.flowableCheck.Size = new System.Drawing.Size(100, 17);
            this.flowableCheck.TabIndex = 5;
            this.flowableCheck.Text = "Жидкотекучий";
            this.flowableCheck.UseVisualStyleBackColor = true;
            this.flowableCheck.CheckedChanged += new System.EventHandler(this.flowableCheck_CheckedChanged);
            // 
            // colorableCheck
            // 
            this.colorableCheck.AutoSize = true;
            this.colorableCheck.Location = new System.Drawing.Point(9, 122);
            this.colorableCheck.Name = "colorableCheck";
            this.colorableCheck.Size = new System.Drawing.Size(102, 17);
            this.colorableCheck.TabIndex = 6;
            this.colorableCheck.Text = "Имеет оттенки";
            this.colorableCheck.UseVisualStyleBackColor = true;
            this.colorableCheck.CheckedChanged += new System.EventHandler(this.colorableCheck_CheckedChanged);
            // 
            // ottenkiLabel
            // 
            this.ottenkiLabel.AutoSize = true;
            this.ottenkiLabel.Location = new System.Drawing.Point(6, 155);
            this.ottenkiLabel.Name = "ottenkiLabel";
            this.ottenkiLabel.Size = new System.Drawing.Size(49, 13);
            this.ottenkiLabel.TabIndex = 7;
            this.ottenkiLabel.Text = "Оттенки";
            // 
            // colorsList
            // 
            this.colorsList.Enabled = false;
            this.colorsList.FormattingEnabled = true;
            this.colorsList.Location = new System.Drawing.Point(170, 150);
            this.colorsList.Name = "colorsList";
            this.colorsList.Size = new System.Drawing.Size(68, 108);
            this.colorsList.TabIndex = 8;
            // 
            // plusColorButton
            // 
            this.plusColorButton.Enabled = false;
            this.plusColorButton.Location = new System.Drawing.Point(139, 150);
            this.plusColorButton.Name = "plusColorButton";
            this.plusColorButton.Size = new System.Drawing.Size(25, 23);
            this.plusColorButton.TabIndex = 9;
            this.plusColorButton.Text = "+";
            this.plusColorButton.UseVisualStyleBackColor = true;
            this.plusColorButton.Click += new System.EventHandler(this.plusColorButton_Click);
            // 
            // minusColorButton
            // 
            this.minusColorButton.Enabled = false;
            this.minusColorButton.Location = new System.Drawing.Point(139, 179);
            this.minusColorButton.Name = "minusColorButton";
            this.minusColorButton.Size = new System.Drawing.Size(25, 23);
            this.minusColorButton.TabIndex = 10;
            this.minusColorButton.Text = "-";
            this.minusColorButton.UseVisualStyleBackColor = true;
            this.minusColorButton.Click += new System.EventHandler(this.minusColorButton_Click);
            // 
            // colorBox
            // 
            this.colorBox.Enabled = false;
            this.colorBox.Location = new System.Drawing.Point(55, 150);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(78, 20);
            this.colorBox.TabIndex = 11;
            // 
            // createButton
            // 
            this.createButton.BackColor = System.Drawing.Color.YellowGreen;
            this.createButton.Location = new System.Drawing.Point(240, 183);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 36);
            this.createButton.TabIndex = 12;
            this.createButton.Text = "Добавить материал";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // matList
            // 
            this.matList.FormattingEnabled = true;
            this.matList.Location = new System.Drawing.Point(170, 35);
            this.matList.Name = "matList";
            this.matList.Size = new System.Drawing.Size(138, 108);
            this.matList.TabIndex = 13;
            this.matList.SelectedIndexChanged += new System.EventHandler(this.matList_SelectedIndexChanged);
            // 
            // removeMat
            // 
            this.removeMat.BackColor = System.Drawing.Color.DarkSalmon;
            this.removeMat.Location = new System.Drawing.Point(240, 150);
            this.removeMat.Name = "removeMat";
            this.removeMat.Size = new System.Drawing.Size(75, 34);
            this.removeMat.TabIndex = 14;
            this.removeMat.Text = "Удалить материал";
            this.removeMat.UseVisualStyleBackColor = false;
            this.removeMat.Click += new System.EventHandler(this.removeMat_Click);
            // 
            // setDefaultsButton
            // 
            this.setDefaultsButton.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.setDefaultsButton.Location = new System.Drawing.Point(240, 224);
            this.setDefaultsButton.Name = "setDefaultsButton";
            this.setDefaultsButton.Size = new System.Drawing.Size(75, 34);
            this.setDefaultsButton.TabIndex = 15;
            this.setDefaultsButton.Text = "Вернуть по умолчанию";
            this.setDefaultsButton.UseVisualStyleBackColor = false;
            this.setDefaultsButton.Click += new System.EventHandler(this.setDefaultsButton_Click);
            // 
            // SaveChangesButton
            // 
            this.SaveChangesButton.BackColor = System.Drawing.Color.GreenYellow;
            this.SaveChangesButton.Location = new System.Drawing.Point(5, 208);
            this.SaveChangesButton.Name = "SaveChangesButton";
            this.SaveChangesButton.Size = new System.Drawing.Size(75, 45);
            this.SaveChangesButton.TabIndex = 16;
            this.SaveChangesButton.Text = "Сохранить изменения";
            this.SaveChangesButton.UseVisualStyleBackColor = false;
            this.SaveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.LightSalmon;
            this.cancelButton.Location = new System.Drawing.Point(89, 208);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 45);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Отменить изменения";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.tabPageMainProperties);
            this.tabOptions.Controls.Add(this.tabPageMatCreation);
            this.tabOptions.Controls.Add(this.tabPageAnesteticsCreation);
            this.tabOptions.Controls.Add(this.tabPageDictBlocks);
            this.tabOptions.Location = new System.Drawing.Point(12, 12);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(339, 299);
            this.tabOptions.TabIndex = 18;
            // 
            // tabPageMatCreation
            // 
            this.tabPageMatCreation.Controls.Add(this.nameLabel);
            this.tabPageMatCreation.Controls.Add(this.cancelButton);
            this.tabPageMatCreation.Controls.Add(this.nameOfMatBox);
            this.tabPageMatCreation.Controls.Add(this.SaveChangesButton);
            this.tabPageMatCreation.Controls.Add(this.lightCuredCheck);
            this.tabPageMatCreation.Controls.Add(this.setDefaultsButton);
            this.tabPageMatCreation.Controls.Add(this.healableCheck);
            this.tabPageMatCreation.Controls.Add(this.removeMat);
            this.tabPageMatCreation.Controls.Add(this.isoFillCheck);
            this.tabPageMatCreation.Controls.Add(this.matList);
            this.tabPageMatCreation.Controls.Add(this.flowableCheck);
            this.tabPageMatCreation.Controls.Add(this.createButton);
            this.tabPageMatCreation.Controls.Add(this.colorableCheck);
            this.tabPageMatCreation.Controls.Add(this.colorBox);
            this.tabPageMatCreation.Controls.Add(this.ottenkiLabel);
            this.tabPageMatCreation.Controls.Add(this.minusColorButton);
            this.tabPageMatCreation.Controls.Add(this.colorsList);
            this.tabPageMatCreation.Controls.Add(this.plusColorButton);
            this.tabPageMatCreation.Location = new System.Drawing.Point(4, 22);
            this.tabPageMatCreation.Name = "tabPageMatCreation";
            this.tabPageMatCreation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMatCreation.Size = new System.Drawing.Size(331, 273);
            this.tabPageMatCreation.TabIndex = 0;
            this.tabPageMatCreation.Text = "Материалы";
            this.tabPageMatCreation.UseVisualStyleBackColor = true;
            // 
            // tabPageAnesteticsCreation
            // 
            this.tabPageAnesteticsCreation.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnesteticsCreation.Name = "tabPageAnesteticsCreation";
            this.tabPageAnesteticsCreation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnesteticsCreation.Size = new System.Drawing.Size(331, 273);
            this.tabPageAnesteticsCreation.TabIndex = 1;
            this.tabPageAnesteticsCreation.Text = "Анестетики";
            this.tabPageAnesteticsCreation.UseVisualStyleBackColor = true;
            // 
            // tabPageMainProperties
            // 
            this.tabPageMainProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageMainProperties.Name = "tabPageMainProperties";
            this.tabPageMainProperties.Size = new System.Drawing.Size(331, 273);
            this.tabPageMainProperties.TabIndex = 2;
            this.tabPageMainProperties.Text = "Основные";
            this.tabPageMainProperties.UseVisualStyleBackColor = true;
            // 
            // tabPageDictBlocks
            // 
            this.tabPageDictBlocks.Location = new System.Drawing.Point(4, 22);
            this.tabPageDictBlocks.Name = "tabPageDictBlocks";
            this.tabPageDictBlocks.Size = new System.Drawing.Size(331, 273);
            this.tabPageDictBlocks.TabIndex = 3;
            this.tabPageDictBlocks.Text = "Словарь блоков";
            this.tabPageDictBlocks.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 323);
            this.Controls.Add(this.tabOptions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsForm";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.MaterailCreationDialogForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MaterailCreationDialogForm_FormClosing);
            this.tabOptions.ResumeLayout(false);
            this.tabPageMatCreation.ResumeLayout(false);
            this.tabPageMatCreation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameOfMatBox;
        private System.Windows.Forms.CheckBox lightCuredCheck;
        private System.Windows.Forms.CheckBox healableCheck;
        private System.Windows.Forms.CheckBox isoFillCheck;
        private System.Windows.Forms.CheckBox flowableCheck;
        private System.Windows.Forms.CheckBox colorableCheck;
        private System.Windows.Forms.Label ottenkiLabel;
        private System.Windows.Forms.ListBox colorsList;
        private System.Windows.Forms.Button plusColorButton;
        private System.Windows.Forms.Button minusColorButton;
        private System.Windows.Forms.TextBox colorBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ListBox matList;
        private System.Windows.Forms.Button removeMat;
        private System.Windows.Forms.Button setDefaultsButton;
        private System.Windows.Forms.Button SaveChangesButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage tabPageMatCreation;
        private System.Windows.Forms.TabPage tabPageAnesteticsCreation;
        private System.Windows.Forms.TabPage tabPageMainProperties;
        private System.Windows.Forms.TabPage tabPageDictBlocks;
    }
}