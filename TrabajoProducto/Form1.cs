using System;
using Domain;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nest;

namespace TrabajoProducto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string id;
            string name;
            string description;
            int quantity;
            decimal price;
            DateTime caducityDate;

            try {
                id = txtCodigo.Text;
                name = txtNombre.Text;
                description = txtDescripcion.Text;

                quantity = Convert.ToInt32(txtCantidad.Text);
                caducityDate = Convert.ToDateTime(txtCaducidad.Text);
                ValidarCampos(id, name, description, txtCantidad.Text, txtPrecio.Text, txtCaducidad.Text);

                if (!decimal.TryParse(txtPrecio.Text, out price))
                {

                    MessageBox.Show($"Error, el precio: {txtPrecio.Text} no tiene el formato correcto",
                        "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

            Product product = new Product()
            {
              // Id = id,
            //    Name = name, 
            //    Description=description,
            //    Quantity= quantity,
            //    Price= price,
            //    CaducityDate= caducityDate
            };



            private void limpiar() {

                txtCodigo.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtCantidad.Text = string.Empty;
                txtPrecio.Text = string.Empty;
                txtCaducidad.Text = string.Empty;
                txtCodigo.Focus();

            }




            private void ValidarCampos(string id, string name, string description, string quantity, string price, string caducityDate)
            {
                if (string.IsNullOrWhiteSpace(id) ||
                    string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(description) ||
                    string.IsNullOrWhiteSpace(quantity) ||
                    string.IsNullOrWhiteSpace(price) ||
                    string.IsNullOrWhiteSpace(caducityDate))
                {
                    throw new ArgumentException("Error, todos los campos son requeridos");

                }
            }
        }
    }

