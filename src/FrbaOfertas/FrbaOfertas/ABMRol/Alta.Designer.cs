namespace FrbaOfertas.ABMRol
{
    partial class Alta
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NombreNuevoRol = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Funcionalidades = new System.Windows.Forms.ComboBox();
            this.btn_atras = new System.Windows.Forms.Button();
            this.table_funcionalidades = new System.Windows.Forms.DataGridView();
            this.idFunc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRolFuncionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Funcionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.table_funcionalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Funcionalidad";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // NombreNuevoRol
            // 
            this.NombreNuevoRol.Location = new System.Drawing.Point(88, 20);
            this.NombreNuevoRol.Name = "NombreNuevoRol";
            this.NombreNuevoRol.Size = new System.Drawing.Size(163, 20);
            this.NombreNuevoRol.TabIndex = 2;
            this.NombreNuevoRol.TextChanged += new System.EventHandler(this.NombreNuevoRol_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Funcionalidades
            // 
            this.Funcionalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Funcionalidades.FormattingEnabled = true;
            this.Funcionalidades.Location = new System.Drawing.Point(88, 54);
            this.Funcionalidades.Name = "Funcionalidades";
            this.Funcionalidades.Size = new System.Drawing.Size(163, 21);
            this.Funcionalidades.TabIndex = 3;
            this.Funcionalidades.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btn_atras
            // 
            this.btn_atras.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_atras.Location = new System.Drawing.Point(10, 357);
            this.btn_atras.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_atras.Name = "btn_atras";
            this.btn_atras.Size = new System.Drawing.Size(73, 25);
            this.btn_atras.TabIndex = 22;
            this.btn_atras.Text = "Atrás";
            this.btn_atras.UseVisualStyleBackColor = true;
            this.btn_atras.Click += new System.EventHandler(this.btn_atras_Click);
            // 
            // table_funcionalidades
            // 
            this.table_funcionalidades.AllowUserToAddRows = false;
            this.table_funcionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_funcionalidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idFunc,
            this.idRolFuncionalidad,
            this.Funcionalidad,
            this.Eliminar});
            this.table_funcionalidades.Location = new System.Drawing.Point(10, 150);
            this.table_funcionalidades.Name = "table_funcionalidades";
            this.table_funcionalidades.Size = new System.Drawing.Size(241, 184);
            this.table_funcionalidades.TabIndex = 23;
            // 
            // idFunc
            // 
            this.idFunc.DataPropertyName = "func_id";
            this.idFunc.HeaderText = "id";
            this.idFunc.Name = "idFunc";
            this.idFunc.Visible = false;
            // 
            // idRolFuncionalidad
            // 
            this.idRolFuncionalidad.DataPropertyName = "rol_funcionalidad_id";
            this.idRolFuncionalidad.HeaderText = "id_rol_funcionalidad";
            this.idRolFuncionalidad.Name = "idRolFuncionalidad";
            this.idRolFuncionalidad.Visible = false;
            // 
            // Funcionalidad
            // 
            this.Funcionalidad.DataPropertyName = "func_detalle";
            this.Funcionalidad.HeaderText = "Funcionalidad";
            this.Funcionalidad.Name = "Funcionalidad";
            this.Funcionalidad.ReadOnly = true;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 393);
            this.Controls.Add(this.table_funcionalidades);
            this.Controls.Add(this.btn_atras);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Funcionalidades);
            this.Controls.Add(this.NombreNuevoRol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Alta";
            this.Text = "Alta Rol";
            ((System.ComponentModel.ISupportInitialize)(this.table_funcionalidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NombreNuevoRol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox Funcionalidades;
        private System.Windows.Forms.Button btn_atras;
        private System.Windows.Forms.DataGridView table_funcionalidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFunc;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRolFuncionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Funcionalidad;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}