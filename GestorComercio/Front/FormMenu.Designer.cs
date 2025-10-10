namespace Front
{
    partial class FormMenu
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.txtFitro = new System.Windows.Forms.TextBox();
            this.BotonFiltrar = new System.Windows.Forms.Button();
            this.textBoxFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.labelFiltro = new System.Windows.Forms.Label();
            this.ComboBoxCriterio = new System.Windows.Forms.ComboBox();
            this.labelCriterio = new System.Windows.Forms.Label();
            this.ComboBoxCampo = new System.Windows.Forms.ComboBox();
            this.labelCampo = new System.Windows.Forms.Label();
            this.msArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgregarMarca = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgregarCategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAgregar.Location = new System.Drawing.Point(12, 68);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(80, 60);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnModificar.Location = new System.Drawing.Point(12, 161);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(80, 60);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEliminar.Location = new System.Drawing.Point(12, 262);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 60);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AllowUserToOrderColumns = true;
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvArticulos.Location = new System.Drawing.Point(109, 68);
            this.dgvArticulos.MultiSelect = false;
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(382, 254);
            this.dgvArticulos.TabIndex = 5;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.Location = new System.Drawing.Point(516, 68);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(148, 140);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxArticulo.TabIndex = 6;
            this.pbxArticulo.TabStop = false;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(20, 27);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(63, 20);
            this.lblFiltro.TabIndex = 12;
            this.lblFiltro.Text = "Buscar:";
            // 
            // txtFitro
            // 
            this.txtFitro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFitro.Location = new System.Drawing.Point(89, 27);
            this.txtFitro.Name = "txtFitro";
            this.txtFitro.Size = new System.Drawing.Size(402, 20);
            this.txtFitro.TabIndex = 13;
            this.txtFitro.TextChanged += new System.EventHandler(this.txtFitro_TextChanged);
            this.txtFitro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFitro_KeyPress);
            // 
            // BotonFiltrar
            // 
            this.BotonFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BotonFiltrar.Location = new System.Drawing.Point(550, 336);
            this.BotonFiltrar.Name = "BotonFiltrar";
            this.BotonFiltrar.Size = new System.Drawing.Size(75, 23);
            this.BotonFiltrar.TabIndex = 42;
            this.BotonFiltrar.Text = "Buscar";
            this.BotonFiltrar.UseVisualStyleBackColor = true;
            this.BotonFiltrar.Click += new System.EventHandler(this.BotonFiltrar_Click);
            // 
            // textBoxFiltroAvanzado
            // 
            this.textBoxFiltroAvanzado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxFiltroAvanzado.Location = new System.Drawing.Point(435, 339);
            this.textBoxFiltroAvanzado.Name = "textBoxFiltroAvanzado";
            this.textBoxFiltroAvanzado.Size = new System.Drawing.Size(100, 20);
            this.textBoxFiltroAvanzado.TabIndex = 41;
            // 
            // labelFiltro
            // 
            this.labelFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFiltro.AutoSize = true;
            this.labelFiltro.Location = new System.Drawing.Point(394, 341);
            this.labelFiltro.Name = "labelFiltro";
            this.labelFiltro.Size = new System.Drawing.Size(29, 13);
            this.labelFiltro.TabIndex = 40;
            this.labelFiltro.Text = "Filtro";
            // 
            // ComboBoxCriterio
            // 
            this.ComboBoxCriterio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ComboBoxCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCriterio.FormattingEnabled = true;
            this.ComboBoxCriterio.Location = new System.Drawing.Point(251, 338);
            this.ComboBoxCriterio.Name = "ComboBoxCriterio";
            this.ComboBoxCriterio.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxCriterio.TabIndex = 39;
            // 
            // labelCriterio
            // 
            this.labelCriterio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCriterio.AutoSize = true;
            this.labelCriterio.Location = new System.Drawing.Point(210, 341);
            this.labelCriterio.Name = "labelCriterio";
            this.labelCriterio.Size = new System.Drawing.Size(39, 13);
            this.labelCriterio.TabIndex = 38;
            this.labelCriterio.Text = "Criterio";
            // 
            // ComboBoxCampo
            // 
            this.ComboBoxCampo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ComboBoxCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCampo.FormattingEnabled = true;
            this.ComboBoxCampo.Location = new System.Drawing.Point(80, 339);
            this.ComboBoxCampo.Name = "ComboBoxCampo";
            this.ComboBoxCampo.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxCampo.TabIndex = 37;
            this.ComboBoxCampo.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCampo_SelectedIndexChanged);
            // 
            // labelCampo
            // 
            this.labelCampo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCampo.AutoSize = true;
            this.labelCampo.Location = new System.Drawing.Point(27, 342);
            this.labelCampo.Name = "labelCampo";
            this.labelCampo.Size = new System.Drawing.Size(40, 13);
            this.labelCampo.TabIndex = 36;
            this.labelCampo.Text = "Campo";
            // 
            // msArchivo
            // 
            this.msArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAgregarMarca,
            this.tsmAgregarCategoria});
            this.msArchivo.Name = "msArchivo";
            this.msArchivo.Size = new System.Drawing.Size(84, 20);
            this.msArchivo.Text = "Propiedades";
            // 
            // tsmAgregarMarca
            // 
            this.tsmAgregarMarca.Name = "tsmAgregarMarca";
            this.tsmAgregarMarca.Size = new System.Drawing.Size(227, 22);
            this.tsmAgregarMarca.Text = "Agregar marca de articulo";
            this.tsmAgregarMarca.Click += new System.EventHandler(this.tsmAgregarMarca_Click_1);
            // 
            // tsmAgregarCategoria
            // 
            this.tsmAgregarCategoria.Name = "tsmAgregarCategoria";
            this.tsmAgregarCategoria.Size = new System.Drawing.Size(227, 22);
            this.tsmAgregarCategoria.Text = "Agregar categoria de articulo";
            this.tsmAgregarCategoria.Click += new System.EventHandler(this.tsmAgregarCategoria_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msArchivo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(676, 24);
            this.menuStrip1.TabIndex = 43;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 371);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.BotonFiltrar);
            this.Controls.Add(this.textBoxFiltroAvanzado);
            this.Controls.Add(this.labelFiltro);
            this.Controls.Add(this.ComboBoxCriterio);
            this.Controls.Add(this.labelCriterio);
            this.Controls.Add(this.ComboBoxCampo);
            this.Controls.Add(this.labelCampo);
            this.Controls.Add(this.txtFitro);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.dgvArticulos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(692, 410);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(692, 410);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver Articulos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMenu_FormClosing);
            this.Load += new System.EventHandler(this.FormMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.PictureBox pbxArticulo;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.TextBox txtFitro;
        private System.Windows.Forms.Button BotonFiltrar;
        private System.Windows.Forms.TextBox textBoxFiltroAvanzado;
        private System.Windows.Forms.Label labelFiltro;
        private System.Windows.Forms.ComboBox ComboBoxCriterio;
        private System.Windows.Forms.Label labelCriterio;
        private System.Windows.Forms.ComboBox ComboBoxCampo;
        private System.Windows.Forms.Label labelCampo;
        private System.Windows.Forms.ToolStripMenuItem msArchivo;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregarMarca;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregarCategoria;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}