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
    public partial class Form2 : Form
    {
        List<int> numeros = new List<int>();
        Random rnd = new Random();
        public Form2()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            numeros.Clear();

            for (int i = 0; i < 30; i++)
                numeros.Add(rnd.Next(0, 101)); // 0 a 100

            lbNumeros.Items.Clear();
            foreach (var n in numeros)
                lbNumeros.Items.Add(n);

            lbPasos.Items.Clear();
            lblResultado.Text = "Números generados (no ordenados).";
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (numeros.Count == 0)
            {
                MessageBox.Show("Primero genera los números.");
                return;
            }

            numeros.Sort();

            lbNumeros.Items.Clear();
            for (int i = 0; i < numeros.Count; i++)
                lbNumeros.Items.Add($"[{i}] {numeros[i]}");

            lbPasos.Items.Clear();
            lblResultado.Text = "Lista ordenada.";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (numeros.Count == 0)
            {
                MessageBox.Show("Primero genera y ordena los números.");
                return;
            }

            int objetivo;
            if (!int.TryParse(tbNumero.Text, out objetivo))
            {
                MessageBox.Show("Ingresa un número válido.");
                return;
            }

            numeros.Sort(); // asegurar orden
            lbNumeros.Items.Clear();
            for (int i = 0; i < numeros.Count; i++)
                lbNumeros.Items.Add($"[{i}] {numeros[i]}");

            lbPasos.Items.Clear();
            lblResultado.Text = "";

            int bajo = 0;
            int alto = numeros.Count - 1;
            int paso = 1;
            bool encontrado = false;

            while (bajo <= alto)
            {
                int medio = (bajo + alto) / 2;
                int valorMedio = numeros[medio];

                // Mostrar paso
                lbPasos.Items.Add($"Paso {paso}: bajo={bajo}, alto={alto}, medio={medio}, valor={valorMedio}");
                lbPasos.Items.Add("  Sublista: " + string.Join(", ", numeros.GetRange(bajo, alto - bajo + 1)));
                lbPasos.Items.Add("");

                if (valorMedio == objetivo)
                {
                    lblResultado.Text = $"¡Encontrado! El número {objetivo} está en el índice {medio}.";
                    encontrado = true;
                    break;
                }
                else if (objetivo < valorMedio)
                {
                    alto = medio - 1;
                }
                else
                {
                    bajo = medio + 1;
                }

                paso++;
            }

            if (!encontrado)
                lblResultado.Text = $"No se encontró el número {objetivo}.";
        }
    }
}
