﻿using System;
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
    public partial class FrmInscripcion : Form
    {
        public FrmInscripcion()
        {
            InitializeComponent();
        }

        private void PicInicio_Click(object sender, EventArgs e)
        {

        }

        private void btnNotas_Click(object sender, EventArgs e)
        {

        }

        private void btnCursos_Click(object sender, EventArgs e)
        {

        }

        private void btnAsignacion_Click(object sender, EventArgs e)
        {
            FrmAsignacion nuevoFormulario = new FrmAsignacion  ();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            FrmInscripcion nuevoFormulario = new FrmInscripcion();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            FrmHomeEstudiantes nuevoFormulario = new FrmHomeEstudiantes();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnPensum_Click(object sender, EventArgs e)
        {

        }

        private void PicAsignacion_Click(object sender, EventArgs e)
        {

        }

        private void PicInscripcion_Click(object sender, EventArgs e)
        {

        }

        private void PicCursos_Click(object sender, EventArgs e)
        {

        }

        private void picPensum_Click(object sender, EventArgs e)
        {

        }

        private void PicNotas_Click(object sender, EventArgs e)
        {

        }

        private void PicLogo_Click(object sender, EventArgs e)
        {

        }

        private void PanMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblInscripcion_Click(object sender, EventArgs e)
        {

        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
