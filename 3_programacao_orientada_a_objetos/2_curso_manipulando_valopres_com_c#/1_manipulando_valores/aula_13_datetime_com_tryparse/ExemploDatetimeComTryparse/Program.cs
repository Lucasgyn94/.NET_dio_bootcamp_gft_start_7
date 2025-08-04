using System.Globalization;

string dataString = "15-12-2025 18:00";


DateTime.TryParseExact(dataString,
                        "dd-MM-yyyy HH:mm",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime data);

Console.WriteLine(data);