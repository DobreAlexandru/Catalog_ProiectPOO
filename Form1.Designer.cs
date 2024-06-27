namespace Catalog
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txt_user = new TextBox();
            txt_pass = new TextBox();
            btn_log = new Button();
            tip_user = new ComboBox();
            SuspendLayout();
            // 
            // txt_user
            // 
            txt_user.Location = new Point(306, 135);
            txt_user.Name = "txt_user";
            txt_user.Size = new Size(171, 23);
            txt_user.TabIndex = 0;
            // 
            // txt_pass
            // 
            txt_pass.Location = new Point(306, 190);
            txt_pass.Name = "txt_pass";
            txt_pass.Size = new Size(171, 23);
            txt_pass.TabIndex = 1;
            // 
            // btn_log
            // 
            btn_log.Location = new Point(501, 287);
            btn_log.Name = "btn_log";
            btn_log.Size = new Size(75, 23);
            btn_log.TabIndex = 2;
            btn_log.Text = "LOG IN";
            btn_log.UseVisualStyleBackColor = true;
            btn_log.Click += login;
            // 
            // tip_user
            // 
            tip_user.AccessibleName = "";
            tip_user.DropDownStyle = ComboBoxStyle.DropDownList;
            tip_user.FormattingEnabled = true;
            tip_user.Items.AddRange(new object[] { "Administrator", "Secretar", "Profesor", "Student" });
            tip_user.Location = new Point(575, 164);
            tip_user.Name = "tip_user";
            tip_user.Size = new Size(121, 23);
            tip_user.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tip_user);
            Controls.Add(btn_log);
            Controls.Add(txt_pass);
            Controls.Add(txt_user);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_user;
        private TextBox txt_pass;
        private Button btn_log;
        private ComboBox tip_user;
    }
}
