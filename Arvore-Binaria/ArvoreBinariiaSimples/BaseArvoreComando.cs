public abstract class BaseArvoreComando
{
    private No CriarNo(int valor, No? pai)
    {
        var _no = new No { Valor = valor };
        if (pai != null)
            _no.Pai = pai.Valor;
        return _no;
    }

    protected No Adicionar(int valor, No? no)
    {
        if (no == null)
        {
            return CriarNo(valor, no);
        }

        if (valor > no.Valor)
        {
            if (no.Direito == null)
            {
                no.Direito = CriarNo(valor, no);
                return no;
            }
            Adicionar(valor, no.Direito);
            return no;
        }

        if (no.Esquerdo == null)
        {
            no.Esquerdo = CriarNo(valor, no);
            return no;
        }
        Adicionar(valor, no.Esquerdo);
        return no;
    }
}