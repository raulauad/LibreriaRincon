using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json;
using LibreriaDesktop.Modelos;
using Microsoft.VisualBasic;


namespace LibreriaDesktop
{
    public partial class LibreriaForm : Form
    {

        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7060/api/") // ajustá el puerto
        };

        private int currentLibroId = 0;


        public LibreriaForm()
        {
            InitializeComponent();
        }






        private async Task CargarLibrosAsync()
        {
            try
            {
                dataGridViewLibros.SelectionChanged -= dataGridViewLibros_SelectionChanged;

                var response = await _httpClient.GetAsync("libros");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var libros = JsonConvert.DeserializeObject<List<Libro>>(json);

                dataGridViewLibros.DataSource = libros;
                dataGridViewLibros.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar libros: " + ex.Message);
            }
            finally
            {
                dataGridViewLibros.SelectionChanged += dataGridViewLibros_SelectionChanged;
            }
        }



        private async void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string titulo = Interaction.InputBox("Ingresá el título del libro:", "Agregar Libro");
            string autor = Interaction.InputBox("Ingresá el autor del libro:", "Agregar Libro");
            string genero = Interaction.InputBox("Ingresá el género del libro:", "Agregar Libro");

            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor))
            {
                MessageBox.Show("Título y autor son obligatorios.");
                return;
            }

            var nuevoLibro = new Libro
            {
                Titulo = titulo,
                Autor = autor,
                Genero = genero,
                Disponible = true
            };

            var response = await _httpClient.PostAsJsonAsync("libros", nuevoLibro);
            if (response.IsSuccessStatusCode)
            {
                await CargarLibrosAsync();
                MessageBox.Show("Libro agregado correctamente.");
            }
            else
            {
                MessageBox.Show("Error al agregar libro.");
            }
        }

        private async void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un libro para editar.");
                return;
            }

            var libro = (Libro)dataGridViewLibros.SelectedRows[0].DataBoundItem;

            string nuevoTitulo = Interaction.InputBox("Nuevo título:", "Editar Libro", libro.Titulo);
            string nuevoAutor = Interaction.InputBox("Nuevo autor:", "Editar Libro", libro.Autor);
            string nuevoGenero = Interaction.InputBox("Nuevo género:", "Editar Libro", libro.Genero);

            libro.Titulo = nuevoTitulo;
            libro.Autor = nuevoAutor;
            libro.Genero = nuevoGenero;

            var response = await _httpClient.PutAsJsonAsync($"libros/{libro.Id}", libro);
            if (response.IsSuccessStatusCode)
            {
                await CargarLibrosAsync();
                MessageBox.Show("Libro actualizado.");
            }
        }

        private async void LibrosForm_Load(object sender, EventArgs e)
        {
            await CargarLibrosAsync();
        }





        private void dataGridViewLibros_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewLibros.SelectedRows.Count > 0)
            {
                var libro = (Libro)dataGridViewLibros.SelectedRows[0].DataBoundItem;

            }
        }


        private async void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un libro para eliminar.");
                return;
            }

            var libro = (Libro)dataGridViewLibros.SelectedRows[0].DataBoundItem;

            var confirm = MessageBox.Show(
                $"¿Estás seguro que querés eliminar el libro \"{libro.Titulo}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var response = await _httpClient.DeleteAsync($"libros/{libro.Id}");
                    if (response.IsSuccessStatusCode)
                    {
                        await CargarLibrosAsync();
                        MessageBox.Show("Libro eliminado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el libro.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la API: " + ex.Message);
                }
            }
        }

        private async void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Estás seguro de que querés eliminar todos los libros?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                var response = await _httpClient.DeleteAsync("libros/eliminar-todos");
                if (response.IsSuccessStatusCode)
                {
                    await CargarLibrosAsync();
                    MessageBox.Show("Todos los libros han sido eliminados.");
                }
                else
                {
                    MessageBox.Show("Error al eliminar los libros.");
                }
            }
        }

        private async void pRESTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un libro para prestar.");
                return;
            }

            var libro = (Libro)dataGridViewLibros.SelectedRows[0].DataBoundItem;

            if (!libro.Disponible)
            {
                MessageBox.Show("El libro no está disponible para préstamo.");
                return;
            }

            string fechaLimiteTexto = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingresá la fecha límite para devolver el libro (formato: dd/MM/yyyy):",
                "Fecha límite",
                DateTime.Now.AddDays(7).ToString("dd/MM/yyyy")
            );

            if (!DateTime.TryParse(fechaLimiteTexto, out DateTime fechaLimite))
            {
                MessageBox.Show("Fecha inválida.");
                return;
            }

            var prestamo = new Prestamo
            {
                LibroId = libro.Id,
                FechaPrestamo = DateTime.Now,
                FechaLimiteDevolucion = fechaLimite
            };

            var response = await _httpClient.PostAsJsonAsync("prestamos", prestamo);
            if (response.IsSuccessStatusCode)
            {
                await CargarLibrosAsync();
                MessageBox.Show("Libro prestado correctamente hasta el " + fechaLimite.ToShortDateString());
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Error al prestar libro: " + error);
            }
        }




        private async void dEVOLVERToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (dataGridViewLibros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un libro prestado para devolver.");
                return;
            }

            var libro = (Libro)dataGridViewLibros.SelectedRows[0].DataBoundItem;

            if (libro.Disponible)
            {
                MessageBox.Show("Este libro ya está disponible, no requiere devolución.");
                return;
            }

            try
            {
                // Obtener préstamo activo
                var response = await _httpClient.GetAsync("prestamos");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var prestamos = JsonConvert.DeserializeObject<List<Prestamo>>(json);

                var prestamoActivo = prestamos.FirstOrDefault(p => p.LibroId == libro.Id && p.FechaDevolucion == null);

                if (prestamoActivo == null)
                {
                    MessageBox.Show("No se encontró un préstamo activo para este libro.");
                    return;
                }

                // Registrar la devolución
                var fechaDevolucion = DateTime.Now;
                var content = JsonContent.Create(fechaDevolucion);
                var result = await _httpClient.PutAsync($"prestamos/devolver/{prestamoActivo.Id}", content);

                if (!result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al devolver el libro.");
                    return;
                }

                await CargarLibrosAsync();

                // Consultar si hay interés
                var interesResponse = await _httpClient.GetAsync($"prestamos/{prestamoActivo.Id}/interes");
                interesResponse.EnsureSuccessStatusCode();

                var interesJson = await interesResponse.Content.ReadAsStringAsync();
                var interesObj = JsonConvert.DeserializeObject<InteresResultado>(interesJson);

                if (interesObj.Interes > 0)
                {
                    MessageBox.Show($"Libro devuelto con demora.\nInterés por demora: ${interesObj.Interes}");
                }
                else
                {
                    MessageBox.Show("Libro devuelto a tiempo. ¡Gracias!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var form = new PrestamosActivosForm();
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                await CargarLibrosAsync();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
