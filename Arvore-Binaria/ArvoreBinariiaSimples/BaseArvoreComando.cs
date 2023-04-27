public abstract class BaseArvoreComando
{
    private No CriarNo(int valor, No? pai)
    {
        var _no = new No { Valor = valor };
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

    private void AtribuirLado(int valor, No no, No noFilho)
    {
        if (valor > no.Valor)
        {
            no.Direito = noFilho;
            return;
        }
        no.Esquerdo = noFilho;
    }

    protected No Adicionar(int valor, No? no)
    {
        if (no == null)
        {
            return CriarNo(valor, no);
        }

        var _no = SelecionaLado(valor, no);
        if (_no == null)
        {
            AtribuirLado(valor, no, CriarNo(valor, no));
            return no;
        }
        Adicionar(valor, _no);
        return no;
    }

    protected No? RemoverItem(int valor, No? no)
    {
        return no;
    }

    private No? LocalizarNo(int valor, No? no)
    {
        var encontrei = no?.Valor == valor;

        return no;
    }
}