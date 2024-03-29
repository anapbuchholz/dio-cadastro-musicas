﻿using System;

namespace DIO.Musicas
{
    class Program
    {
        static MusicaRepositorio repositorio = new MusicaRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

				while (opcaoUsuario.ToUpper() != "X")
				{
					switch (opcaoUsuario)
					{
						case "1":
							ListarMusicas();
							break;
						case "2":
							InserirMusica();
							break;
						case "3":
							AtualizarMusica();
							break;
						case "4":
							ExcluirMusica();
							break;
						case "5":
							VisualizarMusica();
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

        private static void ExcluirMusica()
		{
			Console.Write("Digite o id da Música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceMusica);
		}

        private static void VisualizarMusica()
		{
			Console.Write("Digite o id da Música: ");
			int indiceMusica = int.Parse(Console.ReadLine());

			var Musica = repositorio.RetornaPorId(indiceMusica);

			Console.WriteLine(Musica);
		}

        private static void AtualizarMusica()
		{
			Console.Write("Digite o id da Música: ");
			int indiceMusica = int.Parse(Console.ReadLine());


			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Música: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Música: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Música: ");
			string entradaDescricao = Console.ReadLine();

			Musica atualizaMusica = new Musica (id: indiceMusica, 
																					genero: (Genero)entradaGenero, 
																					titulo: entradaTitulo, 
																					ano: entradaAno, 
																					descricao: entradaDescricao);

			repositorio.Atualiza(indiceMusica, atualizaMusica);
		}
        private static void ListarMusicas()
		{
			Console.WriteLine("Listar Músicas");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma música cadastrada.");
				return;
			}

			foreach (var Musica in lista) 
			{
                var excluido = Musica.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Musica.retornaId(), Musica.retornanomeMusica(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirMusica()
		{
			Console.WriteLine("Inserir nova Música");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Música: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Música: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Música: ");
			string entradaDescricao = Console.ReadLine();

			Musica novaMusica = new Musica(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaMusica);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Músicas a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Músicas");
			Console.WriteLine("2- Inserir nova Música");
			Console.WriteLine("3- Atualizar Música");
			Console.WriteLine("4- Excluir Música");
			Console.WriteLine("5- Visualizar Música");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
