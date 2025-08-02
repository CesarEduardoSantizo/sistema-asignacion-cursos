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

namespace loginadmi.Administrador.Cursos
{
    public partial class frmAsignacionLaboratorio : Form
    {
        public frmAsignacionLaboratorio()
        {
            InitializeComponent();
        }

        // ----------------------------------------- Programado por: Anderson Trigueros ----------------------------- //

        private void frmAsignacionLaboratorio_Load(object sender, EventArgs e)
        {
            //Opciones de Semestre
            cboSemestre.Items.Clear();
            cboSemestre.Items.Add("1");
            cboSemestre.Items.Add("2");

            //Opciones de Cursos
            clsCurso curso = new clsCurso();
            var cursos = curso.ObtenerListadoCursos();
            cboCurso.DataSource = cursos;
            cboCurso.DisplayMember = "sNombreCurso";
            cboCurso.ValueMember = "iCodigoCurso";
            cboCurso.SelectedIndex = -1;

            //Opciones de Carreras
            clsCarrera carrera = new clsCarrera();
            var carreras = carrera.ObtenerCarreras();
            cboCarreras.DataSource = carreras;
            cboCarreras.DisplayMember = "sNombreCarrera";
            cboCarreras.ValueMember = "iCodigoCarrera";
            cboCarreras.SelectedIndex = -1;
        }


        private bool EsOpcionValida(ComboBox combo)
        {
            return combo.SelectedIndex != -1;
        }

        private void btnRegistroLaboratorio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboCurso.Text) || string.IsNullOrEmpty(cboCarreras.Text) ||
                string.IsNullOrEmpty(txtSeccion.Text) || string.IsNullOrEmpty(txtDia.Text) ||
                string.IsNullOrEmpty(txtHoraInicio.Text) || string.IsNullOrEmpty(txtHoraSalida.Text) ||
                string.IsNullOrEmpty(txtAño.Text) || string.IsNullOrEmpty(cboSemestre.Text) ||
                string.IsNullOrEmpty(txtPrecio.Text) )
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (!EsOpcionValida(cboCurso) || !EsOpcionValida(cboCarreras))
            {
                MessageBox.Show("Por favor, seleccione una opción válida de las listas.");
                return;
            }
            else
            {
                string conexionBD = ConexionBD.CadenaConexion();
                try
                {
                    using (MySqlConnection conexion = new MySqlConnection(conexionBD))
                    {
                        conexion.Open();
                        string sConsultaInsertar = "INSERT INTO asignacionlaboratorio (codigoCurso_fk, precioLaboratorio, horaInicio, " +
                            "diaLaboratorio, semestreAsignacion, añoAsignacion, codigoCarrera_fk, horaSalida, seccion) " +
                            "VALUES (@codigoCurso, @precio,@horaInicio, @dia, @semestre, @año, @codigoCarrera, @horaSalida, @seccion)";
                        MySqlCommand comando = new MySqlCommand(sConsultaInsertar, conexion);
                        comando.Parameters.AddWithValue("@codigoCurso", cboCurso.SelectedValue);
                        comando.Parameters.AddWithValue("@precio", txtPrecio.Text);
                        comando.Parameters.AddWithValue("@horaInicio", txtHoraInicio.Text);
                        comando.Parameters.AddWithValue("@dia", txtDia.Text);
                        comando.Parameters.AddWithValue("@semestre", cboSemestre.Text);
                        comando.Parameters.AddWithValue("@año", txtAño.Text);
                        comando.Parameters.AddWithValue("@codigoCarrera", cboCarreras.SelectedValue);
                        comando.Parameters.AddWithValue("@horaSalida", txtHoraSalida.Text);
                        comando.Parameters.AddWithValue("@seccion", txtSeccion.Text);
                        comando.ExecuteNonQuery();

                        if (comando.LastInsertedId > 0)
                        {
                            MessageBox.Show("Asignación de laboratorio registrada con éxito");
                            cboCurso.SelectedIndex = -1;
                            cboCarreras.SelectedIndex = -1;
                            txtPrecio.Clear();
                            txtSeccion.Clear();
                            txtHoraInicio.Clear();
                            txtHoraSalida.Clear();
                            txtDia.Clear();
                            cboSemestre.SelectedIndex = -1;
                            txtAño.Clear();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al registrar la asignación de laboratorio: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado: " + ex.Message);
                }
            }
        }

        private void btnListadoLaboratorios_Click(object sender, EventArgs e)
        {
            frmListadoLaboratorio frmListadoLaboratorio = new frmListadoLaboratorio();
            frmListadoLaboratorio.Show();
            this.Hide();
        }
    }
}
