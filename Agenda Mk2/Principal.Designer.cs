namespace Agenda_Mk2
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNuevaAsignatura = new System.Windows.Forms.Button();
            this.cbAsignaturas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEliminarAsignatura = new System.Windows.Forms.Button();
            this.btnNuevaTarea = new System.Windows.Forms.Button();
            this.btnEliminarTarea = new System.Windows.Forms.Button();
            this.dgvTareas = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevaAsignatura
            // 
            this.btnNuevaAsignatura.Location = new System.Drawing.Point(329, 57);
            this.btnNuevaAsignatura.Name = "btnNuevaAsignatura";
            this.btnNuevaAsignatura.Size = new System.Drawing.Size(135, 35);
            this.btnNuevaAsignatura.TabIndex = 0;
            this.btnNuevaAsignatura.Text = "NUEVA ASIGNATURA";
            this.btnNuevaAsignatura.UseVisualStyleBackColor = true;
            this.btnNuevaAsignatura.Click += new System.EventHandler(this.btnNuevaAsignatura_Click);
            // 
            // cbAsignaturas
            // 
            this.cbAsignaturas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAsignaturas.FormattingEnabled = true;
            this.cbAsignaturas.Location = new System.Drawing.Point(136, 71);
            this.cbAsignaturas.Name = "cbAsignaturas";
            this.cbAsignaturas.Size = new System.Drawing.Size(167, 21);
            this.cbAsignaturas.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "ASIGNATURAS:";
            // 
            // btnEliminarAsignatura
            // 
            this.btnEliminarAsignatura.Location = new System.Drawing.Point(470, 57);
            this.btnEliminarAsignatura.Name = "btnEliminarAsignatura";
            this.btnEliminarAsignatura.Size = new System.Drawing.Size(144, 35);
            this.btnEliminarAsignatura.TabIndex = 12;
            this.btnEliminarAsignatura.Text = "ELIMINAR ASIGNATURA";
            this.btnEliminarAsignatura.UseVisualStyleBackColor = true;
            this.btnEliminarAsignatura.Click += new System.EventHandler(this.btnEliminarAsignatura_Click);
            // 
            // btnNuevaTarea
            // 
            this.btnNuevaTarea.Enabled = false;
            this.btnNuevaTarea.Location = new System.Drawing.Point(164, 348);
            this.btnNuevaTarea.Name = "btnNuevaTarea";
            this.btnNuevaTarea.Size = new System.Drawing.Size(135, 35);
            this.btnNuevaTarea.TabIndex = 13;
            this.btnNuevaTarea.Text = "NUEVA TAREA";
            this.btnNuevaTarea.UseVisualStyleBackColor = true;
            this.btnNuevaTarea.Click += new System.EventHandler(this.btnNuevaTarea_Click);
            // 
            // btnEliminarTarea
            // 
            this.btnEliminarTarea.Location = new System.Drawing.Point(446, 348);
            this.btnEliminarTarea.Name = "btnEliminarTarea";
            this.btnEliminarTarea.Size = new System.Drawing.Size(144, 35);
            this.btnEliminarTarea.TabIndex = 14;
            this.btnEliminarTarea.Text = "ELIMINAR TAREA";
            this.btnEliminarTarea.UseVisualStyleBackColor = true;
            this.btnEliminarTarea.Click += new System.EventHandler(this.btnEliminarTarea_Click);
            // 
            // dgvTareas
            // 
            this.dgvTareas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTareas.Location = new System.Drawing.Point(136, 149);
            this.dgvTareas.Name = "dgvTareas";
            this.dgvTareas.Size = new System.Drawing.Size(478, 193);
            this.dgvTareas.TabIndex = 15;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(305, 348);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(135, 35);
            this.btnModificar.TabIndex = 16;
            this.btnModificar.Text = "MODIFICAR TAREA";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 429);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dgvTareas);
            this.Controls.Add(this.btnEliminarTarea);
            this.Controls.Add(this.btnNuevaTarea);
            this.Controls.Add(this.btnEliminarAsignatura);
            this.Controls.Add(this.cbAsignaturas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNuevaAsignatura);
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevaAsignatura;
        public System.Windows.Forms.ComboBox cbAsignaturas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminarAsignatura;
        private System.Windows.Forms.Button btnNuevaTarea;
        private System.Windows.Forms.Button btnEliminarTarea;
        public System.Windows.Forms.DataGridView dgvTareas;
        private System.Windows.Forms.Button btnModificar;
    }
}

