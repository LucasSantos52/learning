namespace Modulo14;

public class WorkingWithLinq
{
    public void Where()
    {
        // string nomeCompleto = "Lucas Santos";

        // Func<char, bool> filtro = r => r == 'a';

        // var resultado = nomeCompleto.Where(filtro); // sintaxe de método
        // var resultado = nomeCompleto.Where(r => r == 'a'); // sintaxe de método

        // var resultado = from r in nomeCompleto where r == 'a' select r; // sintaxe de consulta

        // foreach (var letra in resultado)
        // {
        //     Console.WriteLine(letra);
        // }

        var numeros = new int[] { 10, 6, 5, 50, 15, 2 };
        var resultados = numeros.Where(n => n >= 10);

        foreach (var resultado in resultados)
        {
            Console.WriteLine(resultado);
        }
    }

    public void OrderBy()
    {
        var numeros = new int[] { 10, 6, 5, 50, 15, 2 };
        // var resultados = numeros.OrderBy(p => p); // order crescente

        var nomes = new string[] { "Lucas", "Andre", "Santos" };
        var resultados = nomes.OrderByDescending(p => p); // ordernação descendente

        foreach (var resultado in resultados)
        {
            Console.WriteLine(resultado);
        }
    }

    public void Take()
    {
        var numeros = new int[] { 10, 6, 5, 50, 15, 2 };

        var resultados = numeros.Take(3);
        var resultadosOrdernados = numeros.Take(3).OrderBy(p => p);
        var resultadosOrdernadosFiltrado = numeros.Where(p => p > 10).Take(3).OrderBy(p => p);

        Console.WriteLine("Take 3----------------------");
        foreach (var resultado in resultados)
        {
            Console.Write(resultado + " ");
        }
        Console.WriteLine("");
        Console.WriteLine("Take 3 + OrderBy asc----------------------");
        foreach (var resultado in resultadosOrdernados)
        {
            Console.Write(resultado + " ");
        }

        Console.WriteLine("");
        Console.WriteLine("Where > 10 + Take 3 + OrderBy asc----------------------");
        foreach (var resultado in resultadosOrdernadosFiltrado)
        {
            Console.Write(resultado + " ");
        }
    }

    public void Count()
    {
        var numeros = new int[] { 10, 6, 5, 50, 15, 2 };

        var resultado = numeros.Count(); // conta a quantidade
        var resultado2 = numeros.Count(p => p >= 10); // conta a quantidade com filtro

        Console.WriteLine("total: " + resultado);
        Console.WriteLine(">= 10: " + resultado2);
    }

    public void FirstAndFirstOrDefault()
    {
        // First
        // var numeros = new int[] { 10, 6, 5, 50, 15, 2 };
        // var resultado = numeros.First(); // primeiro encontrado
        // var resultado2 = numeros.First(p => p > 15); // primeiro com filtro
        /*
            existem 2 possíveis exceções
            
            -> não existe numero maior que 50
                var numeros = new int[] { 10, 6, 5, 50, 15, 2 };
                var resultado3 = numeros.First(p => p > 100); 

            -> não existe nada no array
                var numeros = new int[] { };
                var resultado3 = numeros.First(); 
        */
        // Console.WriteLine("First: " + resultado);

     
     
        // FirstOrDefault
        var numeros = new int[] { 10, 6, 5, 50, 15, 2 };
        var resultado = numeros.FirstOrDefault(); // retorna o primeiro ou o valor padrão do tipo -> 10
        var resultado2 = numeros.FirstOrDefault(p => p > 100); // retorna o valor padrão do tipo -> 0
        var resultado3 = numeros.FirstOrDefault(p => p > 100, -1); // retorna o valor padrão que foi passado como segundo argumento -> -1

        var numeros2 = new int[] { };
        var resultado4 = numeros2.FirstOrDefault(); // retorna o valor padrão do tipo -> 0
        
        // FirstOrDefault não gera exceção, caso nada seja encontrado retorna o valor padrão do tipo informado
        Console.WriteLine("FirstOrDefault: " + resultado);
    }
}