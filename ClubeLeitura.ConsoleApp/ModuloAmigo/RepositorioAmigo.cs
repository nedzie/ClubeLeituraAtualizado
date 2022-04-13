using ClubeLeitura.ConsoleApp.Compartilhado;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo : RepositorioBase<Amigo>
    {
        public RepositorioAmigo()
        {
        }

        public List<Amigo> SelecionarAmigosComMulta()
        {
            return registros.FindAll(x => x.TemMultaEmAberto() == true);
        }
    }
}