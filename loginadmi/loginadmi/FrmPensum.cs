using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginadmi
{
    public partial class FrmPensum : Form
    {
        public FrmPensum()
        {
            InitializeComponent();
            CargarPensum();
        }

        private void CargarPensum()
        {
            string sconexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
            {
                try
                {
                    conexion.Open();
                    string sconsulta = @"SELECT 
                                            p.codigoCurso_fk, 
                                            c.nombreCurso, 
                                            p.codigoPreRequisito_fk, 
                                            p.numeroCiclo 
                                       FROM Pensum p
                                       INNER JOIN Curso c ON p.codigoCurso_fk = c.codigoCurso_pk";
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(sconsulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    lstvPensum.DataSource = tabla;

                    lstvPensum.Columns["codigoCurso_fk"].HeaderText = "Código Curso";
                    lstvPensum.Columns["nombreCurso"].HeaderText = "Nombre del Curso";
                    lstvPensum.Columns["codigoPreRequisito_fk"].HeaderText = "Pre Requisito";
                    lstvPensum.Columns["numeroCiclo"].HeaderText = "Ciclo";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el pensum: " + ex.Message);
                }
            }
        }

        private void lstvPensum_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblPensum_Click(object sender, EventArgs e)
        {

        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            FrmNotasEstudiante nuevoFormulario = new FrmNotasEstudiante();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnPensum_Click(object sender, EventArgs e)
        {
            FrmPensum nuevoFormulario = new FrmPensum();
            nuevoFormulario.Show();
            this.Hide();
        }
    }
}
