using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.control;
using Veterinaria.model;
using Veterinaria.view;

namespace Veterinaria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void raçaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRaca frm_raca = new FrmRaca();
            frm_raca.ShowDialog();
        }

        private void sexoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSexo frm_Sexo = new FrmSexo();
            frm_Sexo.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja Sair do sistema?", "SAIR!", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes)
            {


                Close();
            }
        }

        private void tipoAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoAnimal frmTipoAnimal = new FrmTipoAnimal();
            frmTipoAnimal.ShowDialog();
        }
    }
}
