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
        No novoPai = No.NoNulo;
        No novoTio = No.NoNulo;

        (novoPai, novoTio) = EscolherLado(noCorrente, valor);

        if (novoTio.Tipo == Tipo.Nulo && noTio.Tipo != Tipo.Nulo)
            novoTio = noTio;

        if (novoPai.Tipo == Tipo.Nulo)
        {
            return AtribuirLado(noCorrente, valor, CriarNovoNo(Tipo.Vermelho, valor, noCorrente), noPai, novoTio, noVo);
        }

        AdicionarNo(novoPai, valor, noCorrente, novoTio, noCorrente.Pai ?? No.NoNulo);

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

    private static void ValidarBalanceamento(No noPai, No noFilho, No noVo, No noTio, No noBisavo)
    {
        //Caso 1e (esqueda)
        //v = (vertise - no sendo incluído) = noFilho  
        if (noTio.Tipo == Tipo.Vermelho //possui um tio rubro
         && noPai.Tipo == Tipo.Vermelho //seu pai é um filho rubro
         && noFilho.Tipo == Tipo.Vermelho)
        {
            noPai.Tipo = Tipo.Preto;
            noTio.Tipo = Tipo.Preto;
            if (noVo.Tipo != Tipo.Raiz)
                noVo.Tipo = Tipo.Vermelho;

            if (!Tipo.Pretos.HasFlag(noBisavo.Tipo))
            {
                //violação da regra 4 foi elevada a 1 níveil
                // v é elevado dois níveis 
                // executamos um passo-CE para o novo v (avô de v)
                var (_, tio) = EscolherLado(noBisavo.Pai, noFilho.Valor);
                ValidarBalanceamento(noBisavo, noVo, noBisavo.Pai, tio, noBisavo.Pai.Pai ?? No.NoNulo);
            }

            return;
        }

        if (noPai.Tipo == Tipo.Vermelho
        && noFilho.Tipo == Tipo.Vermelho
        && noFilho.Valor > noPai.Valor
        && Tipo.Pretos.HasFlag(noTio.Tipo))
        {
            (noPai, noFilho) = (noFilho, noPai);
            AtribuirLado(noFilho, noPai.Valor, No.NoNulo, noVo, noTio, noBisavo);
            AtribuirLado(noPai, noFilho.Valor, noFilho, noVo, noTio, noBisavo);

            (noVo, noPai) = (noPai, noVo);
            AtribuirLado(noPai, noVo.Valor, No.NoNulo, noVo, noTio, noBisavo);
            AtribuirLado(noVo, noPai.Valor, noPai, noVo, noTio, noBisavo);
            (noVo.Tipo, noPai.Tipo) = (noPai.Tipo, noVo.Tipo);
            AtribuirLado(noBisavo, noVo.Valor, noVo, noVo, noTio, noBisavo);
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