using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace SistemaTeleMensagens
{
    public partial class Listar : Form
    {
        public Listar()
        {
            InitializeComponent();


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pesquisar();

          
        }

        private void Pesquisar()
        {
            string nomeDigitado = "";
            int menor;
            bool nomeConfere = true;
            dataGridView1.Rows.Clear();
            StreamWriter sw = new StreamWriter(@"rel.txt", false);
            sw.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            sw.WriteLine("+  Software desenvolvido por Gleidson Viana      +");
            sw.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            sw.WriteLine();
            sw.WriteLine();
            sw.WriteLine();
            for (int i = 0; i < Principal.cntCliente; i++)
            {


                if (Principal.cliente[i] != null)
                {

                    if (checkBox2.Checked)
                    {
                        if (textBox2.Text != "")
                        {
                            nomeDigitado = textBox2.Text.ToUpper();//coloca em caixa alta o texto

                            nomeConfere = true;

                            if (nomeDigitado.Length < Principal.cliente[i].nome.Length)
                            { menor = nomeDigitado.Length; }
                            else
                            { menor = Principal.cliente[i].nome.Length; }

                            for (int j = 0; j < menor; j++)
                            {
                                if (Principal.cliente[i].nome[j] != nomeDigitado[j])
                                {
                                    nomeConfere = false;
                                }
                            }

                            if (nomeConfere)
                            {
                                dataGridView1.Rows.Add(Principal.cliente[i].codCliente, Principal.cliente[i].nome, Principal.cliente[i].dia + "/" + Principal.cliente[i].mes + "/" + Principal.cliente[i].ano, Principal.cliente[i].numero);

                                sw.WriteLine(" Cód: " + Principal.cliente[i].codCliente + " Nome: " + Principal.cliente[i].nome + " Data: " + Principal.cliente[i].dia + "/" + Principal.cliente[i].mes + "/" + Principal.cliente[i].ano + " Núm: " + Principal.cliente[i].numero);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Você não digitou o nome", "Atenção!");
                            break;
                        }
                    }

                    else//se optou por buscar pelo nome não faz essas outras comparaçoes abaixo



                        if (checkBox1.Checked)
                        {
                            if (Principal.cliente[i].mes == (comboBox2.SelectedIndex + 1) && Principal.cliente[i].dia == numericUpDown1.Value)
                            {

                                dataGridView1.Rows.Add(Principal.cliente[i].codCliente, Principal.cliente[i].nome, Principal.cliente[i].dia + "/" + Principal.cliente[i].mes + "/" + Principal.cliente[i].ano, Principal.cliente[i].numero);

                                sw.WriteLine(" Cód: " + Principal.cliente[i].codCliente + " Nome: " + Principal.cliente[i].nome + " Data: " + Principal.cliente[i].dia + "/" + Principal.cliente[i].mes + "/" + Principal.cliente[i].ano + " Núm: " + Principal.cliente[i].numero);
                            }
                        }

                        else
                        {
                            if (Principal.cliente[i].mes == (comboBox2.SelectedIndex + 1))
                            {

                                dataGridView1.Rows.Add(Principal.cliente[i].codCliente, Principal.cliente[i].nome, Principal.cliente[i].dia + "/" + Principal.cliente[i].mes + "/" + Principal.cliente[i].ano, Principal.cliente[i].numero);
                                sw.WriteLine(" Cód: " + Principal.cliente[i].codCliente + " Nome: " + Principal.cliente[i].nome + " Data: " + Principal.cliente[i].dia + "/" + Principal.cliente[i].mes + "/" + Principal.cliente[i].ano + " Núm: " + Principal.cliente[i].numero);

                            }

                        }
                }



            }
            button2.Enabled = true;
            sw.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"rel.txt");//somente para abrir o arquivo de txt de nome "rel" que esta na pasta do programa e assim o cliente pode imprimir
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                for (int i = 0; i < Principal.cntCliente; i++)
                {
                    if (int.Parse(textBox1.Text) == Principal.cliente[i].codCliente)
                    {

                        DialogResult dialogResult = MessageBox.Show("Deseja mesmo excluir este contato?", "Atenção!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Principal.cliente[i] = null;
                            Principal.cntClienteAtual--;
                            Principal.gravar();
                            MessageBox.Show("Contato removido com suceso", "Aviso");
                            textBox1.Text = "";
                            Pesquisar();
                            return;
                            
                        }
                        else
                        {
                            MessageBox.Show("O contato não foi removido", "Aviso");
                            return;
                        }
                                                
                        }

                    
                }
                MessageBox.Show("Não foi encontrado o cliente", "Aviso");
                textBox1.Text = "";
            }
                
            else
            {
                MessageBox.Show("Insira corretamente o código do cliente", "Aviso");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if( numericUpDown1.Enabled ==true)
            numericUpDown1.Enabled = false;
            else
                numericUpDown1.Enabled = true;
            if (checkBox1.Checked)
            { checkBox2.Checked = false; }
            
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
           
            if(checkBox2.Checked)
            { checkBox1.Checked = false; }

            if (textBox2.Enabled == true)
                textBox2.Enabled = false;
            else
                textBox2.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
