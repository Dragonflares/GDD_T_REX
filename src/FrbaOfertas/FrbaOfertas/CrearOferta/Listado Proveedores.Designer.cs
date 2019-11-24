namespace FrbaOfertas.CrearOferta
{
    partial class ListadoProveedor
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
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.dgv_proveedores = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.razonsocial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_volver = new System.Windows.Forms.Button();
            this.razon_social = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_proveedores)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(34, 161);
            this.btn_limpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(135, 24);
            this.btn_limpiar.TabIndex = 8;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(386, 161);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(134, 24);
            this.btn_buscar.TabIndex = 9;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // dgv_proveedores
            // 
            this.dgv_proveedores.AllowUserToAddRows = false;
            this.dgv_proveedores.AllowUserToDeleteRows = false;
            this.dgv_proveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_proveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.razon_social,
            this.rubro,
            this.cuit,
            this.id,
            this.seleccionar});
            this.dgv_proveedores.Location = new System.Drawing.Point(34, 202);
            this.dgv_proveedores.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_proveedores.Name = "dgv_proveedores";
            this.dgv_proveedores.ReadOnly = true;
            this.dgv_proveedores.RowTemplate.Height = 24;
            this.dgv_proveedores.Size = new System.Drawing.Size(486, 154);
            this.dgv_proveedores.TabIndex = 13;
            this.dgv_proveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_proveedores_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.razonsocial);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(34, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(486, 147);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proveedor";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(316, 47);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(124, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(103, 69);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(124, 20);
            this.textBox3.TabIndex = 12;
            // 
            // razonsocial
            // 
            this.razonsocial.Location = new System.Drawing.Point(103, 29);
            this.razonsocial.Margin = new System.Windows.Forms.Padding(2);
            this.razonsocial.Name = "razonsocial";
            this.razonsocial.Size = new System.Drawing.Size(124, 20);
            this.razonsocial.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "CUIT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rubro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razón Social";
            // 
            // btn_volver
            // 
            this.btn_volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_volver.Location = new System.Drawing.Point(34, 360);
            this.btn_volver.Margin = new System.Windows.Forms.Padding(2);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(135, 30);
            this.btn_volver.TabIndex = 22;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_atras_Click);
            // 
            // razon_social
            // 
            this.razon_social.HeaderText = "Razón Social";
            this.razon_social.Name = "razon_social";
            this.razon_social.ReadOnly = true;
            this.razon_social.Width = 120;
            // 
            // rubro
            // 
            this.rubro.HeaderText = "Rubro";
            this.rubro.Name = "rubro";
            this.rubro.ReadOnly = true;
            // 
            // cuit
            // 
            this.cuit.HeaderText = "CUIT";
            this.cuit.Name = "cuit";
            this.cuit.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // seleccionar
            // 
            this.seleccionar.HeaderText = "Seleccionar";
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.ReadOnly = true;
            this.seleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.seleccionar.Text = "Seleccionar";
            this.seleccionar.UseColumnTextForButtonValue = true;
            this.seleccionar.Width = 90;
            // 
            // ListadoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 419);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_proveedores);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.btn_limpiar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ListadoProveedor";
            this.Text = "Listado Proveedores";
            this.Load += new System.EventHandler(this.FormListadoProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_proveedores)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.DataGridView dgv_proveedores;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox razonsocial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn razon_social;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubro;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewButtonColumn seleccionar;
    }
}