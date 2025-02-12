﻿using System;
using System.Windows.Forms;
namespace FrbaOfertas.ABMCliente
{
    partial class AltaCliente
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
            this.label5 = new System.Windows.Forms.Label();
            this.combo_tipo_dni = new System.Windows.Forms.ComboBox();
            this.text_nro_dni = new System.Windows.Forms.TextBox();
            this.text_usuario = new System.Windows.Forms.TextBox();
            this.text_nombre = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.text_email = new System.Windows.Forms.TextBox();
            this.text_telefono = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.text_credito = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.text_pass = new System.Windows.Forms.TextBox();
            this.text_apellido = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.datepicker_fecha_nac = new System.Windows.Forms.DateTimePicker();
            this.text_piso = new System.Windows.Forms.TextBox();
            this.text_cod_postal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.text_calle = new System.Windows.Forms.TextBox();
            this.text_localidad = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.text_dto = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Carga de cliente";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Usuario";
            this.label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // combo_tipo_dni
            // 
            this.combo_tipo_dni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_tipo_dni.FormattingEnabled = true;
            this.combo_tipo_dni.Items.AddRange(new object[] {
            "DNI",
            "CI"});
            this.combo_tipo_dni.Location = new System.Drawing.Point(42, 189);
            this.combo_tipo_dni.Name = "combo_tipo_dni";
            this.combo_tipo_dni.Size = new System.Drawing.Size(99, 21);
            this.combo_tipo_dni.TabIndex = 5;
            this.combo_tipo_dni.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // text_nro_dni
            // 
            this.text_nro_dni.Location = new System.Drawing.Point(174, 190);
            this.text_nro_dni.Name = "text_nro_dni";
            this.text_nro_dni.Size = new System.Drawing.Size(100, 20);
            this.text_nro_dni.TabIndex = 6;
            this.text_nro_dni.TextChanged += new System.EventHandler(this.TextBox8_TextChanged);
            // 
            // text_usuario
            // 
            this.text_usuario.Location = new System.Drawing.Point(42, 73);
            this.text_usuario.Name = "text_usuario";
            this.text_usuario.Size = new System.Drawing.Size(99, 20);
            this.text_usuario.TabIndex = 0;
            this.text_usuario.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            // 
            // text_nombre
            // 
            this.text_nombre.Location = new System.Drawing.Point(42, 112);
            this.text_nombre.Name = "text_nombre";
            this.text_nombre.Size = new System.Drawing.Size(99, 20);
            this.text_nombre.TabIndex = 2;
            this.text_nombre.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(171, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Número de documento";
            this.label9.Click += new System.EventHandler(this.Label9_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Nombre";
            this.label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tipo de documento";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Fecha de Nacimiento";
            // 
            // text_email
            // 
            this.text_email.Location = new System.Drawing.Point(42, 229);
            this.text_email.Name = "text_email";
            this.text_email.Size = new System.Drawing.Size(99, 20);
            this.text_email.TabIndex = 7;
            this.text_email.TextChanged += new System.EventHandler(this.TextBox4_TextChanged);
            // 
            // text_telefono
            // 
            this.text_telefono.Location = new System.Drawing.Point(174, 229);
            this.text_telefono.Name = "text_telefono";
            this.text_telefono.Size = new System.Drawing.Size(100, 20);
            this.text_telefono.TabIndex = 8;
            this.text_telefono.TextChanged += new System.EventHandler(this.TextBox5_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(171, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Telefono";
            this.label7.Click += new System.EventHandler(this.Label7_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Email";
            this.label10.Click += new System.EventHandler(this.Label10_Click);
            // 
            // text_credito
            // 
            this.text_credito.Location = new System.Drawing.Point(111, 272);
            this.text_credito.Name = "text_credito";
            this.text_credito.ReadOnly = true;
            this.text_credito.Size = new System.Drawing.Size(100, 20);
            this.text_credito.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(108, 256);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Credito total";
            // 
            // text_pass
            // 
            this.text_pass.Location = new System.Drawing.Point(174, 73);
            this.text_pass.Name = "text_pass";
            this.text_pass.PasswordChar = '*';
            this.text_pass.Size = new System.Drawing.Size(100, 20);
            this.text_pass.TabIndex = 1;
            this.text_pass.Enter += new System.EventHandler(this.text_pass_Enter);
            // 
            // text_apellido
            // 
            this.text_apellido.Location = new System.Drawing.Point(174, 112);
            this.text_apellido.Name = "text_apellido";
            this.text_apellido.Size = new System.Drawing.Size(100, 20);
            this.text_apellido.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(171, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Apellido";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(171, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 41;
            this.label13.Text = "Contraseña";
            this.label13.Click += new System.EventHandler(this.Label13_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(42, 447);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 34);
            this.button3.TabIndex = 16;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(182, 447);
            this.btn_save.Name = "btn_save";
            this.btn_save.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_save.Size = new System.Drawing.Size(92, 34);
            this.btn_save.TabIndex = 15;
            this.btn_save.Text = "Guardar";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // datepicker_fecha_nac
            // 
            this.datepicker_fecha_nac.CustomFormat = "dd-MM-yyyy";
            this.datepicker_fecha_nac.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datepicker_fecha_nac.Location = new System.Drawing.Point(111, 151);
            this.datepicker_fecha_nac.Name = "datepicker_fecha_nac";
            this.datepicker_fecha_nac.Size = new System.Drawing.Size(100, 20);
            this.datepicker_fecha_nac.TabIndex = 4;
            this.datepicker_fecha_nac.Value = new System.DateTime(1999, 12, 4, 0, 0, 0, 0);
            // 
            // text_piso
            // 
            this.text_piso.Location = new System.Drawing.Point(144, 40);
            this.text_piso.Name = "text_piso";
            this.text_piso.Size = new System.Drawing.Size(37, 20);
            this.text_piso.TabIndex = 11;
            // 
            // text_cod_postal
            // 
            this.text_cod_postal.Location = new System.Drawing.Point(144, 79);
            this.text_cod_postal.Name = "text_cod_postal";
            this.text_cod_postal.Size = new System.Drawing.Size(100, 20);
            this.text_cod_postal.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(141, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Cod. Postal";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(141, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 13);
            this.label14.TabIndex = 54;
            this.label14.Text = "Piso";
            // 
            // text_calle
            // 
            this.text_calle.Location = new System.Drawing.Point(12, 40);
            this.text_calle.Name = "text_calle";
            this.text_calle.Size = new System.Drawing.Size(99, 20);
            this.text_calle.TabIndex = 10;
            // 
            // text_localidad
            // 
            this.text_localidad.Location = new System.Drawing.Point(12, 79);
            this.text_localidad.Name = "text_localidad";
            this.text_localidad.Size = new System.Drawing.Size(99, 20);
            this.text_localidad.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 51;
            this.label15.Text = "Localidad";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 13);
            this.label16.TabIndex = 50;
            this.label16.Text = "Calle y Numero";
            // 
            // text_dto
            // 
            this.text_dto.Location = new System.Drawing.Point(207, 40);
            this.text_dto.Name = "text_dto";
            this.text_dto.Size = new System.Drawing.Size(37, 20);
            this.text_dto.TabIndex = 12;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(204, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 13);
            this.label17.TabIndex = 58;
            this.label17.Text = "Dto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.text_dto);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.text_piso);
            this.groupBox1.Controls.Add(this.text_cod_postal);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.text_calle);
            this.groupBox1.Controls.Add(this.text_localidad);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Location = new System.Drawing.Point(30, 298);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 124);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dirección";
            // 
            // AltaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 510);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.datepicker_fecha_nac);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.text_pass);
            this.Controls.Add(this.text_apellido);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.text_credito);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.text_email);
            this.Controls.Add(this.text_telefono);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_nro_dni);
            this.Controls.Add(this.text_usuario);
            this.Controls.Add(this.text_nombre);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combo_tipo_dni);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "AltaCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta cliente";
            this.Load += new System.EventHandler(this.ABMCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combo_tipo_dni;
        private System.Windows.Forms.TextBox text_nro_dni;
        private System.Windows.Forms.TextBox text_usuario;
        private System.Windows.Forms.TextBox text_nombre;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_email;
        private System.Windows.Forms.TextBox text_telefono;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox text_credito;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox text_pass;
        private System.Windows.Forms.TextBox text_apellido;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DateTimePicker datepicker_fecha_nac;
        private TextBox text_piso;
        private TextBox text_cod_postal;
        private Label label8;
        private Label label14;
        private TextBox text_calle;
        private TextBox text_localidad;
        private Label label15;
        private Label label16;
        private TextBox text_dto;
        private Label label17;
        private GroupBox groupBox1;
    }
}