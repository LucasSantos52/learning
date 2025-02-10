namespace Modulo10;

public class WorkingWithStrings
{
    public void ToLowerCase()
    {
        Console.Write("to lower case: ");
        string text = Console.ReadLine();
        Console.WriteLine(text.ToLower());
    }

    public void ToUpperCase()
    {
        Console.Write("to Upper case: ");
        string text = Console.ReadLine();
        Console.WriteLine(text.ToUpper());
    }

    public void Substring()
    {
        Console.Write("Substring: ");
        string text = Console.ReadLine();
        Console.WriteLine(text.Substring(0, 6)); // Lucas Santos -> Lucas - do 0 os 6 proximos caracteres
        Console.WriteLine(text.Substring(5, 3)); // Lucas Santos -> Sa - 3 caracteres depois do 5
        Console.WriteLine(text.Substring(6)); // Lucas Santos -> Santos - tudo a partir do 6 caractere
    }

    public void Range()
    {
        string fileName = "2012_12_01_backup.bck";

        string year = fileName[..4];
        Console.WriteLine("ano: " + year);

        string extension = fileName[^3..];
        Console.WriteLine("extensão: " + extension);

        string partial = fileName[11..^4];
        Console.WriteLine("parcial: " + partial);

        string onlyName = fileName[..^4];
        Console.WriteLine("apenas nome: " + onlyName);
    }

    public void Contains()
    {
        string fileName = "2012_12_01_backup.bck";

        Console.WriteLine("buscar por: ");
        var searchText = Console.ReadLine();

        if (fileName.Contains(searchText))
        {
            Console.WriteLine("palavra encontrada");
        }
        else
        {
            Console.WriteLine("palavra não encontrada");
        }
        // Console.WriteLine("Contem: " + fileName.Contains("backup"));
    }
    
    public void Trim()
    {
        string teste = "     **Lucas Santos**     ";
        Console.WriteLine("SemEspaços: " + teste.Trim()); // sem passar parametros remove os espaços em branco no inicio e no final da string
        Console.WriteLine("Total: " + teste.Trim('*')); // remove todos os caracteres passados
        Console.WriteLine("Inicio: " + teste.TrimStart('*')); // remove os caracteres no começo
        Console.WriteLine("Inicio: " + teste.TrimEnd('*')); // remove os caracteres no final
    }

    public void StartWithEndWith()
    {
        string teste = "Curso CSharp";
        Console.WriteLine("start" + teste.StartsWith("Curso")); // true
        Console.WriteLine("end" + teste.EndsWith("CSharp02")); // false
        Console.WriteLine("end" + teste.EndsWith("CSharp")); // true        
    }

    public void Replace()
    {
        string teste = "Curso CSharp";
        Console.WriteLine(teste); // -> Curso CSharp
        Console.WriteLine(teste.Replace("CSharp", "C#")); // -> Curso C#
    }

    public void Length()
    {
        string teste = "Curso CSharp";
        Console.WriteLine(teste); 
        Console.WriteLine(teste.Length); // -> 12
    }

    
}
