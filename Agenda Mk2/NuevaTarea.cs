using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Agenda_Mk2
{
    public partial class NuevaTarea : Form
    {//Creamos las referencias respectivas al resto de forms, variables Strings publicas necesarias para almacenar la informacion y poder pasarlas al form Principal.
        Principal form1;

        public String fecha;
        public String descripcion;
        private String fechaHoy = DateTime.Now.ToShortDateString();

        public NuevaTarea(Principal p)//referencia al form Principal
        {
            InitializeComponent();
            form1 = p;
        }

        private void btnAceptarTarea_Click(object sender, EventArgs e)
        {
            if (mtbFecha.Text != "  /  /") //si se deja vacia la fecha, automaticamente te pone el dia actual. De lo contrario puedes añadir la fecha que quieras
            {
                fecha = mtbFecha.Text;
                comprobar(); //metodo para determinar si se ha rellenado el textbox de descripcion y poder continuar con los registros.
                llenarTareasBases();
            }
            else
            {
                fecha = fechaHoy;
                comprobar();
                llenarTareasBases();
            }
            
        }

        private void comprobar()
        {
            if (tbDescripcion.Text == "") //si queda vacio, te informa de ello
            {
                MessageBox.Show("Tienes que rellenar el campo *descripcion*");
            }
            else
            {
                descripcion = tbDescripcion.Text; 

                this.DialogResult = DialogResult.OK; //envia la orden para que se active el if dentro del boton *NuevaTarea*
                Close();
            }
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            mtbFecha.Text = fechaHoy; //boton para asignar la fecha al dia actual en caso de que quieras
        }

        private void llenarTareasBases()
        {
            form1.conexion.Open();
            String consulta = "insert into tareas values(" + form1.id
                + ",'" + mtbFecha.Text
                + "','" + tbDescripcion.Text
                + "','" + form1.asignatura + "'); ";
            MySqlCommand cmd = new MySqlCommand(consulta, form1.conexion);
            cmd.ExecuteNonQuery();

            form1.conexion.Close();
            MessageBox.Show("fila insertada");
        }
    }
}
