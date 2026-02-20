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
            btnAbrir = new Button();
            btnModificar = new Button();
            btnGuardar = new Button();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            btnExportar = new Button();
            btnImportar = new Button();
            btnEliminar = new Button();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 80);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(960, 450);
            dataGridView1.TabIndex = 0;
            // 
            // btnAbrir
            // 
            btnAbrir.Location = new Point(12, 12);
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(100, 30);
            btnAbrir.TabIndex = 1;
            btnAbrir.Text = "Abrir";
            btnAbrir.UseVisualStyleBackColor = true;
            btnAbrir.Click += btnAbrir_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(118, 12);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(100, 30);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(224, 12);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(542, 48);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 26);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 48);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Escriba texto para buscar...";
            txtBuscar.Size = new Size(524, 23);
            txtBuscar.TabIndex = 5;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(330, 12);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(100, 30);
            btnExportar.TabIndex = 6;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(436, 12);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(100, 30);
            btnImportar.TabIndex = 7;
            btnImportar.Text = "Importar";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(542, 12);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(648, 12);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 30);
            btnAgregar.TabIndex = 9;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 541);
            Controls.Add(btnAgregar);
            Controls.Add(btnEliminar);
            Controls.Add(btnImportar);
            Controls.Add(btnExportar);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(btnGuardar);
            Controls.Add(btnModificar);
            Controls.Add(btnAbrir);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Gestor de Archivos CSV";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnAbrir;
        private Button btnModificar;
        private Button btnGuardar;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Button btnExportar;
        private Button btnImportar;
        private Button btnEliminar;
        private Button btnAgregar;
    }
}
