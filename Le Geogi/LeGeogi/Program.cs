namespace LeGeogi.Classes
{
    class Program
    {
        static RefeicaoRepositorio repositorio = new RefeicaoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarRefeicao();
                        break;

                    case "2":
                        InserirRefeicao();
                        break;

                    case "3":
                        AtualizarRefeicao();
                        break;

                    case "4":
                        ExcluirRefeicao();
                        break;
                    
                    case "5":
                        VisualizarRefeicao();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }
        
        //Método para excluir Refeição
        private static void ExcluirRefeicao()
        {
            Console.WriteLine("-----------------------------");
            Console.Write("Digite o id da refeição: ");
            Console.WriteLine();
            int indiceRefeicao = int.Parse(Console.ReadLine()!);

            repositorio.Exclui(indiceRefeicao);
        }

        //Método para listar Refeições
        private static void ListarRefeicao()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Listar refeições");
            Console.WriteLine();

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma refeição cadastrada.");
                return;
            }

            foreach (var refeicao in lista)
            {
                var excluido = refeicao.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", refeicao.retornaId(), refeicao.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        //Método para visualizar uma determinada Refeição
        private static void VisualizarRefeicao()
        {
            Console.WriteLine("-----------------------------");
            Console.Write("Digite o id da refeição: ");
            Console.WriteLine();
            int indiceRefeicao = int.Parse(Console.ReadLine()!);

            var refeicao = repositorio.RetornaPorId(indiceRefeicao);

            Console.WriteLine("-----------------------------");
            Console.WriteLine(refeicao);
        }

        //Método para atulaizar uma determinada Refeição
        private static void AtualizarRefeicao()
        {
            Console.WriteLine("-----------------------------");
            Console.Write("Digite o id da refeição: ");
            Console.WriteLine();
            int indiceRefeicao = int.Parse(Console.ReadLine()!);

            foreach ( int i in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Categoria), i));
            }

            Console.Write("Digite a categoria entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine()!);

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine()!;

            Console.Write("Digite o Preço da Refeição: ");
            double entradaPreco = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine()!;

            Refeicao atualizaRefeicao = new Refeicao(id: indiceRefeicao, categoria: (Categoria)entradaGenero, titulo: entradaTitulo, preco: entradaPreco, descricao: entradaDescricao);
            repositorio.Atualiza(indiceRefeicao, atualizaRefeicao);
        }

        //Método para inserir uma Refeição
        private static void InserirRefeicao()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Inserir nova refeição");
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Categoria), i));
            }
            
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            Console.WriteLine("Digite a categoria entre as opções acima: ");
            int entradaCategoria = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Digite o Título da refeição: ");
            string entradaTitulo = Console.ReadLine()!;

            Console.WriteLine("Digite o Preço da Refeição: ");
            double entradaPreco = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Digite a Descrição da Refeição: ");
            string entradaDescricao = Console.ReadLine()!;

            Refeicao novaRefeicao = new Refeicao(id: repositorio.ProximoId(), categoria: (Categoria)entradaCategoria, titulo: entradaTitulo, preco: entradaPreco, descricao: entradaDescricao);
            repositorio.Insere(novaRefeicao);
        }

        //Método para a escolha de opções
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("LeGeogi a seu dispor!!!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine();
            Console.WriteLine("1- Listar refeições");
            Console.WriteLine("2- Inserir nova refeição");
            Console.WriteLine("3- Atualizar refeição");
            Console.WriteLine("4- Excluir refeição");
            Console.WriteLine("5- Visualizar refeição");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
            

            string opcaoUsuario = Console.ReadLine()!.ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}


