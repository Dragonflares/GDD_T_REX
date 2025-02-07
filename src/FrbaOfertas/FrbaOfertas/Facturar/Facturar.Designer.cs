﻿namespace FrbaOfertas.Facturar
{
    partial class Facturar
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
            this.dgv_ofertas = new System.Windows.Forms.DataGridView();
            this.bn_volver = new System.Windows.Forms.Button();
            this.btn_facturar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.text_proveedor = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.date_hasta = new System.Windows.Forms.DateTimePicker();
            this.date_desde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_listar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comprador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioOferta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ofertas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_ofertas
            // 
            this.dgv_ofertas.AllowUserToAddRows = false;
            this.dgv_ofertas.AllowUserToDeleteRows = false;
            this.dgv_ofertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ofertas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.descripcion,
            this.comprador,
            this.precioOferta,
            this.Cantidad,
            this.fechaCompra});
            this.dgv_ofertas.Location = new System.Drawing.Point(26, 237);
            this.dgv_ofertas.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_ofertas.Name = "dgv_ofertas";
            this.dgv_ofertas.ReadOnly = true;
            this.dgv_ofertas.RowTemplate.Height = 24;
            this.dgv_ofertas.Size = new System.Drawing.Size(655, 154);
            this.dgv_ofertas.TabIndex = 26;
            // 
            // bn_volver
            // 
            this.bn_volver.Location = new System.Drawing.Point(27, 396);
            this.bn_volver.Name = "bn_volver";
            this.bn_volver.Size = new System.Drawing.Size(129, 38);
            this.bn_volver.TabIndex = 7;
            this.bn_volver.Text = "Volver";
            this.bn_volver.UseVisualStyleBackColor = true;
            this.bn_volver.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_facturar
            // 
            this.btn_facturar.Location = new System.Drawing.Point(552, 396);
            this.btn_facturar.Name = "btn_facturar";
            this.btn_facturar.Size = new System.Drawing.Size(129, 38);
            this.btn_facturar.TabIndex = 6;
            this.btn_facturar.Text = "Facturar";
            this.btn_facturar.UseVisualStyleBackColor = true;
            this.btn_facturar.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.text_proveedor);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(27, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 152);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros de facturación";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(79, 71);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 33);
            this.button4.TabIndex = 5;
            this.button4.Text = "Seleccionar proveedor";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // text_proveedor
            // 
            this.text_proveedor.Location = new System.Drawing.Point(44, 40);
            this.text_proveedor.Name = "text_proveedor";
            this.text_proveedor.Size = new System.Drawing.Size(208, 20);
            this.text_proveedor.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.date_hasta);
            this.groupBox2.Controls.Add(this.date_desde);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(360, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 99);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Período de Facturación";
            // 
            // date_hasta
            // 
            this.date_hasta.CustomFormat = "yyyy/MM/dd";
            this.date_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_hasta.Location = new System.Drawing.Point(107, 67);
            this.date_hasta.Name = "date_hasta";
            this.date_hasta.Size = new System.Drawing.Size(131, 20);
            this.date_hasta.TabIndex = 3;
            // 
            // date_desde
            // 
            this.date_desde.CustomFormat = "yyyy/MM/dd";
            this.date_desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_desde.Location = new System.Drawing.Point(107, 30);
            this.date_desde.Name = "date_desde";
            this.date_desde.Size = new System.Drawing.Size(131, 20);
            this.date_desde.TabIndex = 2;
            this.date_desde.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de Fin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de Inicio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedor";
            // 
            // btn_listar
            // 
            this.btn_listar.Location = new System.Drawing.Point(552, 185);
            this.btn_listar.Name = "btn_listar";
            this.btn_listar.Size = new System.Drawing.Size(129, 38);
            this.btn_listar.TabIndex = 4;
            this.btn_listar.Text = "Generar Listado";
            this.btn_listar.UseVisualStyleBackColor = true;
            this.btn_listar.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(26, 185);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(129, 38);
            this.btn_limpiar.TabIndex = 5;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.button5_Click);
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
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 165;
            // 
            // comprador
            // 
            this.comprador.DataPropertyName = "comprador";
            this.comprador.HeaderText = "Comprador";
            this.comprador.Name = "comprador";
            this.comprador.ReadOnly = true;
            // 
            // precioOferta
            // 
            this.precioOferta.DataPropertyName = "precioOferta";
            this.precioOferta.HeaderText = "Precio de Oferta";
            this.precioOferta.Name = "precioOferta";
            this.precioOferta.ReadOnly = true;
            this.precioOferta.Width = 120;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // fechaCompra
            // 
            this.fechaCompra.DataPropertyName = "compraFecha";
            this.fechaCompra.HeaderText = "Fecha de Compra";
            this.fechaCompra.Name = "fechaCompra";
            this.fechaCompra.ReadOnly = true;
            this.fechaCompra.Width = 115;
            // 
            // Facturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 446);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_listar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_facturar);
            this.Controls.Add(this.bn_volver);
            this.Controls.Add(this.dgv_ofertas);
            this.Name = "Facturar";
            this.Text = "Facturar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Facturar_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ofertas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ofertas;
        private System.Windows.Forms.Button bn_volver;
        private System.Windows.Forms.Button btn_facturar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox text_proveedor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_listar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.DateTimePicker date_hasta;
        private System.Windows.Forms.DateTimePicker date_desde;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn comprador;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioOferta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCompra;
    }
}