namespace FrbaOfertas.ABMRol
{
    partial class Modificacion
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
            this.components = new System.ComponentModel.Container();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.comboBoxFuncionalidades = new System.Windows.Forms.ComboBox();
            this.NombreTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.table_funcionalidades = new System.Windows.Forms.DataGridView();
            this.BotonAgregar = new System.Windows.Forms.Button();
            this.btn_activar = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_atras = new System.Windows.Forms.Button();
            this.idFunc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRolFuncionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Funcionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.table_funcionalidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(161, 334);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_limpiar.TabIndex = 11;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(296, 334);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_guardar.TabIndex = 10;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // comboBoxFuncionalidades
            // 
            this.comboBoxFuncionalidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFuncionalidades.FormattingEnabled = true;
            this.comboBoxFuncionalidades.Location = new System.Drawing.Point(103, 63);
            this.comboBoxFuncionalidades.Name = "comboBoxFuncionalidades";
            this.comboBoxFuncionalidades.Size = new System.Drawing.Size(161, 21);
            this.comboBoxFuncionalidades.TabIndex = 9;
            // 
            // NombreTextBox
            // 
            this.NombreTextBox.Location = new System.Drawing.Point(103, 31);
            this.NombreTextBox.Name = "NombreTextBox";
            this.NombreTextBox.Size = new System.Drawing.Size(161, 20);
            this.NombreTextBox.TabIndex = 8;
            this.NombreTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.NombreTextBox_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Funcionalidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre";
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
            this.table_funcionalidades.Location = new System.Drawing.Point(27, 106);
            this.table_funcionalidades.Name = "table_funcionalidades";
            this.table_funcionalidades.Size = new System.Drawing.Size(344, 198);
            this.table_funcionalidades.TabIndex = 12;
            this.table_funcionalidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_funcionalidades_CellContentClick);
            // 
            // BotonAgregar
            // 
            this.BotonAgregar.Location = new System.Drawing.Point(296, 63);
            this.BotonAgregar.Name = "BotonAgregar";
            this.BotonAgregar.Size = new System.Drawing.Size(75, 23);
            this.BotonAgregar.TabIndex = 13;
            this.BotonAgregar.Text = "Agregar";
            this.BotonAgregar.UseVisualStyleBackColor = true;
            this.BotonAgregar.Click += new System.EventHandler(this.BotonAgregar_Click);
            // 
            // btn_activar
            // 
            this.btn_activar.Location = new System.Drawing.Point(296, 28);
            this.btn_activar.Name = "btn_activar";
            this.btn_activar.Size = new System.Drawing.Size(75, 23);
            this.btn_activar.TabIndex = 14;
            this.btn_activar.Text = "Activar";
            this.btn_activar.UseVisualStyleBackColor = true;
            this.btn_activar.Click += new System.EventHandler(this.btn_activar_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btn_atras
            // 
            this.btn_atras.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_atras.Location = new System.Drawing.Point(26, 334);
            this.btn_atras.Margin = new System.Windows.Forms.Padding(2);
            this.btn_atras.Name = "btn_atras";
            this.btn_atras.Size = new System.Drawing.Size(73, 25);
            this.btn_atras.TabIndex = 22;
            this.btn_atras.Text = "Atrás";
            this.btn_atras.UseVisualStyleBackColor = true;
            this.btn_atras.Click += new System.EventHandler(this.btn_atras_Click);
            // 
            // idFunc
            // 
            this.idFunc.DataPropertyName = "id";
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
            this.Funcionalidad.DataPropertyName = "Funcionalidad";
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
            // Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(409, 373);
            this.Controls.Add(this.btn_atras);
            this.Controls.Add(this.btn_activar);
            this.Controls.Add(this.BotonAgregar);
            this.Controls.Add(this.table_funcionalidades);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.comboBoxFuncionalidades);
            this.Controls.Add(this.NombreTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Modificacion";
            this.Text = "Formulario Modificacion";
            this.Load += new System.EventHandler(this.FormularioModificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table_funcionalidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.ComboBox comboBoxFuncionalidades;
        private System.Windows.Forms.TextBox NombreTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView table_funcionalidades;
        private System.Windows.Forms.Button BotonAgregar;
        private System.Windows.Forms.Button btn_activar;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btn_atras;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFunc;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRolFuncionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Funcionalidad;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}