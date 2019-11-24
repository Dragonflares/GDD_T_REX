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
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dar_de_baja = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cupon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_volver
            // 
            this.btn_volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_volver.Location = new System.Drawing.Point(36, 344);
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
            this.cod,
            this.id_compra,
            this.codigo,
            this.id,
            this.dar_de_baja});
            this.dgv_cupon.Location = new System.Drawing.Point(36, 167);
            this.dgv_cupon.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_cupon.Name = "dgv_cupon";
            this.dgv_cupon.ReadOnly = true;
            this.dgv_cupon.RowTemplate.Height = 24;
            this.dgv_cupon.Size = new System.Drawing.Size(486, 154);
            this.dgv_cupon.TabIndex = 30;
            this.dgv_cupon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_cupon_CellContentClick);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(323, 58);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(134, 24);
            this.btn_buscar.TabIndex = 29;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(322, 30);
            this.btn_limpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(135, 24);
            this.btn_limpiar.TabIndex = 28;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_limpiar);
            this.groupBox1.Controls.Add(this.btn_buscar);
            this.groupBox1.Location = new System.Drawing.Point(37, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 105);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de Busqueda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo Cupon";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(129, 20);
            this.textBox1.TabIndex = 1;
            // 
            // cod
            // 
            this.cod.HeaderText = "Código";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.Width = 120;
            // 
            // id_compra
            // 
            this.id_compra.HeaderText = "Id Compra";
            this.id_compra.Name = "id_compra";
            this.id_compra.ReadOnly = true;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Fecha Vencimiento";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 130;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // dar_de_baja
            // 
            this.dar_de_baja.HeaderText = "Dar de Baja";
            this.dar_de_baja.Name = "dar_de_baja";
            this.dar_de_baja.ReadOnly = true;
            this.dar_de_baja.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dar_de_baja.Text = "Dar de Baja";
            this.dar_de_baja.UseColumnTextForButtonValue = true;
            this.dar_de_baja.Width = 90;
            // 
            // CanjeCupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 399);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.dgv_cupon);
            this.Name = "CanjeCupon";
            this.Text = "Buscar Cupones";
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewButtonColumn dar_de_baja;
    }
}