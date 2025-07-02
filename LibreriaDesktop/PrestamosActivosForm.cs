using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaDesktop.Modelos;
using System.Net.Http.Json;

namespace LibreriaDesktop
{
    public partial class PrestamosActivosForm : Form
    {
        private List<PrestamoDto> prestamosGlobal = new();

        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7060/api/") // Cambiar puerto si es necesario
        };

        public PrestamosActivosForm()
        {
            InitializeComponent();
        }

        private async void PrestamosActivosForm_Load(object sender, EventArgs e)
        {
            await CargarPrestamosActivosAsync();
        }

        private async Task CargarPrestamosActivosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("prestamos");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                // CORRECTO: deserializamos como PrestamoDto
                var prestamos = JsonConvert.DeserializeObject<List<PrestamoDto>>(json);

                if (prestamos == null)
                {
                    MessageBox.Show("No se encontraron préstamos.");
                    return;
                }

                prestamosGlobal = prestamos;

                // Asignar directamente al DataGridView
                dataGridView1.DataSource = prestamos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar préstamos activos: " + ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un préstamo para devolver.");
                return;
            }

            int prestamoId = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;

            var prestamo = prestamosGlobal.FirstOrDefault(p => p.Id == prestamoId);
            if (prestamo == null)
            {
                MessageBox.Show("No se encontró el préstamo.");
                return;
            }

            var fechaDevolucion = DateTime.Now;
            var content = JsonContent.Create(fechaDevolucion);

            var result = await _httpClient.PutAsync($"prestamos/devolver/{prestamo.Id}", content);
            if (!result.IsSuccessStatusCode)
            {
                MessageBox.Show("Error al devolver el libro.");
                return;
            }

            // Obtener si hay interés
            var interesResponse = await _httpClient.GetAsync($"prestamos/{prestamo.Id}/interes");
            interesResponse.EnsureSuccessStatusCode();

            var interesJson = await interesResponse.Content.ReadAsStringAsync();
            var interesObj = JsonConvert.DeserializeObject<InteresResultado>(interesJson);

            if (interesObj.Interes > 0)
            {
                MessageBox.Show($"Libro devuelto con demora.\nInterés: ${interesObj.Interes}");
            }
            else
            {
                MessageBox.Show("Libro devuelto correctamente.");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
