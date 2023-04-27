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
        no.Tipo = !(TipoNo.Raiz | TipoNo.RaizDireitoEsquerdo).HasFlag(no.Tipo)
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
                  ? TipoNo.RaizEsquerdo
                  : no.Esquerdo != null && no.Direito != null
                  ? TipoNo.RaizDireitoEsquerdo
                  : TipoNo.RaizDireito;
    }

    private void AtribuirLado(int valor, No no, No? noFilho)
    {
        if (noFilho != null)
            noFilho.Pai = no.Valor;

        if (valor > no.Valor)
            no.Direito = noFilho;
        else
            no.Esquerdo = noFilho;

        AtribuiTipo(no);
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
            || ((TipoNo.FilhoDireito | TipoNo.FilhoEsquerdo | TipoNo.Folha).HasFlag(no.Tipo) && no.Tipo != TipoNo.FilhoDireitoEsquerdo);

    protected No? RemoverItem(int valor, No? no)
    {
        var _noLocalizado = LocalizarNo(valor, no);

        if (_noLocalizado == null)
            return no;

        if (RemocaoSimples(_noLocalizado))
        {
            if (_noLocalizado.Tipo == TipoNo.Raiz)
            {
                no = null;
                return no;
            }

            var pai = LocalizarNo(_noLocalizado.Pai.GetValueOrDefault(), no);
            
            if (pai == null)
                return no;

            if (_noLocalizado.Tipo == TipoNo.Folha)
            {
                AtribuirLado(valor, pai, null);
                return no;
            }

            AtribuirLado(valor, pai, _noLocalizado.Esquerdo ?? _noLocalizado.Direito);
        }

        return no;
    }
}