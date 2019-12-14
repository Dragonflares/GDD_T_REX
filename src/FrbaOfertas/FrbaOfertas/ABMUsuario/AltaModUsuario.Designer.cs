namespace FrbaOfertas.ABMUsuario
{
    partial class AltaModUsuario
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
            this.button3 = new System.Windows.Forms.Button();
            this.registrarse = new System.Windows.Forms.Button();
            this.contrasenia = new System.Windows.Forms.TextBox();
            this.nombreUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 30);
            this.button3.TabIndex = 84;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // registrarse
            // 
            this.registrarse.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.registrarse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrarse.Location = new System.Drawing.Point(195, 180);
            this.registrarse.Name = "registrarse";
            this.registrarse.Size = new System.Drawing.Size(84, 30);
            this.registrarse.TabIndex = 83;
            this.registrarse.Text = "Guardar";
            this.registrarse.UseVisualStyleBackColor = false;
            this.registrarse.Click += new System.EventHandler(this.registrarse_Click);
            // 
            // contrasenia
            // 
            this.contrasenia.Location = new System.Drawing.Point(159, 85);
            this.contrasenia.Name = "contrasenia";
            this.contrasenia.Size = new System.Drawing.Size(113, 20);
            this.contrasenia.TabIndex = 80;
            // 
            // nombreUsuario
            // 
            this.nombreUsuario.Location = new System.Drawing.Point(17, 85);
            this.nombreUsuario.Name = "nombreUsuario";
            this.nombreUsuario.Size = new System.Drawing.Size(113, 20);
            this.nombreUsuario.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 76;
            this.label3.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Nombre de Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 20);
            this.label1.TabIndex = 74;
            this.label1.Text = "Información Usuario";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 20);
            this.textBox1.TabIndex = 85;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 30);
            this.button1.TabIndex = 86;
            this.button1.Text = "Habilitar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = "Estado";
            // 
            // AltaModUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 222);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.registrarse);
            this.Controls.Add(this.contrasenia);
            this.Controls.Add(this.nombreUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AltaModUsuario";
            this.Text = "AltaModUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button registrarse;
        private System.Windows.Forms.TextBox contrasenia;
        private System.Windows.Forms.TextBox nombreUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
    }
}