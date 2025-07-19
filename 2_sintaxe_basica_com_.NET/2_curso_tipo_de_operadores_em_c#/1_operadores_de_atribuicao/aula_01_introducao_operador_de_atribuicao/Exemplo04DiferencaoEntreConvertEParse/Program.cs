/*DIFERENÇA ENTRE CONVERT E PARSE
* A principal diferença e que o Convert Aceita valores nulos, enquanto o Parse não aceita e encerra nosso programa.
 */
int a = Convert.ToInt32(null);
Console.WriteLine(a);

int b = int.Parse(null);
Console.WriteLine(b);