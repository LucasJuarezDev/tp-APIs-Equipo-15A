using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Front
{
    public partial class FrmAddMarcaYCategoria : Form
    {

        public string TablaDestino { get; set; }

        public FrmAddMarcaYCategoria()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TablaDestino == "Marcas")
                    AgregarMarcaNueva();
                else
                    AgregarCategoriaNueva();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Close();
            }
        }

        private void AgregarMarcaNueva()
        {
            marcaNegocio marcas = new marcaNegocio();
            marcas.Agregar(txtNombre.Text);
        }

        private void AgregarCategoriaNueva()
        {
            categoriaNegocio categorias = new categoriaNegocio();
            categorias.Agregar(txtNombre.Text);
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string texto = txtNombre.Text.Trim();

                if (string.IsNullOrEmpty(texto))
                {
                    MessageBox.Show("Por favor completar el campo");
                    return;
                }
                else if (texto.All(char.IsDigit))
                {
                    MessageBox.Show("No se pueden ingresar solo números");
                    return;
                }

                if (TablaDestino == "Marcas")
                {
                    AgregarMarcaNueva();
                    MessageBox.Show("Marca Agregada exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    AgregarCategoriaNueva();
                    MessageBox.Show("Categoria Agregada exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FrmAddMarcaYCategoria_Load_1(object sender, EventArgs e)
        {
            if (TablaDestino == "Marcas")
                lblTitulo.Text = "Agregamos una Marca nueva";
            else
                lblTitulo.Text = "Agregamos una Categoria nueva";

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
