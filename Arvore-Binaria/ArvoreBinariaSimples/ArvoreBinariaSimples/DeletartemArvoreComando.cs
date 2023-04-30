namespace ArvoreBinariaSimples;

public class DeletartemArvoreComando : BaseArvoreComando, IComando
{
    public No? Executar(No? no)
    {
        Console.WriteLine("Digite o valor para deletar:");
        var valor = Convert.ToInt32(Console.ReadLine());
        return RemoverItem(valor, no);
    }
}