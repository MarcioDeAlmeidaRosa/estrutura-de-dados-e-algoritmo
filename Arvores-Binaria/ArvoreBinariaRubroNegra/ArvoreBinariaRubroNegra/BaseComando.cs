namespace ArvoceBinariaRubroNegra;

public abstract class BaseComando
{
    private static readonly No NoNulo = new No { Tipo = Tipo.Nulo };

    public static No CriarNovoNo(Tipo tipo, int valor, int? valorPai)
        => new No
        {
            Valor = valor,
            Tipo = tipo,
            Direito = NoNulo,
            Esquerdo = NoNulo,
            Pai = valorPai,
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
            return AtribuirLado(noCorrente, valor, CriarNovoNo(Tipo.Vermelho, valor, noCorrente.Valor), noAvo, tio);
        }

        AdicionarNo(lado, valor, noCorrente, tio);
        
        return noCorrente;
    }

    protected No Adicionar(No? no, int valor)
    {
        if (no == null)
            return CriarNovoNo(Tipo.Raiz, valor, default);

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

            return;
        }

        if (noPai.Tipo == Tipo.Vermelho
        && noFilho.Tipo == Tipo.Vermelho
        && noFilho.Valor > noPai.Valor
        && Tipo.Pretos.HasFlag(noTio.Tipo))
        {
            (noPai, noFilho) = (noFilho, noPai);
            AtribuirLado(noFilho, noPai.Valor, NoNulo, noAvo, noTio);
            AtribuirLado(noPai, noFilho.Valor, noFilho, noAvo, noTio);
            AtribuirLado(noAvo, noPai.Valor, noPai, noAvo, noTio);
            return;
        }
    }

}