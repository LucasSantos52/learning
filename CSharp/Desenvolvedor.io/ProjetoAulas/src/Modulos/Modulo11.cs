namespace Modulo11;

public class WorkingWithDateTime
{
    public void AulaDateTime()
    {
        var date1 = new DateTime(2024, 12, 02, 10, 09, 05); // criando data e hora no formato yyyy/MM/dd HH:mm:ss
        var date2 = DateTime.Parse("2024/12/02 10:09:05"); // passando data como string
        var date3 = DateTime.Now; // hora atual
        var date4 = DateTime.Today; // apenas a data com horario vazio

        Console.WriteLine(date1);
        Console.WriteLine(date2);
        Console.WriteLine(date3);
        Console.WriteLine(date4);

        Console.WriteLine(date1.ToString("dd-MM-yyyy"));
        Console.WriteLine(date1.ToString("dd-MM-yyyy HH:mm:ss"));

        var dateOffset1 = new DateTimeOffset(DateTime.Now, new TimeSpan(-3, 0, 0));
        Console.WriteLine(dateOffset1.LocalDateTime);
        Console.WriteLine(dateOffset1.UtcDateTime);
    }

    public void SubtraindoData()
    {
        var date1 = DateTime.Now;
        var date2 = DateTime.Parse("2000-10-30");

        var diff = date1 - date2;

        Console.WriteLine(diff.TotalDays);
        Console.WriteLine(diff.TotalHours);
    }

    public void ModificandoDate()
    {
        var date1 = DateTime.Parse("2001-01-20");

        Console.WriteLine("Atual " + date1.ToString("dd/MM/yy"));
        Console.WriteLine("+dia " + date1.AddDays(3).ToString("dd/MM/yy"));
        Console.WriteLine("+mes " + date1.AddMonths(1).ToString("dd/MM/yy"));
        Console.WriteLine("+ano " + date1.AddYears(2).ToString("dd/MM/yy"));
    }

    public void ModificandoHour()
    {
        var hour = DateTime.Parse("2001-01-20 10:30:00");

        Console.WriteLine("Atual " + hour.ToString("HH:mm:ss"));
        Console.WriteLine("+hora " + hour.AddHours(3).ToString("HH:mm:ss"));
        Console.WriteLine("+min " + hour.AddMinutes(1).ToString("HH:mm:ss"));
        Console.WriteLine("+seg " + hour.AddSeconds(2).ToString("HH:mm:ss"));
    }

    public void DiaDaSemana()
    {
        var day = DateTime.Parse("2001-01-20 10:30:00");

        Console.WriteLine(day.DayOfWeek);
    }

    public void ApenasDate()
    {
        // var somenteData = new DateOnly(2001,01,10);
        var somenteData = DateOnly.Parse("2001-01-10");

        Console.WriteLine(somenteData.ToString("dd/MM/yy"));
    }

    public void ApenasHour()
    {
        // var somenteHora = new TimeOnly(07,30,10,0);
        var somenteHora = TimeOnly.Parse("07:30:10");

        Console.WriteLine(somenteHora.ToString("HH:mm:ss"));
    }
}
