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
            no = new ManipularArvore().AdicionarItem(no);
            break;

        case "9":
            Console.WriteLine("Encerrendo execução...");
            return;
        default:
            Console.WriteLine("Comando não permitido:");
            break;
    }


}
