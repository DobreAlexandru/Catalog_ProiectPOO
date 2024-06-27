namespace Catalog
{
    partial class MenuAdmin
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
            btn_student = new Button();
            btn_prof = new Button();
            btn_discipline = new Button();
            btn_catalog = new Button();
            SuspendLayout();
            // 
            // btn_student
            // 
            btn_student.Location = new Point(135, 120);
            btn_student.Name = "btn_student";
            btn_student.Size = new Size(75, 23);
            btn_student.TabIndex = 0;
            btn_student.Text = "Studenti";
            btn_student.UseVisualStyleBackColor = true;
            btn_student.Click += showStudents;
            // 
            // btn_prof
            // 
            btn_prof.Location = new Point(135, 179);
            btn_prof.Name = "btn_prof";
            btn_prof.Size = new Size(75, 23);
            btn_prof.TabIndex = 1;
            btn_prof.Text = "Profesori";
            btn_prof.UseVisualStyleBackColor = true;
            btn_prof.Click += showProfesori;
            // 
            // btn_discipline
            // 
            btn_discipline.Location = new Point(135, 246);
            btn_discipline.Name = "btn_discipline";
            btn_discipline.Size = new Size(75, 23);
            btn_discipline.TabIndex = 2;
            btn_discipline.Text = "Discipline";
            btn_discipline.UseVisualStyleBackColor = true;
            btn_discipline.Click += showDiscipline;
            // 
            // btn_catalog
            // 
            btn_catalog.Location = new Point(135, 298);
            btn_catalog.Name = "btn_catalog";
            btn_catalog.Size = new Size(75, 23);
            btn_catalog.TabIndex = 3;
            btn_catalog.Text = "Cataloage";
            btn_catalog.UseVisualStyleBackColor = true;
            btn_catalog.Click += showCatalog;
            // 
            // MenuAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_catalog);
            Controls.Add(btn_discipline);
            Controls.Add(btn_prof);
            Controls.Add(btn_student);
            Name = "MenuAdmin";
            Text = "MenuAdmin";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_student;
        private Button btn_prof;
        private Button btn_discipline;
        private Button btn_catalog;
    }
}