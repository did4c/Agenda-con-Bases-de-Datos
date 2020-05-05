using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda_Mk2
{
    public partial class Modificar : Form
    {
        Principal form1;

        public Modificar(Principal p)
        {
            InitializeComponent();
            form1 = p;
        }

        private void btnAceptarTarea_Click(object sender, EventArgs e)
        {
            form1.conexion.Open();
            String actualizar = "update tareas set fecha='" + mtbFecha.Text + "',descripcion='" + tbDescripcion.Text + "',asignatura='" + form1.asignatura + "' where identificador='" + form1.identificador + "'";
            MySqlCommand cmd = new MySqlCommand(actualizar, form1.conexion);
            cmd.ExecuteNonQuery();

            form1.conexion.Close();

            this.Close();

            form1.llenardatagrid();
            form1.Show();
        }
    }
}
