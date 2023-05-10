namespace ExecutorGenerico;

public class ControladorDeComandos<TypeNo> where TypeNo : BaseNo
{
    private readonly Dictionary<int, IComando<TypeNo>> Comandos;

    public ControladorDeComandos(IList<IComando<TypeNo>> comandos)
    {
        Comandos = comandos.ToDictionary(x => x.IdComando) ??
            throw new ArgumentException("Lista de comandos não enviada");
    }

    internal void ImprimirObjetivos()
    {
        Console.WriteLine("Digite ");

        foreach (var comando in Comandos.Values)
        {
            comando.ImprimirObjetivo();
        }
    }

    internal void ImprimirComando(int comando)
    {
        Comandos[comando].ImprimirMensagem();
    }

    internal bool ComandoRegistrado(int comando)
        => Comandos.TryGetValue(comando, out var _);

    internal TypeNo? Executar(int comando, TypeNo? no, int valor)
        => Comandos[comando].Executar(no, valor);
}