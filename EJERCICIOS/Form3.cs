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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string parrafo = tbParrafo.Text.ToLower();   // Para ignorar mayúsculas
            string palabra = tbPalabra.Text.ToLower();

            if (string.IsNullOrWhiteSpace(parrafo) || string.IsNullOrWhiteSpace(palabra))
            {
                lblResultado.Text = "Ingrese ambos datos.";
                return;
            }

            int contador = ContarApariciones(parrafo, palabra);

            lblResultado.Text = $"La palabra aparece {contador} veces.";
        }

        private int ContarApariciones(string texto, string palabra)
        {
            int contador = 0;
            int i = 0;

            while (i <= texto.Length - palabra.Length)
            {
                bool coincide = true;

                // Revisamos carácter por carácter
                for (int j = 0; j < palabra.Length; j++)
                {
                    if (texto[i + j] != palabra[j])
                    {
                        coincide = false;
                        break;
                    }
                }

                if (coincide)
                {
                    contador++;
                    i += palabra.Length; // avanzar para evitar superposiciones
                }
                else
                {
                    i++;
                }
            }

            return contador;
        }
    }
}
