namespace archCSV
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
            dataGridView1 = new DataGridView();
            panelControles = new Panel();
            txtBuscar = new TextBox();
            btnEliminar = new Button();
            btnImportar = new Button();
            btnExportar = new Button();
            btnBuscar = new Button();
            btnGuardar = new Button();
            btnModificar = new Button();
            btnAbrir = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelControles.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 330);
            dataGridView1.TabIndex = 0;
            // 
            // panelControles
            // 
            panelControles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelControles.Controls.Add(txtBuscar);
            panelControles.Controls.Add(btnEliminar);
            panelControles.Controls.Add(btnImportar);
            panelControles.Controls.Add(btnExportar);
            panelControles.Controls.Add(btnBuscar);
            panelControles.Controls.Add(btnGuardar);
            panelControles.Controls.Add(btnModificar);
            panelControles.Controls.Add(btnAbrir);
            panelControles.Location = new Point(12, 348);
            panelControles.Name = "panelControles";
            panelControles.Size = new Size(776, 90);
            panelControles.TabIndex = 1;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(535, 13);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Texto a buscar...";
            txtBuscar.Size = new Size(228, 23);
            txtBuscar.TabIndex = 7;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(218, 52);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar Fila";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(430, 52);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(100, 30);
            btnImportar.TabIndex = 5;
            btnImportar.Text = "Importar CSV";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(324, 52);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(100, 30);
            btnExportar.TabIndex = 4;
            btnExportar.Text = "Exportar CSV";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(430, 10);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 30);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(218, 10);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(112, 10);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(100, 30);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAbrir
            // 
            btnAbrir.Location = new Point(6, 10);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(100, 30);
            btnAbrir.TabIndex = 0;
            btnAbrir.Text = "Abrir CSV";
            btnAbrir.UseVisualStyleBackColor = true;
            btnAbrir.Click += btnAbrir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelControles);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Gestor de Archivos CSV";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelControles.ResumeLayout(false);
            panelControles.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panelControles;
        private Button btnAbrir;
        private Button btnModificar;
        private Button btnGuardar;
        private Button btnBuscar;
        private Button btnExportar;
        private Button btnImportar;
        private Button btnEliminar;
        private TextBox txtBuscar;
    }
}
