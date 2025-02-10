using Modulo11;
using Modulo12;
using Modulo13;
using Modulo14;

namespace ProjetoAulas
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Alive");
            // WorkingWithStrings();
            // WorkingWithDateTime();
            // WorkingWithExceptions();
            // WorkingWithFiles();
            WorkingWithLinq();
        }

        private static void WorkingWithLinq()
        {
            var linq = new WorkingWithLinq();
            // linq.Where();
            // linq.OrderBy();
            // linq.Take();
            // linq.Count();
            linq.FirstAndFirstOrDefault();
        }

        private static void WorkingWithFiles()
        {
            var files = new WorkingWithFiles();
            // files.CreatingFile();
            // files.ReadingFile();
            files.DeletingFile();
        }

        private static void WorkingWithExceptions()
        {
            var exception = new WorkingWithExceptions();
            // exception.ExceptionGenerate();
            exception.TratandoException();
        }

        private static void WorkingWithDateTime()
        {
            var dateTime = new WorkingWithDateTime();
            // dateTime.AulaDateTime();
            // dateTime.SubtraindoData();
            // dateTime.ModificandoDate();
            // dateTime.ModificandoHour();
            // dateTime.DiaDaSemana();
            // dateTime.ApenasDate();
            dateTime.ApenasHour();
        }

        private static void WorkingWithStrings()
        {
            var working = new Modulo10.WorkingWithStrings();
            // working.ToLowerCase();
            // working.ToUpperCase();
            // working.Substring();
            // working.Range();
            // working.Contains();
            // working.Trim();
            // working.StartWithEndWith();
            // working.Replace();
            working.Length();
        }
    }
}