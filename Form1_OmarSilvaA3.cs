using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Coppel
{
    public partial class Form1 : Form
    {
        private CoppelDataSet datos;

        private CoppelDataSetTableAdapters.centroTrabajoTableAdapter centroTrabajoTA;
        private CoppelDataSetTableAdapters.DirectivoTableAdapter DirectivoTA;
        private CoppelDataSetTableAdapters.EmpleadoTableAdapter EmpleadoTA;
        private CoppelDataSetTableAdapters.PuestosTableAdapter PuestosTA;

        public Form1()
        {
            InitializeComponent();
            datos = new CoppelDataSet();
            centroTrabajoTA = new CoppelDataSetTableAdapters.centroTrabajoTableAdapter();
            DirectivoTA = new CoppelDataSetTableAdapters.DirectivoTableAdapter();
            EmpleadoTA = new CoppelDataSetTableAdapters.EmpleadoTableAdapter();
            PuestosTA = new CoppelDataSetTableAdapters.PuestosTableAdapter();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //OmarSilva_A3
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //Llenar Las tablas de la base de datos
                centroTrabajoTA.Fill(datos.centroTrabajo);
                DirectivoTA.Fill(datos.Directivo);
                EmpleadoTA.Fill(datos.Empleado);
                PuestosTA.Fill(datos.Puestos);

                //Enlazar los DataGridView con los DataTable
                dgvcentroTrabajo.DataSource = datos.centroTrabajo;
                dgvDirectivo.DataSource = datos.Directivo;
                dgvEmpleado.DataSource = datos.Empleado;
                dgvPuestos.DataSource = datos.Puestos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los datos desde la base de datos:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );


            }

        }
    }
}
