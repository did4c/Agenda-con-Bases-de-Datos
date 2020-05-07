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

        public String asignatura, identificador; //Variables para almacenar la asignatura de la que queremos crear una tarea. 
        public int id, conTareas;

        public MySqlConnection conexion;

        public Principal() //vincular base de datos con visual 
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

        public void llenarDGV() //lo dice el nombre del metodo
        {
            generarIdentificador(); //genera el id correspondiente a la tarea nueva o modificada (por cada linea que lee aumenta en 1 el id)
            MySqlCommand cm = new MySqlCommand("select * from tareas;", conexion);
            MySqlDataAdapter da = new MySqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTareas.DataSource = dt; //carga la base en el datagridview
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
                llenarDGV(); //actualiza la base de datos y dtaagridview
            }
            btnEliminarTarea.Enabled = true; //Habilitado la opcion de eliminar una tarea
        }

        private void btnEliminarTarea_Click(object sender, EventArgs e)
        {
            identificador = dgvTareas.CurrentRow.Cells["identificador"].Value.ToString(); //guarda el valor de la celda identificador del datagridview

            conexion.Open();
            String actualizar = "delete from tareas where identificador='" + identificador + "'";
            MySqlCommand cmd = new MySqlCommand(actualizar, conexion);
            cmd.ExecuteNonQuery();
            conexion.Close();

            if (conTareas <= 1) //si hay 1 tarea, la elimina, actualiza la base y datagrid, dehabilito boton eliminar tarea y asigno id en 1 para que no comience en 2 desde 0
            {
                contadorTareas();
                llenarDGV();
                btnEliminarTarea.Enabled = false; 
                id = 1; 
            }
            else //si hay mas de una tarea, elimina la seleccionada, actualiza base y datagrid y ajusta los ids de cada tarea de manera ordenada y descendente
            {
                contadorTareas();
                llenarDGV();
                ajustarID();
            }
        }

        public void generarIdentificador() //genera el id correspondiente a la tarea nueva o modificada (por cada linea que lee aumenta en 1 el id)
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

        public void contadorTareas() //mismo funcionamiento que el metodo "generarIdentificacion" pero aplicable para el total de numero de tareas que hay
        {
            conTareas = 0;
            conexion.Open();
            String consulta = "select identificador from tareas";
            MySqlCommand cmd = new MySqlCommand(consulta, conexion);
            MySqlDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                conTareas++;
            }
            //MessageBox.Show(id+"");
            res.Close();
            conexion.Close();
        }

        public void guardarInfoID() //guarda las valores de las celdas fecha, descripcion y asignatura que se encuentran en la tarea seleccionada
        {
            identificador = dgvTareas.CurrentRow.Cells["identificador"].Value.ToString(); //guarda el valor de la celda identificador del datagridview

            conexion.Open();
            String consulta = "select * from tareas where identificador=@id";
            MySqlCommand cmd = new MySqlCommand(consulta, conexion);
            cmd.Parameters.AddWithValue("@id", identificador);
            cmd.Prepare();
            MySqlDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                form4.mtbFecha.Text = res.GetString(1); //celda de fecha
                form4.tbDescripcion.Text = res.GetString(2); //celda de descripcion
                form4.cbAsignaturas.Text = res.GetString(3); //celda de asignatura
            }
            //MessageBox.Show(id + "");
            res.Close();
            conexion.Close();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            deshabilitarBotonEliminar(); 
        }

        private void deshabilitarBotonEliminar() //lo dice el propio nombre
        {
            if (conTareas <= 1) //en caso de haber una o ninguna tarea para que no salte error al no poderse eliminar ninguna tarea 
            {
                btnEliminarTarea.Enabled = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) //modifica la tarea selecionada a tu gusto (el id no cambia)
        {
            form4 = new Modificar(this);
            guardarInfoID(); //guardo los datos de esa tarea para pasarlos a las herramientas del formulario Modificar
            form4.Show();
            deshabilitarBotonEliminar();
        }

        public void ajustarID() //reasignar a cada tarea ids de forma ordenada y descendente (ejemplo: de 1,5,6,8... pasa a 1,2,3,4...)
        {
            int s=0, u=0, p=0;
            int[] numID = new int[conTareas]; //array para guardar las ids antiguas de cada tarea y usarlo en la comparacion mas adelante
            //MessageBox.Show(conTareas+"");

            contadorTareas(); //recuento tareas

            conexion.Open();
            String consulta = "select identificador from tareas";
            MySqlCommand cmd = new MySqlCommand(consulta, conexion);
            MySqlDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                numID[s] = Int16.Parse(res.GetString(0)); //guardo el id en cada posicion
                s++;
            }
            res.Close();
            conexion.Close();

            //for (int i = 0; i < numID.Length; i++)
            //{
            //    MessageBox.Show(""+numID[i]);
            //}

            conexion.Open();
            while (p<=conTareas) //hasta que p no llega al numero de tareas que hay, hace:
            {
                p++;
                //MessageBox.Show("ANTIGUO: " + numID[u] + ", NUEVO: " + p); //testeo para ver el funcionamiento
                String update = "update tareas set identificador='" + p + "' where identificador='"+numID[u]+"'"; //hago la comparacion y modifico la celda id en orden
                MySqlCommand cmd2 = new MySqlCommand(update, conexion);
                cmd2.ExecuteNonQuery();
                //MessageBox.Show("El numero original " + numID[u] + " ha pasado a ser " + res.GetString(0) + "--------------->" + u);
                u++;
                if (p==numID.Length) //cuando realiza la ultima asignacion id en la tarea, cierro metodo
                {
                    break;
                }
            }
            conexion.Close();
        }
    }
}
