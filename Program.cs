using System.Collections.Generic;

namespace Aula28LerDadosExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 1;
            p1.Nome = "Epiphone";
            p1.Preco = 3000f;

            p1.Cadastrar(p1);

            List<Produto> lista = new List<Produto>();
            lista = p1.Ler();

            foreach(Produto item in lista)
            {
                System.Console.WriteLine($"R$ {item.Preco} - {item.Nome}");
            }

        }
    }
}
