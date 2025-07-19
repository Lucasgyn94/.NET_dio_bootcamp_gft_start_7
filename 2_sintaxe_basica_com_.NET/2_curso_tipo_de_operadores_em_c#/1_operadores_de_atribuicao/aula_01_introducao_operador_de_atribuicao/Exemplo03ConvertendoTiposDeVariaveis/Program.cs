/*CAST - CASTING */
static void ConverteParaIntComConvert()
{
    int a = Convert.ToInt32("10");
    Console.WriteLine(a);
}

static void ConverteParaIntComParse()
{
    int a = int.Parse("15");
    Console.WriteLine(a);
}

Console.Write($"Valor convertido com Convert = ");
ConverteParaIntComConvert();

Console.Write($"Valor convertido com Parse = ");
ConverteParaIntComParse();
