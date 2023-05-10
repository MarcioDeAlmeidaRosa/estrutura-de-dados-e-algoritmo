using ArvoreBinariaSimples;
using Utils;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Utilizando árvore binária...");

No? no = default;

while (true)
{
    Comandos.ImprimirComandos();
    var comando = Console.ReadLine();
    int valor = 0;
    switch (comando)
    {
        case "1":
            var comandoAdicionar = new AdicionarNovoItemArvoreComando();
            comandoAdicionar.ImprimirMensagem();
            valor = Convert.ToInt32(Console.ReadLine());
            no = comandoAdicionar.Executar(no, valor);
            ImprimeSaida.Imprimir(no);
            break;

        case "2":
            var comandoGerar = new GerarArvoreDinamicaComando();
            comandoGerar.ImprimirMensagem();
            valor = Convert.ToInt32(Console.ReadLine());
            no = comandoGerar.Executar(no, valor);
            ImprimeSaida.Imprimir(no);
            break;

        case "3":
            var comandoDeletar = new DeletartemArvoreComando();
            comandoDeletar.ImprimirMensagem();
            valor = Convert.ToInt32(Console.ReadLine());
            no = comandoDeletar.Executar(no, valor);
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
