namespace ArvoceBinariaRubroNegra;

public abstract class BaseComando
{
    private static readonly No NoNulo = new No { Tipo = Tipo.Nulo };

    public static No CriarNovoNo(Tipo tipo, int valor, No? norPai)
        => new No
        {
            Valor = valor,
            Tipo = tipo,
            Direito = NoNulo,
            Esquerdo = NoNulo,
            Pai = norPai,
        };

    private static (No noEscolhido, No noTio) EscolherLado(No no, int valor)
    {
        if (valor > no.Valor)
            return (no.Direito, no.Esquerdo);

        return (no.Esquerdo, no.Direito);
    }

    private static No AtribuirLado(No noCorrente, int valor, No noFilho, No noPai, No noTio, No? noVo)
    {
        if (noFilho.Tipo != Tipo.Nulo)
            noFilho.Pai = noCorrente;

        if (valor > noCorrente.Valor)
            noCorrente.Direito = noFilho;
        else
            noCorrente.Esquerdo = noFilho;

        ValidarBalanceamento(noCorrente, noFilho, noPai, noTio, noVo);

        return noCorrente;
    }

    private static No AdicionarNo(No noCorrente, int valor, No noPai, No irmao, No? noVo)
    {
        No novoNoCorrente = NoNulo;
        No novoNoIrmao = NoNulo;

        (novoNoCorrente, novoNoIrmao) = EscolherLado(noCorrente, valor);

        if (novoNoIrmao.Tipo == Tipo.Nulo && irmao.Tipo != Tipo.Nulo)
            novoNoIrmao = irmao;

        if (novoNoCorrente.Tipo == Tipo.Nulo)
        {
            return AtribuirLado(noCorrente, valor, CriarNovoNo(Tipo.Vermelho, valor, noCorrente), noPai, novoNoIrmao, noVo);
        }

        AdicionarNo(novoNoCorrente, valor, noCorrente, novoNoIrmao, noCorrente.Pai);

        return noCorrente;
    }

    protected No Adicionar(No? no, int valor)
    {
        if (no == null)
            return CriarNovoNo(Tipo.Raiz, valor, default);

        return AdicionarNo(no, valor, NoNulo, NoNulo, NoNulo);
    }

    private static void ValidarBalanceamento(No noCorrente, No noFilho, No noPai, No noTio, No? noVo)
    {
        if (noCorrente.Tipo == Tipo.Vermelho
        && noFilho.Tipo == Tipo.Vermelho
        && noTio.Tipo == Tipo.Vermelho)
        {
            noCorrente.Tipo = Tipo.Preto;
            noTio.Tipo = Tipo.Preto;
            if (noPai.Tipo != Tipo.Raiz)
                noPai.Tipo = Tipo.Vermelho;

            return;
        }

        if (noCorrente.Tipo == Tipo.Vermelho
        && noFilho.Tipo == Tipo.Vermelho
        && noFilho.Valor > noCorrente.Valor
        && Tipo.Pretos.HasFlag(noTio.Tipo))
        {
            (noCorrente, noFilho) = (noFilho, noCorrente);
            AtribuirLado(noFilho, noCorrente.Valor, NoNulo, noPai, noTio, noVo);
            AtribuirLado(noCorrente, noFilho.Valor, noFilho, noPai, noTio, noVo);

            (noPai, noCorrente) = (noCorrente, noPai);
            AtribuirLado(noCorrente, noPai.Valor, NoNulo, noPai, noTio, noVo);
            AtribuirLado(noPai, noCorrente.Valor, noCorrente, noPai, noTio, noVo);
            noPai.Tipo = Tipo.Preto;
            noCorrente.Tipo = Tipo.Vermelho;
            AtribuirLado(noVo, noPai.Valor, noPai, noPai, noTio, noVo);
            return;
        }
    }

    private No BuscarNo(No no, int valor)
    {
        var (noEncontrado, _) = EscolherLado(no, valor);

        if (noEncontrado.Valor == valor)
            return noEncontrado;

        noEncontrado = BuscarNo(no, valor);

        return noEncontrado;
    }

}