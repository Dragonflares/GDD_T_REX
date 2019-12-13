namespace FrbaOfertas.CargaCredito
{
    partial class CargaCredito
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
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.text_titular = new System.Windows.Forms.TextBox();
            this.text_numero_tarj = new System.Windows.Forms.TextBox();
            this.text_banco = new System.Windows.Forms.TextBox();
            this.combo_metodo_pago = new System.Windows.Forms.ComboBox();
            this.combo_tipo_tarj = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.text_monto = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.text_monto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carga de crédito";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nro Tarjeta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Monto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Metodo Pago";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "DNI Titular Tarjeta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Tipo Tarjeta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Banco Tarjeta";
            // 
            // text_titular
            // 
            this.text_titular.Location = new System.Drawing.Point(178, 172);
            this.text_titular.Name = "text_titular";
            this.text_titular.Size = new System.Drawing.Size(100, 20);
            this.text_titular.TabIndex = 3;
            // 
            // text_numero_tarj
            // 
            this.text_numero_tarj.Location = new System.Drawing.Point(178, 228);
            this.text_numero_tarj.Name = "text_numero_tarj";
            this.text_numero_tarj.Size = new System.Drawing.Size(100, 20);
            this.text_numero_tarj.TabIndex = 5;
            // 
            // text_banco
            // 
            this.text_banco.Location = new System.Drawing.Point(42, 228);
            this.text_banco.Name = "text_banco";
            this.text_banco.Size = new System.Drawing.Size(100, 20);
            this.text_banco.TabIndex = 4;
            // 
            // combo_metodo_pago
            // 
            this.combo_metodo_pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_metodo_pago.FormattingEnabled = true;
            this.combo_metodo_pago.Items.AddRange(new object[] {
            "Crédito",
            "Débito"});
            this.combo_metodo_pago.Location = new System.Drawing.Point(42, 171);
            this.combo_metodo_pago.Name = "combo_metodo_pago";
            this.combo_metodo_pago.Size = new System.Drawing.Size(100, 21);
            this.combo_metodo_pago.TabIndex = 2;
            this.combo_metodo_pago.SelectedIndexChanged += new System.EventHandler(this.combo_metodo_pago_SelectedIndexChanged);
            // 
            // combo_tipo_tarj
            // 
            this.combo_tipo_tarj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_tipo_tarj.FormattingEnabled = true;
            this.combo_tipo_tarj.Items.AddRange(new object[] {
            "Crédito",
            "Débito"});
            this.combo_tipo_tarj.Location = new System.Drawing.Point(42, 287);
            this.combo_tipo_tarj.Name = "combo_tipo_tarj";
            this.combo_tipo_tarj.Size = new System.Drawing.Size(100, 21);
            this.combo_tipo_tarj.TabIndex = 6;
            this.combo_tipo_tarj.SelectedIndexChanged += new System.EventHandler(this.combo_tipo_tarj_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cargar crédito";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(54, 341);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 34);
            this.button3.TabIndex = 9;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // text_monto
            // 
            this.text_monto.Location = new System.Drawing.Point(177, 288);
            this.text_monto.Name = "text_monto";
            this.text_monto.Size = new System.Drawing.Size(101, 20);
            this.text_monto.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(111, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Cliente";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(111, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "Seleccionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CargaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 407);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.text_monto);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.combo_tipo_tarj);
            this.Controls.Add(this.combo_metodo_pago);
            this.Controls.Add(this.text_banco);
            this.Controls.Add(this.text_numero_tarj);
            this.Controls.Add(this.text_titular);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CargaCredito";
            this.Text = "CargaCredito";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CargaCredito_FormClosing);
            this.Load += new System.EventHandler(this.CargaCredito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.text_monto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox text_titular;
        private System.Windows.Forms.TextBox text_numero_tarj;
        private System.Windows.Forms.TextBox text_banco;
        private System.Windows.Forms.ComboBox combo_metodo_pago;
        private System.Windows.Forms.ComboBox combo_tipo_tarj;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown text_monto;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}