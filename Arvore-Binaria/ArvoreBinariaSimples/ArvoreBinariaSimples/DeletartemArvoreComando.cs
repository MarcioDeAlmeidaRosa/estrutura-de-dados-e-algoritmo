namespace ArvoreBinariaSimples;

public class DeletartemArvoreComando : BaseArvoreComando, IComando
{
    public No? Executar(No? no, int valor)
    {
        return RemoverItem(valor, no);
    }

    public void ImprimirMensagem()
    {
        Console.WriteLine("Digite o valor para deletar:");
    }
}