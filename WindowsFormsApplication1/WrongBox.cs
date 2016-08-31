using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace KlisheNamespace
{
    partial class WrongBox : Form
    {
         bool withCancel =false;
    
       /// <summary>
       /// Создает окно с нужным сообщением и кнопкой ОК
       /// </summary>
       /// <param name="messageText">Текст сообщения</param>
        public WrongBox(string messageText, bool cancelBut)
        {
            InitializeComponent();
            if (cancelBut)
            {
                cancelButton.Visible = true;
                cancelButton.Enabled = true;
                withCancel = true;
            }
            messageLabel.Text = messageText;
        }
        public WrongBox(string messageText)
        {
            InitializeComponent();
            messageLabel.Text = messageText;      
        }
       
        private void okButton_Click(object sender, EventArgs e)
        {
            if (withCancel)
            {
                this.DialogResult = DialogResult.OK;
            }
           
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
