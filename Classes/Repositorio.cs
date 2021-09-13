using System;
using System.Collections.Generic;
using FilmesSeries.Interfaces;

namespace FilmesSeries
{
    public class Repositorio : IRepositorio<Repositorio>
    {
        private List<Repositorio> listaSerie = new List<Repositorio>();
        public void Atualiza(int id, Repositorio entidade)
        {
            throw new NotImplementedException();
        }

        public void Exclui(int id)
        {
            throw new NotImplementedException();
        }

        public void Insere(Repositorio entidade)
        {
            throw new NotImplementedException();
        }

        public List<Repositorio> Lista()
        {
            throw new NotImplementedException();
        }

        public int ProximoId()
        {
            throw new NotImplementedException();
        }

        public Repositorio RetornaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }

}