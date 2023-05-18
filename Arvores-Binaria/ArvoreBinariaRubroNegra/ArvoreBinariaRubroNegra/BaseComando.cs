namespace ArvoceBinariaRubroNegra;

public abstract class BaseComando
{
    public static No CriarNovoNo(Tipo tipo, int valor, No? norPai)
        => new No
        {
            Valor = valor,
            Tipo = tipo,
            Pai = norPai,
        };

    private static (No noEscolhido, No noTio) EscolherLado(No no, int valor)
    {
        if (valor > no.Valor)
            return (no.Direito, no.Esquerdo);

        return (no.Esquerdo, no.Direito);
    }

    protected No Adicionar(No? no, int valor)
    {
        if (no == null)
            return CriarNovoNo(Tipo.Raiz, valor, default);

        return AdicionarNo(no, valor, No.NoNulo, No.NoNulo, No.NoNulo);
    }

    private static No AdicionarNo(No noCorrente, int valor, No noPai, No noTio, No noVo)
    {
        No novoNoCorrente = No.NoNulo;
        No novoTio = No.NoNulo;

        (novoNoCorrente, novoTio) = EscolherLado(noCorrente, valor);

        if (novoTio.Tipo == Tipo.Nulo && noTio.Tipo != Tipo.Nulo)
            novoTio = noTio;

        if (novoNoCorrente.Tipo == Tipo.Nulo)
        {
            return AtribuirLado(noCorrente, valor, CriarNovoNo(Tipo.Vermelho, valor, noCorrente), noPai, novoTio, noVo);
        }

        AdicionarNo(novoNoCorrente, valor, noCorrente, novoTio, noCorrente.Pai ?? No.NoNulo);

        return noCorrente;
    }

    private static No AtribuirLado(No noCorrente, int valor, No noFilho, No noPai, No noTio, No noVo)
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

    private static void ValidarBalanceamento(No noCorrente, No noFilho, No noPai, No noTio, No noVo)
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
            AtribuirLado(noFilho, noCorrente.Valor, No.NoNulo, noPai, noTio, noVo);
            AtribuirLado(noCorrente, noFilho.Valor, noFilho, noPai, noTio, noVo);

            (noPai, noCorrente) = (noCorrente, noPai);
            AtribuirLado(noCorrente, noPai.Valor, No.NoNulo, noPai, noTio, noVo);
            AtribuirLado(noPai, noCorrente.Valor, noCorrente, noPai, noTio, noVo);
            (noPai.Tipo, noCorrente.Tipo) = (noCorrente.Tipo, noPai.Tipo);
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