using System.Text.Json;

public class GerarArvoreDinamicaComando : BaseArvoreComando, IComando
{
    private const int Multiplicador = 3;

    public No Executar(No? no)
    {
        Console.WriteLine("Digite a quantidade de itens na árvore:");
        var valor = Convert.ToInt32(Console.ReadLine());
        byte[] randomicoBytes = new byte[valor];
        Random random = new();
        random.NextBytes(randomicoBytes);
        foreach (int numero in randomicoBytes)
        {
            no = Adicionar(numero, no);
        }

        Console.WriteLine(JsonSerializer.Serialize(no));

        return no;
    }

}