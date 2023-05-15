namespace ArvoceBinariaRubroNegra;

[Flags]
public enum Tipo
{
    Preto = 1,

    Raiz = 2,
    
    Nulo = 4,

    Pretos = Preto | Raiz | Nulo,

    Vermelho = 8,
}