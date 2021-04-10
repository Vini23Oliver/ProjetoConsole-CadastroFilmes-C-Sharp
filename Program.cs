using System;

namespace Cadastrofilmes
{
    class Program
    {
        static FilmesRepositorio repositorio = new FilmesRepositorio();
        static void Main(string[] args)
        {
            Apresentação();

            do
            {
                Console.Clear();
                int A = Convert.ToInt32(ObterOpçãoUsuario());
                switch (A)
                {
                    case 1:
                        InserirFilme();
                        break;

                    case 2:
                        ListarFilme();
                        Console.ReadKey();
                        break;

                    case 3:
                        excluirFilme();
                        break;

                    case 4:
                        atualizarfilme();
                        break;

                    case 5:
                        vizualizarfilme();
                        break;

                    case 6:
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

            } while (testLoop() != "X");


        }


        // Criação dos metodos do Switch...Case.
        
        
        private static void InserirFilme()
        {
             
            Console.WriteLine("Inserir novo filme");
            Console.WriteLine();

                do
                {
                    Console.Clear();
                    foreach (int n in Enum.GetValues(typeof(Categorias)))
                    {
                        Console.WriteLine("{0}-{1}", n, Enum.GetName(typeof(Categorias), n));
                    }

                    Console.WriteLine("Digite o numero da categoria do filme: ");
                    int CategoriaFilme = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("Digite o nome do Filme: ");
                    string NomeFilme = Console.ReadLine();

                    Console.Clear();
                    Console.WriteLine("Digite o ano de inicio do filme: ");
                    int AnoFilme = int.Parse(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("Digite a descriçaõ do Filme: ");
                    string DescriçãoFilme = Console.ReadLine();

                    Filme lancaFilme = new Filme(id: repositorio.ProximoId(),
                                                 categoria: (Categorias)CategoriaFilme,
                                                 nome: NomeFilme,
                                                 descrição: DescriçãoFilme,
                                                 ano: AnoFilme);

                    repositorio.Insere(lancaFilme);


                } while (Pergunta() != 0) ;
        }

         private static void ListarFilme()
         {
            Console.WriteLine("Listar Filmes");
            Console.WriteLine();

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine(" Nenhum filme cadastrado!! ");
            }
            else
            {
                foreach (var filme in lista)
                {
                    Console.WriteLine("#ID {0}: - {1}", filme.retornaId(), filme.retornarNome());
                }
            }


         }

        private static void excluirFilme()
        {
            Console.WriteLine(" Digite o ID do filme: ");
            int IDFilme = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nDESEJA MESMO EXCLUIR O FILME? [S] OU [N]: ");
            string resp = Console.ReadLine().ToUpper();
            
            //int resp = Convert.ToInt32(Console.ReadLine().ToUpper());

            if (resp == "S")
            {
                repositorio.Excluir(IDFilme);
            }
            else
            {
                Console.Write("\nAperte ENTER para voltar ao menu principal: ");
                Console.ReadKey();
            }


        }

        private static void atualizarfilme()
        {
            Console.WriteLine("Digite o ID do filme: ");
            int indiceFilme = Convert.ToInt32(Console.ReadLine ());

            Console.Clear();
            foreach (int n in Enum.GetValues(typeof(Categorias)))
            {
                Console.WriteLine("{0}-{1}", n, Enum.GetName(typeof(Categorias), n));
            }

            Console.WriteLine("Digite o numero da categoria do filme: ");
            int CategoriaFilme = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Digite o nome do Filme: ");
            string NomeFilme = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Digite o ano de inicio do filme: ");
            int AnoFilme = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Digite a descriçaõ do Filme: ");
            string DescriçãoFilme = Console.ReadLine();

            Filme AtualizaFilme = new Filme(id: indiceFilme,
                                         categoria: (Categorias)CategoriaFilme,
                                         nome: NomeFilme,
                                         descrição: DescriçãoFilme,
                                         ano: AnoFilme);

            repositorio.Atualiza(indiceFilme, AtualizaFilme);

        }
        
        private static void vizualizarfilme()
        {
            Console.WriteLine("Digite o ID do Filme: ");
            int IDfilme = Convert.ToInt32(Console.ReadLine());

            var filme = repositorio.RetornaPorId(IDfilme);

            Console.WriteLine(filme);
        }
            
        

        // criação dos metodos de ajuda (Secundarios para melhorar a performance do codigo)

        private static string ObterOpçãoUsuario()
        {
            Console.WriteLine();            
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Inserir Filme");
            Console.WriteLine("2 - Listar Filme");
            Console.WriteLine("3 - Excluir Filme");
            Console.WriteLine("4 - Atualizar Filme");
            Console.WriteLine("5 - Visualizar Filme");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("X - sair");

            string opçãoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opçãoUsuario;

        }

        private static void Apresentação()
        {
            Console.WriteLine();
            Console.WriteLine("\t\tBem vindo a DIO Filmes!!!");
            Console.WriteLine();
            
        }

        private static int Pergunta()
        {

          Console.WriteLine("\nDigite 1 para inserir um filme ou 0 para continuar: ");
          int i = Convert.ToInt32(Console.ReadLine());
          return i; 
        }

        private static string testLoop()
        {
            Console.Write("\n\n\t\tDeseja retornar ao menu principal? [S] - sim ou [X] - finalizar programa: ");
            string resp = Console.ReadLine().ToUpper();

            if (resp == "X")
            {
                Console.WriteLine("\n\n\t\t\t\t\t\t\tOBRIGADO");
            }
            return resp;
        }
    }
}
