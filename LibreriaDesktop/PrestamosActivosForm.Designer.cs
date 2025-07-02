namespace LibreriaDesktop
{
    partial class PrestamosActivosForm
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
            dataGridView1 = new DataGridView();
            btnDevolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(779, 260);
            dataGridView1.TabIndex = 0;
            // 
            // btnDevolver
            // 
            btnDevolver.Location = new Point(306, 278);
            btnDevolver.Name = "btnDevolver";
            btnDevolver.Size = new Size(166, 46);
            btnDevolver.TabIndex = 1;
            btnDevolver.Text = "DEVOLVER";
            btnDevolver.UseVisualStyleBackColor = true;
            btnDevolver.Click += button1_Click;
            // 
            // PrestamosActivosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 336);
            Controls.Add(btnDevolver);
            Controls.Add(dataGridView1);
            Name = "PrestamosActivosForm";
            Text = "PrestamosActivosForm";
            Load += PrestamosActivosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnDevolver;
    }
}