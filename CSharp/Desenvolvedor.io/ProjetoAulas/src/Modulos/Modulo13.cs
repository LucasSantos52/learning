namespace Modulo13;

public class WorkingWithFiles
{
    public void CreatingFile()
    {
        var escrever = new StreamWriter("Cadastro.txt", true);
        Console.WriteLine("Informe um nome: ");
        var nome = Console.ReadLine();
        escrever.WriteLine("ID...: " + Random.Shared.Next(1, 100));
        escrever.WriteLine("Nome.: " + nome);
        escrever.WriteLine("------------------------");
        escrever.Close();
    }

    public void ReadingFile()
    {
        // var conteudo = File.ReadAllText("Cadastro.txt");

        // Console.WriteLine(conteudo); // ler tudo

        var lerLinhaPorLinha = new StreamReader("Cadastro.txt");
        while (!lerLinhaPorLinha.EndOfStream)
        {
            var linha = lerLinhaPorLinha.ReadLine();
            Console.WriteLine(linha);
        }

        lerLinhaPorLinha.Close();
    }

    public void DeletingFile()
    {
        if (File.Exists("Cadastro.txt"))
        {
            File.Delete("Cadastro.txt");
        }
    }
}