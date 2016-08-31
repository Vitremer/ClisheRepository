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
   
    public partial class OptionsForm : Form
    {
      
        Materials newMaterial = new Materials();

        mainForm Form1;
        List<Materials> currentMaterialsList = new List<Materials>();

        WrongBox wrongMessage;


        void UpdateMaterialList()
        {
            Form1 = this.Owner as mainForm;            
            currentMaterialsList = Form1.GetMainMatList();
            matList.DataSource = null;
            matList.DataSource = currentMaterialsList;
            matList.DisplayMember = "Name";
            matList.ValueMember = "Name";

        }
        /// <summary>
        /// Создание формы настроек - параметр задает какую вкладку открыть первой.
        /// </summary>
        /// <param name="tabPage">Принимает значения от 1 до 4. 1 - Основные настройки, 2 - Материалы, 3 - Анестетики, 4 - Словарь текстовых блоков</param>
        public OptionsForm(byte tabPage)
        {
            InitializeComponent();
            if (tabPage > 0 && tabPage < 5)
            {
                tabOptions.SelectedIndex = tabPage - 1;
            }
           
          
        }

        private void MaterailCreationDialogForm_Load(object sender, EventArgs e)
        {
            UpdateMaterialList();
        }

        private void nameOfMatBox_TextChanged(object sender, EventArgs e)
        {
            newMaterial.Name = nameOfMatBox.Text;   
        }

        private void lightCuredCheck_CheckedChanged(object sender, EventArgs e)
        {
            newMaterial.lightCured = lightCuredCheck.Checked;
        }

        private void healableCheck_CheckedChanged(object sender, EventArgs e)
        {
            newMaterial.healable = healableCheck.Checked;
            if (healableCheck.Checked) isoFillCheck.Checked = false;
            isoFillCheck.Enabled = !healableCheck.Checked;
            
        }

        private void isoFillCheck_CheckedChanged(object sender, EventArgs e)
        {
            newMaterial.isolation = isoFillCheck.Checked;
            if (isoFillCheck.Checked) healableCheck.Checked = false;              
            healableCheck.Enabled = !isoFillCheck.Checked;
        }

        private void flowableCheck_CheckedChanged(object sender, EventArgs e)
        {
            newMaterial.flowable = flowableCheck.Checked;
        }

        private void plusColorButton_Click(object sender, EventArgs e)
        {
            if (newMaterial.AddColor(colorBox.Text))
            {
                UpdateColorList();
               
            }

        }

        private void minusColorButton_Click(object sender, EventArgs e)
        {
            if (newMaterial.RemoveColor(colorsList.SelectedItem.ToString()))
            {
                UpdateColorList();
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {


             Form1 = this.Owner as mainForm;
            if (Form1.AddMat(newMaterial))
            {
                UpdateMaterialList();
                
            }
            else
            {
                nameOfMatBox.Text.Remove(0);
                wrongMessage= new WrongBox("Материал с таким именем уже существует!");
                wrongMessage.ShowDialog();
            }
        }

        private void matList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if ((Materials)matList.SelectedItem != null)
            {
                foreach (Materials mat in currentMaterialsList)
                {
                    if (mat == (Materials)matList.SelectedItem)
                    {
                        newMaterial = mat;
                        break;
                    }
                }
                nameOfMatBox.Text = newMaterial.Name;
                Update();
            }

        }

        void Update()
        {
            lightCuredCheck.Checked = newMaterial.lightCured;
            flowableCheck.Checked = newMaterial.flowable;
            healableCheck.Checked = newMaterial.healable;
            isoFillCheck.Checked = newMaterial.isolation;
            colorableCheck.Checked = newMaterial.colorable;
           
            if (newMaterial.colorsList.Count > 0)
            {
                UpdateColorList();
               
            }
        }
        void UpdateColorList()
        {
            colorsList.DataSource = null;
            colorsList.DataSource = newMaterial.colorsList;
            colorsList.DisplayMember = "Name";
        }
        private void removeMat_Click(object sender, EventArgs e)
        {
             Form1 = this.Owner as mainForm;
            if (Form1.RemoveMat(newMaterial))
            {
                UpdateMaterialList();
            }
            else
            {
                wrongMessage = new WrongBox("EpicFail! Материала с таким именем не существует в списке!");
                wrongMessage.ShowDialog();
            }
        }

        private void MaterailCreationDialogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                Form1 = this.Owner as mainForm;
                Form1.CancelChangesMaterialList();
                this.Dispose();
            }
        }

        private void colorableCheck_CheckedChanged(object sender, EventArgs e)
        {
            newMaterial.colorable = colorableCheck.Checked;
             colorBox.Enabled = colorableCheck.Checked;
             colorsList.Enabled = colorableCheck.Checked;
             plusColorButton.Enabled = colorableCheck.Checked;
             minusColorButton.Enabled = colorableCheck.Checked;
             colorsList.Enabled = colorableCheck.Checked;

        }

        
   
        private void setDefaultsButton_Click(object sender, EventArgs e)
        {
            Form1 = this.Owner as mainForm;
            wrongMessage = new WrongBox("Сбросить список материалов по умолчанию?", true);
            wrongMessage.Owner = this;
            wrongMessage.ShowDialog();
            if(wrongMessage.DialogResult == DialogResult.OK)
            {
               currentMaterialsList = Form1.SetDefaultsMaterials();
                UpdateMaterialList();
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Form1 = this.Owner as mainForm;
            Form1.CancelChangesMaterialList();
            this.Dispose();
            this.Close();
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            Form1 = this.Owner as mainForm;
            Form1.SaveCurrentMaterialList(currentMaterialsList);
            this.Dispose();
            this.Close();
        }

        

    }
}
