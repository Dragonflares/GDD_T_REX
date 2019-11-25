namespace FrbaOfertas.Login
{
    partial class NuevoUser
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.confirmContrasenia = new System.Windows.Forms.TextBox();
            this.contrasenia = new System.Windows.Forms.TextBox();
            this.nombreUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.registrarse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.Enabled = false;
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBox1.Location = new System.Drawing.Point(171, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 20);
            this.textBox1.TabIndex = 54;
            // 
            // confirmContrasenia
            // 
            this.confirmContrasenia.Location = new System.Drawing.Point(171, 131);
            this.confirmContrasenia.Name = "confirmContrasenia";
            this.confirmContrasenia.Size = new System.Drawing.Size(113, 20);
            this.confirmContrasenia.TabIndex = 53;
            // 
            // contrasenia
            // 
            this.contrasenia.Location = new System.Drawing.Point(29, 131);
            this.contrasenia.Name = "contrasenia";
            this.contrasenia.Size = new System.Drawing.Size(113, 20);
            this.contrasenia.TabIndex = 52;
            // 
            // nombreUsuario
            // 
            this.nombreUsuario.Location = new System.Drawing.Point(29, 79);
            this.nombreUsuario.Name = "nombreUsuario";
            this.nombreUsuario.Size = new System.Drawing.Size(113, 20);
            this.nombreUsuario.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Confirme Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Rol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Nombre de Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "Registro Usuario";
            // 
            // registrarse
            // 
            this.registrarse.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.registrarse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrarse.Location = new System.Drawing.Point(171, 171);
            this.registrarse.Name = "registrarse";
            this.registrarse.Size = new System.Drawing.Size(113, 30);
            this.registrarse.TabIndex = 72;
            this.registrarse.Text = "Registrarse";
            this.registrarse.UseVisualStyleBackColor = false;
            this.registrarse.Click += new System.EventHandler(this.registrarse_Click);
            // 
            // NuevoUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 222);
            this.Controls.Add(this.registrarse);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.confirmContrasenia);
            this.Controls.Add(this.contrasenia);
            this.Controls.Add(this.nombreUsuario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NuevoUser";
            this.Text = "NuevoUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox confirmContrasenia;
        private System.Windows.Forms.TextBox contrasenia;
        private System.Windows.Forms.TextBox nombreUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button registrarse;
    }
}