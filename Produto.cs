using System.IO;
using System;
using System.Collections.Generic;

namespace Aula28LerDadosExcel
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float  Preco { get; set; }

        private const string PATH = "DataBase/Produto.csv";
        

        public Produto(){
            //DESAFIO:
            string pasta = PATH.Split("/")[0];
            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }
            //Quer saber se ele não existe
            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }
        /// <summary>
        /// cadastro de produtos
        /// </summary>
        /// <param name="prod">produto</param>
        public void Cadastrar(Produto prod){
              
            //Acrescenta todas as linhas
            var linha = new string[]{PrepararLinha(prod)};
            
            File.AppendAllLines(PATH,linha);
        }

        public List<Produto> Ler()
        {
            //Criamos uma lista que servirá como nosso retorno
            List<Produto> produtos = new List<Produto>();

            // Lemos um arquivo e transformamos em array
            // [0] = codigo=1;nome=Fender;preco=4500f
            // [1] = codigo=1;nome=Gibson;preco=4500f
            string[] linhas = File.ReadAllLines(PATH);

            foreach(string linha in linhas){

                // Separamos os dados de cada linha com Split
                // [0] = codigo=1
                // [1] = nome=Fender
                // [2] = preco=4500
                string[] dado = linha.Split(";");

                //Criamos instâncias de produtos para serem colocadas na lista 
                Produto p   = new Produto();
                p.Codigo    = Int32.Parse( Separar(dado[0]) );
                p.Nome      = Separar( dado[1] );
                p.Preco     = float.Parse( Separar(dado[2]) ); 

                produtos.Add(p);   
            }

            return produtos;
        }

        /// <summary>
        /// Criamos este metodo para separar as colunas 
        /// </summary>
        /// <param name="_coluna"></param>
        /// <returns></returns>
        private string Separar(string _coluna){
            return _coluna.Split("=")[1];
        }

        //1;Celular;600

        private string PrepararLinha(Produto p){
            return $"Código = {p.Codigo}; Nome = {p.Nome}; Preço = {p.Preco}";
        }

        


    }

}