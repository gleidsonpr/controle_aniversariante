using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SistemaTeleMensagens
{
    class Principal
    {
        public static int cntCliente = 0;
        public static int cdCliente = 100;
        public static int cntClienteAtual = 0;
        public static Cliente[] cliente = new Cliente[20000];

        public static void carregar()
        {

            //inicio do deserializamento
            using (Stream input = File.OpenRead("base.dat"))
            {

                BinaryFormatter bf = new BinaryFormatter();
                cntCliente = (int)bf.Deserialize(input);//primeiro item é a quantidade de pesoas cadastradas

                cntClienteAtual = cntCliente;

                for (int i = 0; i < cntCliente; i++)
                {
                    cliente[i] = (Cliente)bf.Deserialize(input);
                    cdCliente++;
                }


            }




        }
        public static void gravar()
        {


            using (Stream output = File.Create("base.dat"))
            {


                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(output, cntClienteAtual);//grava quantos clientes tem no momento, mas percorre todos que tinha antes como pode ver abaixo 
                for (int i = 0; i < cntCliente; i++)
                {
                    if (cliente[i] != null)
                    {

                        bf.Serialize(output, cliente[i]);



                    }
                }


            }


            carregar();//carrega novamente os arquivos, caso tenha adcionado ou excluido algum
        }

    }
}
