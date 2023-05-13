using ExecutorGenerico;

namespace ArvoceBinariaRubroNegra;

public class No: BaseNo
{
    public int? Pai { get; set; }

    public int Valor { get; set; }

    public No Esquerdo { get; set; }

    public No Direito { get; set; }

    public Tipo Tipo { get; set; }
}