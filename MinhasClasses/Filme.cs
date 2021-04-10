using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastrofilmes
{
    class Filme : EntidadeBase
    {

        // atributos
        private Categorias Categoria { get; set; }
        private string Descrição { get; set; }
        private string Nome { get; set; }
        private int Ano { get; set;}
        private bool Excluido { get; set; }


        // Metodos

        public Filme (int id, Categorias categoria, string nome, string descrição, int ano) // contador = medodo principal que recebe o mesmo nome que a classe
        {
            this.Categoria = categoria;
            this.Nome = nome;
            this.Descrição = descrição;
            this.Ano = ano;
            this.Excluido = false;
        }

        public string retornarNome() // metodo que me retorna o nome do filme recebido no parametro do meu contador
        {
            return this.Nome;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public override string ToString() // converte o objeto para string sobrescrevendo da maneira colocada no metodo
        {
            string retorno = "";
            retorno += "Genero: " + this.Categoria  + Environment.NewLine; // Environment.NewLine obtem uma nova linha definida para esta string
            retorno += "Titulo: " + this.Nome + Environment.NewLine; // Environment.NewLine obtem uma nova linha definida para esta string
            retorno += "Descrição: " + this.Descrição + Environment.NewLine; // Environment.NewLine obtem uma nova linha definida para esta string
            retorno += "Ano de inicio: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }
    }
}
