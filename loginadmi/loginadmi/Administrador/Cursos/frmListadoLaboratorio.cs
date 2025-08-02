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
    public partial class frmListadoLaboratorio : Form
    {
        public frmListadoLaboratorio()
        {
            InitializeComponent();
        }

        //Listas para almacenar datos originales de los laboratorios ingresados en la base
        List<string> sListaDatosSeccion = new List<string>();
        List<string> sListaDatosHoraInicio = new List<string>();
        List<string> sListaDatosHoraSalida = new List<string>();
        List<string> sListaDatosDias = new List<string>();
        List<string> sListaDatosPrecios = new List<string>();
        List<int> iListaCodigoAsignaciones = new List<int>();


        private bool eliminarAsignacion(int codigoAsignacion)
        {
            string conexionBD = ConexionBD.CadenaConexion();
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionBD))
                {
                    conexion.Open();
                    string sEliminacion = "DELETE FROM asignacionlaboratorio WHERE codigoAsignacionLaboratorio_pk = @codigoAsignacion";
                    MySqlCommand comando = new MySqlCommand(sEliminacion, conexion);
                    comando.Parameters.AddWithValue("@codigoAsignacion", codigoAsignacion);
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        private void dgvLaboratorios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void cargarLaboratorios()
        {
            sListaDatosSeccion.Clear();
            sListaDatosHoraInicio.Clear();
            sListaDatosHoraSalida.Clear();

            string sConexionBD = ConexionBD.CadenaConexion();
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(sConexionBD))
                {
                    conexion.Open();
                    string sSeleccionCursos = @"SELECT al.codigoAsignacionLaboratorio_pk AS codigoAsignacion, 
                                                        al.codigocurso_fk AS codigoCurso, 
                                                        c.nombreCurso AS Curso, 
                                                        al.seccion AS Seccion, 
                                                        al.horaInicio AS horaInicio, 
                                                        al.horaSalida AS horaSalida,
                                                        al.diaLaboratorio AS Dia,
                                                        al.precioLaboratorio AS Precio
                                                FROM asignacionlaboratorio al 
                                                JOIN Curso c ON al.codigoCurso_fk = c.codigoCurso_pk 
                                                JOIN Carrera cr ON al.codigoCarrera_fk = cr.codigoCarrera_pk 
                                                WHERE al.añoAsignacion = @año 
                                                    AND al.semestreAsignacion = @semestre 
                                                    AND cr.nombreCarrera = @nombreCarrera";
                    MySqlCommand comando = new MySqlCommand(sSeleccionCursos, conexion);
                    comando.Parameters.AddWithValue("@año", txtAño.Text);
                    comando.Parameters.AddWithValue("@semestre", txtSemestre.Text);
                    comando.Parameters.AddWithValue("@nombreCarrera", txtCarrera.Text);
                    MySqlDataReader resultado = comando.ExecuteReader();
                    DataTable tabla = new DataTable();
                    tabla.Columns.Add("Código");
                    tabla.Columns.Add("Curso");
                    tabla.Columns.Add("Sección");
                    tabla.Columns.Add("Hora Inicio");
                    tabla.Columns.Add("Hora Salida");
                    tabla.Columns.Add("Día Asignado");
                    tabla.Columns.Add("Precio");

                    while (resultado.Read())
                    {
                        string sCodigo = resultado["codigoCurso"].ToString();
                        string sCurso = resultado["Curso"].ToString();
                        string sSeccion = resultado["Seccion"].ToString();
                        string sHoraInicio = resultado["horaInicio"].ToString();
                        string sHoraSalida = resultado["horaSalida"].ToString();
                        string sDia = resultado["Dia"].ToString();
                        string sPrecio = resultado["Precio"].ToString();

                        tabla.Rows.Add(sCodigo, sCurso, sSeccion, sHoraInicio, sHoraSalida, sDia, sPrecio);
                        
                        iListaCodigoAsignaciones.Add(Convert.ToInt32(resultado["codigoAsignacion"]));
                        sListaDatosSeccion.Add(sSeccion);
                        sListaDatosHoraInicio.Add(sHoraInicio);
                        sListaDatosHoraSalida.Add(sHoraSalida);
                        sListaDatosDias.Add(sDia);
                        sListaDatosPrecios.Add(sPrecio);

                    }
                    if (tabla.Rows.Count > 0)
                    {
                        dgvLaboratorios.DataSource = tabla;
                        if (!dgvLaboratorios.Columns.Contains("btnEliminar"))
                        {
                            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                            btnEliminar.HeaderText = "Eliminar";
                            btnEliminar.Text = "Eliminar";
                            btnEliminar.Name = "btnEliminar";
                            btnEliminar.UseColumnTextForButtonValue = true;
                            dgvLaboratorios.Columns.Add(btnEliminar);
                        }
                        if (!dgvLaboratorios.Columns.Contains("btnModificar"))
                        {
                            DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
                            btnModificar.HeaderText = "Modificar";
                            btnModificar.Text = "Modificar";
                            btnModificar.Name = "btnModificar";
                            btnModificar.UseColumnTextForButtonValue = true;
                            dgvLaboratorios.Columns.Add(btnModificar);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron cursos con los datos proporcionados");
                    }
                    dgvLaboratorios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvLaboratorios.Columns["Curso"].ReadOnly = true;
                    dgvLaboratorios.Columns["Código"].ReadOnly = true;

                    dgvLaboratorios.Columns["Código"].FillWeight = 50;
                    dgvLaboratorios.Columns["Sección"].FillWeight = 55;
                    dgvLaboratorios.Columns["btnEliminar"].FillWeight = 70;
                    dgvLaboratorios.Columns["btnModificar"].FillWeight = 70;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los cursos: " + ex.Message);
            }
        }

        private void btnMostrarLaboratorios_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAño.Text) || string.IsNullOrEmpty(txtSemestre.Text) || string.IsNullOrEmpty(txtCarrera.Text))
            {
                MessageBox.Show("Complete todos los campos para mostrar los laboratorios.");
                return;
            }
            else
            {
                cargarLaboratorios();
            }

        }
    }
}
