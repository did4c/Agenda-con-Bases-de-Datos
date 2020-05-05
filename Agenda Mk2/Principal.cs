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
    public partial class Principal : Form
    {//Creamos las referencias respectivas al resto de forms, la clase y lista necesaria para almacenar la informacion dentro del form Principal.
        NuevaAsignatura form2;
        NuevaTarea form3;
        Modificar form4;

        //Clase tarea = new Clase();
        //List<Clase> tareas = new List<Clase>();

        public String asignatura, identificador; //Variable para almacenar la asignatura de la que queremos crear una tarea. 
        public int id;

        public MySqlConnection conexion;

        public Principal()
        {
            InitializeComponent();

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "agenda";

            conexion = new MySqlConnection(builder.ToString());

            llenardatagrid();
        }

        public void llenardatagrid()
        {
            MySqlCommand cm = new MySqlCommand("select * from tareas;", conexion);
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTareas.DataSource = dt;
        }

        //private void llenarDGV() //Metodo para llenar el DataGripView con la informacion que le proporcionamos.
        //{
        //    dgvTareas.DataSource = null;
        //    dgvTareas.DataSource = tareas;
        //}

        private void btnNuevaAsignatura_Click(object sender, EventArgs e)
        {//Crear asignaturas.
            form2 = new NuevaAsignatura(this);//Llama al form2 y lo muestra en pantalla
            form2.Show();

            btnNuevaTarea.Enabled = true; //Al añadir un asignatura, habilita la opcion de crear tareas
        }

        private void btnEliminarAsignatura_Click(object sender, EventArgs e)
        {
            cbAsignaturas.Items.Remove(cbAsignaturas.SelectedItem); //elimina la asignatura seleccionada en el combobox

            if (cbAsignaturas.Items.Count == 0) //condicion para si quieres eliminar la ultima asignatura en el combobox, se quede vacio y deshabilite la opcion de crear nueva tarea
            {
                cbAsignaturas.Text = "";
                btnNuevaTarea.Enabled = false;
            }
        }

        private void btnNuevaTarea_Click(object sender, EventArgs e)
        { 
            asignatura = (String)cbAsignaturas.SelectedItem; //guarda la asignatura seleccionada en esta variable publica para poder ser tomada en el form3
            form3 = new NuevaTarea(this);//Llama al form2 y lo muestra en pantalla
            if (form3.ShowDialog() == DialogResult.OK)//condicion que queda a la espera de que en el form3 se active la orden de DialogResult y poder rellenar, en condicion a la clase, la lista y ser mostrada en el DataGripView
            {
                //tarea = new Clase();

                //tarea.Identificador = id;
                //tarea.Fecha = form3.fecha;
                //tarea.Descripcion = form3.descripcion;
                //tarea.Asignatura = asignatura;

                //tareas.Add(tarea);
                //llenarDGV();
                llenardatagrid();

            }
            btnEliminarTarea.Enabled = true; //Habilitado la opcion de eliminar una tarea
        }

        private void btnEliminarTarea_Click(object sender, EventArgs e)
        {
           /* tareas.RemoveAt(dgvTareas.CurrentRow.Index);*/ //Elimina una tarea del list
            /*llenarDGV();*///Se actualiza esa eliminacion realizada por pantalla
            llenardatagrid();
            //if (tareas.Count == 0)
            //{
            //    btnEliminarTarea.Enabled = false;//Deshabilita la opcion de poder eliminar tareas cuando ya no hay tareas registradas en el list.
            //}
        }

        public void generarIdentificador() //genera el id correspondiente a la tarea nueva o modificada
        {
            id = 1;

            conexion.Open();
            String consulta = "select identificador from tareas";
            MySqlCommand cmd = new MySqlCommand(consulta, conexion);
            MySqlDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                id++;
            }
            MessageBox.Show(id+"");
            res.Close();
            conexion.Close();
        }

        public void guardarInfoID()
        {
            identificador = dgvTareas.CurrentRow.Cells["identificador"].Value.ToString();

            conexion.Open();
            String consulta = "select * from tareas where identificador=@id";
            MySqlCommand cmd = new MySqlCommand(consulta, conexion);
            cmd.Parameters.AddWithValue("@id", identificador);
            cmd.Prepare();
            MySqlDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                form4.mtbFecha.Text = res.GetString(1);
                form4.tbDescripcion.Text = res.GetString(2);
                form4.cbAsignaturas.Text = res.GetString(3);
            }
            MessageBox.Show(id + "");
            res.Close();
            conexion.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            form4 = new Modificar(this);
            guardarInfoID();
            form4.Show();
        }
    }
}
