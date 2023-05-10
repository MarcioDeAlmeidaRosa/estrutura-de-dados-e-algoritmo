namespace ExecutorGenerico;

public interface IComando<TypeNo> where TypeNo : BaseNo
{
    int IdComando { get; }

    string PropositoComando { get; }

    void ImprimirMensagem();
    
    void ImprimirObjetivo();

    TypeNo? Executar(TypeNo? no, int valor);
}