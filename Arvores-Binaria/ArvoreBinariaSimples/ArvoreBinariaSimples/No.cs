namespace ArvoreBinariaSimples;

public class No
{
    public int? Pai { get; set; }

    public int Valor { get; set; }

    public No? Esquerdo { get; set; }

    public No? Direito { get; set; }

    public TipoNo Tipo{ get; set; }
}