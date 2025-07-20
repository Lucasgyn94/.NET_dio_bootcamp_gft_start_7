Console.WriteLine("### VERIFICADOR DE VOGAIS ###");
Console.WriteLine("Digite uma letra para verificar se é uma vogal: ");
string entradaUsuario = Console.ReadLine();
string letra = entradaUsuario.Trim().ToLower().Substring(0, 1);

Console.WriteLine($"Letra digitada: {letra}");

switch (letra)
{
    case "a":
    case "e":
    case "i":
    case "o":
    case "u":
        Console.WriteLine($"A letra '{letra}' é uma vogal");
        break;

    default:
        Console.WriteLine($"A letra '{letra}' não é uma vogal");
        break;
}


Console.WriteLine("############ FIM ############");
