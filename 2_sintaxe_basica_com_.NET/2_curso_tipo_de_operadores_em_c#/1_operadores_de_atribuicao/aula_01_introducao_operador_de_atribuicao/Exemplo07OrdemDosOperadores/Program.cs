/*ORDEM DOS OPERADORES
* Assim como na matemática, no C# os operadores de maior precedência são avaliados primeiro.
* Expressões com parênteses são avaliadas primeiro, seguidas por operadores de exponenciação, multiplicação/divisão, e finalmente, adição/subtração. 
 */

double a = 4 / 2 + 2;
Console.WriteLine($"Valor de a: {a}");

double b = 4 / (2 + 2);
Console.WriteLine($"Valor de b: {b}");