using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJERCICIOS
{
    public partial class Form4 : Form
    {
        List<Estudiante> estudiantes = new List<Estudiante>();
        public Form4()
        {
            InitializeComponent();
            CargarEstudiantes();
        }

        class Estudiante
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        private void CargarEstudiantes()
        {
            estudiantes.Add(new Estudiante { Id = 1, Nombre = "Ana" });
            estudiantes.Add(new Estudiante { Id = 2, Nombre = "Brenda" });
            estudiantes.Add(new Estudiante { Id = 3, Nombre = "Carlos" });
            estudiantes.Add(new Estudiante { Id = 4, Nombre = "Daniel" });
            estudiantes.Add(new Estudiante { Id = 5, Nombre = "Erick" });
            estudiantes.Add(new Estudiante { Id = 6, Nombre = "Fernanda" });
            estudiantes.Add(new Estudiante { Id = 7, Nombre = "Gabriel" });
            estudiantes.Add(new Estudiante { Id = 8, Nombre = "Hector" });
            estudiantes.Add(new Estudiante { Id = 9, Nombre = "Ivania" });
            estudiantes.Add(new Estudiante { Id = 10, Nombre = "Josue" });

            // Ordenamos la lista por nombre (para la búsqueda binaria)
            estudiantes = estudiantes.OrderBy(e => e.Nombre).ToList();

            // Mostrar todos en el ListBox principal
            lbEstudiantes.Items.Clear();
            foreach (var est in estudiantes)
            {
                lbEstudiantes.Items.Add($"ID: {est.Id} - Nombre: {est.Nombre}");
            }
        }

        private void btnBuscarID_Click(object sender, EventArgs e)
        {
            lbResultadoID.Items.Clear();

            int idBuscado;
            if (!int.TryParse(tbID.Text, out idBuscado))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }

            bool encontrado = false;

            foreach (var est in estudiantes)
            {
                if (est.Id == idBuscado)
                {
                    lbResultadoID.Items.Add($"ID: {est.Id} - Nombre: {est.Nombre}");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                lbResultadoID.Items.Add("Estudiante NO encontrado.");
            }
        }

        private void btnBuscarN_Click(object sender, EventArgs e)
        {
            lbResultadoN.Items.Clear();

            string nombreBuscado = tbNombre.Text.Trim();

            int inicio = 0;
            int fin = estudiantes.Count - 1;

            while (inicio <= fin)
            {
                int medio = (inicio + fin) / 2;

                int comparacion = string.Compare(estudiantes[medio].Nombre,
                                                 nombreBuscado,
                                                 StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0)
                {
                    lbResultadoN.Items.Add($"ID: {estudiantes[medio].Id} - Nombre: {estudiantes[medio].Nombre}");
                    return;
                }
                else if (comparacion < 0)
                {
                    inicio = medio + 1;
                }
                else
                {
                    fin = medio - 1;
                }
            }

            lbResultadoN.Items.Add("Estudiante NO encontrado.");
        }
    }
}
