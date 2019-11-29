namespace FrbaOfertas.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.buscarButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.semestre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.anio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tipoListado = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridResultados = new System.Windows.Forms.DataGridView();
            this.volverButton = new System.Windows.Forms.Button();
            this.tipoErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.anioErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.semestreErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anioErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.semestreErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.limpiarButton);
            this.panel1.Controls.Add(this.buscarButton);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.semestre);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.anio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tipoListado);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 183);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(64, 138);
            this.limpiarButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(100, 28);
            this.limpiarButton.TabIndex = 8;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // buscarButton
            // 
            this.buscarButton.BackColor = System.Drawing.SystemColors.Control;
            this.buscarButton.Location = new System.Drawing.Point(513, 138);
            this.buscarButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(119, 28);
            this.buscarButton.TabIndex = 7;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = false;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Filtros de Búsqueda";
            // 
            // semestre
            // 
            this.semestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semestre.FormattingEnabled = true;
            this.semestre.Location = new System.Drawing.Point(477, 87);
            this.semestre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.semestre.Name = "semestre";
            this.semestre.Size = new System.Drawing.Size(83, 24);
            this.semestre.TabIndex = 5;
            this.semestre.SelectedIndexChanged += new System.EventHandler(this.semestre_SelectedIndexChanged);
            this.semestre.Validating += new System.ComponentModel.CancelEventHandler(this.semestre_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Semestre";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // anio
            // 
            this.anio.Location = new System.Drawing.Point(208, 87);
            this.anio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.anio.Name = "anio";
            this.anio.Size = new System.Drawing.Size(132, 22);
            this.anio.TabIndex = 3;
            this.anio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.anio_KeyPress);
            this.anio.Validating += new System.ComponentModel.CancelEventHandler(this.anio_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Año";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de Listado";
            // 
            // tipoListado
            // 
            this.tipoListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoListado.FormattingEnabled = true;
            this.tipoListado.Location = new System.Drawing.Point(208, 28);
            this.tipoListado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tipoListado.Name = "tipoListado";
            this.tipoListado.Size = new System.Drawing.Size(423, 24);
            this.tipoListado.TabIndex = 0;
            this.tipoListado.Validating += new System.ComponentModel.CancelEventHandler(this.tipoListado_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridResultados);
            this.groupBox1.Location = new System.Drawing.Point(16, 220);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(685, 251);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultados";
            // 
            // gridResultados
            // 
            this.gridResultados.AllowUserToAddRows = false;
            this.gridResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResultados.Location = new System.Drawing.Point(0, 23);
            this.gridResultados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridResultados.Name = "gridResultados";
            this.gridResultados.Size = new System.Drawing.Size(677, 228);
            this.gridResultados.TabIndex = 0;
            this.gridResultados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridResultados_CellContentClick);
            // 
            // volverButton
            // 
            this.volverButton.BackColor = System.Drawing.SystemColors.Control;
            this.volverButton.Location = new System.Drawing.Point(49, 500);
            this.volverButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(119, 28);
            this.volverButton.TabIndex = 8;
            this.volverButton.Text = "Atrás";
            this.volverButton.UseVisualStyleBackColor = false;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // tipoErrorProvider
            // 
            this.tipoErrorProvider.ContainerControl = this;
            // 
            // anioErrorProvider
            // 
            this.anioErrorProvider.ContainerControl = this;
            // 
            // semestreErrorProvider
            // 
            this.semestreErrorProvider.ContainerControl = this;
            // 
            // ListadoEstadisticoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(717, 543);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ListadoEstadisticoForm";
            this.Text = "Listado estadístico";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anioErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.semestreErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox tipoListado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox anio;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox semestre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridResultados;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.ErrorProvider tipoErrorProvider;
        private System.Windows.Forms.ErrorProvider anioErrorProvider;
        private System.Windows.Forms.ErrorProvider semestreErrorProvider;
        private System.Windows.Forms.Button limpiarButton;
    }
    }
}