using System.Data;
using System.IO;
using System.Text;

namespace archCSV
{
    public partial class Form1 : Form
    {
        // Variable para almacenar la ruta del archivo CSV actual
        private string archivoActual = string.Empty;
        
        // DataTable para manejar los datos del CSV
        private DataTable tablaOriginal = new DataTable();

        public Form1()
        {
            InitializeComponent();
            ConfigurarDataGridView();
        }

        /// <summary>
        /// Configura las propiedades iniciales del DataGridView
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
        }

        /// <summary>
        /// Botón 1: Abrir archivo CSV y cargar datos en el DataGridView
        /// </summary>
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                // Configurar el cuadro de diálogo para abrir archivos
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
                    openFileDialog.Title = "Seleccionar archivo CSV";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        archivoActual = openFileDialog.FileName;
                        CargarCSV(archivoActual, true);
                        MessageBox.Show("Archivo cargado correctamente", "Éxito", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga un archivo CSV en el DataGridView
        /// </summary>
        /// <param name="rutaArchivo">Ruta del archivo CSV</param>
        /// <param name="limpiarTabla">Si es true, limpia la tabla antes de cargar</param>
        private void CargarCSV(string rutaArchivo, bool limpiarTabla = false)
        {
            try
            {
                // Leer todas las líneas del archivo
                string[] lineas = File.ReadAllLines(rutaArchivo, Encoding.UTF8);

                if (lineas.Length == 0)
                {
                    MessageBox.Show("El archivo está vacío", "Advertencia", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Si se requiere limpiar la tabla, crear una nueva
                if (limpiarTabla)
                {
                    tablaOriginal = new DataTable();
                    
                    // La primera línea contiene los encabezados
                    string[] encabezados = lineas[0].Split(',');
                    foreach (string encabezado in encabezados)
                    {
                        tablaOriginal.Columns.Add(encabezado.Trim());
                    }
                }

                // Procesar las líneas de datos (desde la línea 1 en adelante)
                int inicio = limpiarTabla ? 1 : 0;
                for (int i = inicio; i < lineas.Length; i++)
                {
                    string[] valores = lineas[i].Split(',');
                    
                    // Asegurar que la cantidad de valores coincida con las columnas
                    if (valores.Length == tablaOriginal.Columns.Count)
                    {
                        DataRow fila = tablaOriginal.NewRow();
                        for (int j = 0; j < valores.Length; j++)
                        {
                            fila[j] = valores[j].Trim();
                        }
                        tablaOriginal.Rows.Add(fila);
                    }
                }

                // Asignar el DataTable al DataGridView
                dataGridView1.DataSource = tablaOriginal;
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"Error de acceso al archivo: {ioEx.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el CSV: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón 2: Habilitar edición de la fila seleccionada
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una fila para modificar", "Advertencia", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Habilitar modo de edición en la fila seleccionada
                int indice = dataGridView1.SelectedRows[0].Index;
                dataGridView1.CurrentCell = dataGridView1.Rows[indice].Cells[0];
                dataGridView1.BeginEdit(true);

                MessageBox.Show("Puede editar la fila seleccionada. Los cambios se aplicarán automáticamente.", 
                    "Modo de Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón 3: Guardar cambios en el archivo CSV
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(archivoActual))
                {
                    // Si no hay archivo cargado, usar SaveFileDialog
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
                        saveFileDialog.Title = "Guardar archivo CSV";
                        saveFileDialog.FileName = "datos.csv";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            archivoActual = saveFileDialog.FileName;
                        }
                        else
                        {
                            return;
                        }
                    }
                }

                GuardarCSV(archivoActual);
                MessageBox.Show("Archivo guardado correctamente", "Éxito", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Guarda los datos del DataGridView en un archivo CSV
        /// </summary>
        /// <param name="rutaArchivo">Ruta donde se guardará el archivo</param>
        private void GuardarCSV(string rutaArchivo)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                // Escribir encabezados
                List<string> encabezados = new List<string>();
                foreach (DataGridViewColumn columna in dataGridView1.Columns)
                {
                    encabezados.Add(columna.HeaderText);
                }
                sb.AppendLine(string.Join(",", encabezados));

                // Escribir filas de datos
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    List<string> valores = new List<string>();
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        string valor = celda.Value?.ToString() ?? string.Empty;
                        valores.Add(valor);
                    }
                    sb.AppendLine(string.Join(",", valores));
                }

                // Guardar en el archivo
                File.WriteAllText(rutaArchivo, sb.ToString(), Encoding.UTF8);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("No tiene permisos para guardar en esta ubicación", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón 4: Buscar y filtrar datos en el DataGridView
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string textoBusqueda = txtBuscar.Text.Trim();

                if (string.IsNullOrEmpty(textoBusqueda))
                {
                    // Si el texto está vacío, mostrar todos los datos
                    dataGridView1.DataSource = tablaOriginal;
                    return;
                }

                // Crear una tabla filtrada
                DataTable tablaFiltrada = tablaOriginal.Clone();

                foreach (DataRow fila in tablaOriginal.Rows)
                {
                    bool encontrado = false;
                    foreach (var item in fila.ItemArray)
                    {
                        if (item.ToString().ToLower().Contains(textoBusqueda.ToLower()))
                        {
                            encontrado = true;
                            break;
                        }
                    }

                    if (encontrado)
                    {
                        tablaFiltrada.ImportRow(fila);
                    }
                }

                dataGridView1.DataSource = tablaFiltrada;

                if (tablaFiltrada.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron resultados", "Búsqueda", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón 5: Exportar datos actuales a un nuevo archivo CSV
        /// </summary>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar", "Advertencia", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
                    saveFileDialog.Title = "Exportar a CSV";
                    saveFileDialog.FileName = "exportacion.csv";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        GuardarCSV(saveFileDialog.FileName);
                        MessageBox.Show("Datos exportados correctamente", "Éxito", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón 6: Importar datos de otro archivo CSV y añadirlos a los datos actuales
        /// </summary>
        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
                    openFileDialog.Title = "Importar datos desde CSV";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (tablaOriginal.Columns.Count == 0)
                        {
                            // Si no hay datos cargados, cargar como nuevo archivo
                            CargarCSV(openFileDialog.FileName, true);
                        }
                        else
                        {
                            // Añadir datos al archivo actual
                            string[] lineas = File.ReadAllLines(openFileDialog.FileName, Encoding.UTF8);

                            if (lineas.Length > 1)
                            {
                                // Verificar que los encabezados coincidan
                                string[] encabezadosImportados = lineas[0].Split(',');
                                
                                if (encabezadosImportados.Length != tablaOriginal.Columns.Count)
                                {
                                    MessageBox.Show("El archivo a importar no tiene la misma estructura de columnas", 
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Importar filas (omitir encabezado)
                                int filasImportadas = 0;
                                for (int i = 1; i < lineas.Length; i++)
                                {
                                    string[] valores = lineas[i].Split(',');
                                    if (valores.Length == tablaOriginal.Columns.Count)
                                    {
                                        DataRow fila = tablaOriginal.NewRow();
                                        for (int j = 0; j < valores.Length; j++)
                                        {
                                            fila[j] = valores[j].Trim();
                                        }
                                        tablaOriginal.Rows.Add(fila);
                                        filasImportadas++;
                                    }
                                }

                                dataGridView1.DataSource = null;
                                dataGridView1.DataSource = tablaOriginal;

                                MessageBox.Show($"Se importaron {filasImportadas} filas correctamente", 
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Botón 7: Eliminar la fila seleccionada del DataGridView
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya una fila seleccionada
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una fila para eliminar", "Advertencia", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar la eliminación con el usuario
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea eliminar la fila seleccionada?", 
                    "Confirmar eliminación", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Obtener el índice de la fila seleccionada
                    int indice = dataGridView1.SelectedRows[0].Index;

                    // Eliminar la fila del DataTable original
                    tablaOriginal.Rows[indice].Delete();
                    tablaOriginal.AcceptChanges();

                    // Refrescar el DataGridView
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = tablaOriginal;

                    MessageBox.Show("Fila eliminada correctamente", "Éxito", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la fila: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
