using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cadastrofilmes.MinhasInterfaces;

namespace Cadastrofilmes
{
    class FilmesRepositorio : IRepositorio<Filme>
    {
        private List<Filme> listaFilme = new List<Filme>();

        public void Atualiza(int id, Filme objeto)
        {
            listaFilme[id] = objeto;
        }

        public void Excluir(int id)
        {
            listaFilme[id].Excluir();
        }

        public void Insere(Filme objeto)
        {
            listaFilme.Add(objeto); // adicionar o objeto a minha lista
        }

        public List<Filme> Lista()
        {
            return listaFilme;
        }

        public int ProximoId()
        {
            return listaFilme.Count;
        }

        public Filme RetornaPorId(int id)
        {
            return listaFilme[id];
        }
    }
}
