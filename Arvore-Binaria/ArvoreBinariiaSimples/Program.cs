// See https://aka.ms/new-console-template for more information
Console.WriteLine("Utilizando árvore binária...");

No? no = default;

while (true)
{
    Comandos.ImprimirComandos();
    var comando = Console.ReadLine();
    switch (comando)
    {
        case "1":
            no = new AdicionarNovoItemArvoreComando().Executar(no);
            ImprimeSaida.Imprimir(no);
            break;

        case "2":
            no = new GerarArvoreDinamicaComando().Executar(no);
            ImprimeSaida.Imprimir(no);
            break;

        case "3":
            no = new DeletartemArvoreComando().Executar(no);
            ImprimeSaida.Imprimir(no);
            break;

        case "9":
            Console.WriteLine("Encerrendo execução...");
            return;
        default:
            Console.WriteLine("Comando não permitido:");
            break;
    }


}
