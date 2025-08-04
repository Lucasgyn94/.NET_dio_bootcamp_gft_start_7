using System.Globalization;
using System.Linq.Expressions;

string dataString = "15-12-2025 18:00";


bool sucesso = DateTime.TryParseExact(dataString,
                        "dd-MM-yyyy HH:mm",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime data);

if (sucesso)
{
    Console.WriteLine($"Data convertida com sucesso: {data}");
}
else
{
    Console.WriteLine($"Erro ao converter data: {dataString} - não válida!");
}
