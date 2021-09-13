using System;

namespace FilmesSeries
{
  class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();
    static FilmeRepositorio repositorioFilme = new FilmeRepositorio();

    static void Main(string[] args)
    {
        string tipo = ObterEscolhaUsuario();

        while (tipo.ToUpper() != "X")
		{
            if (tipo.ToUpper() == "FILME")
            {
                tipo = FilmesOpcoes();
            }
            else if (tipo.ToUpper() == "SERIE")
            {
                tipo = SeriesOpcoes();
            }
            if(tipo.ToUpper() != "X")
                tipo = ObterEscolhaUsuario();

        }

        Console.WriteLine("Obrigado por utilizar nossos serviços.");
		Console.ReadLine();       
    }

    private static string FilmesOpcoes()
    {
        string opcaoUsuario = ObterOpcaoUsuario2();

        while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarFilmes();
						break;
					case "2":
						InserirFilme();
						break;
					case "3":
						AtualizarFilme();
						break;
					case "4":
						ExcluirFilme();
						break;
					case "5":
						VisualizarFilme();
						break;
					case "C":
						Console.Clear();
						break;
                    case "V":
						opcaoUsuario = "V";
						return opcaoUsuario;
					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario2();
			}
        return opcaoUsuario;
    }
    private static string SeriesOpcoes()
    {
        string opcaoUsuario = ObterOpcaoUsuario1();

        while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;
                    case "V":
						opcaoUsuario = "V";
						return opcaoUsuario;
					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario1();
			}
        return opcaoUsuario;
    }

    
    // Interação usuário
        private static string ObterConfirmacaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("1- Sim");
            Console.WriteLine("2- Não");
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static string ObterEscolhaUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Filmes e Séries a seu dispor!!!");
            Console.WriteLine("Deseja informações sobre Filmes ou Séries: ");

            Console.WriteLine();
            Console.WriteLine("1- Filmes");
            Console.WriteLine("2- Séries");
            Console.WriteLine("X- Sair");
            
            string escolhaUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            string tipo = "";
            switch (escolhaUsuario){
                case "1":
                    tipo = "Filme";
                    break;
                case "2":
                    tipo = "Serie";
                    break;
                case "X":
                    tipo = "x";
                    break;
            }

            return tipo;
            
        }

        private static string ObterOpcaoUsuario1()
        {
            Console.WriteLine();
            Console.WriteLine("Filmes e Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("V- Voltar para tela inicial");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static string ObterOpcaoUsuario2()
        {
            Console.WriteLine();
            Console.WriteLine("Filmes e Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar filmes");
            Console.WriteLine("2- Inserir novo filme");
            Console.WriteLine("3- Atualizar filme");
            Console.WriteLine("4- Excluir filme");
            Console.WriteLine("5- Visualizar filme");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("V- Voltar para tela inicial");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    //Métodos para séries
        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Deseja realmente excluir a série: ");
            string confirmacaoUsuario = ObterConfirmacaoUsuario();
             
            switch (confirmacaoUsuario)
                {
                    case "1":
                        repositorio.Exclui(indiceSerie);
                        Console.WriteLine("Serie excluída");
                        break;
                    case "2":
                        Console.WriteLine("Serie não excluída");
                        break;
                }  
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}
    
    //Métodos para filmes
        private static void ExcluirFilme()
            {
                Console.Write("Digite o id do filme: ");
                int indice = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Deseja realmente excluir o filme: ");
                string confirmacaoUsuario = ObterConfirmacaoUsuario();
                
                switch (confirmacaoUsuario)
                    {
                        case "1":
                            repositorioFilme.Exclui(indice);
                            Console.WriteLine("Filme excluída");
                            break;
                        case "2":
                            Console.WriteLine("Filme não excluída");
                            break;
                    }  
            }
    
        private static void VisualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indice = int.Parse(Console.ReadLine());

			var filme = repositorioFilme.RetornaPorId(indice);

			Console.WriteLine(filme);
		}

         private static void AtualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id:indiceFilme,
                                            genero: (Genero)entradaGenero,
										    titulo: entradaTitulo,
										    ano: entradaAno,
										    descricao: entradaDescricao);
			
			repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
		}

        private static void ListarFilmes()
		{
			Console.WriteLine("Listar filmes");

			var lista = repositorioFilme.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var filme in lista)
			{
                var excluido = filme.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirFilme()
	    {
			Console.WriteLine("Inserir novo filme");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioFilme.Insere(novoFilme);
		}
    }
}

