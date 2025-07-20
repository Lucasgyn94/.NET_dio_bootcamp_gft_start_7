/* CAST IMPLÍCITO 
* Conversão de diferentes tipos onde não precisamos utilizar a Conversão (Convert, Parse), pois a mesma e feita automaticamente.
*/
static void ConvertIntParaDouble()
{
    int a = 10;
    double b = a;

    Console.WriteLine(b);

}

static void ConversaoNaoPossivelLongParaInt()
{

    long a = long.MaxValue;
    int b = Convert.ToInt32(a);

    Console.WriteLine(b);
}

//ConversaoNaoPossivelLongParaInt(); /*Essa conversão não é possivel por o valor e muito grande ou muito pequeno para um Int32. E nesse caso o nosso valor long.Maxvalue e muito grande para o Int32 */

static void ConvertIntParaLong()
{
    int a = int.MaxValue;
    long b = a;
    Console.WriteLine(a);
}

ConvertIntParaLong();