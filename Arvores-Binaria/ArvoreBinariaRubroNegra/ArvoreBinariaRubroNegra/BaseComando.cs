namespace ArvoceBinariaRubroNegra;

public abstract class BaseComando
{
    private static readonly No NoNulo = new No { Tipo = Tipo.Nulo };

    public static No CriarNovoNo(Tipo tipo, int valor)
        => new No
        {
            Valor = valor,
            Tipo = tipo,
            Direito = NoNulo,
            Esquerdo = NoNulo,
        };

    private static (No noEscolhido, No noTio) EscolherLado(No no, int valor)
    {
        if (valor > no.Valor)
            return (no.Direito, no.Esquerdo);

        return (no.Esquerdo, no.Direito);
    }

    private static No AtribuirLado(No noPai, int valor, No noFilho, No noAvo, No noTio)
    {
        if (noFilho.Tipo != Tipo.Nulo)
            noFilho.Pai = noPai.Valor;

        if (valor > noPai.Valor)
            noPai.Direito = noFilho;
        else
            noPai.Esquerdo = noFilho;

        ValidarBalanceamento(noPai, noFilho, noAvo, noTio);

        return noPai;
    }

    private static No AdicionarNo(No noCorrente, int valor, No noAvo, No irmao)
    {
        No lado = NoNulo;
        No tio = NoNulo;

        (lado, tio) = EscolherLado(noCorrente, valor);

        if (tio.Tipo == Tipo.Nulo && irmao.Tipo != Tipo.Nulo)
            tio = irmao;

        if (lado.Tipo == Tipo.Nulo)
        {
            return AtribuirLado(noCorrente, valor, CriarNovoNo(Tipo.Vermelho, valor), noAvo, tio);
        }

        AdicionarNo(lado, valor, noCorrente, tio);
        return noCorrente;
    }

    protected No Adicionar(No? no, int valor)
    {
        if (no == null)
            return CriarNovoNo(Tipo.Raiz, valor);

        return AdicionarNo(no, valor, NoNulo, NoNulo);
    }

    private static void ValidarBalanceamento(No noPai, No noFilho, No noAvo, No noTio)
    {
        if (noPai.Tipo == Tipo.Vermelho
        && noFilho.Tipo == Tipo.Vermelho
        && noTio.Tipo == Tipo.Vermelho)
        {
            noPai.Tipo = Tipo.Preto;
            noTio.Tipo = Tipo.Preto;
            if (noAvo.Tipo != Tipo.Raiz)
                noAvo.Tipo = Tipo.Vermelho;
        }

    }

}