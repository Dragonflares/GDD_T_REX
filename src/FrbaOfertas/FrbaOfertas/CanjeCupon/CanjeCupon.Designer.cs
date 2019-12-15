namespace FrbaOfertas.CanjeCupon
{
    partial class CanjeCupon
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
            this.btn_volver = new System.Windows.Forms.Button();
            this.dgv_cupon = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entregar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.text_producto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.text_documento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_nya = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cupon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_volver
            // 
            this.btn_volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_volver.Location = new System.Drawing.Point(36, 410);
            this.btn_volver.Margin = new System.Windows.Forms.Padding(2);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(135, 30);
            this.btn_volver.TabIndex = 31;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // dgv_cupon
            // 
            this.dgv_cupon.AllowUserToAddRows = false;
            this.dgv_cupon.AllowUserToDeleteRows = false;
            this.dgv_cupon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cupon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.descripcion,
            this.cliente,
            this.codigo,
            this.Entregar});
            this.dgv_cupon.Location = new System.Drawing.Point(36, 167);
            this.dgv_cupon.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_cupon.Name = "dgv_cupon";
            this.dgv_cupon.ReadOnly = true;
            this.dgv_cupon.RowTemplate.Height = 24;
            this.dgv_cupon.Size = new System.Drawing.Size(607, 218);
            this.dgv_cupon.TabIndex = 30;
            this.dgv_cupon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_cupon_CellContentClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Producto";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // cliente
            // 
            this.cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cliente.DataPropertyName = "cliente";
            this.cliente.HeaderText = "Cliente Comprador";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            // 
            // codigo
            // 
            this.codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.codigo.DataPropertyName = "fechaVencimiento";
            this.codigo.HeaderText = "Fecha Vencimiento";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // Entregar
            // 
            this.Entregar.DataPropertyName = "Entregar";
            this.Entregar.HeaderText = "Entregar";
            this.Entregar.Name = "Entregar";
            this.Entregar.ReadOnly = true;
            this.Entregar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Entregar.Text = "Entregar";
            this.Entregar.UseColumnTextForButtonValue = true;
            this.Entregar.Width = 90;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(434, 58);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(134, 24);
            this.btn_buscar.TabIndex = 5;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(433, 30);
            this.btn_limpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(135, 24);
            this.btn_limpiar.TabIndex = 6;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.text_email);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.text_nya);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.text_documento);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.text_producto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_limpiar);
            this.groupBox1.Controls.Add(this.btn_buscar);
            this.groupBox1.Location = new System.Drawing.Point(37, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 105);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de Busqueda";
            // 
            // text_producto
            // 
            this.text_producto.Location = new System.Drawing.Point(79, 33);
            this.text_producto.Name = "text_producto";
            this.text_producto.Size = new System.Drawing.Size(129, 20);
            this.text_producto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto";
            // 
            // text_documento
            // 
            this.text_documento.Location = new System.Drawing.Point(285, 33);
            this.text_documento.Name = "text_documento";
            this.text_documento.Size = new System.Drawing.Size(129, 20);
            this.text_documento.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Documento";
            // 
            // text_nya
            // 
            this.text_nya.Location = new System.Drawing.Point(121, 59);
            this.text_nya.Name = "text_nya";
            this.text_nya.Size = new System.Drawing.Size(87, 20);
            this.text_nya.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Nombre / Apellido";
            // 
            // text_email
            // 
            this.text_email.Location = new System.Drawing.Point(285, 59);
            this.text_email.Name = "text_email";
            this.text_email.Size = new System.Drawing.Size(129, 20);
            this.text_email.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Email";
            // 
            // CanjeCupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 451);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.dgv_cupon);
            this.Name = "CanjeCupon";
            this.Text = "Buscar Cupones";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CanjeCupon_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cupon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_volver;
        private System.Windows.Forms.DataGridView dgv_cupon;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox text_producto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewButtonColumn Entregar;
        private System.Windows.Forms.TextBox text_email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_nya;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_documento;
        private System.Windows.Forms.Label label2;
    }
}