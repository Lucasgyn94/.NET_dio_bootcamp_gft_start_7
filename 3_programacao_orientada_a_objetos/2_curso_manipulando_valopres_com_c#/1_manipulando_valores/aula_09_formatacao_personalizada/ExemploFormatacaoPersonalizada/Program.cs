using System.Globalization;

//CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

decimal valorMonetario = 1580M;

Console.WriteLine($"{valorMonetario.ToString("C1")}");
Console.WriteLine($"{valorMonetario.ToString("C2")}");
Console.WriteLine($"{valorMonetario.ToString("C4")}");
Console.WriteLine($"{valorMonetario.ToString("C8")}");