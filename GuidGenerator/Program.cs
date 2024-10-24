﻿using System;

class Program
{
    static void Main(string[] args)
    {
        int numero;
        bool numeroValido;

        do
        {
            Console.WriteLine("Quantidade:");
            string entrada = Console.ReadLine();

            numeroValido = int.TryParse(entrada, out numero);

            if (!numeroValido)
            {
                Console.WriteLine("Valor inválido. Por favor, digite um número.");
            }

        } while (!numeroValido);

        Console.WriteLine("");

        for (int i = 0; i < numero; i++)
        {
            Guid g = Guid.NewGuid();
            Console.WriteLine(g);
        }

        Console.WriteLine("");
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}
