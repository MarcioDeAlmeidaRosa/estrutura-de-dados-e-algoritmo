namespace ArvoreBinariaSimples;

public class AdicionarNovoItemArvoreComando : BaseArvoreComando, IComando
{
    public No? Executar(No? no, int valor)
    {
        return Adicionar(valor, no);
    }

    public void ImprimirMensagem()
    {
        Console.WriteLine("Digite o valor:");
    }
}