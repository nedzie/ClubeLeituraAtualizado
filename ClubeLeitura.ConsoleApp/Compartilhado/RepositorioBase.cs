using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ClubeLeitura.ConsoleApp.Compartilhado
{
    public class RepositorioBase<T> where T : EntidadeBase
    {
        protected readonly List<T> registros;
        protected int contadorNumero;

        public RepositorioBase()
        {
            registros = new List<T>();
        }

        public virtual string Inserir(T entidade)
        {
            entidade.numero = ++contadorNumero;
            //SalvarEmArquivo(entidade);
            registros.Add(entidade);
            return "REGISTRO_VALIDO";
        }

        public void Editar(int numeroSelecionado, T entidade)
        {
            entidade.numero = numeroSelecionado;
            registros.Insert(entidade.numero, entidade); // In
            registros.Remove(registros.Find(x => x.numero == numeroSelecionado));
        }

        public bool Excluir(int numeroSelecionado)
        {
            return registros.Remove(registros.Find(x => x.numero == numeroSelecionado));
        }

        public T SelecionarRegistro(int numeroRegistro)
        {
            return registros.Find(x => x.numero == numeroRegistro);
        }

        public List<T> SelecionarTodos()
        {
            return registros;
        }

        public bool ExisteRegistro(int numeroRegistro)
        {
            return registros.Exists(x => x.numero == numeroRegistro);
        }

        #region Métodos privados
        private static void SalvarEmArquivo(T entidade)
        {
            string caminhoCon = @"C:\Users\marco\Documents\Academia do Programador\Projetos\ClubeLeituraTiago\ClubeLeitura.ConsoleApp\Compartilhado\con.json";
            int con;
            StreamReader sr = new(caminhoCon);
            con = int.Parse(sr.ReadLine());
            sr.Close();
            string JSONresult = JsonConvert.SerializeObject(entidade);
            string caminho = @"C:\Users\marco\Documents\Academia do Programador\Projetos\ClubeLeituraTiago\ClubeLeitura.ConsoleApp\Compartilhado\" + typeof(T).Name + con + ".json";

            if (File.Exists(caminho))
            {
                File.Delete(caminho);
                using (var Z = new StreamWriter(caminho, true))
                {
                    Z.Write(JSONresult.ToString());
                    Z.Close();
                }
            }
            else if (!File.Exists(caminho))
            {
                using (var Z = new StreamWriter(caminho, true))
                {
                    Z.Write(JSONresult.ToString());
                    Z.Close();
                }
            }
            con++;
            string conSerializado = JsonConvert.SerializeObject(con);
            File.Delete(caminhoCon);
            using (var X = new StreamWriter(caminhoCon, true))
            {
                X.Write(conSerializado);
                X.Close();
            }
        }
        #endregion
    }
}