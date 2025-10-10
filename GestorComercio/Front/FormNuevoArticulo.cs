using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Front
{
    public partial class FormNuevoArticulo : Form
    {
        private int idImageToModify = 0;
        private string Tipo = "";
        private string placeHolderImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxdAOY_-vITFVI-ej84s2U_ErxhOly-z3y_Q&s";
        private bool hasImageLoad = false;
        private Articulo Articulo = null;
        articuloNegocio articuloNegocio = new articuloNegocio();
        imagenNegocio imagenNegocio = new imagenNegocio();

        private Articulo articulo = null;
        private List<Imagen> imagenesArt = null;

        public event Action<int, string> ImagenActualizada;

        public event Action<int, int> ImagenHaciaDGV;


        ///////////////////////////////////////  OTROS METODOS    ////////////////////////////////////////////
        private void cmbImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string url = ((Imagen)cmbImagenes.SelectedItem).Url;
                pbxAgregado.Load(url);
            }
            catch (Exception)
            {
                pbxAgregado.Load(this.placeHolderImage);
            }
        }

        private void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtUrlImagen.TextLength > 0)
                {
                    this.hasImageLoad = true;
                    btnNuevaImagen.Enabled = true;
                    btnModificarUrlImagen.Enabled = true;
                }
                else
                {
                    this.hasImageLoad = false;
                    btnNuevaImagen.Enabled = false;
                    btnModificarUrlImagen.Enabled = false;
                }
                pbxAgregado.Load(txtUrlImagen.Text);
            }
            catch (Exception)
            {
                pbxAgregado.Load(this.placeHolderImage);
            }
        }

        private void btnModificarUrlImagen_Click(object sender, EventArgs e)
        {
            Imagen obj = (Imagen)cmbImagenes.SelectedItem;
            this.idImageToModify = obj.Id;
            //MessageBox.Show(this.idImageToModify);
            try
            {
                DialogResult resultSobrescribir = MessageBox.Show(
                "¿Quieres sobreescribir la imagen?",
                "Modificar imagen",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (resultSobrescribir == DialogResult.Yes)
                {
                    imagenNegocio.modifyImage(txtUrlImagen.Text, this.Articulo.Id, this.idImageToModify);
                    ImagenActualizada?.Invoke(this.Articulo.Id, txtUrlImagen.Text);
                    this.idImageToModify = 0;
                    MessageBox.Show("Imagen cambiada con éxito!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnNuevaImagen_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultNueva = MessageBox.Show(
                    "¿Quieres guardarla como nueva?",
                    "Guardar imagen",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultNueva == DialogResult.Yes)
                {
                    imagenNegocio.addImage(txtUrlImagen.Text, this.Articulo.Id);
                    MessageBox.Show("Imagen guardada como nueva!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        ///////////////////////////////////////  CONSTRUCTORES  ////////////////////////////////////////////
        public FormNuevoArticulo(string tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;
            lblTitulo.Text = "Agrega tu nuevo articulo";
            BTN_Cargar_Art.Text = "Cargar";

            cmbImagenes.Visible = false;
            lblcomboboxImagenes.Visible = false;
            btnModificarUrlImagen.Visible = false;
            btnNuevaImagen.Visible = false;
        }

        public FormNuevoArticulo(string tipo, Articulo articulo)
        {
            InitializeComponent();
            this.Tipo = tipo;
            lblTitulo.Text = "Modificar articulo";
            BTN_Cargar_Art.Text = "Modificar";
            this.Articulo = articulo;
        }

        ///////////////////////////////////////  MANIPULACION DE ARTICULO  ////////////////////////////////////////////
        private void FormNuevoArticulo_Load(object sender, EventArgs e)
        {
            marcaNegocio marcaNegocio = new marcaNegocio();
            categoriaNegocio categoriaNegocio = new categoriaNegocio();
            btnNuevaImagen.Enabled = false;
            btnModificarUrlImagen.Enabled = false;
            txtIdArt.Text = this.Tipo == "Agregar" ? articuloNegocio.ReturnID().ToString() : this.Articulo.Id.ToString();

            try
            {
                if (this.Tipo == "Modificar")
                {
                    cboMarca.DataSource = marcaNegocio.ListarMarcas();
                    cboMarca.ValueMember = "Id";
                    cboMarca.DisplayMember = "Descripcion";

                    cboCategoria.DataSource = categoriaNegocio.ListarCategorias();
                    cboCategoria.ValueMember = "Id";
                    cboCategoria.DisplayMember = "Descripcion";

                    cmbImagenes.DataSource = imagenNegocio.listImagesById(this.Articulo.Id);
                    cmbImagenes.ValueMember = "Id";
                    cmbImagenes.DisplayMember = "Url";

                    if (cmbImagenes.Items.Count > 0)
                    {
                        Imagen primera = (Imagen)cmbImagenes.Items[0];
                        pbxAgregado.Load(primera.Url);
                    }
                    else
                    {
                        pbxAgregado.Load(this.placeHolderImage);
                    }

                    if (Articulo != null)
                    {
                        txtCodigo.Text = Articulo.Codigo;
                        txtNombre.Text = Articulo.Nombre;
                        txtDescripcion.Text = Articulo.Descripcion;
                        txtPrecio.Text = Articulo.Precio.ToString();

                        if (Articulo.TipoMarca != null)
                            cboMarca.SelectedValue = Articulo.TipoMarca.Id;

                        if (Articulo.TipoCategoria != null)
                            cboCategoria.SelectedValue = Articulo.TipoCategoria.Id;

                        if (Articulo.imagenArticulo != null &&
                            cmbImagenes.Items.Count > 0 &&
                            cmbImagenes.Items.Cast<Imagen>().Any(i => i.Id == Articulo.imagenArticulo.Id))
                        {
                            cmbImagenes.SelectedValue = Articulo.imagenArticulo.Id;
                        }
                        else
                        {
                            pbxAgregado.Load(this.placeHolderImage);
                        }
                    }
                }
                else if (this.Tipo == "Agregar")
                {
                    cboMarca.SelectedItem = -1;
                    cboCategoria.SelectedItem = -1;

                    cboCategoria.DataSource = categoriaNegocio.ListarCategorias();
                    cboCategoria.ValueMember = "Id";
                    cboCategoria.DisplayMember = "Descripcion";

                    cboMarca.DataSource = marcaNegocio.ListarMarcas();
                    cboMarca.ValueMember = "Id";
                    cboMarca.DisplayMember = "Descripcion";

                    pbxAgregado.Load(this.placeHolderImage);
                }
            }
            catch (System.Net.WebException)
            {
                // Error de red o 404
                pbxAgregado.Load(this.placeHolderImage);

                if (Articulo != null)
                {
                    txtCodigo.Text = Articulo.Codigo;
                    txtNombre.Text = Articulo.Nombre;
                    txtDescripcion.Text = Articulo.Descripcion;
                    txtPrecio.Text = Articulo.Precio.ToString();

                    if (Articulo.TipoMarca != null)
                        cboMarca.SelectedValue = Articulo.TipoMarca.Id;

                    if (Articulo.TipoCategoria != null)
                        cboCategoria.SelectedValue = Articulo.TipoCategoria.Id;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No se pudo cargar la información del artículo.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        ///////////////////////////////////////  VALIDACIONES  ////////////////////////////////////////////
        private void SoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidarCampos()
        {
            bool correcto = true;
            decimal precio;

            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                lblValidacionPrecio.ForeColor = Color.Red;
                lblValidacionPrecio.Text = "*";
                lblValidacionPrecio.Visible = true;
                lblValidacionPrecio.Font = new Font(lblValidacionPrecio.Font.FontFamily, 14); // el 14 es el tamaño que le puse al *

                MessageBox.Show("Precio Invalido, Ingrese uno correcto");
                correcto = false;
            }
            else if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                lblValidacionPrecio.ForeColor = Color.Red;
                lblValidacionPrecio.Text = "*";
                lblValidacionPrecio.Visible = true;
                lblValidacionPrecio.Font = new Font(lblValidacionPrecio.Font.FontFamily, 14);

                MessageBox.Show("El campo PRECIO debe completarse");
                correcto = false;
            }
            else
            {
                lblValidacionPrecio.ForeColor = Color.DarkGray;
                lblValidacionPrecio.Visible = false;
            }

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                lblValidacionCodigo.ForeColor = Color.Red;
                lblValidacionCodigo.Text = "*";
                lblValidacionCodigo.Visible = true;
                lblValidacionCodigo.Font = new Font(lblValidacionCodigo.Font.FontFamily, 14);

                MessageBox.Show("El campo CODIGO debe completarse");
                correcto = false;
            }
            else
            {
                lblValidacionCodigo.ForeColor = Color.DarkGray;
                lblValidacionCodigo.Visible = false;
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                lblValidacionNombre.ForeColor = Color.Red;
                lblValidacionNombre.Text = "*";
                lblValidacionNombre.Visible = true;
                lblValidacionNombre.Font = new Font(lblValidacionNombre.Font.FontFamily, 14);

                MessageBox.Show("El campo NOMBRE debe completarse");
                correcto = false;
            }
            else if (soloNumeros(txtNombre.Text))
            {
                lblValidacionNombre.ForeColor = Color.Red;
                lblValidacionNombre.Text = "*";
                lblValidacionNombre.Visible = true;
                lblValidacionNombre.Font = new Font(lblValidacionNombre.Font.FontFamily, 14);

                MessageBox.Show("Ingrese un nombre correcto que NO lleve Numeros");
                correcto = false;
            }
            else
            {
                lblValidacionNombre.ForeColor = Color.DarkGray;
                lblValidacionNombre.Visible = false;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                lblValidacionDescripcion.ForeColor = Color.Red;
                lblValidacionDescripcion.Text = "*";
                lblValidacionDescripcion.Visible = true;
                lblValidacionDescripcion.Font = new Font(lblValidacionDescripcion.Font.FontFamily, 14); // Ajusta el tamaño según sea necesario

                MessageBox.Show("El campo DESCRIPCION debe completarse");
                correcto = false;
            }
            else if (soloNumeros(txtDescripcion.Text))
            {
                lblValidacionDescripcion.ForeColor = Color.Red;
                lblValidacionDescripcion.Text = "*";
                lblValidacionDescripcion.Visible = true;
                lblValidacionDescripcion.Font = new Font(lblValidacionDescripcion.Font.FontFamily, 14); // Ajusta el tamaño según sea necesario

                MessageBox.Show("Ingrese una descripcion correcta que NO lleve Numeros");
                correcto = false;
            }
            else
            {
                lblValidacionDescripcion.ForeColor = Color.DarkGray;
                lblValidacionDescripcion.Visible = false;
            }


            return correcto;
        }
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void BTN_Cancelar_Art_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }

        private void BTN_Cargar_Art_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    if (Articulo == null) { Articulo = new Articulo(); }

                    Articulo.Codigo = txtCodigo.Text;
                    Articulo.Nombre = txtNombre.Text;
                    Articulo.Descripcion = txtDescripcion.Text;
                    Articulo.TipoMarca = (Marca)cboMarca.SelectedItem;
                    Articulo.TipoCategoria = (Categoria)cboCategoria.SelectedItem;
                    Articulo.Precio = decimal.Parse(txtPrecio.Text);
                    if (this.Tipo == "Modificar")
                    {
                        if (cmbImagenes.SelectedItem is Imagen imagenSeleccionada)
                        {
                            Articulo.imagenArticulo = imagenSeleccionada; 
                        }
                        articuloNegocio.ModifyArt(Articulo);

                        ImagenHaciaDGV?.Invoke(Articulo.Id, (int)cmbImagenes.SelectedValue);

                        MessageBox.Show("Articulo Modificado", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (this.Tipo == "Agregar")
                    {
                        articuloNegocio.Agregar(Articulo);
                        if (this.hasImageLoad)
                        {
                            string parametro = txtUrlImagen.Text.Trim();

                            if (!parametro.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                            {
                                parametro = this.placeHolderImage;
                            }
                            imagenNegocio.addImage(parametro, articuloNegocio.ReturnID() - 1);
                        }
                        else
                        {
                            string parametro = this.placeHolderImage;
                            imagenNegocio.addImage(parametro, articuloNegocio.ReturnID() - 1);
                        }
                        MessageBox.Show("Articulo Agregado!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    Close();
                }
                else
                {
                   // MessageBox.Show("Cargue Correctamente Los Campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
