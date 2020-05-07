namespace Agenda_Mk2
{
    partial class Modificar
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
            this.btnHoy = new System.Windows.Forms.Button();
            this.mtbFecha = new System.Windows.Forms.MaskedTextBox();
            this.tbDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptarTarea = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAsignaturas = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnHoy
            // 
            this.btnHoy.Location = new System.Drawing.Point(419, 78);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(69, 29);
            this.btnHoy.TabIndex = 22;
            this.btnHoy.Text = "HOY";
            this.btnHoy.UseVisualStyleBackColor = true;
            // 
            // mtbFecha
            // 
            this.mtbFecha.Location = new System.Drawing.Point(494, 83);
            this.mtbFecha.Mask = "00/00/0000";
            this.mtbFecha.Name = "mtbFecha";
            this.mtbFecha.Size = new System.Drawing.Size(76, 20);
            this.mtbFecha.TabIndex = 21;
            this.mtbFecha.ValidatingType = typeof(System.DateTime);
            // 
            // tbDescripcion
            // 
            this.tbDescripcion.Location = new System.Drawing.Point(233, 158);
            this.tbDescripcion.Multiline = true;
            this.tbDescripcion.Name = "tbDescripcion";
            this.tbDescripcion.Size = new System.Drawing.Size(337, 144);
            this.tbDescripcion.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "DESCRIPCIÓN:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "FECHA:";
            // 
            // btnAceptarTarea
            // 
            this.btnAceptarTarea.Location = new System.Drawing.Point(233, 375);
            this.btnAceptarTarea.Name = "btnAceptarTarea";
            this.btnAceptarTarea.Size = new System.Drawing.Size(151, 29);
            this.btnAceptarTarea.TabIndex = 17;
            this.btnAceptarTarea.Text = "ACEPTAR";
            this.btnAceptarTarea.UseVisualStyleBackColor = true;
            this.btnAceptarTarea.Click += new System.EventHandler(this.btnAceptarTarea_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(230, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "ASIGNATURAS:";
            // 
            // cbAsignaturas
            // 
            this.cbAsignaturas.Location = new System.Drawing.Point(376, 324);
            this.cbAsignaturas.Name = "cbAsignaturas";
            this.cbAsignaturas.Size = new System.Drawing.Size(194, 20);
            this.cbAsignaturas.TabIndex = 24;
            // 
            // Modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbAsignaturas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnHoy);
            this.Controls.Add(this.mtbFecha);
            this.Controls.Add(this.tbDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptarTarea);
            this.Name = "Modificar";
            this.Text = "Modificar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptarTarea;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.MaskedTextBox mtbFecha;
        public System.Windows.Forms.TextBox tbDescripcion;
        public System.Windows.Forms.TextBox cbAsignaturas;
    }
}