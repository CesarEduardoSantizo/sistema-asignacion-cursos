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

namespace loginadmi
{
    public partial class agregar_catedratico : Form
    {
        public agregar_catedratico()
        {
            InitializeComponent();
        }

        private void agregar_catedratico_Load(object sender, EventArgs e)
        {

        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            homeadmi nuevoFormulario = new homeadmi();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btn_estudiantes_Click(object sender, EventArgs e)
        {
            agregarestudiante nuevoFormulario = new agregarestudiante();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btn_catedratico_Click(object sender, EventArgs e)
        {
            agregar_catedratico nuevoFormulario = new agregar_catedratico();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            string nombres = txt_nombres.Text.Trim();
            string apellidos = txt_carne.Text.Trim();
            string carne = txt_carne.Text.Trim();
            string telefono = txt_telefono.Text.Trim();
            string correo = txt_correo.Text.Trim();
            string usuario = txt_usuario.Text.Trim();         // Asegúrate de tener este TextBox en el formulario
            string contraseña = txt_contraseña.Text.Trim();   // Asegúrate de tener este TextBox también

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos) ||
                string.IsNullOrWhiteSpace(carne) || string.IsNullOrWhiteSpace(telefono) ||
                string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    // Primero insertamos al catedrático
                    string insertarCatedratico = @"INSERT INTO Catedratico 
                (carnetCatedratico_pk, nombreCatedratico, apellidosCatedratico, telefonoCatedratico, correoCatedratico)
                VALUES (@carnet, @nombres, @apellidos, @telefono, @correo)";

                    MySqlCommand comandoInsertarCatedratico = new MySqlCommand(insertarCatedratico, conexion);
                    comandoInsertarCatedratico.Parameters.AddWithValue("@carnet", carne);
                    comandoInsertarCatedratico.Parameters.AddWithValue("@nombres", nombres);
                    comandoInsertarCatedratico.Parameters.AddWithValue("@apellidos", apellidos);
                    comandoInsertarCatedratico.Parameters.AddWithValue("@telefono", telefono);
                    comandoInsertarCatedratico.Parameters.AddWithValue("@correo", correo);

                    comandoInsertarCatedratico.ExecuteNonQuery();

                    // Luego insertamos al usuario asociado al catedrático
                    string insertarUsuario = @"INSERT INTO Usuario 
                (usuario, contraseña, codigoRolUsuario_fk, carnetCatedratico_fk) 
                VALUES (@usuario, @contraseña, @rol, @carnetCatedratico)";

                    MySqlCommand comandoInsertarUsuario = new MySqlCommand(insertarUsuario, conexion);
                    comandoInsertarUsuario.Parameters.AddWithValue("@usuario", usuario);
                    comandoInsertarUsuario.Parameters.AddWithValue("@contraseña", contraseña);
                    comandoInsertarUsuario.Parameters.AddWithValue("@rol", 2); // Asignar rol 2 para catedrático
                    comandoInsertarUsuario.Parameters.AddWithValue("@carnetCatedratico", carne);

                    comandoInsertarUsuario.ExecuteNonQuery();

                    MessageBox.Show("Catedrático y usuario registrados exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar catedrático: " + ex.Message);
                }
            }
        }

        private void lbl_carrera_Click(object sender, EventArgs e)
        {

        }

        private void txt_nombres_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_agregar_estudiante_Click(object sender, EventArgs e)
        {

        }
        private void btn_listaCatedraticos_Click(object sender, EventArgs e)
        {
            ListaCatedratico nuevoFormulario = new ListaCatedratico();
            nuevoFormulario.Show();
            this.Hide(); // o this.Close(); si quieres cerrarlo
        }
    }
}
