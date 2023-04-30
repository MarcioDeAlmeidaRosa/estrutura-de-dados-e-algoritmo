namespace ArvoreBinariaSimples;

public interface IComando
{
    void ImprimirMensagem();
    No? Executar(No? no, int valor);
}