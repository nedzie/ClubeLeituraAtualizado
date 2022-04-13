
using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixa : RepositorioBase<Caixa>
    {
        public bool EtiquetaJaUtilizada(string etiquetaInformada)
        {
            return registros.Exists(x => x.Etiqueta == etiquetaInformada);
        }
    }
}