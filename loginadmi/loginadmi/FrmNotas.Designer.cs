using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace loginadmi
{
    partial class FrmNotas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        static string fuente = "server = localhost; user= grupoCinco; pwd= U&grupo5_2501.; database=bd_asignacioncursos;";
        MySqlConnection ob = new MySqlConnection(fuente);
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string Codigo_Nota = txtCodigoNotas.Text;
            string Carnet_Estudiante = txtCarnetEstudiante.Text;
            string Codigo_Curso = txtCodigoCurso.Text;
            string Nota_Primer_Parcial = txtNotaPrimerParcial.Text;
            string Nota_SegundoParcial = txtNotaSegundoParcial.Text;
            string Nota_Actividades = txtNotaActividades.Text;
            string Nota_Final_Parcial = txtNotaFinalParcial.Text;

            if (txtCodigoNotas.Text.Equals("") || txtCarnetEstudiante.Text.Equals("") || txtCodigoCurso.Text.Equals("") || txtNotaPrimerParcial.Text.Equals("") || txtNotaSegundoParcial.Text.Equals("") || txtNotaActividades.Text.Equals("") || txtNotaFinalParcial.Text.Equals(""))
            {
                MessageBox.Show("Complete todos los campos");
            }
            else
            {
                string insertar = "INSERT INTO 'Notas' (category Codigo_Nota,Carnet_Estudiante, Codigo_Curso, Nota_Primer_Parcia, Nota_SegundoParcial, Nota_Actividades, Nota_Final_Parcial) VALUES ('" + txtCodigoCurso.Text + "','" + txtCarnetEstudiante.Text + "','" + txtCodigoCurso.Text + "','" + txtNotaPrimerParcial.Text + "','" + txtNotaSegundoParcial.Text + "','" + txtNotaActividades.Text + "','" + txtNotaFinalParcial.Text + "')";
                MySqlCommand cmd = new MySqlCommand(insertar, ob);

                try
                {
                    ob.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Datos agregados con exito");

                    ob.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Se ha producido un error contacte a soporte");
                }

                // actualizacion en tiempo real
                string comando = "select * from Notas";
                MySqlCommand ejecuta = new MySqlCommand(comando, ob);
                MySqlDataAdapter con = new MySqlDataAdapter(ejecuta);

                ds = new DataSet();
                con.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        public DataSet ds { get; set; }

        private void buttonEli_click(object sender, EventArgs e)
        {
            if (txtCodigoNotas.Text.Equals(""))
            {
                MessageBox.Show("Ingrese codigo de nota");
            }
            else
            {
                ob.Open();
                string CodigoNota_pk = txtCodigoNotas.Text;
                string query = ("delete from Notas where CodigoNota_pk = " + txtCodigoNotas.Text);
                MySqlCommand cmd = new MySqlCommand(query, ob);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Exito en la operacion");
                ob.Close() ;

                //Actualizacion en tiempo real
                String comando = "select * from Notas";
                MySqlCommand ejecuta = new MySqlCommand(comando,ob);
                MySqlDataAdapter con = new MySqlDataAdapter(ejecuta);

                ds = new DataSet();
                con.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
        private void buttonMod_Click(object sender, EventArgs e)
        {

            string query = "update Notas set carnetEstudiante_fk=" + txtCarnetEstudiante.Text + " where CodigoNota_pk=" + txtCodigoNotas.Text.ToString() + "";

            MySqlCommand cmd = new MySqlCommand( query, ob);

            ob.Open() ;
                cmd.ExecuteNonQuery() ;
            MessageBox.Show("Registro Actualizado");

            //Actualizacion en Tiempo Real

            string comando = "select * from Notas";
            MySqlCommand ejecuta = new MySqlCommand (comando,ob);
            MySqlDataAdapter con = new MySqlDataAdapter (ejecuta);

            ds = new DataSet();
            con.Fill(ds);
            dataGridView1.DataSource=ds.Tables[0];
        }

                #region Windows Form Designer generated code

                /// <summary>
                /// Required method for Designer support - do not modify
                /// the contents of this method with the code editor.
                /// </summary>
                private void InitializeComponent()
                {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotas));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_Lista_estudiantes = new System.Windows.Forms.Label();
            this.btn_catedratico = new System.Windows.Forms.Button();
            this.btn_estudiantes = new System.Windows.Forms.Button();
            this.btn_inicio = new System.Windows.Forms.Button();
            this.pnl_home = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtNotaFinalParcial = new System.Windows.Forms.TextBox();
            this.txtNotaActividades = new System.Windows.Forms.TextBox();
            this.txtNotaSegundoParcial = new System.Windows.Forms.TextBox();
            this.txtNotaPrimerParcial = new System.Windows.Forms.TextBox();
            this.lblNotaFinalParcial = new System.Windows.Forms.Label();
            this.lblNotaActividades = new System.Windows.Forms.Label();
            this.lblSegundoParcial = new System.Windows.Forms.Label();
            this.lblNotaprimerParcial = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.list_estudiantes = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCodigoCurso = new System.Windows.Forms.TextBox();
            this.txtCodigoNotas = new System.Windows.Forms.TextBox();
            this.lblCodigoCurso = new System.Windows.Forms.Label();
            this.lblCodigoNotas = new System.Windows.Forms.Label();
            this.lblCarnetEstudiante = new System.Windows.Forms.Label();
            this.txtCarnetEstudiante = new System.Windows.Forms.TextBox();
            this.btn_cursos = new System.Windows.Forms.Button();
            this.btn = new System.Windows.Forms.Button();
            this.btn_lab = new System.Windows.Forms.Button();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.pnl_home.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.list_estudiantes)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.panel2.Controls.Add(this.lbl_Lista_estudiantes);
            this.panel2.Location = new System.Drawing.Point(241, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1072, 94);
            this.panel2.TabIndex = 62;
            // 
            // lbl_Lista_estudiantes
            // 
            this.lbl_Lista_estudiantes.AutoSize = true;
            this.lbl_Lista_estudiantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Lista_estudiantes.ForeColor = System.Drawing.Color.White;
            this.lbl_Lista_estudiantes.Location = new System.Drawing.Point(173, 14);
            this.lbl_Lista_estudiantes.Name = "lbl_Lista_estudiantes";
            this.lbl_Lista_estudiantes.Size = new System.Drawing.Size(191, 69);
            this.lbl_Lista_estudiantes.TabIndex = 0;
            this.lbl_Lista_estudiantes.Text = "Notas";
            this.lbl_Lista_estudiantes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_catedratico
            // 
            this.btn_catedratico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btn_catedratico.ForeColor = System.Drawing.Color.White;
            this.btn_catedratico.Location = new System.Drawing.Point(91, 366);
            this.btn_catedratico.Margin = new System.Windows.Forms.Padding(4);
            this.btn_catedratico.Name = "btn_catedratico";
            this.btn_catedratico.Size = new System.Drawing.Size(111, 34);
            this.btn_catedratico.TabIndex = 72;
            this.btn_catedratico.Text = "Catedratico";
            this.btn_catedratico.UseVisualStyleBackColor = false;
            this.btn_catedratico.Click += new System.EventHandler(this.btn_catedratico_Click);
            // 
            // btn_estudiantes
            // 
            this.btn_estudiantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btn_estudiantes.ForeColor = System.Drawing.Color.White;
            this.btn_estudiantes.Location = new System.Drawing.Point(91, 286);
            this.btn_estudiantes.Margin = new System.Windows.Forms.Padding(4);
            this.btn_estudiantes.Name = "btn_estudiantes";
            this.btn_estudiantes.Size = new System.Drawing.Size(111, 34);
            this.btn_estudiantes.TabIndex = 71;
            this.btn_estudiantes.Text = "Estudiante";
            this.btn_estudiantes.UseVisualStyleBackColor = false;
            this.btn_estudiantes.Click += new System.EventHandler(this.btn_estudiantes_Click);
            // 
            // btn_inicio
            // 
            this.btn_inicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btn_inicio.ForeColor = System.Drawing.Color.White;
            this.btn_inicio.Location = new System.Drawing.Point(91, 209);
            this.btn_inicio.Margin = new System.Windows.Forms.Padding(4);
            this.btn_inicio.Name = "btn_inicio";
            this.btn_inicio.Size = new System.Drawing.Size(111, 34);
            this.btn_inicio.TabIndex = 70;
            this.btn_inicio.Text = "Inicio";
            this.btn_inicio.UseVisualStyleBackColor = false;
            this.btn_inicio.Click += new System.EventHandler(this.btn_inicio_Click);
            // 
            // pnl_home
            // 
            this.pnl_home.BackColor = System.Drawing.Color.White;
            this.pnl_home.Controls.Add(this.dataGridView1);
            this.pnl_home.Controls.Add(this.txtNotaFinalParcial);
            this.pnl_home.Controls.Add(this.txtNotaActividades);
            this.pnl_home.Controls.Add(this.txtNotaSegundoParcial);
            this.pnl_home.Controls.Add(this.txtNotaPrimerParcial);
            this.pnl_home.Controls.Add(this.lblNotaFinalParcial);
            this.pnl_home.Controls.Add(this.lblNotaActividades);
            this.pnl_home.Controls.Add(this.lblSegundoParcial);
            this.pnl_home.Controls.Add(this.lblNotaprimerParcial);
            this.pnl_home.Controls.Add(this.btnModificar);
            this.pnl_home.Controls.Add(this.btnEliminar);
            this.pnl_home.Controls.Add(this.btnInsertar);
            this.pnl_home.Controls.Add(this.list_estudiantes);
            this.pnl_home.Controls.Add(this.panel1);
            this.pnl_home.Location = new System.Drawing.Point(241, -2);
            this.pnl_home.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_home.Name = "pnl_home";
            this.pnl_home.Size = new System.Drawing.Size(1072, 788);
            this.pnl_home.TabIndex = 64;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(124, 321);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(791, 239);
            this.dataGridView1.TabIndex = 57;
            // 
            // txtNotaFinalParcial
            // 
            this.txtNotaFinalParcial.Location = new System.Drawing.Point(756, 232);
            this.txtNotaFinalParcial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.txtNotaFinalParcial.Multiline = true;
            this.txtNotaFinalParcial.Name = "txtNotaFinalParcial";
            this.txtNotaFinalParcial.Size = new System.Drawing.Size(190, 42);
            this.txtNotaFinalParcial.TabIndex = 56;
            // 
            // txtNotaActividades
            // 
            this.txtNotaActividades.Location = new System.Drawing.Point(545, 232);
            this.txtNotaActividades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.txtNotaActividades.Multiline = true;
            this.txtNotaActividades.Name = "txtNotaActividades";
            this.txtNotaActividades.Size = new System.Drawing.Size(190, 42);
            this.txtNotaActividades.TabIndex = 55;
            // 
            // txtNotaSegundoParcial
            // 
            this.txtNotaSegundoParcial.Location = new System.Drawing.Point(326, 232);
            this.txtNotaSegundoParcial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.txtNotaSegundoParcial.Multiline = true;
            this.txtNotaSegundoParcial.Name = "txtNotaSegundoParcial";
            this.txtNotaSegundoParcial.Size = new System.Drawing.Size(190, 42);
            this.txtNotaSegundoParcial.TabIndex = 54;
            // 
            // txtNotaPrimerParcial
            // 
            this.txtNotaPrimerParcial.Location = new System.Drawing.Point(107, 232);
            this.txtNotaPrimerParcial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.txtNotaPrimerParcial.Multiline = true;
            this.txtNotaPrimerParcial.Name = "txtNotaPrimerParcial";
            this.txtNotaPrimerParcial.Size = new System.Drawing.Size(190, 42);
            this.txtNotaPrimerParcial.TabIndex = 53;
            // 
            // lblNotaFinalParcial
            // 
            this.lblNotaFinalParcial.AutoSize = true;
            this.lblNotaFinalParcial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotaFinalParcial.Location = new System.Drawing.Point(751, 192);
            this.lblNotaFinalParcial.Name = "lblNotaFinalParcial";
            this.lblNotaFinalParcial.Size = new System.Drawing.Size(164, 25);
            this.lblNotaFinalParcial.TabIndex = 52;
            this.lblNotaFinalParcial.Text = "Nota Final Parcial";
            // 
            // lblNotaActividades
            // 
            this.lblNotaActividades.AutoSize = true;
            this.lblNotaActividades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotaActividades.Location = new System.Drawing.Point(540, 192);
            this.lblNotaActividades.Name = "lblNotaActividades";
            this.lblNotaActividades.Size = new System.Drawing.Size(159, 25);
            this.lblNotaActividades.TabIndex = 51;
            this.lblNotaActividades.Text = "Nota Actividades";
            // 
            // lblSegundoParcial
            // 
            this.lblSegundoParcial.AutoSize = true;
            this.lblSegundoParcial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSegundoParcial.Location = new System.Drawing.Point(321, 192);
            this.lblSegundoParcial.Name = "lblSegundoParcial";
            this.lblSegundoParcial.Size = new System.Drawing.Size(155, 25);
            this.lblSegundoParcial.TabIndex = 50;
            this.lblSegundoParcial.Text = "Nota 2do Parcial";
            // 
            // lblNotaprimerParcial
            // 
            this.lblNotaprimerParcial.AutoSize = true;
            this.lblNotaprimerParcial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotaprimerParcial.Location = new System.Drawing.Point(102, 192);
            this.lblNotaprimerParcial.Name = "lblNotaprimerParcial";
            this.lblNotaprimerParcial.Size = new System.Drawing.Size(150, 25);
            this.lblNotaprimerParcial.TabIndex = 49;
            this.lblNotaprimerParcial.Text = "Nota 1er Parcial";
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Location = new System.Drawing.Point(729, 702);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(250, 60);
            this.btnModificar.TabIndex = 48;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(399, 702);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(250, 60);
            this.btnEliminar.TabIndex = 47;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btnInsertar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.btnInsertar.ForeColor = System.Drawing.Color.White;
            this.btnInsertar.Location = new System.Drawing.Point(76, 702);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(250, 60);
            this.btnInsertar.TabIndex = 46;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = false;
            this.btnInsertar.Click += new System.EventHandler(this.button1_Click);
            // 
            // list_estudiantes
            // 
            this.list_estudiantes.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.list_estudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list_estudiantes.Location = new System.Drawing.Point(76, 160);
            this.list_estudiantes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.list_estudiantes.Name = "list_estudiantes";
            this.list_estudiantes.RowHeadersWidth = 51;
            this.list_estudiantes.RowTemplate.Height = 24;
            this.list_estudiantes.Size = new System.Drawing.Size(903, 430);
            this.list_estudiantes.TabIndex = 45;
            this.list_estudiantes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.list_estudiantes_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.txtCodigoCurso);
            this.panel1.Controls.Add(this.txtCodigoNotas);
            this.panel1.Controls.Add(this.lblCodigoCurso);
            this.panel1.Controls.Add(this.lblCodigoNotas);
            this.panel1.Controls.Add(this.lblCarnetEstudiante);
            this.panel1.Controls.Add(this.txtCarnetEstudiante);
            this.panel1.Location = new System.Drawing.Point(76, 601);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 82);
            this.panel1.TabIndex = 42;
            // 
            // txtCodigoCurso
            // 
            this.txtCodigoCurso.Location = new System.Drawing.Point(598, 36);
            this.txtCodigoCurso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.txtCodigoCurso.Multiline = true;
            this.txtCodigoCurso.Name = "txtCodigoCurso";
            this.txtCodigoCurso.Size = new System.Drawing.Size(289, 42);
            this.txtCodigoCurso.TabIndex = 50;
            // 
            // txtCodigoNotas
            // 
            this.txtCodigoNotas.Location = new System.Drawing.Point(8, 36);
            this.txtCodigoNotas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.txtCodigoNotas.Multiline = true;
            this.txtCodigoNotas.Name = "txtCodigoNotas";
            this.txtCodigoNotas.Size = new System.Drawing.Size(289, 42);
            this.txtCodigoNotas.TabIndex = 49;
            // 
            // lblCodigoCurso
            // 
            this.lblCodigoCurso.AutoSize = true;
            this.lblCodigoCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoCurso.Location = new System.Drawing.Point(593, 9);
            this.lblCodigoCurso.Name = "lblCodigoCurso";
            this.lblCodigoCurso.Size = new System.Drawing.Size(133, 25);
            this.lblCodigoCurso.TabIndex = 36;
            this.lblCodigoCurso.Text = "Codigo Curso";
            // 
            // lblCodigoNotas
            // 
            this.lblCodigoNotas.AutoSize = true;
            this.lblCodigoNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoNotas.Location = new System.Drawing.Point(3, 9);
            this.lblCodigoNotas.Name = "lblCodigoNotas";
            this.lblCodigoNotas.Size = new System.Drawing.Size(131, 25);
            this.lblCodigoNotas.TabIndex = 35;
            this.lblCodigoNotas.Text = "Codigo Notas";
            this.lblCodigoNotas.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblCarnetEstudiante
            // 
            this.lblCarnetEstudiante.AutoSize = true;
            this.lblCarnetEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarnetEstudiante.Location = new System.Drawing.Point(298, 9);
            this.lblCarnetEstudiante.Name = "lblCarnetEstudiante";
            this.lblCarnetEstudiante.Size = new System.Drawing.Size(168, 25);
            this.lblCarnetEstudiante.TabIndex = 34;
            this.lblCarnetEstudiante.Text = "Carnet Estudiante";
            // 
            // txtCarnetEstudiante
            // 
            this.txtCarnetEstudiante.Location = new System.Drawing.Point(303, 36);
            this.txtCarnetEstudiante.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.txtCarnetEstudiante.Multiline = true;
            this.txtCarnetEstudiante.Name = "txtCarnetEstudiante";
            this.txtCarnetEstudiante.Size = new System.Drawing.Size(289, 42);
            this.txtCarnetEstudiante.TabIndex = 32;
            this.txtCarnetEstudiante.TextChanged += new System.EventHandler(this.txt_nocarnetestudiante_TextChanged);
            // 
            // btn_cursos
            // 
            this.btn_cursos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btn_cursos.ForeColor = System.Drawing.Color.White;
            this.btn_cursos.Location = new System.Drawing.Point(91, 662);
            this.btn_cursos.Margin = new System.Windows.Forms.Padding(4);
            this.btn_cursos.Name = "btn_cursos";
            this.btn_cursos.Size = new System.Drawing.Size(111, 34);
            this.btn_cursos.TabIndex = 78;
            this.btn_cursos.Text = "Cursos";
            this.btn_cursos.UseVisualStyleBackColor = false;
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btn.ForeColor = System.Drawing.Color.White;
            this.btn.Location = new System.Drawing.Point(91, 554);
            this.btn.Margin = new System.Windows.Forms.Padding(4);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(111, 34);
            this.btn.TabIndex = 77;
            this.btn.Text = "Notas";
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_lab
            // 
            this.btn_lab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.btn_lab.ForeColor = System.Drawing.Color.White;
            this.btn_lab.Location = new System.Drawing.Point(91, 461);
            this.btn_lab.Margin = new System.Windows.Forms.Padding(4);
            this.btn_lab.Name = "btn_lab";
            this.btn_lab.Size = new System.Drawing.Size(111, 34);
            this.btn_lab.TabIndex = 74;
            this.btn_lab.Text = "Labotorios";
            this.btn_lab.UseVisualStyleBackColor = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(-1, 547);
            this.pictureBox12.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(73, 62);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 76;
            this.pictureBox12.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
            this.pictureBox11.Location = new System.Drawing.Point(-1, 650);
            this.pictureBox11.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(73, 62);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 75;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
            this.pictureBox13.Location = new System.Drawing.Point(-1, 444);
            this.pictureBox13.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(73, 62);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox13.TabIndex = 69;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(-1, 352);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(73, 62);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 67;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(-1, 190);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(73, 62);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 66;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-1, 270);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(73, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 65;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // FrmNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(7)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1312, 783);
            this.Controls.Add(this.btn_cursos);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.btn_lab);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_catedratico);
            this.Controls.Add(this.btn_estudiantes);
            this.Controls.Add(this.btn_inicio);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnl_home);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FrmNotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListaEstudiantes";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnl_home.ResumeLayout(false);
            this.pnl_home.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.list_estudiantes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

                }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_Lista_estudiantes;
        private System.Windows.Forms.Button btn_catedratico;
        private System.Windows.Forms.Button btn_estudiantes;
        private System.Windows.Forms.Button btn_inicio;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnl_home;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCarnetEstudiante;
        private System.Windows.Forms.TextBox txtCarnetEstudiante;
        private System.Windows.Forms.DataGridView list_estudiantes;
        private System.Windows.Forms.Button btn_cursos;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Button btn_lab;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.TextBox txtCodigoCurso;
        private System.Windows.Forms.TextBox txtCodigoNotas;
        private System.Windows.Forms.Label lblCodigoCurso;
        private System.Windows.Forms.Label lblCodigoNotas;
        private System.Windows.Forms.TextBox txtNotaFinalParcial;
        private System.Windows.Forms.TextBox txtNotaActividades;
        private System.Windows.Forms.TextBox txtNotaSegundoParcial;
        private System.Windows.Forms.TextBox txtNotaPrimerParcial;
        private System.Windows.Forms.Label lblNotaFinalParcial;
        private System.Windows.Forms.Label lblNotaActividades;
        private System.Windows.Forms.Label lblSegundoParcial;
        private System.Windows.Forms.Label lblNotaprimerParcial;
        private DataGridView dataGridView1;
    }
}