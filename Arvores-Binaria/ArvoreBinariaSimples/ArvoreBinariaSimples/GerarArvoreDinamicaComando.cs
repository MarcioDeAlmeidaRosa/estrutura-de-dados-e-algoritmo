namespace ArvoreBinariaSimples;

public class GerarArvoreDinamicaComando : BaseArvoreComando, IComando
{
    public No? Executar(No? no, int valor)
    {
        byte[] randomicoBytes = new byte[valor];
        Random random = new();
        random.NextBytes(randomicoBytes);
        foreach (int numero in randomicoBytes)
        {
            no = Adicionar(numero, no);
        }
        return no;
    }

    public void ImprimirMensagem()
    {
        Console.WriteLine("Digite a quantidade de itens na árvore:");
    }
}