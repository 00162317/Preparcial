﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Preparcial.Controlador;
using Preparcial.Modelo;
using Preparcial.Vista;

namespace Preparcial
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile("../../Recursos/UCA.png");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

            PoblarControlers();
        }

        private void PoblarControlers()
        {
            cmbUser.DataSource = null;
            cmbUser.ValueMember = "Contrasena";
            cmbUser.DisplayMember = "NombreUsuario";
            cmbUser.DataSource = ControladorUsuario.GetUsuarios();
        }

        private void BttnLogin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(cmbUser.SelectedValue.ToString()))
            {
                FrmMain frmMain = new FrmMain((Usuario)cmbUser.SelectedItem);
                Hide();
                frmMain.Show();
            }
            else
                MessageBox.Show("Contrasena incorrecta");
        }

        private void BttnUpdatePassword_Click(object sender, EventArgs e)
        {
            FrmPassword frmPassword = new FrmPassword(cmbUser.DataSource, cmbUser.DisplayMember, cmbUser.ValueMember);
            frmPassword.Show();
        }
    }
}
