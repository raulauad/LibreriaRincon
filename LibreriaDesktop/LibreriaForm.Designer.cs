namespace LibreriaDesktop
{
    partial class LibreriaForm
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
            dataGridViewLibros = new DataGridView();
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            aGREGARToolStripMenuItem = new ToolStripMenuItem();
            eDITARToolStripMenuItem = new ToolStripMenuItem();
            eLIMINARToolStripMenuItem = new ToolStripMenuItem();
            aCTUALIZARToolStripMenuItem = new ToolStripMenuItem();
            pRESTARToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLibros).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewLibros
            // 
            dataGridViewLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLibros.Location = new Point(83, 118);
            dataGridViewLibros.Name = "dataGridViewLibros";
            dataGridViewLibros.Size = new Size(779, 339);
            dataGridViewLibros.TabIndex = 0;
            dataGridViewLibros.SelectionChanged += dataGridViewLibros_SelectionChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(40, 44, 55);
            menuStrip1.Dock = DockStyle.Left;
            menuStrip1.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, aGREGARToolStripMenuItem, eDITARToolStripMenuItem, eLIMINARToolStripMenuItem, aCTUALIZARToolStripMenuItem, pRESTARToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(83, 613);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.BackColor = Color.DarkRed;
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem });
            archivoToolStripMenuItem.ForeColor = Color.White;
            archivoToolStripMenuItem.Margin = new Padding(0, 120, 0, 10);
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(70, 19);
            archivoToolStripMenuItem.Text = "ARCHIVO";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            salirToolStripMenuItem.ForeColor = Color.Black;
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(180, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // aGREGARToolStripMenuItem
            // 
            aGREGARToolStripMenuItem.BackColor = Color.DarkRed;
            aGREGARToolStripMenuItem.ForeColor = Color.White;
            aGREGARToolStripMenuItem.Margin = new Padding(0, 60, 0, 30);
            aGREGARToolStripMenuItem.Name = "aGREGARToolStripMenuItem";
            aGREGARToolStripMenuItem.Size = new Size(70, 19);
            aGREGARToolStripMenuItem.Text = "AGREGAR";
            aGREGARToolStripMenuItem.Click += agregarToolStripMenuItem_Click;
            // 
            // eDITARToolStripMenuItem
            // 
            eDITARToolStripMenuItem.BackColor = Color.DarkRed;
            eDITARToolStripMenuItem.ForeColor = Color.White;
            eDITARToolStripMenuItem.Margin = new Padding(0, 30, 0, 30);
            eDITARToolStripMenuItem.Name = "eDITARToolStripMenuItem";
            eDITARToolStripMenuItem.Size = new Size(70, 19);
            eDITARToolStripMenuItem.Text = "EDITAR";
            eDITARToolStripMenuItem.Click += editarToolStripMenuItem_Click;
            // 
            // eLIMINARToolStripMenuItem
            // 
            eLIMINARToolStripMenuItem.BackColor = Color.DarkRed;
            eLIMINARToolStripMenuItem.ForeColor = Color.White;
            eLIMINARToolStripMenuItem.Margin = new Padding(0, 30, 0, 20);
            eLIMINARToolStripMenuItem.Name = "eLIMINARToolStripMenuItem";
            eLIMINARToolStripMenuItem.Size = new Size(70, 19);
            eLIMINARToolStripMenuItem.Text = "ELIMINAR";
            eLIMINARToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // aCTUALIZARToolStripMenuItem
            // 
            aCTUALIZARToolStripMenuItem.BackColor = Color.DarkRed;
            aCTUALIZARToolStripMenuItem.ForeColor = Color.White;
            aCTUALIZARToolStripMenuItem.Margin = new Padding(0, 30, 0, 40);
            aCTUALIZARToolStripMenuItem.Name = "aCTUALIZARToolStripMenuItem";
            aCTUALIZARToolStripMenuItem.Size = new Size(70, 19);
            aCTUALIZARToolStripMenuItem.Text = "LIMPIAR";
            aCTUALIZARToolStripMenuItem.Click += limpiarToolStripMenuItem_Click;
            // 
            // pRESTARToolStripMenuItem
            // 
            pRESTARToolStripMenuItem.BackColor = Color.DarkRed;
            pRESTARToolStripMenuItem.ForeColor = Color.White;
            pRESTARToolStripMenuItem.Margin = new Padding(0, 20, 0, 30);
            pRESTARToolStripMenuItem.Name = "pRESTARToolStripMenuItem";
            pRESTARToolStripMenuItem.Size = new Size(70, 19);
            pRESTARToolStripMenuItem.Text = "PRESTAR";
            pRESTARToolStripMenuItem.Click += pRESTARToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(40, 44, 55);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Times New Roman", 35F);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(83, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 40, 50, 0);
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(779, 122);
            label1.TabIndex = 2;
            label1.Text = "El Rincón de la Lectura\n\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(348, 503);
            button1.Name = "button1";
            button1.Size = new Size(219, 35);
            button1.TabIndex = 3;
            button1.Text = "Libros Prestados";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // LibreriaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 613);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dataGridViewLibros);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "LibreriaForm";
            Text = "LibreriaForm";
            Load += LibrosForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewLibros).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewLibros;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem aGREGARToolStripMenuItem;
        private ToolStripMenuItem eDITARToolStripMenuItem;
        private ToolStripMenuItem eLIMINARToolStripMenuItem;
        private ToolStripMenuItem aCTUALIZARToolStripMenuItem;
        private Label label1;
        private ToolStripMenuItem pRESTARToolStripMenuItem;
        private Button button1;
        private ToolStripMenuItem salirToolStripMenuItem;
    }
}