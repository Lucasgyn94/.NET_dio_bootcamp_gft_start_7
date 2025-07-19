/* CONVERTENDO DE MANEIRA SEGURA
* Toda vez que tentamos converter um tipo de dado para outro, se a conversão não for possível,
é lançado um erro / exceção e o programa e encerrado. Podemos tratar isso com TryParse.
*/
static void TentativaDeConversaoSemTryParse()
{
    string a = "15-";
    int b = Convert.ToInt32(a);

    Console.WriteLine(b);

}

static void ConversaoComTryParseModelo1()
{
    string a = "15-";
    int b = 0;

    int.TryParse(a, out b);

    Console.WriteLine(b);
Console.WriteLine("Conversão realizada com sucesso!");

}

static void ConversaoComTryParseModelo2()
{
    string a = "15-";

    int.TryParse(a, out int b);

    Console.WriteLine(b);
    Console.WriteLine("Conversão realizada com sucesso!");
    
}



