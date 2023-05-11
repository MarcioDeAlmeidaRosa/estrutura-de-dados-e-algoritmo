namespace ArvoceBinariaRubroNegra;

public abstract class BaseComando
{
    private static readonly No NoNulo = new No { Tipo = Tipo.Preto };

    private static No CriarNovoNo(Tipo tipo, int valor)
        => new No
        {
            Valor = valor,
            Tipo = tipo,
            Direito = NoNulo,
            Esquerdo = NoNulo,
        };

    protected No? Adicionar(No? no, int valor)
    {
        if (no == null)
        {
            return CriarNovoNo(Tipo.Raiz, valor);
        }
        return CriarNovoNo(Tipo.Vermelho, valor);
    }

}