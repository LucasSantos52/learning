namespace Modulo12;

public class WorkingWithExceptions()
{
    public void ExceptionGenerate()
    {
        while (true)
        {
            Console.WriteLine("informe um numero: ");
            var numeroInformado = Console.ReadLine();
            var resultado = 500 / int.Parse(numeroInformado);
            Console.WriteLine("Resultado: " + resultado);
        }
    }

    public void TratandoException()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("informe um numero: ");
                var numeroInformado = Console.ReadLine();
                var resultado = 500 / int.Parse(numeroInformado);
                Console.WriteLine("Resultado: " + resultado);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Erro -> " + e.Message);
                Console.WriteLine("StackTrace -> " + e.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro -> " + e.Message);
                Console.WriteLine("StackTrace -> " + e.StackTrace);
            }
        }
    }
}