// MenuForm.Designer.cs
namespace Catalog
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.Button btnSave;

        private void InitializeComponent()
        {
            dataGridViewStudents = new DataGridView();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Location = new Point(12, 12);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.Size = new Size(240, 150);
            dataGridViewStudents.TabIndex = 0;
            dataGridViewStudents.CellClick += dataGridViewStudents_CellClick;
            dataGridViewStudents.CellContentClick += dataGridViewStudents_CellContentClick;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(177, 168);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // MenuForm
            // 
            ClientSize = new Size(284, 201);
            Controls.Add(btnSave);
            Controls.Add(dataGridViewStudents);
            Name = "MenuForm";
            Load += MenuForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            ResumeLayout(false);
        }
    }
}
