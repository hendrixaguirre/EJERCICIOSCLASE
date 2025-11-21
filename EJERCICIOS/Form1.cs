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
    public partial class Form1 : Form
    {
        int[] numeros = new int[20];
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                numeros[i] = rnd.Next(1, 100);
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int buscado;

            if (!int.TryParse(tbNumero.Text, out buscado))
            {
                lblResultados.Text = "Ingrese un número válido.";
                return;
            }

            bool encontrado = false;
            int posicion = -1;

            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] == buscado)
                {
                    encontrado = true;
                    posicion = i;
                    break;
                }
            }

            if (encontrado)
            {
                lblResultados.Text = $"El número {buscado} está en la posición {posicion}.";
            }
            else
            {
                lblResultados.Text = $"El número {buscado} NO existe en el arreglo.";
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                numeros[i] = rnd.Next(1, 100);
            }

            lblResultados.Text = "Arreglo generado: \n" + string.Join("\n ", numeros);
        }
    }
}
