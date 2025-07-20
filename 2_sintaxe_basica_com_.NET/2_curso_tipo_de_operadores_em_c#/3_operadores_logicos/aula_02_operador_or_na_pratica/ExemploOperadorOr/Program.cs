Console.WriteLine("### VERIFICADOR DE ENTRADA ###");
Console.WriteLine("OBS: Entrada permitida para maiores de 18 anos ou com autorização dos pais");
Console.WriteLine($"Digite a sua idade: ");
string entradaUsuario = Console.ReadLine();

int idade = Convert.ToInt32(entradaUsuario);

bool autorizacaoDosResponsaveis = false;

if (idade <= 0 || idade > 110)
{
    Console.WriteLine("Idade inválida! Digite uma idade entre 1 e 120 anos;");
}
else if (idade >= 18 || autorizacaoDosResponsaveis)
{
    Console.WriteLine("Entrada permitida!");
}
else
{
    Console.WriteLine("Entrada não permitida!");
}

Console.WriteLine("##############################");