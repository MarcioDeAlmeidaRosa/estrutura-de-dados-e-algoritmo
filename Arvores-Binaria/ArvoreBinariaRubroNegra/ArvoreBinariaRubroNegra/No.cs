using System.Text.Json.Serialization;
using ExecutorGenerico;

namespace ArvoceBinariaRubroNegra;

public class No : BaseNo
{
    public static readonly No NoNulo = new No { Tipo = Tipo.Nulo };

    public No()
    {
        Esquerdo = NoNulo;
        Direito = NoNulo;
    }

    [JsonIgnore]
    public No? Pai { get; set; }
    
    public int? ValorPai
    {
        get
        {
            return Pai?.Valor;

        }
    }

    public int Valor { get; set; }

    public No Esquerdo { get; set; }

    public No Direito { get; set; }

    public Tipo Tipo { get; set; }
}