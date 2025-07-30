string entradaUsuario = "";

while (true)
{

    Console.WriteLine("Digite uma opção: ");
    Console.WriteLine("1- Cadastrar Cliente");
    Console.WriteLine("2- Buscar cliente");
    Console.WriteLine("3- Apagar cliente");
    Console.WriteLine("4- encerrar");
    entradaUsuario = Console.ReadLine();

    switch (entradaUsuario)
    {
        case "1":
            Console.WriteLine("Cadastro de clientes");
            break;
        case "2":
            Console.WriteLine("Busca de clientes");
            break;
        case "3":
            Console.WriteLine("Deleção de clientes");
            break;
        case "4":
            Console.WriteLine("Encerramento de programa!");
            Environment.Exit(0);
            break;
        default:

            Console.WriteLine("Escolha uma opção válida entre 1 e 4");
            break;
    }

}
Console.Clear();