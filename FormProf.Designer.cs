namespace Catalog
{
    partial class FormProf
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
            button1 = new Button();
            dataGridViewGrades = new DataGridView();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGrades).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(700, 399);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Salveaza";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSave_Click;
            // 
            // dataGridViewGrades
            // 
            dataGridViewGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGrades.Location = new Point(12, 12);
            dataGridViewGrades.Name = "dataGridViewGrades";
            dataGridViewGrades.Size = new Size(658, 410);
            dataGridViewGrades.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(700, 354);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "LOG OUT";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormProf
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(dataGridViewGrades);
            Controls.Add(button1);
            Name = "FormProf";
            Text = "FormProf";
            ((System.ComponentModel.ISupportInitialize)dataGridViewGrades).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private DataGridView dataGridViewGrades;
        private Button button2;
    }
}