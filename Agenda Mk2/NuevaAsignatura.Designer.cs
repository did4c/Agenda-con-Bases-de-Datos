namespace Agenda_Mk2
{
    partial class NuevaAsignatura
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
            this.tbAnyadirAsignatura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnyadirAsignatura = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbAnyadirAsignatura
            // 
            this.tbAnyadirAsignatura.Location = new System.Drawing.Point(189, 142);
            this.tbAnyadirAsignatura.Name = "tbAnyadirAsignatura";
            this.tbAnyadirAsignatura.Size = new System.Drawing.Size(222, 20);
            this.tbAnyadirAsignatura.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(202, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "INTRODUZCA UN NOMBRE:";
            // 
            // btnAnyadirAsignatura
            // 
            this.btnAnyadirAsignatura.Location = new System.Drawing.Point(238, 168);
            this.btnAnyadirAsignatura.Name = "btnAnyadirAsignatura";
            this.btnAnyadirAsignatura.Size = new System.Drawing.Size(118, 31);
            this.btnAnyadirAsignatura.TabIndex = 13;
            this.btnAnyadirAsignatura.Text = "AÑADIR";
            this.btnAnyadirAsignatura.UseVisualStyleBackColor = true;
            this.btnAnyadirAsignatura.Click += new System.EventHandler(this.btnAnyadirAsignatura_Click);
            // 
            // NuevaAsignatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 334);
            this.Controls.Add(this.tbAnyadirAsignatura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAnyadirAsignatura);
            this.Name = "NuevaAsignatura";
            this.Text = "NuevaAsignatura";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnyadirAsignatura;
        public System.Windows.Forms.TextBox tbAnyadirAsignatura;
    }
}