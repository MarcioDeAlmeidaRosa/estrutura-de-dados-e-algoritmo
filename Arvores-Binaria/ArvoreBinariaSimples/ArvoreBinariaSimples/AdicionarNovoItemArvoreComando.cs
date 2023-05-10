using ExecutorGenerico;

namespace ArvoreBinariaSimples;

public class AdicionarNovoItemArvoreComando : BaseArvoreComando, IComando<No>
{
    public int IdComando => 1;

    public string PropositoComando => "adicionar um item na árvore";

    public No? Executar(No? no, int valor)
    {
        return Adicionar(valor, no);
    }

    public void ImprimirMensagem()
    {
        Console.WriteLine("Digite o valor:");
    }

    public void ImprimirObjetivo()
    {
        Console.WriteLine($"{IdComando} - Para {PropositoComando}");
    }
}