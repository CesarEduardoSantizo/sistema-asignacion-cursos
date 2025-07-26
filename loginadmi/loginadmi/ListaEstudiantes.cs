﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace loginadmi
{
    public partial class ListaEstudiantes : Form
    {
        public ListaEstudiantes()
        {
            InitializeComponent();
            CargarEstudiantes();
        }

        private void CargarEstudiantes()
        {
            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT nombreEstudiante, apellidosEstudiante, carnetEstudiante_pk, codigoCarrera_fk, correoEstudiante, telefonoEstudiante FROM estudiante";
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    list_estudiantes.DataSource = tabla;

                    // Cambiar los títulos de las columnas
                    list_estudiantes.Columns["nombreEstudiante"].HeaderText = "Nombres";
                    list_estudiantes.Columns["apellidosEstudiante"].HeaderText = "Apellidos";
                    list_estudiantes.Columns["carnetEstudiante_pk"].HeaderText = "Carné";
                    list_estudiantes.Columns["codigoCarrera_fk"].HeaderText = "Carrera";
                    list_estudiantes.Columns["correoEstudiante"].HeaderText = "Correo";
                    list_estudiantes.Columns["telefonoEstudiante"].HeaderText = "Teléfono";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los estudiantes: " + ex.Message);
                }
            }
        }

        private void list_estudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_nocarnetestudiante_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_eliminarEstudiantes_Click(object sender, EventArgs e)
        {
            string carnet = txt_nocarnetestudiante.Text.Trim();

            if (string.IsNullOrEmpty(carnet))
            {
                MessageBox.Show("Por favor ingresa el número de carné.");
                return;
            }

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    string eliminacionUser = "DELETE FROM usuario WHERE carnetEstudiante_fk = @carnet";
                    MySqlCommand comandoUser = new MySqlCommand(eliminacionUser, conexion);
                    comandoUser.Parameters.AddWithValue("@carnet", carnet);
                    comandoUser.ExecuteNonQuery();

                    string consulta = "DELETE FROM estudiante WHERE carnetEstudiante_pk = @carnet";
                    MySqlCommand comandoEstudiante = new MySqlCommand(consulta, conexion);
                    comandoEstudiante.Parameters.AddWithValue("@carnet", carnet);
                    int filasAfectadas = comandoEstudiante.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Estudiante eliminado correctamente.");
                        CargarEstudiantes();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un estudiante con ese carné.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el estudiante: " + ex.Message);
                }
            }
        }
    }
}
