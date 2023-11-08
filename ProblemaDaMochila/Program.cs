// See https://aka.ms/new-console-template for more information
using ProblemaDaMochila;

Console.WriteLine("Problema da mochila");

var simplex = new Simplex();
int contador = 0;
simplex.DefineFullBaseMatrix();
simplex.PrintMatrix();

while (simplex.CanContinue())
{
    var colunaPivo = simplex.IndexColunaPivo();
    var linhaPivo = simplex.IndexLinhaPivo(colunaPivo);
    simplex.SwitchBasicVar(linhaPivo, colunaPivo);
    simplex.IteracaoSimplex(colunaPivo, linhaPivo);
    contador++;
    Console.WriteLine($"Numero de iteracoes: {contador}");

}
simplex.PrintResultado();

Console.WriteLine("Funfou? :3");
