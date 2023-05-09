namespace ArvoreBinariaSimples;

[Flags]
public enum TipoNo
{
    Raiz = 1,

    RaizDireita = 2,

    RaizEsquerda = 4,
    
    RaizDireitaEsquerda = RaizDireita | RaizEsquerda,

    Folha = 8,

    FilhoDireito = 16,

    FilhoEsquerdo = 32,

    FilhoDireitoEsquerdo = FilhoDireito | FilhoEsquerdo,

}