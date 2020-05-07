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

        public String asignatura, identificador; //Variable para almacenar la asignatura de la que queremos crear una tarea. 
        public int id, conTareas;

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

            llenarDGV();
            dgvTareas.Columns["identificador"].Visible = false;
        }

        public void llenarDGV()
        {
            generarIdentificador();
            MySqlCommand cm = new MySqlCommand("select * from tareas;", conexion);
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTareas.DataSource = dt;
        }

        private void btnNuevaAsignatura_Click(object sender, EventArgs e)
        {//Crear asignaturas.
            form2 = new NuevaAsignatura(this);//Llama al form2 y lo muestra en pantalla
            form2.Show();

            btnNuevaTarea.Enabled = true; //Al añadir un asignatura, habilita la opcion de crear tareas
            btnEliminarTarea.Enabled = true;
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
                llenarDGV();
            }
            btnEliminarTarea.Enabled = true; //Habilitado la opcion de eliminar una tarea
        }

        private void btnEliminarTarea_Click(object sender, EventArgs e)
        {
            identificador = dgvTareas.CurrentRow.Cells["identificador"].Value.ToString();

            conexion.Open();
            String actualizar = "delete from tareas where identificador='" + identificador + "'";
            MySqlCommand cmd = new MySqlCommand(actualizar, conexion);
            cmd.ExecuteNonQuery();
            conexion.Close();

            if (conTareas <= 1)
            {
                contadorTareas();
                llenarDGV();
                btnEliminarTarea.Enabled = false;
            }
            else
            {
                contadorTareas();
                llenarDGV();
                ajustarID();
            }
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
            //MessageBox.Show(id+"");
            res.Close();
            conexion.Close();
        }

        public void contadorTareas() //genera el id correspondiente a la tarea nueva o modificada
        {
            conTareas = 0;
            conexion.Open();
            String consulta = "select identificador from tareas";
            MySqlCommand cmd = new MySqlCommand(consulta, conexion);
            MySqlDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                //conTareas= Int16.Parse(res.GetString(0));
                conTareas++;
            }
            //MessageBox.Show(id+"");
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
            //MessageBox.Show(id + "");
            res.Close();
            conexion.Close();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            deshabilitarBotonEliminar();
        }

        private void deshabilitarBotonEliminar()
        {
            if (conTareas <= 1)
            {
                btnEliminarTarea.Enabled = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            form4 = new Modificar(this);
            guardarInfoID();
            form4.Show();
            deshabilitarBotonEliminar();
        }

        public void ajustarID()
        {
            int s=0, u=0, p=0;
            int[] numID = new int[conTareas];
            MessageBox.Show(conTareas+"");

            contadorTareas();

            conexion.Open();
            String consulta = "select identificador from tareas";
            MySqlCommand cmd = new MySqlCommand(consulta, conexion);
            MySqlDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                numID[s] = Int16.Parse(res.GetString(0));
                s++;
            }
            res.Close();
            conexion.Close();

            //for (int i = 0; i < numID.Length; i++)
            //{
            //    MessageBox.Show(""+numID[i]);
            //}

            conexion.Open();
            while (p<=conTareas)
            {
                p++;
                //MessageBox.Show("ANTIGUO: " + numID[u] + ", NUEVO: " + p);
                String update = "update tareas set identificador='" + p + "' where identificador='"+numID[u]+"'";
                MySqlCommand cmd2 = new MySqlCommand(update, conexion);
                cmd2.ExecuteNonQuery();
                //MessageBox.Show("El numero original " + numID[u] + " ha pasado a ser " + res.GetString(0) + "--------------->" + u);
                u++;
                if (p==numID.Length)
                {
                    break;
                }
            }
            conexion.Close();
        }
    }
}
