using ExecutorGenerico;

namespace ArvoreBinariaSimples;

public class DeletartemArvoreComando : BaseArvoreComando, IComando<No>
{
    public int IdComando => 3;

    public string PropositoComando => "remover uma item na árvore";

    public No? Executar(No? no, int valor)
    {
        return RemoverItem(valor, no);
    }

    public void ImprimirMensagem()
    {
        Console.WriteLine("Digite o valor para deletar:");
    }

    public void ImprimirObjetivo()
    {
        Console.WriteLine($"{IdComando} - Para {PropositoComando}");
    }
}