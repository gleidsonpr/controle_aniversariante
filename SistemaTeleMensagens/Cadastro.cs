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
    public partial class Cadastro : Form
    {
        
        public Cadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (textBox1.Text != "" && textBox2.Text != "")

            {
                string[] a = maskedTextBox1.Text.Split('-');

                if ((int.Parse(a[0]) > 0 && int.Parse(a[0]) < 32) && (int.Parse(a[1]) > 0 && int.Parse(a[1]) < 13) && int.Parse(a[2]) > 1900)
                {
                    Principal.cliente[Principal.cntCliente] = new Cliente(Principal.cdCliente, textBox1.Text, int.Parse(a[0]), int.Parse(a[1]), int.Parse(a[2]), textBox2.Text);

                    Principal.cntClienteAtual++;
                    Principal.cntCliente++;
                    MessageBox.Show("Cadastro efetuado com sucesso", "Aviso");
                    Principal.gravar();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    maskedTextBox1.Text="01-01-1900";
                    
                    
                }
                else
                {
                    MessageBox.Show("A data inserida não é valida", "Aviso");
                }
            
            }
            else
            {
                MessageBox.Show("Você deve inserir todos os dados","Aviso");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
