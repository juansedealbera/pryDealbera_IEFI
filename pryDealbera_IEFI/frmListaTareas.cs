﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryDealbera_IEFI
{
    public partial class frmListaTareas : Form
    {
        public frmListaTareas()
        {
            InitializeComponent();
        }

        clsConexionBD conexion = new clsConexionBD();

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            conexion.ListarBD(dgvGrilla);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
