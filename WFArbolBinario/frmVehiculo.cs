using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFArbolBinario
{
    public partial class frmVehiculo : Form
    {
        ArbolBinarioBusqueda miArbol = new ArbolBinarioBusqueda();
        public frmVehiculo()
        {
            InitializeComponent();
        }

        private void Insertar_Click(object sender, EventArgs e)
        {
               miArbol.insertar(new Vehiculo(txtPlaca.Text,
                                                int.Parse(txtModelo.Text),
                                                txtMarca.Text));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = ArbolBinarioBusqueda.preorden(miArbol.raizArbol());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vehiculo miVehiculo;
            miVehiculo = (Vehiculo)miArbol.buscar(new Vehiculo(txtPlaca.Text)).valorNodo();
            MessageBox.Show(miVehiculo.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            miArbol.eliminar(new Vehiculo(txtPlaca.Text));
        }
    }
}
