namespace Front
{
    partial class FormNuevoArticulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTN_Cancelar_Art = new System.Windows.Forms.Button();
            this.BTN_Cargar_Art = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblcomboboxImagenes = new System.Windows.Forms.Label();
            this.cmbImagenes = new System.Windows.Forms.ComboBox();
            this.lblValidacionDescripcion = new System.Windows.Forms.Label();
            this.lblValidacionNombre = new System.Windows.Forms.Label();
            this.lblValidacionCodigo = new System.Windows.Forms.Label();
            this.lblValidacionPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtIdArt = new System.Windows.Forms.TextBox();
            this.lblIdArt = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pbxAgregado = new System.Windows.Forms.PictureBox();
            this.btnModificarUrlImagen = new System.Windows.Forms.Button();
            this.txtUrlImagen = new System.Windows.Forms.TextBox();
            this.btnNuevaImagen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAgregado)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Cancelar_Art
            // 
            this.BTN_Cancelar_Art.Location = new System.Drawing.Point(253, 355);
            this.BTN_Cancelar_Art.Name = "BTN_Cancelar_Art";
            this.BTN_Cancelar_Art.Size = new System.Drawing.Size(75, 23);
            this.BTN_Cancelar_Art.TabIndex = 12;
            this.BTN_Cancelar_Art.Text = "Cancelar";
            this.BTN_Cancelar_Art.UseVisualStyleBackColor = true;
            this.BTN_Cancelar_Art.Click += new System.EventHandler(this.BTN_Cancelar_Art_Click);
            // 
            // BTN_Cargar_Art
            // 
            this.BTN_Cargar_Art.Location = new System.Drawing.Point(82, 355);
            this.BTN_Cargar_Art.Name = "BTN_Cargar_Art";
            this.BTN_Cargar_Art.Size = new System.Drawing.Size(75, 23);
            this.BTN_Cargar_Art.TabIndex = 11;
            this.BTN_Cargar_Art.Text = "Cargar";
            this.BTN_Cargar_Art.UseVisualStyleBackColor = true;
            this.BTN_Cargar_Art.Click += new System.EventHandler(this.BTN_Cargar_Art_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitulo.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(98, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(282, 25);
            this.lblTitulo.TabIndex = 39;
            this.lblTitulo.Text = "Agrega tu nuevo Articulo";
            // 
            // lblcomboboxImagenes
            // 
            this.lblcomboboxImagenes.AutoSize = true;
            this.lblcomboboxImagenes.Font = new System.Drawing.Font("Mongolian Baiti", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcomboboxImagenes.Location = new System.Drawing.Point(7, 318);
            this.lblcomboboxImagenes.Name = "lblcomboboxImagenes";
            this.lblcomboboxImagenes.Size = new System.Drawing.Size(84, 18);
            this.lblcomboboxImagenes.TabIndex = 57;
            this.lblcomboboxImagenes.Text = "Imagenes";
            // 
            // cmbImagenes
            // 
            this.cmbImagenes.FormattingEnabled = true;
            this.cmbImagenes.Location = new System.Drawing.Point(117, 318);
            this.cmbImagenes.Name = "cmbImagenes";
            this.cmbImagenes.Size = new System.Drawing.Size(121, 21);
            this.cmbImagenes.TabIndex = 7;
            this.cmbImagenes.SelectedIndexChanged += new System.EventHandler(this.cmbImagenes_SelectedIndexChanged);
            // 
            // lblValidacionDescripcion
            // 
            this.lblValidacionDescripcion.AutoSize = true;
            this.lblValidacionDescripcion.Location = new System.Drawing.Point(100, 160);
            this.lblValidacionDescripcion.Name = "lblValidacionDescripcion";
            this.lblValidacionDescripcion.Size = new System.Drawing.Size(0, 13);
            this.lblValidacionDescripcion.TabIndex = 55;
            // 
            // lblValidacionNombre
            // 
            this.lblValidacionNombre.AutoSize = true;
            this.lblValidacionNombre.Location = new System.Drawing.Point(70, 125);
            this.lblValidacionNombre.Name = "lblValidacionNombre";
            this.lblValidacionNombre.Size = new System.Drawing.Size(0, 13);
            this.lblValidacionNombre.TabIndex = 54;
            // 
            // lblValidacionCodigo
            // 
            this.lblValidacionCodigo.AutoSize = true;
            this.lblValidacionCodigo.Location = new System.Drawing.Point(70, 60);
            this.lblValidacionCodigo.Name = "lblValidacionCodigo";
            this.lblValidacionCodigo.Size = new System.Drawing.Size(0, 13);
            this.lblValidacionCodigo.TabIndex = 53;
            // 
            // lblValidacionPrecio
            // 
            this.lblValidacionPrecio.AutoSize = true;
            this.lblValidacionPrecio.Location = new System.Drawing.Point(56, 281);
            this.lblValidacionPrecio.Name = "lblValidacionPrecio";
            this.lblValidacionPrecio.Size = new System.Drawing.Size(0, 13);
            this.lblValidacionPrecio.TabIndex = 52;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(117, 281);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(121, 20);
            this.txtPrecio.TabIndex = 6;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // txtIdArt
            // 
            this.txtIdArt.Enabled = false;
            this.txtIdArt.Location = new System.Drawing.Point(117, 60);
            this.txtIdArt.Name = "txtIdArt";
            this.txtIdArt.Size = new System.Drawing.Size(121, 20);
            this.txtIdArt.TabIndex = 0;
            // 
            // lblIdArt
            // 
            this.lblIdArt.AutoSize = true;
            this.lblIdArt.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdArt.Location = new System.Drawing.Point(7, 64);
            this.lblIdArt.Name = "lblIdArt";
            this.lblIdArt.Size = new System.Drawing.Size(100, 16);
            this.lblIdArt.TabIndex = 51;
            this.lblIdArt.Text = "Articulo Nro";
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(117, 240);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(121, 21);
            this.cboCategoria.TabIndex = 5;
            // 
            // cboMarca
            // 
            this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(117, 198);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(121, 21);
            this.cboMarca.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(117, 160);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(121, 20);
            this.txtDescripcion.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(117, 122);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(6, 281);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(53, 16);
            this.lblPrecio.TabIndex = 49;
            this.lblPrecio.Text = "Precio";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(6, 241);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(77, 16);
            this.lblCategoria.TabIndex = 46;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(7, 198);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(52, 16);
            this.lblMarca.TabIndex = 44;
            this.lblMarca.Text = "Marca";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(7, 161);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(94, 16);
            this.lblDescripcion.TabIndex = 43;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(7, 126);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 16);
            this.lblNombre.TabIndex = 40;
            this.lblNombre.Text = "Nombre";
            // 
            // pbxAgregado
            // 
            this.pbxAgregado.Location = new System.Drawing.Point(280, 71);
            this.pbxAgregado.Name = "pbxAgregado";
            this.pbxAgregado.Size = new System.Drawing.Size(169, 172);
            this.pbxAgregado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAgregado.TabIndex = 58;
            this.pbxAgregado.TabStop = false;
            // 
            // btnModificarUrlImagen
            // 
            this.btnModificarUrlImagen.Location = new System.Drawing.Point(275, 281);
            this.btnModificarUrlImagen.Name = "btnModificarUrlImagen";
            this.btnModificarUrlImagen.Size = new System.Drawing.Size(84, 30);
            this.btnModificarUrlImagen.TabIndex = 10;
            this.btnModificarUrlImagen.Text = "Modificar Foto";
            this.btnModificarUrlImagen.UseVisualStyleBackColor = true;
            this.btnModificarUrlImagen.Click += new System.EventHandler(this.btnModificarUrlImagen_Click);
            // 
            // txtUrlImagen
            // 
            this.txtUrlImagen.Location = new System.Drawing.Point(300, 249);
            this.txtUrlImagen.MaxLength = 999;
            this.txtUrlImagen.Name = "txtUrlImagen";
            this.txtUrlImagen.Size = new System.Drawing.Size(124, 20);
            this.txtUrlImagen.TabIndex = 8;
            this.txtUrlImagen.TextChanged += new System.EventHandler(this.txtUrlImagen_TextChanged);
            // 
            // btnNuevaImagen
            // 
            this.btnNuevaImagen.Location = new System.Drawing.Point(365, 281);
            this.btnNuevaImagen.Name = "btnNuevaImagen";
            this.btnNuevaImagen.Size = new System.Drawing.Size(79, 30);
            this.btnNuevaImagen.TabIndex = 9;
            this.btnNuevaImagen.Text = "Agregar Foto";
            this.btnNuevaImagen.UseVisualStyleBackColor = true;
            this.btnNuevaImagen.Click += new System.EventHandler(this.btnNuevaImagen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 64;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(117, 92);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(121, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(7, 92);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(60, 16);
            this.lblCodigo.TabIndex = 63;
            this.lblCodigo.Text = "Codigo";
            // 
            // FormNuevoArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(456, 387);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.btnModificarUrlImagen);
            this.Controls.Add(this.txtUrlImagen);
            this.Controls.Add(this.btnNuevaImagen);
            this.Controls.Add(this.pbxAgregado);
            this.Controls.Add(this.lblcomboboxImagenes);
            this.Controls.Add(this.cmbImagenes);
            this.Controls.Add(this.lblValidacionDescripcion);
            this.Controls.Add(this.lblValidacionNombre);
            this.Controls.Add(this.lblValidacionCodigo);
            this.Controls.Add(this.lblValidacionPrecio);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtIdArt);
            this.Controls.Add(this.lblIdArt);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.BTN_Cancelar_Art);
            this.Controls.Add(this.BTN_Cargar_Art);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(472, 426);
            this.MinimumSize = new System.Drawing.Size(472, 426);
            this.Name = "FormNuevoArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormNuevoArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAgregado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BTN_Cancelar_Art;
        private System.Windows.Forms.Button BTN_Cargar_Art;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblcomboboxImagenes;
        private System.Windows.Forms.ComboBox cmbImagenes;
        private System.Windows.Forms.Label lblValidacionDescripcion;
        private System.Windows.Forms.Label lblValidacionNombre;
        private System.Windows.Forms.Label lblValidacionCodigo;
        private System.Windows.Forms.Label lblValidacionPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtIdArt;
        private System.Windows.Forms.Label lblIdArt;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblNombre;
        public System.Windows.Forms.PictureBox pbxAgregado;
        private System.Windows.Forms.Button btnModificarUrlImagen;
        private System.Windows.Forms.TextBox txtUrlImagen;
        private System.Windows.Forms.Button btnNuevaImagen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
    }
}