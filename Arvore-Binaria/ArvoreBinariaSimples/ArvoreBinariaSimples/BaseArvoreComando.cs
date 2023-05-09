namespace ArvoreBinariaSimples;

public abstract class BaseArvoreComando
{
    private No CriarNo(int valor, No? pai, TipoNo tipo)
    {
        var _no = new No { Valor = valor, Tipo = tipo };
        if (pai != null)
            _no.Pai = pai.Valor;
        return _no;
    }

    private No? SelecionaLado(int valor, No? no)
    {
        return valor > no?.Valor
            ? no?.Direito
            : no?.Esquerdo;
    }

    private void AtribuiTipo(No no)
    {
        no.Tipo = !(TipoNo.Raiz | TipoNo.RaizDireitaEsquerda).HasFlag(no.Tipo)
            ? no.Esquerdo == null && no.Direito == null
                ? TipoNo.Folha
                : no.Esquerdo != null && no.Direito == null
                ? TipoNo.FilhoEsquerdo
                : no.Esquerdo != null && no.Direito != null
                ? TipoNo.FilhoDireitoEsquerdo
                : TipoNo.FilhoDireito
            : no.Esquerdo == null && no.Direito == null
                ? TipoNo.Raiz
                : no.Esquerdo != null && no.Direito == null
                  ? TipoNo.RaizEsquerda
                  : no.Esquerdo != null && no.Direito != null
                  ? TipoNo.RaizDireitaEsquerda
                  : TipoNo.RaizDireita;
    }

    private void AtribuirLado(int valor, No? noPai, No? noFilho)
    {
        if (noPai == null)
            return;

        if (noFilho != null)
            noFilho.Pai = noPai.Valor;

        if (valor > noPai.Valor)
            noPai.Direito = noFilho;
        else
            noPai.Esquerdo = noFilho;

        AtribuiTipo(noPai);
    }

    protected No Adicionar(int valor, No? no)
    {
        if (no == null)
        {
            return CriarNo(valor, no, TipoNo.Raiz);
        }

        var _no = SelecionaLado(valor, no);
        if (_no == null)
        {
            AtribuirLado(valor, no, CriarNo(valor, no, TipoNo.Folha));
            return no;
        }
        Adicionar(valor, _no);
        return no;
    }

    private No? LocalizarNo(int valor, No? no)
    {
        if (no == null)
            return no;

        if (no.Valor == valor)
            return no;

        return LocalizarNo(valor, SelecionaLado(valor, no));
    }

    private bool RemocaoSimples(No no)
            => (no.Tipo.HasFlag(TipoNo.Raiz))
            || ((TipoNo.FilhoDireito | TipoNo.FilhoEsquerdo | TipoNo.Folha).HasFlag(no.Tipo)
                 && no.Tipo != TipoNo.FilhoDireitoEsquerdo);

    private bool RemocaoIntermediaria(No no)
        => (TipoNo.RaizDireitaEsquerda | TipoNo.FilhoDireitoEsquerdo).HasFlag(no.Tipo)
            && (no.Esquerdo?.Tipo ?? TipoNo.Folha | no.Direito?.Tipo ?? TipoNo.Folha).HasFlag(TipoNo.Folha);

    private No? AtribuirNoLugar(No? no, int valor, No novoValor)
    {
        if (no?.Valor == valor)
        {
            no = novoValor;
            return no;
        }

        var _no = AtribuirNoLugar(SelecionaLado(valor, no), valor, novoValor);
        AtribuirLado(valor, no, _no);

        return no;
    }

    protected No? RemoverItem(int valor, No? no)
    {
        var _noDelecaoLocalizado = LocalizarNo(valor, no);

        if (_noDelecaoLocalizado == null)
            return no;

        if (RemocaoSimples(_noDelecaoLocalizado))
        {
            if (_noDelecaoLocalizado.Tipo == TipoNo.Raiz)
            {
                no = null;
                return no;
            }

            var pai = LocalizarNo(_noDelecaoLocalizado.Pai.GetValueOrDefault(), no);

            if (pai == null)
                return no;

            if (_noDelecaoLocalizado.Tipo == TipoNo.Folha)
            {
                AtribuirLado(valor, pai, null);
                return no;
            }

            AtribuirLado(valor, pai, _noDelecaoLocalizado.Esquerdo ?? _noDelecaoLocalizado.Direito);
        }
        else if (RemocaoIntermediaria(_noDelecaoLocalizado))
        {
            if (_noDelecaoLocalizado.Esquerdo != null)
            {
                _noDelecaoLocalizado.Esquerdo.Pai = _noDelecaoLocalizado.Pai;
                _noDelecaoLocalizado.Esquerdo.Tipo = _noDelecaoLocalizado.Tipo;
                AtribuirLado(valor, _noDelecaoLocalizado.Esquerdo, _noDelecaoLocalizado.Direito);
                no = AtribuirNoLugar(no, valor, _noDelecaoLocalizado.Esquerdo);
            }
            else if (_noDelecaoLocalizado.Direito != null)
            {
                _noDelecaoLocalizado.Direito.Pai = _noDelecaoLocalizado.Pai;
                _noDelecaoLocalizado.Direito.Tipo = _noDelecaoLocalizado.Tipo;
                AtribuirLado(valor, _noDelecaoLocalizado.Direito, null);
                no = AtribuirNoLugar(no, valor, _noDelecaoLocalizado.Direito);
            }
        }

        return no;
    }
}