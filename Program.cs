// See https://aka.ms/new-console-template for more information


using System;
using System.Linq;
using System.Text.RegularExpressions;

//Eduardo da Silva Ramos
class Program
{
    static void Main()
    {
        string textoCifrado = "Lu0s z q0tm0uƒ€qx ƒ40t ‚uyt (~ 0†w|q~„mPe}q(†ytq(q‚q‚i0…}0uy~…„w0y‚‚m|u†qv„uPeu0q„qy…u0tm0 † (u}0†é‚yqƒ(s ‚u{0u0„i}qxwƒPTqvt 0ri|qƒ0m0sywi‚‚ ƒ(u0sqz qƒ(q0uƒ|‚qxwƒPSqz‚ ƒ0wƒƒ 0lyŠul 0ƒyuP_0ƒqq|0o‚y„qvt 0ë PTuu0ƒuz0yƒƒw0 …u(sxq}i}0tu(‚uƒƒ}‚uy÷ë PPSi€y„qt0Yykyq|PZuƒƒ…z‚uy÷ë";
        string textoDecifrado = DecifrarTexto(textoCifrado);

        textoDecifrado = textoDecifrado.Replace("@", "\n");
        textoDecifrado = SubstituirPalindromos(textoDecifrado);

        Console.WriteLine("conteudo do texto cifrado: ");
        Console.WriteLine(textoCifrado);
        Console.WriteLine("\npalindromos encontrados: ");
        string[] palindromos = EncontrarPalindromos(textoDecifrado);
        if (palindromos.Length > 0)
        {
            Console.WriteLine(string.Join(", ", palindromos));
        }
        else
        {
            Console.WriteLine("nenhum palindromo encontrado.");
        }
        Console.WriteLine("\nnumero de caracteres do texto decifrado: " + textoDecifrado.Length);
        Console.WriteLine("quantidade de palavras no texto decifrado: " + ContarPalavras(textoDecifrado));
        Console.WriteLine("\ntexto decifrado em maiusculo:");
        Console.WriteLine(textoDecifrado.ToUpper());
    }

    static string DecifrarTexto(string textoCifrado)
    {
        char[] textoDecifrado = new char[textoCifrado.Length];

        for (int i = 0; i < textoCifrado.Length; i++)
        {
            char caractereAtual = textoCifrado[i];
            int indice = i + 1;

            int valor = (indice % 5 == 0) ? 8 : 16;
            textoDecifrado[i] = (char)(caractereAtual - valor);
        }

        return new string(textoDecifrado);
    }

    static string[] EncontrarPalindromos(string texto)
    {
        string[] palavras = Regex.Split(texto, @"\W+").Where(p => !string.IsNullOrEmpty(p)).ToArray();
        string[] palindromos = palavras.Where(EhPalindromo).ToArray();
        return palindromos;
    }

    static bool EhPalindromo(string palavra)
    {
        char[] arrayPalavra = palavra.ToCharArray();
        Array.Reverse(arrayPalavra);
        string palavraInvertida = new string(arrayPalavra);

        return palavra.Equals(palavraInvertida, StringComparison.OrdinalIgnoreCase);
    }

    static string SubstituirPalindromos(string texto)
    {
        string[] palindromos = EncontrarPalindromos(texto);

        if (palindromos.Length >= 3)
        {
            texto = texto.Replace(palindromos[0], "gloriosa");
            texto = texto.Replace(palindromos[1], "bondade");
            texto = texto.Replace(palindromos[2], "passam");
        }

        return texto;
    }

    static int ContarPalavras(string texto)
    {
        string[] palavras = Regex.Split(texto, @"\W+").Where(p => !string.IsNullOrEmpty(p)).ToArray();
        return palavras.Length;
    }
}
