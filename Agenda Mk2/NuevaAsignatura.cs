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
    public partial class NuevaAsignatura : Form
    {
        Principal form1; 

        public NuevaAsignatura(Principal p) //referencia al form Principal
        {
            InitializeComponent();
            form1 = p;
        }

        private void btnAnyadirAsignatura_Click(object sender, EventArgs e)
        {
            if (tbAnyadirAsignatura.Text == "") //condicion la cual tienes que rellenar el textbox para continuar
            {
                MessageBox.Show("Tienes que rellenar el campo");
            }
            else
            {
                form1.cbAsignaturas.Items.Add(tbAnyadirAsignatura.Text); //la informacion del textbox pasa al form Principal y se añade al combobox
                Close();
            }
        }
    }
}
