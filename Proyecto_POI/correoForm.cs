﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_POI
{
    public partial class correoForm : Form
    {
        public correoForm()
        {
            InitializeComponent();
        }

        private void aceptarBtn_Click(object sender, EventArgs e)
        {
            mainForm newForm = new mainForm();
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }

        private void salirBtn_Click(object sender, EventArgs e)
        {
            mainForm newForm = new mainForm();
            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }
    }
}
