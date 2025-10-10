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
using System.IO;
//using Newtonsoft.Json;

namespace Front
{
    public partial class FormMenu : Form
    {

        List<Articulo> listaArticulos = new List<Articulo>();
        List<Imagen> listaImagenes = new List<Imagen>();
        Dictionary<int, int> imagenesSeleccionadas = new Dictionary<int, int>();

        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            //CargarImagenesSeleccionadas();
            cargarDgv();

        }

        //------------------------funciones-------------------------------------

        private void cargarDgv()
        {
            articuloNegocio articulos = new articuloNegocio();
            imagenNegocio imagenes = new imagenNegocio();

            try
            {
                // Obtener la lista de artículos con la imagen priorizada
                listaArticulos = articulos.listar(imagenesSeleccionadas);
                listaImagenes = imagenes.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos..." + ex.Message);
                return;
            }

            // Configurar DataGridView
            dgvArticulos.DataSource = null; // Primero limpiar
            dgvArticulos.DataSource = listaArticulos;

            // Quitar columna de imagen si existe
            if (dgvArticulos.Columns.Contains("imagenArticulo"))
                dgvArticulos.Columns.Remove("imagenArticulo");

            // Configurar ComboBox de campos
            ComboBoxCampo.Items.Clear();
            ComboBoxCampo.Items.Add("precio");
            ComboBoxCampo.Items.Add("nombre");
            ComboBoxCampo.Items.Add("categoría");

            // Cargar imagen del primer artículo, si existe
            if (listaArticulos.Count > 0 && listaArticulos[0].imagenArticulo != null)
            {
                try
                {
                    pbxArticulo.Load(listaArticulos[0].imagenArticulo.Url);
                }
                catch
                {
                    pbxArticulo.Load("https://myemotos.cl/wp-content/uploads/2024/06/sin_imagen.jpg");
                }
            }
            else
            {
                pbxArticulo.Load("https://myemotos.cl/wp-content/uploads/2024/06/sin_imagen.jpg");
            }
        }

        private void cargaImagen(int IdArt, int? IdImagenSeleccionada = null)
        {
            try
            {
                // Buscar usando el Id de imagen seleccionada primero (si existe)
                Imagen nuevaImagen;
                if (IdImagenSeleccionada.HasValue)
                {
                    nuevaImagen = listaImagenes
                        .Where(x => x.IdArticulo == IdArt)
                        .OrderByDescending(x => x.Id == IdImagenSeleccionada.Value) // la seleccionada primero
                        .FirstOrDefault();
                }
                else
                {
                    nuevaImagen = listaImagenes.Find(x => x.IdArticulo == IdArt);
                }

                if (nuevaImagen != null)
                    pbxArticulo.Load(nuevaImagen.Url);
                else
                    pbxArticulo.Load("https://myemotos.cl/wp-content/uploads/2024/06/sin_imagen.jpg");
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://myemotos.cl/wp-content/uploads/2024/06/sin_imagen.jpg");
            }
        }

        //private void GuardarImagenesSeleccionadas()
        //{
        //    try
        //    {
        //        string path = Path.Combine(Application.StartupPath, "imagenesSeleccionadas.json");
        //        string json = JsonConvert.SerializeObject(imagenesSeleccionadas, Formatting.Indented);
        //        File.WriteAllText(path, json);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al guardar imágenes seleccionadas: " + ex.Message);
        //    }
        //}

        //private void CargarImagenesSeleccionadas()
        //{
        //    try
        //    {
        //        string path = Path.Combine(Application.StartupPath, "imagenesSeleccionadas.json");
        //        if (File.Exists(path))
        //        {
        //            string json = File.ReadAllText(path);
        //            imagenesSeleccionadas = JsonConvert.DeserializeObject<Dictionary<int, int>>(json);
        //        }
        //        else
        //        {
        //            imagenesSeleccionadas = new Dictionary<int, int>();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al cargar imágenes seleccionadas: " + ex.Message);
        //        imagenesSeleccionadas = new Dictionary<int, int>();
        //    }
        //}

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormNuevoArticulo formNuevoArticulo = new FormNuevoArticulo("Agregar");
            formNuevoArticulo.ShowDialog();
            cargarDgv();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            articuloNegocio articuloNegocio = new articuloNegocio();
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo articuloSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                FormNuevoArticulo frm = new FormNuevoArticulo("Modificar", articuloSeleccionado);

                frm.ImagenHaciaDGV += (idArticulo, idImagen) =>
                {
                    imagenesSeleccionadas[idArticulo] = idImagen; 

                    listaArticulos = articuloNegocio.listar(imagenesSeleccionadas);
                    dgvArticulos.DataSource = null;
                    dgvArticulos.DataSource = listaArticulos;
                };

                frm.ShowDialog();
                cargarDgv();
            }
            else
            {
                MessageBox.Show("Selecciona un artículo primero.");
            }
        }

        private bool validarFiltro()
        {
            if (ComboBoxCampo.SelectedIndex < 0) //pregunto si campo no tiene nada seleccionado
            {
                MessageBox.Show("Por favor, seleccione el campo para filtrar.");
                return true;
            }
            if (ComboBoxCriterio.SelectedIndex < 0) //pregunto si criterio no tiene nada seleccionado
            {
                MessageBox.Show("Por favor, seleccione el criterio para filtrar.");
                return true;
            }
            if (ComboBoxCampo.SelectedItem.ToString() == "precio")//pregunto si campo es precio
            {
                if (string.IsNullOrEmpty(textBoxFiltroAvanzado.Text))//si el filtro esta vacio o null
                {
                    MessageBox.Show("Debes cargar el filtro...");
                    return true;
                }
                if (!(soloNumeros(textBoxFiltroAvanzado.Text))) //por q esta en op numumerico
                {
                    MessageBox.Show("Solo nros para filtrar por un campo numerico...");
                    return true;
                }
            }
            if (ComboBoxCampo.SelectedItem.ToString() == "nombre" || ComboBoxCampo.SelectedItem.ToString() == "categoría")
            {
                if (string.IsNullOrEmpty(textBoxFiltroAvanzado.Text))//si el filtro esta vacio o null
                {
                    MessageBox.Show("Debes cargar el filtro...");
                    return true;
                }
                if ((soloNumeros(textBoxFiltroAvanzado.Text))) //por q esta en op text
                {
                    MessageBox.Show("Solo letras para filtrar por un campo de texto...");
                    return true;
                }
            }

            return false;
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

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                // Pasamos también el Id de la imagen elegida (si la hay)
                int? idImagenSeleccionada = seleccionado.imagenArticulo?.Id;

                cargaImagen(seleccionado.Id, idImagenSeleccionada);
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxdAOY_-vITFVI-ej84s2U_ErxhOly-z3y_Q&s");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            articuloNegocio ArtiNegocio = new articuloNegocio();
            Articulo ArtiSeleccionado = new Articulo();

            try
            {

                DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    ArtiSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    ArtiNegocio.eliminarLogico(ArtiSeleccionado.Id);
                    cargarDgv();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BotonFiltrar_Click(object sender, EventArgs e)
        {
            articuloNegocio ArtiNegocio = new articuloNegocio();
            try
            {
                if (validarFiltro()) //si hay q validar corta la ejecucion
                {
                    cargarDgv();
                    return;
                }

                string campo = ComboBoxCampo.SelectedItem.ToString();
                string criterio = ComboBoxCriterio.SelectedItem.ToString();
                string filtro = textBoxFiltroAvanzado.Text;
                dgvArticulos.DataSource = ArtiNegocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ComboBoxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = ComboBoxCampo.SelectedItem.ToString(); //capturo la seleccion
            if (opcion == "precio")
            {
                ComboBoxCriterio.Items.Clear();
                ComboBoxCriterio.Items.Add("Mayor a");
                ComboBoxCriterio.Items.Add("Menor a");
                ComboBoxCriterio.Items.Add("Igual a");
            }
            else
            {
                ComboBoxCriterio.Items.Clear();
                ComboBoxCriterio.Items.Add("Comienza con");
                ComboBoxCriterio.Items.Add("Termina con");
                ComboBoxCriterio.Items.Add("Contiene");
            }
        }

        private void txtFitro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;

            string texto = txtFitro.Text.ToString().ToLower();

            if (txtFitro.Text.Length >= 3)
                listaFiltrada = listaArticulos.FindAll(
                    x => x.Nombre.ToLower().Contains(texto) ||
                    x.Codigo.ToLower().Contains(texto) ||
                    x.TipoMarca.Descripcion.ToLower().Contains(texto)
                    );
            else
                listaFiltrada = listaArticulos;

            dgvArticulos.DataSource = null;

            if (listaFiltrada.Count != 0)
            {
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.Columns.Remove("imagenArticulo"); //ocultar esta columna cada vez que filtremos
                //aca tendria que poner algo para que filtre las img tambien ya que van a ser a parte del articulo
            }
        }

        private void txtFitro_KeyPress(object sender, KeyPressEventArgs e)
        {
            List<Articulo> listaFiltrada;
            string texto = txtFitro.Text.ToString().ToLower();

            if(texto != "")
            {
                listaFiltrada = listaArticulos.FindAll(
                    x => x.Nombre.ToLower().Contains(texto) ||
                    x.Codigo.ToLower().Contains(texto) ||
                    x.TipoMarca.Descripcion.ToLower().Contains(texto)
                );
            }
            else
            {
                listaFiltrada = listaArticulos;
            }
            dgvArticulos.DataSource = null;
            if(listaFiltrada.Count != 0)
            {
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.Columns.Remove("imagenArticulo");
            }
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            //GuardarImagenesSeleccionadas();
        }

        private void tsmAgregarMarca_Click(object sender, EventArgs e)
        {
            FrmAddMarcaYCategoria frmMarcaCategoria = new FrmAddMarcaYCategoria();
            frmMarcaCategoria.TablaDestino = "Marcas";
            frmMarcaCategoria.ShowDialog();
        }

        private void tsmAgregarCategoria_Click(object sender, EventArgs e)
        {
            FrmAddMarcaYCategoria frmMarcaCategoria = new FrmAddMarcaYCategoria();
            frmMarcaCategoria.TablaDestino = "Categorias";
            frmMarcaCategoria.ShowDialog();
        }

        private void tsmAgregarMarca_Click_1(object sender, EventArgs e)
        {
            FrmAddMarcaYCategoria frmMarcaCategoria = new FrmAddMarcaYCategoria();
            frmMarcaCategoria.TablaDestino = "Marcas";
            frmMarcaCategoria.ShowDialog();
        }

        private void tsmAgregarCategoria_Click_1(object sender, EventArgs e)
        {
            FrmAddMarcaYCategoria frmMarcaCategoria = new FrmAddMarcaYCategoria();
            frmMarcaCategoria.TablaDestino = "Categorias";
            frmMarcaCategoria.ShowDialog();
        }
    }
}
