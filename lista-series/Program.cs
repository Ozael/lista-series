
SerieRepositorio repositorio = new SerieRepositorio();

string opcaoUsuario = ObterOpcaoUsuario();
while (opcaoUsuario.ToUpper() != "X")
{
  switch (opcaoUsuario)
  {
    case "1":
      ListaSeries();
      break;
    case "2":
      InserirSerie();
      break;
    case "3":
      // AtualizarSerie();
      break;
    case "4":
      // ExcluirSerie();
      break;
    case "5":
      // VisualizarSerie();
      break;
    case "C":
      Console.Clear();
      break;
    default:
      throw new ArgumentOutOfRangeException();

  }
}
System.Console.WriteLine("Obrigado por utilizar nossos serviços");
System.Console.WriteLine();


void ListaSeries()
{
  System.Console.WriteLine("Listar séries");

  var lista = repositorio.Lista();
  if (lista.Count == 0)
  {
    System.Console.WriteLine("Nenhuma série cadastrada.");
    return;
  }
  foreach (var serie in lista)
  {
    System.Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()}");
  }
}

void InserirSerie()
{
  System.Console.WriteLine("Inserir nova série");

  foreach (int i in Enum.GetValues(typeof(Genero)))
  {
    System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
  }
  System.Console.Write("Digite o gênero entre as opções acima: ");
  int entradaGenero = int.Parse(Console.ReadLine());

  System.Console.Write("Digite o Título da Série: ");
  string entradaTitulo = Console.ReadLine();

  System.Console.Write("Digite o Ano de Início da Série: ");
  int entradaAno = int.Parse(Console.ReadLine());

  System.Console.Write("Digite a Descrição da Série: ");
  string entradaDescricao = Console.ReadLine();

  Serie novaSerie = new Serie(id: repositorio.ProximoId(),
  genero: (Genero)entradaGenero,
  titulo: entradaTitulo,
  ano: entradaAno,
  descricao: entradaDescricao);

  repositorio.Insere(novaSerie);
}



static string ObterOpcaoUsuario()
{
  System.Console.WriteLine();
  System.Console.WriteLine("DIO Séries a seu dispor!!!");
  System.Console.WriteLine("Informe a Opção desejada");

  System.Console.WriteLine("1 - Listar séries");
  System.Console.WriteLine("2 - Inserir nova série");
  System.Console.WriteLine("3 - Atualizar série");
  System.Console.WriteLine("4 - Excluir série");
  System.Console.WriteLine("5 - Visualizar série");
  System.Console.WriteLine("C - Limpar Tela");
  System.Console.WriteLine("X - Sair");
  System.Console.WriteLine();

  string opcaoUsuario = Console.ReadLine().ToUpper();
  System.Console.WriteLine();
  return opcaoUsuario;
}