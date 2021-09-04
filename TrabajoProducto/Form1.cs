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
using Newtonsoft.Json;
using Infraestructure;
using Domain.enums;

namespace TrabajoProducto
{
    public partial class Form1 : Form
    {
        private ProductModel productModel;
        public Form1()
        {
            InitializeComponent();
            rtxImprimir.ReadOnly = true;
            productModel = new ProductModel();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int id;
            string name, description;
            int quantity;
            decimal price;
            DateTime caducityDate;

            try {
                
                
                name = txtNombre.Text;
                description = txtDescripcion.Text;

                if (!int.TryParse(txtCantidad.Text, out quantity))
                {

                    MessageBox.Show($"Error, la cantidad: {txtCantidad.Text} no tiene el formato correcto",
                        "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }
                if (!DateTime.TryParse(txtCaducidad.Text, out caducityDate))
                {

                    MessageBox.Show($"Error, la fecha: {txtCaducidad.Text} no tiene el formato correcto",
                        "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }
                ValidarCampos(txtCodigo.Text, name, description, txtCantidad.Text, txtPrecio.Text, txtCaducidad.Text);
                if (!int.TryParse(txtCodigo.Text, out id))
                {
                    MessageBox.Show($"Error, el código de identificación: {txtCodigo.Text} no tiene el formato correcto",
                        "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!decimal.TryParse(txtPrecio.Text, out price))
                {

                    MessageBox.Show($"Error, el precio: {txtPrecio.Text} no tiene el formato correcto",
                        "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }
                if (cmbUnidades.SelectedIndex.Equals(-1))
                {
                    MessageBox.Show("Llene todos los datos", "Mensaje de Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
           

                Product product = new Product()
                {
                    Id = id,
                    Name = name,
                    Description = description,
                    Quantity = quantity,
                    Price = price,
                    CaducityDate = caducityDate,
                    UnitMeasure = (UnitMeasure)cmbUnidades.SelectedIndex
                };

                productModel.Add(product);
                productModel.Update(product); 

                string jsonObject = JsonConvert.SerializeObject(product);

                rtxImprimir.Text = $"Producto agregado:" +
                    $"  " +
                    jsonObject;
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

            private void limpiar() {

                txtCodigo.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtCantidad.Text = string.Empty;
                txtPrecio.Text = string.Empty;
                txtCaducidad.Text = string.Empty;
                txtBusqueda.Text = string.Empty; 
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string name, description;
            int quantity, id;
            decimal price;
            DateTime caducityDate;

            try
            {
                if(!int.TryParse(txtCodigo.Text, out id))
                {
                    MessageBox.Show($"Error, el código de identificación: {txtCodigo.Text} no tiene el formato correcto",
                        "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                name = txtNombre.Text;
                description = txtDescripcion.Text;

                if (!int.TryParse(txtCantidad.Text, out quantity))
                {

                    MessageBox.Show($"Error, la cantidad: {txtCantidad.Text} no tiene el formato correcto",
                        "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }
                if (!DateTime.TryParse(txtCaducidad.Text, out caducityDate))
                {

                    MessageBox.Show($"Error, la fecha: {txtCaducidad.Text} no tiene el formato correcto",
                        "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }
                ValidarCampos(txtCodigo.Text, name, description, txtCantidad.Text, txtPrecio.Text, txtCaducidad.Text);

                if (!decimal.TryParse(txtPrecio.Text, out price))
                {

                    MessageBox.Show($"Error, el precio: {txtPrecio.Text} no tiene el formato correcto",
                        "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }

                Product product = new Product()
                {
                    Id = id,
                    Name = name,
                    Description = description,
                    Quantity = quantity,
                    Price = price,
                    CaducityDate = caducityDate,
                    UnitMeasure = (UnitMeasure)cmbUnidades.SelectedIndex
                };

                productModel.Update(product);

                string jsonObject = JsonConvert.SerializeObject(product);

                rtxImprimir.Text = $"Producto actualizado:" +
                    $"  " +
                    jsonObject;
                limpiar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string name, description;
            int id;
            //int quantity;
            //decimal price;
            //DateTime caducityDate;

            try
            {
                if(!int.TryParse(txtCodigo.Text, out id))
                {
                    MessageBox.Show($"Error, el código de identificación: {txtCodigo.Text} no tiene el formato correcto",
                        "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //name = txtNombre.Text;
                //description = txtDescripcion.Text;

                //if (!int.TryParse(txtCantidad.Text, out quantity))
                //{

                //    MessageBox.Show($"Error, la cantidad: {txtCantidad.Text} no tiene el formato correcto",
                //        "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    return;

                //}
                //if (!DateTime.TryParse(txtCaducidad.Text, out caducityDate))
                //{

                //    MessageBox.Show($"Error, la fecha: {txtCaducidad.Text} no tiene el formato correcto",
                //        "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    return;

                //}
                //ValidarCampos(id, name, description, txtCantidad.Text, txtPrecio.Text, txtCaducidad.Text);

                //if (!decimal.TryParse(txtPrecio.Text, out price))
                //{

                //    MessageBox.Show($"Error, el precio: {txtPrecio.Text} no tiene el formato correcto",
                //        "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    return;

                //}

                Product product = new Product()
                {
                    Id = id
                    //Name = name,
                    //Description = description,
                    //Quantity = quantity,
                    //Price = price,
                    //CaducityDate = caducityDate,
                    //UnitMeasure = (UnitMeasure)cmbUnidades.SelectedIndex
                };

                productModel.Delete(product);

                string jsonObject = JsonConvert.SerializeObject(product);

                rtxImprimir.Text = $"El Producto se ha eliminado con exito.";
                    
                limpiar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigo;
            int id;
            string name, description;
            int quantity;
            decimal price;
            DateTime caducityDate;



            try
            {

                codigo = txtBusqueda.Text;
                ValidarBusqueda(codigo);

                if (cmbBusqueda.SelectedIndex.Equals(-1))
                {
                    MessageBox.Show("Llene todos los datos", "Mensaje de Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                if (!int.TryParse(txtBusqueda.Text, out id))
                {
                    MessageBox.Show($"Error, el código de identificación: {txtBusqueda.Text} no tiene el formato correcto",
                        "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Product product = new Product()
                {
                    Id = id,
                    UnitMeasure = (UnitMeasure)cmbUnidades.SelectedIndex
                };

                productModel.FindById(id);

                string jsonObject = JsonConvert.SerializeObject(id);

                rtxImprimir.Text = $"El producto con codigo {product}:" +
                    $"  " +
                    jsonObject;
                limpiar();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            limpiar(); 
            }
        private void ValidarBusqueda(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                throw new ArgumentException("Error, se requieren todos los campos"); 

            }
        }
    }
    }

