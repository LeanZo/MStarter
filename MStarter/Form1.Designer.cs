namespace MStarter
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.botaoAdd = new System.Windows.Forms.Button();
            this.comboBoxExe = new System.Windows.Forms.ComboBox();
            this.botaoRemover = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // botaoAdd
            // 
            this.botaoAdd.Location = new System.Drawing.Point(12, 21);
            this.botaoAdd.Name = "botaoAdd";
            this.botaoAdd.Size = new System.Drawing.Size(75, 23);
            this.botaoAdd.TabIndex = 0;
            this.botaoAdd.Text = "Adicionar";
            this.botaoAdd.UseVisualStyleBackColor = true;
            this.botaoAdd.Click += new System.EventHandler(this.botaoAdd_Click);
            // 
            // comboBoxExe
            // 
            this.comboBoxExe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExe.FormattingEnabled = true;
            this.comboBoxExe.Location = new System.Drawing.Point(12, 63);
            this.comboBoxExe.Name = "comboBoxExe";
            this.comboBoxExe.Size = new System.Drawing.Size(121, 21);
            this.comboBoxExe.TabIndex = 1;
            // 
            // botaoRemover
            // 
            this.botaoRemover.Location = new System.Drawing.Point(139, 61);
            this.botaoRemover.Name = "botaoRemover";
            this.botaoRemover.Size = new System.Drawing.Size(75, 23);
            this.botaoRemover.TabIndex = 2;
            this.botaoRemover.Text = "Remover";
            this.botaoRemover.UseVisualStyleBackColor = true;
            this.botaoRemover.Click += new System.EventHandler(this.botaoRemover_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 99);
            this.Controls.Add(this.botaoRemover);
            this.Controls.Add(this.comboBoxExe);
            this.Controls.Add(this.botaoAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Opacity = 0.97D;
            this.ShowIcon = false;
            this.Text = "MStarter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button botaoAdd;
        private System.Windows.Forms.ComboBox comboBoxExe;
        private System.Windows.Forms.Button botaoRemover;
    }
}

