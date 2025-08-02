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
    public partial class FrmNotasEstudiante : Form
    {
        public FrmNotasEstudiante()
        {
            InitializeComponent();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            FrmHomeEstudiantes nuevoFormulario = new FrmHomeEstudiantes();
            nuevoFormulario.Show();
            this.Hide();
        }
    }
}
