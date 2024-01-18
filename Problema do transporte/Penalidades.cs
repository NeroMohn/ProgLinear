using System;

namespace Problema_do_transporte
{
    public class Penalidades
    {
        // Matriz contendo [oferta + quantidade, demanda + dummy + quantidade] 
        double[,] matriz = new double[26, 6];

        //Definicao da matriz. Adicao de custos + quantidade + dummy

        double[] altoDosPinheiros = new double[6] { 11.27, 58.40, 8.74, 53.58, 58.10, 27.65 };
        double[] anhanguera = new double[6] { 16.33, 11.55, 51.25, 54.46, 28.39, 16.57 };
        double[] aricanduva = new double[6] { 31.25, 11.69, 38.41, 21.82, 38.65, 38.97 };
        double[] belaVista = new double[6] { 24.33, 29.98, 8.75, 58.13, 2.10, 19.14 };
        double[] bomRetiro = new double[6] { 21.08, 14.28, 42.77, 26.05, 9.33, 19.06 };
        double[] brasilandia = new double[6] { 9.74, 28.57, 18.68, 16.43, 17.28, 25.09 };
        double[] cambuci = new double[6] { 13.18, 55.43, 18.67, 9.95, 0.98, 28.65 };
        double[] capaoRedondo = new double[6] { 41.86, 37.28, 31.99, 41.04, 3.52, 4.71 };
        double[] freguesiaDoO = new double[6] { 43.02, 20.44, 36.43, 46.77, 1.94, 51.38 };
        double[] iguatemi = new double[6] { 31.80, 33.49, 49.50, 23.83, 4.25, 35.79 };
        double[] itaimBibi = new double[6] { 38.70, 38.18, 2.98, 7.49, 20.57, 0.94 };
        double[] jabaquara = new double[6] { 20.26, 24.97, 30.53, 0.88, 38.09, 51.28 };
        double[] liberdade = new double[6] { 44.61, 34.84, 36.92, 11.74, 16.60, 56.34 };
        double[] morumbi = new double[6] { 34.71, 40.53, 15.59, 8.62, 38.27, 40.41 };
        double[] moema = new double[6] { 39.26, 34.96, 51.84, 40.16, 24.25, 6.89 };
        double[] perdizes = new double[6] { 14.89, 44.99, 34.23, 31.66, 15.59, 0.39 };
        double[] perus = new double[6] { 10.27, 16.57, 48.56, 29.36, 51.14, 5.43 };
        double[] santaCecilia = new double[6] { 50.90, 6.92, 31.88, 49.68, 38.20, 38.73 };
        double[] santoAmaro1 = new double[6] { 55.79, 46.34, 9.19, 29.52, 35.89, 30.00 };
        double[] santoAmaro2 = new double[6] { 42.73, 34.32, 34.74, 4.67, 21.09, 5.48 };
        double[] tatuape = new double[6] { 49.58, 27.39, 22.15, 17.81, 15.37, 42.16 };
        double[] tremembe = new double[6] { 33.51, 33.08, 17.19, 25.13, 20.17, 16.77 };
        double[] tucuruvi = new double[6] { 19.29, 38.05, 32.07, 45.24, 12.53, 9.39 };
        double[] vilaMariana = new double[6] { 22.99, 53.46, 27.48, 42.37, 11.52, 36.70 };
        double[] vilaMatilde = new double[6] { 25.73, 45.88, 12.20, 18.87, 3.07, 36.46 };
        double[] dummy = new double[6] { 0, 0, 0, 0, 0, 0 };

        double[] oferta = new double[6] { 5147, 3053, 5900, 5044, 6149, 4312 };
        double[] demanda = new double[26]{1297, 656, 1124, 837, 1445, 1495, 1981, 1440, 1228, 719, 1023, 763, 221, 628, 188, 1119, 1556, 1411, 1017, 1467, 1424, 2396, 913, 1303, 976, 978 };

        double[] penalidadeDemanda = new double[26];
        double[] penalidadeOferta = new double[6];

        public void MontarMatrizRestricao()
        {
            var lista = new List<double[]> { altoDosPinheiros, anhanguera, aricanduva, belaVista, bomRetiro, brasilandia, cambuci, capaoRedondo, freguesiaDoO, iguatemi, itaimBibi, jabaquara, liberdade, morumbi, moema, perdizes, perus, santaCecilia, santoAmaro1, santoAmaro2, tatuape, tremembe, tucuruvi, vilaMariana, vilaMatilde, dummy };

            for(int i=0 ; i <= 25; i++)
            {
                for(int j =0; j<=5; j++)
                    matriz[i, j] = (lista[i])[j];
            }
        }

        public bool CanContinue()
        {
            for (int i = 0 ; i <= 25; i++)
            {
                if (!penalidadeDemanda[i].Equals(double.MinValue))
                    return true; 
            }
            for (int i = 0; i <= 5; i++)
            {
                if (!penalidadeOferta[i].Equals(double.MinValue))
                    return true;
            }
            return false;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i <= 25; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    if ((matriz[i, j]) >= 0)
                        Console.Write($" {matriz[i, j]}|");
                    else
                        Console.Write($"{matriz[i, j]}|");
                }
                Console.WriteLine();
            }
        }
        public void PrintPenalidadeDemanda()
        {
            Console.WriteLine("Penalidade para as demandas");

            for (int i = 0; i <= 25; i++)
                Console.Write($" {penalidadeDemanda[i]} |");

            Console.WriteLine("");
        }
        
        public void PrintPenalidadeOferta()
        {
            Console.WriteLine("Penalidade para as ofertas");

            for (int i = 0; i <= 5; i++)
                Console.Write($" {penalidadeOferta[i]} |");

            Console.WriteLine("") ;
        }

        public void SetPenalidadeOferta()
        {
            double melhor = double.MaxValue;
            double alternativa = double.MaxValue;
            double penalidade = double.MaxValue;

            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 25; j++)
                {
                    if (j == 0)
                    {
                        melhor = matriz[j, i];
                        continue;
                    }
                    if (j == 1)
                    {
                        if (melhor > matriz[j, i])
                        {
                            alternativa = melhor;
                            melhor = matriz[j, i];
                            continue;
                        }
                        alternativa = matriz[j, i];
                        continue;
                    }
                    if (melhor > matriz[j, i])
                    {
                        alternativa = melhor;
                        melhor = matriz[j, i];
                    }
                }
                if (!alternativa.Equals(double.MaxValue))
                {
                    penalidade = alternativa - melhor;
                    penalidadeOferta[i] = penalidade;
                    continue;
                }
                penalidadeOferta[i] = double.MinValue;
            }
        }
        public void SetPenalidadeDemanda()
        {
            double melhor = double.MaxValue;
            double alternativa = double.MaxValue;
            double penalidade = double.MaxValue;

            for (int i = 0; i <= 25; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    if (j == 0)
                    {
                        melhor = matriz[i, j];
                        continue;
                    }
                    if (j == 1)
                    {
                        if( melhor > matriz[i, j])
                        {
                            alternativa = melhor;
                            melhor = matriz[i, j];
                            continue;
                        }
                        alternativa = matriz[i, j];
                        continue;
                    }
                    if(melhor > matriz[i, j])
                    {
                        alternativa = melhor;
                        melhor = matriz[i, j];
                    }
                }
                if (!alternativa.Equals(double.MaxValue))
                {
                    penalidade = alternativa - melhor;
                    penalidadeDemanda[i] = penalidade;
                    continue;
                }
                penalidadeDemanda[i] = double.MinValue;
            }
        }

        public int SelecionaPenalidadeDemanda()
        {
            return Array.IndexOf(penalidadeDemanda, penalidadeDemanda.Max());
        }
        public int SelecionaPenalidadeOferta()
        {
            return Array.IndexOf(penalidadeOferta, penalidadeOferta.Max());
        }

        public void AplicarIteracao()
        {
            int indexPenalidadeOferta = SelecionaPenalidadeOferta();
            int indexPenalidadeDemanda = SelecionaPenalidadeDemanda();
            double menorValor = double.MaxValue;
            int indexPivo = 0;
            int menorValorIndex = 0;

            //Seleciona a oferta
            if (penalidadeOferta[indexPenalidadeOferta] >= penalidadeDemanda[indexPenalidadeDemanda])
            {
                indexPivo = indexPenalidadeOferta;
                for (int i = 0; i <= 25; i++)
                {
                    if (matriz[i, indexPivo] < menorValor)
                    {
                        menorValor = matriz[i, indexPivo];
                        menorValorIndex = i;
                    }
                }
                if(demanda[menorValorIndex] < oferta[indexPivo])
                {
                    oferta[indexPivo] -= demanda[menorValorIndex];
                    demanda[menorValorIndex] = 0;
                }
                else
                {
                    demanda[menorValorIndex] -= oferta[indexPivo];
                    oferta[indexPivo] = 0;
                }

                for (int i = 0; i <= 25; i++)
                {
                    if (i != menorValorIndex)
                        matriz[i, indexPivo] = double.MaxValue;
                }
                Console.Write($"X{menorValorIndex},{indexPivo} = {matriz[menorValorIndex, indexPivo]} ");

            }
            //Seleciona a demanda
            else
            {
                indexPivo = indexPenalidadeDemanda;

                for (int i = 0; i <= 5; i++)
                {
                    if (matriz[indexPivo, i] < menorValor)
                    {
                        menorValor = matriz[indexPivo, i];
                        menorValorIndex = i;
                    }
                }
                if (oferta[menorValorIndex] < demanda[indexPivo])
                {
                    demanda[indexPivo] -= oferta[menorValorIndex];
                    oferta[menorValorIndex] = 0;
                }
                else
                {
                    oferta[menorValorIndex] -= demanda[indexPivo];
                    demanda[indexPivo] = 0;
                }

                for (int i = 0; i <= 5; i++)
                {
                    if (i != menorValorIndex)
                        matriz[indexPivo, i] = double.MaxValue;
                }
                Console.WriteLine($"X{indexPivo},{menorValorIndex} = {matriz[indexPivo, menorValorIndex]} ");

            }
        }
    }

    }

