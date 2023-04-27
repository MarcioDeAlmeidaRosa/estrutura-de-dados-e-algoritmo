public class AdicionarArvoreComando : BaseArvoreComando, IComando
{
    public No Executar(No? no)
    {
        Console.WriteLine("Digite o valor:");
        var valor = Convert.ToInt32(Console.ReadLine());
        return Adicionar(valor, no);
    }
}