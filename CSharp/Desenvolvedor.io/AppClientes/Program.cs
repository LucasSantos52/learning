using System.Globalization;
using Repositorio;

namespace AppClientes;

class Program
{
    static ClienteRepositorio _clienteRepositorio = new ClienteRepositorio();

    static void Main(string[] args)
    {
        var cultura = new CultureInfo("pt-BR");
        Thread.CurrentThread.CurrentCulture = cultura;
        Thread.CurrentThread.CurrentUICulture = cultura;

        _clienteRepositorio.LerDadosClientes();

        while (true)
        {
            Menu();

            Console.ReadKey();
        }
    }

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("Cadastro de clientes");
        Console.WriteLine("--------------------");
        Console.WriteLine("1 - Cadastrar cliente");
        Console.WriteLine("2 - Exibir clientes");
        Console.WriteLine("3 - Editar cliente");
        Console.WriteLine("4 - Excluir cliente");
        Console.WriteLine("5 - Sair");
        Console.WriteLine("--------------------");

        EscolherOpcao();
    }

    static void EscolherOpcao()
    {
        Console.WriteLine("Escolha uma opção: ");

        var opcao = Console.ReadLine();

        switch (int.Parse(opcao))
        {
            case 1:
                {
                    _clienteRepositorio.CadastrarClientes();
                    Menu();
                    break;
                }
            case 2:
                {
                    _clienteRepositorio.ExibirClientes();
                    Menu();
                    break;
                }
            case 3:
                {
                    _clienteRepositorio.EditarClientes();
                    Menu();
                    break;
                }
            case 4:
                {
                    _clienteRepositorio.ExcluirClientes();
                    Menu();
                    break;
                }
            case 5:
                {
                    _clienteRepositorio.GravarDadosClientes();
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    break;
                }
        }
    }

    
}
