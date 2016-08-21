using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaTeleMensagens
{
   

    public partial class Princ : Form
    {
        public Princ()
        {
            InitializeComponent();
            Principal.carregar();
            dadosIniciais();
        }
        public void dadosIniciais()
        {
            DateTime data;
            data = DateTime.Now;
            int dia = data.Day;
            int mes = data.Month;



            for (int i = 0; i < Principal.cntCliente; i++)
            {


                if (Principal.cliente[i] != null)
                {
                                           
                            if (Principal.cliente[i].mes == mes &&Principal.cliente[i].dia==dia)
                            {

                                dataGridView1.Rows.Add(Principal.cliente[i].codCliente, Principal.cliente[i].nome, Principal.cliente[i].dia + "/" + Principal.cliente[i].mes + "/" + Principal.cliente[i].ano, Principal.cliente[i].numero);

                            }
                        

                       
                }



            }








        }
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Cadastro cd = new Cadastro();
            cd.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Listar ls = new Listar();
            ls.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja mesmo sair?", "Atenção!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                
                Application.Exit();
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este software foi desenvolvio por Gleidson Viana, todos os direitos reservados. \nContato: \n www.youtube.com/tecnotera \n canaltecnotera@gmail.com\n www.canaltecnotera.blogspot.com", "Controle de Aniversariantes v.1.00");
        }

        private void Princ_Load(object sender, EventArgs e)
        {
            linkLabel1.Links.Add(0, 29, "http://www.youtube.com/tecnotera");
            linkLabel2.Links.Add(0, 32, "http://canaltecnotera.blogspot.com");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
              DialogResult dialogResult = MessageBox.Show("Deseja mesmo sair?", "Atenção!", MessageBoxButtons.YesNo);
              if (dialogResult == DialogResult.Yes)
              {

                  Application.Exit();
              }
        }
    }


}
