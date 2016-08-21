using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaTeleMensagens
{
    [Serializable]
    class Cliente
    {
        public int ano;
        public int dia;
        public int mes;
        public string nome;
        public string numero;
        public int codCliente;





        public Cliente(int cd,string n, int d, int m, int a, string nu)
        {
            this.codCliente = cd;
            this.ano = a;
            this.dia = d;
            this.mes = m;
            this.nome = n.ToUpper();
            this.numero = nu;
        
        }
    }
}
