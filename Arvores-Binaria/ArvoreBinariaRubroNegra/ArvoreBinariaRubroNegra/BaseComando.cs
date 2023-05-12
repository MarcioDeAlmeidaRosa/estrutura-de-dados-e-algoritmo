namespace ArvoceBinariaRubroNegra;

public abstract class BaseComando
{
    public static readonly No NoNulo = new No { Tipo = Tipo.Nulo };

    private static No CriarNovoNo(Tipo tipo, int valor)
        => new No
        {
            Valor = valor,
            Tipo = tipo,
            Direito = NoNulo,
            Esquerdo = NoNulo,
        };

    private static No? EscolherLado(No no, int valor)
    {
        if (valor > no.Valor)
            return no.Direito;

        return no.Esquerdo;
    }

    private static No AtribuirLado(No noPai, int valor, No? noFilho)
    {
        if (noFilho != null)
            noFilho.Pai = noFilho.Valor;

        if (valor > noPai.Valor)
            noPai.Direito = noFilho;
        else
            noPai.Esquerdo = noFilho;

        return noPai;
    }

    private static No? AdicionarNo(No no, int valor)
    {
        var lado = EscolherLado(no, valor);

        if (lado.Tipo == Tipo.Nulo)
            return AtribuirLado(no, valor, CriarNovoNo(Tipo.Vermelho, valor));

        AdicionarNo(lado, valor);
        return no;
    }

    protected No? Adicionar(No? no, int valor)
    {
        if (no == null)
            return CriarNovoNo(Tipo.Raiz, valor);

        return AdicionarNo(no, valor);
    }

}