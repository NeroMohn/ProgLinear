namespace ProblemaDaMochila
{
    public class Simplex
    {
        public Simplex() { }

        //Construção da tabela base. 
        //Utilizado, nesse caso, uma tabela de 33 linhas [32 restrições, sendo elas os total de produtos e os limites de peso/volume, além da função zmax]
        //e 63 colunas, sendo 30 para os itens, 32 para as folgas e 1 para b.
        double[,] matriz = new double[33, 63];

        double[] restricoesPeso = new double[30]{ 0.7, 1.7, 0.1, 0.8, 0.9, 2.2, 3.8, 3.6, 2.2, 2.8, 0.1, 1.4, 3.4, 1.1, 3.2, 2.7, 3.9, 1.3, 1.6, 1.6, 0.5, 0.3, 1.2, 1.1, 1.2, 3.6, 0.8, 1.1, 3.6, 2.2, };
        double bPeso = 500;
        double[] restricoesVolume = new double[30]{ 4.5, 2.1, 3.7, 4.7, 1.4, 3.6, 2.5, 2.4, 4.9, 2.8, 3.6, 3.6, 2.1, 2.2, 1.3, 2.1, 3.1, 1.1, 3.1, 1.2, 2.3, 1.7, 3.8, 1.3, 1.3, 4.3, 2.3, 3.6, 2.6, 3.2 };
        double bVolume = 830;
        double[] bRestricoesItem = new double[30] { 10, 18, 13, 14, 16, 18, 9, 12, 15, 11, 13, 10, 10, 8, 17, 18, 9, 13, 9, 8, 10, 10, 15, 18, 12, 9, 10, 17, 18, 11 };
        public string[] varBasica = new string[32] { "f1", "f2", "f3", "f4", "f5", "f6", "f7", "f8", "f9", "f10", "f11", "f12", "f13", "f14", "f15", "f16", "f17", "f18", "f19", "f20", "f21", "f22", "f23", "f24", "f25", "f26", "f27", "f28", "f29", "f30", "f31", "f32" };
        public string[] varNaoBasica = new string[62] { "x1", "x2", "x3", "x4", "x5", "x6", "x7", "x8", "x9", "x10", "x11", "x12", "x13", "x14", "x15", "x16", "x17", "x18", "x19", "x20", "x21", "x22", "x23", "x24", "x25", "x26", "x27", "x28", "x29", "x30", "f1", "f2", "f3", "f4", "f5", "f6", "f7", "f8", "f9", "f10", "f11", "f12", "f13", "f14", "f15", "f16", "f17", "f18", "f19", "f20", "f21", "f22", "f23", "f24", "f25", "f26", "f27", "f28", "f29", "f30", "f31", "f32" };  

        public void DefinirFO()
        {
            for (int i = 0; i < 63; i++)
            {
                if (i < 30)
                    matriz[32, i] = -1;
                else
                    matriz[32, i] = 0;
            }
        }
        public void DefinirRestricaoPeso()
        {
            for (int i = 0; i < 30; i++)
            {
                matriz[0, i] = restricoesPeso[i];
            }
            matriz[0, 30] = 1;
            matriz[0, 62] = bPeso;
        }
        public void DefinirRestricaoVolume()
        {
            for (int i = 0; i < 30; i++)
            {
                matriz[1, i] = restricoesVolume[i];
            }
            matriz[1, 62] = bVolume;
            matriz[1, 31] = 1;

        }
        public void PrintMatrix()
        {
            for (int i = 0; i < 33; i++)
            {
                for (int j = 0; j < 63; j++)
                {
                    if ((matriz[i, j]) >= 0)
                        Console.Write($" {matriz[i, j]}|");
                    else
                        Console.Write($"{matriz[i, j]}|");
                }
                Console.WriteLine();
            }
        }
        public void DefinirRestricoesEFolgasItens()
        {
            for(int i = 0; i < 30; i++)
            {
                matriz[i + 2, i] = 1;
                matriz[i + 2, i+32] = 1;
                matriz[i+2,62] = bRestricoesItem[i];
            }
        }
        public void DefineFullBaseMatrix()
        {
            DefinirRestricaoPeso();
            DefinirRestricaoVolume();
            DefinirRestricoesEFolgasItens();
            DefinirFO();
            PrintMatrix();
        }

        public int IndexColunaPivo()
        {
            double MenorValorNegativo = 0;
            int indexMaiorValorNegativo = 0;
            for (int i = 0; i < 62; i++)
            {
                if (matriz[32, i] < MenorValorNegativo)
                {
                    MenorValorNegativo = matriz[32, i];
                    indexMaiorValorNegativo = i;
                }
            }
            return indexMaiorValorNegativo;
        }

        public bool CanContinue()
        {
            for (int i = 0; i < 62; i++)
            {
                if (matriz[32, i] < 0)
                    return true;
            }
            return false;
        }

        public int IndexLinhaPivo(int indexColunaPivo)
        {
            double PP;
            double minValue = Double.MaxValue ;
            int indexLinha = 0;
            for(int i = 0; i< 33; i++)
            {
                var denominador = matriz[i, indexColunaPivo];
                if (denominador != 0) {
                    PP = (matriz[i, 62] / denominador);
                    if (PP < minValue && PP>0)
                    {
                        minValue = PP;
                        indexLinha = i;
                    }
                }
            }
            return indexLinha;
        }

        // Os indexes de linha pivo sempre são os mesmo da identificacao das variaveis basicas
        // index linha = index variavel basica
        // Essa condição é importante para quando formos relacionar aos valores após o simplex aos itens (Xn)
        public void SwitchBasicVar(int indexBasica, int indexVariavelColuna) => varBasica[indexBasica] = varNaoBasica[indexVariavelColuna];

        public void IteracaoSimplex(int indexColunaPivo, int indexLinhapivo)
        {
                EscalonaPivo(indexLinhapivo, indexColunaPivo);

            //logica para a linhas novas 
            for (int i = 0; i < 33; i++)
                {
                if (IsPivo(i, indexLinhapivo))
                    continue;
                EscalonaNovaLinha(i, indexLinhapivo, indexColunaPivo);
                }
        }

        public bool IsPivo(int iteracao, int linhaPivo) => iteracao.Equals(linhaPivo) ? true:false;

        
        public void EscalonaPivo(int indexLinhaPivo, int indexColunaPivo) 
        {
            var baseValue = matriz[indexLinhaPivo, indexColunaPivo];
            for(int i = 0; i < 63; i++)
            {
                matriz[indexLinhaPivo, i] = matriz[indexLinhaPivo, i] / baseValue;
            }    
        }
        public void EscalonaNovaLinha(int indexLinhaAtual,int indexLinhaPivo, int indexColunaPivo) 
        {
            var baseValue = matriz[indexLinhaAtual, indexColunaPivo];
            for (int i = 0; i < 63; i++)
            {
                matriz[indexLinhaAtual, i] = matriz[indexLinhaAtual, i]-(baseValue * matriz[indexLinhaPivo, i]);
            }
        }

        public void PrintResultado()
        {
            Console.WriteLine();
            Console.Write("Variaveis básicas: ");
            for (int i = 0;i < 32; i++)
            {
                Console.Write($"{varBasica[i]}, ");
            }
            Console.WriteLine();
            Console.WriteLine("Resultado");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Variavel | Valor");

            for (int i = 0;i < 32; i++)
                Console.WriteLine($"{varBasica[i]} | {matriz[i,62]}");
            Console.WriteLine($"Z | {matriz[32, 62]}");

        }
    }
}
