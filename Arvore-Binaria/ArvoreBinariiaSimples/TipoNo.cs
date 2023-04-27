[Flags]
public enum TipoNo
{
    Raiz = 1,

    RaizDireito = 2,

    RaizEsquerdo = 4,
    
    RaizDireitoEsquerdo = RaizDireito | RaizEsquerdo,

    Folha = 8,

    FilhoDireito = 16,

    FilhoEsquerdo = 32,

    FilhoDireitoEsquerdo = FilhoDireito | FilhoEsquerdo,

}