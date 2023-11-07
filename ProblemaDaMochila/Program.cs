// See https://aka.ms/new-console-template for more information
using ProblemaDaMochila;

Console.WriteLine("Problema da mochila");

var simplex = new Simplex();

simplex.DefineFullBaseMatrix();
simplex.PrintMatrix();
var linhaPivo = simplex.IndexLinhaPivo(out int colinaPivo);
simplex.SwitchBasicVar(linhaPivo, colinaPivo);

Console.WriteLine(simplex.varBasica[linhaPivo]);
Console.WriteLine(simplex.varNaoBasica[colinaPivo]);
    