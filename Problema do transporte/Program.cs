using Problema_do_transporte;

Console.WriteLine("Problema do transporte");

var penalidade = new Penalidades();
int contador = 0;

penalidade.MontarMatrizRestricao();
penalidade.PrintMatrix();

penalidade.SetPenalidadeDemanda();
penalidade.PrintPenalidadeDemanda();
penalidade.SetPenalidadeOferta();
penalidade.PrintPenalidadeOferta();

while (penalidade.CanContinue())
{
    penalidade.AplicarIteracao();

    penalidade.SetPenalidadeDemanda();
    penalidade.SetPenalidadeOferta();
    penalidade.PrintPenalidadeDemanda();
    penalidade.PrintPenalidadeOferta();
    contador++;
    Console.WriteLine($"Numero de iteracoes: {contador}");
    penalidade.PrintMatrix();
}
penalidade.PrintMatrix();
Console.WriteLine($"Numero de iteracoes: {contador}");


