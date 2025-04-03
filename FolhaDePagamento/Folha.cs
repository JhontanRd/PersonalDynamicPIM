﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento
{
    public class Folha
    {
        // Terei que refatoras todo o código inserindo tratamento de erros, laços de repetição etc a todos os metodos. 
        private double SalarioBase { get; set; }
        private double Vencimentos { get; set; }
        private double SalarioLiquido { get; set; }
        private double Descontos { get; set; }
        private double DescontoDoValeTransporte { get; set; }
        private double DescontoDoValeRefeicaoAlimentacao { get; set; }
        private double DescontoDoInss { get; set; }
        private double DescontoDoIrrf { get; set; }
        private double AdiantamentoQuinzenal { get; set; }
        private double TotalDeHorasExtras { get; set; }
        private double ValorTotalDePericulosidadeInsalubridade { get; set; }
        private double ValorDoAdicionalNoturno { get; set; }
        private double DescontoDoConvenioMedico { get; set; }
        private double DescontoDoConvenioOdontologico { get; set; }
        private double DescontoTotalDeDependentes { get; set; }
        private double DescontoTotalDePensao { get; set; }
        private double DescontoDeAtrasos { get; set; }
        private double TotalDeHorasConvertidas { get; set; }
        private double DescontoDeFaltasInjustificadas { get; set; }
        private double Fgts { get; set; }
        public string MensagemIRRF { get; set; }


        public double ContabilizarValeTransporte(double salario, int dias)
        {
            double valorPorcentagem, valorPassagem, porcentagem, passagem = 9.60;
            int percentual = 6;
            try
            {
                porcentagem = (double)percentual / 100;
                valorPorcentagem = salario * porcentagem;
                valorPassagem = passagem * (double)dias;
                if (valorPorcentagem < valorPassagem)
                {
                    DescontoDoValeTransporte = valorPorcentagem;
                    return valorPorcentagem;
                }
                else
                {
                    DescontoDoValeTransporte = valorPassagem;
                    return valorPassagem;
                }
            }
            catch (Exception ex)
            {
                // Depois vou incluir uma msg de retorno com erro. 
                throw new Exception("Falha ao calcular o vale transporte." + ex);
            }
        }

        public double CalcularValeAlimentacao(double valorDoVale, int diasUteis, int percentual)
        {
            double porcentagem, descontoDoVale;
            try
            {
                porcentagem = percentual / (double)100;
                descontoDoVale = valorDoVale * (double)diasUteis * porcentagem;
                DescontoDoValeRefeicaoAlimentacao = descontoDoVale;
                return descontoDoVale;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao calcular o vale alimentação." + ex);
            }
        }

        public List<string> CalcularInss(double salarioBase)
        {
            List<string> inssFunc = new List<string>();
            try
            {
                inssFunc = FormulaDoInss(salarioBase);
                string resultadoInss = inssFunc[0];
                DescontoDoInss = Convert.ToDouble(resultadoInss);
                return inssFunc;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao realizar a operação!" + ex); ;
            }
        }

        public List<string> FormulaDoInss(double salario)
        {
            double ValorDeDescontoDoInss, faixa2, faixa3, faixa4, restante;
            double valorPadraoFaixa1 = 99.00;
            double valorPadraoFaixa2 = 112.62;
            double valorPadraoFaixa3 = 154.28;
            double valorPadraoFaixa4 = 511.06;
            List<string> dadosInss = new List<string>();

            try
            {
                if (salario <= 1320.00)
                {
                    ValorDeDescontoDoInss = salario * 0.075;
                    dadosInss.Add(ValorDeDescontoDoInss.ToString());
                    dadosInss.Add("O salário se estabelece na primeira faixa da tabela.");
                    dadosInss.Add("Desconto do INSS realizado sobre 7,5%.");
                }
                else if (salario <= 2571.29)
                {
                    restante = salario - 1320.00;
                    faixa2 = restante * 0.09;
                    ValorDeDescontoDoInss = valorPadraoFaixa1 + faixa2;
                    dadosInss.Add(ValorDeDescontoDoInss.ToString());
                    dadosInss.Add("O salário se estabelece na segunda faixa da tabela.");
                    dadosInss.Add("Desconto do INSS realizado sobre 9%");
                }
                else if (salario <= 3856.94)
                {
                    restante = salario - 2571.29;
                    faixa3 = restante * 0.12;
                    ValorDeDescontoDoInss = valorPadraoFaixa1 + valorPadraoFaixa2 + faixa3;
                    dadosInss.Add(ValorDeDescontoDoInss.ToString());
                    dadosInss.Add("O salário se estabelece na terceira faixa da tabela.");
                    dadosInss.Add("Desconto do INSS realizado sobre 12,00%");
                }
                else if (salario <= 7507.49)
                {
                    restante = salario - 3856.94;
                    faixa4 = restante * 0.14;
                    ValorDeDescontoDoInss = valorPadraoFaixa1 + valorPadraoFaixa2 + valorPadraoFaixa3 + faixa4;
                    dadosInss.Add(ValorDeDescontoDoInss.ToString());
                    dadosInss.Add("O salário se estabelece na quarta faixa da tabela.");
                    dadosInss.Add("Desconto do INSS realizado sobre 14,00%");
                }
                else
                {
                    ValorDeDescontoDoInss = valorPadraoFaixa1 + valorPadraoFaixa2 + valorPadraoFaixa3 + valorPadraoFaixa4;
                    dadosInss.Add(ValorDeDescontoDoInss.ToString());
                    dadosInss.Add("O salário não se estabelece em nenhuma faixa pois excede o teto do INSS.");
                    dadosInss.Add("Teto do INSS R$ 876.96");
                }
                return dadosInss;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao realizar a operação!" + ex);
            }
        }

        public List<string> CalcularIrrf(string salario, string inss, string pensao, string dependente)
        {

            string[] vlInss = inss.Split(' ');
            double valorDoInss = Convert.ToDouble(vlInss[0]);

            string[] vlPensao = pensao.Split(' ');
            double valorDaPensao = Convert.ToDouble(vlPensao[0]);

            string[] vlDependente = dependente.Split(' ');
            double valorDeDependente = Convert.ToDouble(vlDependente[0]);

            double salarioBase = Convert.ToDouble(salario);
            string valorDoIrrf;

            List<string> dadosIrrfFun = new List<string>();
            try
            {
                dadosIrrfFun = FormulaDoIrrf(salarioBase, valorDoInss, valorDaPensao, valorDeDependente);
                valorDoIrrf = dadosIrrfFun[0]; // vai ser a possição onde vou guardar o valor
                DescontoDoIrrf = Convert.ToDouble(valorDoIrrf);
                return dadosIrrfFun;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao realizar a operação!" + ex);
            }
        }

        public List<string> FormulaDoIrrf(double salario, double inss, double pensao, double dependente)
        {
            double deducoesLegais, descontoSimplificado, baseDeCalculoDoIrrfDefinitivo, valorDeDescontoDoIrrf = 0, percentual;
            double parcela2 = 158.40;
            double parcela3 = 370.40;
            double parcela4 = 651.73;
            double parcela5 = 884.96;
            double valorSimplificado = 528.00;

            List<string> dadosInss = new List<string>();

            try
            {
                deducoesLegais = salario - inss - pensao - dependente;
                descontoSimplificado = salario - valorSimplificado;

                if (deducoesLegais > descontoSimplificado)
                {
                    baseDeCalculoDoIrrfDefinitivo = deducoesLegais;
                    if (baseDeCalculoDoIrrfDefinitivo <= 2112.00)
                    {
                        valorDeDescontoDoIrrf = 0;
                        dadosInss.Add(valorDeDescontoDoIrrf.ToString());
                        dadosInss.Add("Calculo realizado sobre deduções legais.");
                        dadosInss.Add("A base de calculo se estabelece na primeira faixa.");
                        dadosInss.Add("Funcionário está isento do desconto de IRRF.");
                    }
                    else if (baseDeCalculoDoIrrfDefinitivo <= 2826.65)
                    {
                        percentual = 7.50 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela2;

                        dadosInss.Add(valorDeDescontoDoIrrf.ToString());
                        dadosInss.Add("Calculo realizado sobre deduções legais.");
                        dadosInss.Add("A base de calculo se estabelece na segunda faixa.");
                        dadosInss.Add("Desconto do IRRF realizado sobre 7,5%");
                    }
                    else if (baseDeCalculoDoIrrfDefinitivo <= 3751.05)
                    {
                        percentual = 15.00 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela3;
                        dadosInss.Add(valorDeDescontoDoIrrf.ToString());
                        dadosInss.Add("Calculo realizado sobre deduções legais.");
                        dadosInss.Add("A base de calculo se estabelece na terceira faixa.");
                        dadosInss.Add("Desconto do IRRF realizado sobre 15,00%");
                    }
                    else if (baseDeCalculoDoIrrfDefinitivo <= 4664.68)
                    {
                        percentual = 22.50 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela4;
                        dadosInss.Add(valorDeDescontoDoIrrf.ToString());
                        dadosInss.Add("Calculo realizado sobre deduções legais.");
                        dadosInss.Add("A base de calculo se estabelece na quarta faixa.");
                        dadosInss.Add("Desconto do IRRF realizado sobre 22,50%");
                    }
                    else
                    {
                        percentual = 27.50 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela5;
                        dadosInss.Add(valorDeDescontoDoIrrf.ToString());
                        dadosInss.Add("Calculo realizado sobre deduções legais.");
                        dadosInss.Add("A base de calculo se estabelece acima da quarta faixa.");
                        dadosInss.Add("Desconto do IRRF realizado sobre 27,50%");
                    }
                }
                else
                {
                    baseDeCalculoDoIrrfDefinitivo = descontoSimplificado;
                    if (baseDeCalculoDoIrrfDefinitivo <= 2112.00)
                    {
                        valorDeDescontoDoIrrf = 0;
                        dadosInss.Add(valorDeDescontoDoIrrf.ToString());
                        dadosInss.Add("Calculo realizado sobre o desconto simplificado.");
                        dadosInss.Add("A base de calculo se estabelece na primeira faixa.");
                        dadosInss.Add("Funcionário está isento do desconto de IRRF.");
                    }
                    else if (baseDeCalculoDoIrrfDefinitivo <= 2826.65)
                    {
                        percentual = 7.50 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela2;
                        dadosInss.Add(valorDeDescontoDoIrrf.ToString());
                        dadosInss.Add("Calculo realizado sobre o desconto simplificado.");
                        dadosInss.Add("A base de calculo se estabelece na segunda faixa.");
                        dadosInss.Add("Desconto do IRRF realizado sobre 7,5%");
                    }
                    else if (baseDeCalculoDoIrrfDefinitivo <= 3751.05)
                    {
                        percentual = 15.00 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela3;
                        dadosInss.Add(valorDeDescontoDoIrrf.ToString());
                        dadosInss.Add("Calculo realizado sobre o desconto simplificado.");
                        dadosInss.Add("A base de calculo se estabelece na terceira faixa.");
                        dadosInss.Add("Desconto do IRRF realizado sobre 15,00%");
                    }
                    else if (baseDeCalculoDoIrrfDefinitivo <= 4664.68)
                    {
                        percentual = 22.50 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela4;
                        dadosInss.Add(valorDeDescontoDoIrrf.ToString());
                        dadosInss.Add("Calculo realizado sobre o desconto simplificado.");
                        dadosInss.Add("A base de calculo se estabelece na quarta faixa.");
                        dadosInss.Add("Desconto do IRRF realizado sobre 22,50%");
                    }
                    else
                    {
                        percentual = 27.50 / 100;
                        valorDeDescontoDoIrrf = (baseDeCalculoDoIrrfDefinitivo * percentual) - parcela5;
                        dadosInss.Add(valorDeDescontoDoIrrf.ToString());
                        dadosInss.Add("Calculo realizado sobre o desconto simplificado.");
                        dadosInss.Add("A base de calculo se estabelece acima da quarta faixa.");
                        dadosInss.Add("Desconto do IRRF realizado sobre 27,50%");
                    }
                }
                return dadosInss;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao realizar a operação." + ex);
            }
        }

        public double CalcularAdiantamentoQuinzenal(double salarioBruto)
        {
            double adiantamento, porcentagem = 0.4;
            adiantamento = salarioBruto * porcentagem;
            AdiantamentoQuinzenal = adiantamento;
            return adiantamento;
        }

        public double ConversorDeMinutosEmHoras(int quantidadeDehorasFechadas, int quantidadeDeMinutos)
        {
            double totalDeMinutos, totalDeHoras;
            try
            {
                totalDeMinutos = (double)quantidadeDeMinutos / 60.0;
                totalDeHoras = (double)quantidadeDehorasFechadas + totalDeMinutos;
                TotalDeHorasConvertidas = totalDeHoras;
                return totalDeHoras;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao realizar a operação!");
            }

        }

        private double CalcularDsrSobreHorasExtras(double valor, int diasUteis, int descansosFeriados)
        {
            try
            {
                double valorDoDsr;
                valorDoDsr = (valor / (double)diasUteis) * descansosFeriados;
                return valorDoDsr;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar a operação!");
            }

        }

        public double CalcularHoraExtra(double salario, double porcentagem, double hora)
        {
            // Preciso colocar o DSR sobre horas extras nesse método
            double valorDaHoraNormal, valorDeUmaHoraExtra, valorTotalDaHoraExtra, a;
            try
            {
                valorDaHoraNormal = salario / 220;
                valorDeUmaHoraExtra = valorDaHoraNormal * porcentagem;
                a = valorDaHoraNormal + valorDeUmaHoraExtra;
                valorTotalDaHoraExtra = hora * a;
                TotalDeHorasExtras = valorTotalDaHoraExtra;
                return valorTotalDaHoraExtra;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar a operação!");
            }
        }

        public double CalcularPericulosidadeInsalubridade(double salario, int grau, string beneficio)
        {
            double valorDaPorcentagem, valorDeInsalubridade, valorDoAcrescimo = 0;
            try
            {
                switch (beneficio)
                {
                    case "periculosidade": // Aqui eu estou calculando a periculosidade.
                        valorDaPorcentagem = salario * 0.3;
                        valorDoAcrescimo = valorDaPorcentagem;
                        ValorTotalDePericulosidadeInsalubridade = valorDaPorcentagem;
                        break;

                    case "insalubridade": // Aqui eu estou calculando a insalubridade.
                        double salarioMinimo = 1320.00;
                        try
                        {
                            do
                            {
                                if (grau == 10)
                                {
                                    valorDeInsalubridade = salarioMinimo * 0.1;
                                    ValorTotalDePericulosidadeInsalubridade = valorDeInsalubridade;
                                    valorDoAcrescimo = valorDeInsalubridade;
                                }
                                else if (grau == 20)
                                {
                                    valorDeInsalubridade = salarioMinimo * 0.2;
                                    ValorTotalDePericulosidadeInsalubridade = valorDeInsalubridade;
                                    valorDoAcrescimo = valorDeInsalubridade;
                                }
                                else if (grau == 40)
                                {
                                    valorDeInsalubridade = salarioMinimo * 0.4;
                                    ValorTotalDePericulosidadeInsalubridade = valorDeInsalubridade;
                                    valorDoAcrescimo = valorDeInsalubridade;
                                }
                                else
                                {
                                    // Preciso ver como devolver um erro se cair aqui
                                }
                            } while (grau != 10 && grau != 20 && grau != 40);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Erro ao realizar a operação." + ex);
                        }

                        break;

                    default:
                        // Preciso ver como devolver um erro se cair aqui
                        break;
                }
                return valorDoAcrescimo;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao realizar a operação." + ex);
            }
        }

        public double CalcularAdicionalNoturno(double salario, double horas)
        {
            double valorHoraNormal, valorHoraAdicionalNoturno, acrescimo, adicionalNoturno;
            try
            {
                valorHoraNormal = salario / (double)220;
                acrescimo = valorHoraNormal * 0.2;
                valorHoraAdicionalNoturno = valorHoraNormal + acrescimo;
                adicionalNoturno = horas * valorHoraAdicionalNoturno;
                ValorDoAdicionalNoturno = adicionalNoturno;
                return adicionalNoturno;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public double CalcularConvenioMedico(double salario, double porcentagem)
        {
            double percentual = porcentagem / 100;
            double valorDoConvenioMedico = salario * percentual;
            DescontoDoConvenioMedico = valorDoConvenioMedico;
            return valorDoConvenioMedico;   
        }

        public double CalcularConvenioOdontologico(double salario, double porcentagem)
        {
            double percentual = porcentagem / 100;
            double valorDoConvenioOdontologico = salario * percentual;
            DescontoDoConvenioOdontologico = valorDoConvenioOdontologico;
            return valorDoConvenioOdontologico;
        }

        public double CalcularDependencia(int quantidadeDeDependentes)
        {
            double valorTotalDeDependente, valorPorDependente = 189.59;
            valorTotalDeDependente = (double)quantidadeDeDependentes * valorPorDependente;
            DescontoTotalDeDependentes = valorTotalDeDependente;
            return valorTotalDeDependente;
        }

        public double CalcularPensao()
        {
            double salarioMinimo = 1320.00, porcentagemFixada = 0.3, valorDaPensao;
            valorDaPensao = salarioMinimo * porcentagemFixada;
            DescontoTotalDePensao = valorDaPensao;
            return valorDaPensao;
        }

        public double CalcularAtraso(double salario, double horasDescontadas, int jornada)
        {
            double descontoDeAtraso;
            try
            {
                descontoDeAtraso = (salario * horasDescontadas) / (double)jornada;
                DescontoDeAtrasos = descontoDeAtraso;
                return descontoDeAtraso;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public double CalcularFaltaInjustificada(double salario, int faltas, int dsr, string mensagem, int diasUteis, int DiasNaoUteis)
        {
            double valorDoDia, descontoPorFaltas, descontoDoDsr, totalDeDesconto, reflexoDoDsr;
            try
            {
                valorDoDia = salario / 30;
                descontoPorFaltas = faltas * valorDoDia;
                descontoDoDsr = dsr * valorDoDia;
                totalDeDesconto = descontoPorFaltas + descontoDoDsr;

                if (mensagem == "Sim")
                {
                    double horaExtra = TotalDeHorasExtras;
                    reflexoDoDsr = CalcularDsrSobreHorasExtras(horaExtra, diasUteis, DiasNaoUteis);
                    totalDeDesconto = totalDeDesconto + reflexoDoDsr;
                }
                DescontoDeFaltasInjustificadas = totalDeDesconto;
                return totalDeDesconto;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public double CalcularFgts(double salario)
        {
            double fgts;
            fgts = salario * 0.08;
            Fgts = fgts;
            return fgts;
        }
        /*
        public double GerarFolhaDePagamento()
        {
            int escolha;
            double valor = 0;

            Console.WriteLine("\t---Gerando o Holerite---");
            Console.WriteLine();

            do { 
                Console.WriteLine("- Deseja gerar a folha de pagamento de forma sequencial ou selecionar os campos um a um ?");
                Console.WriteLine("- Digite [1] para sequencial.");
                Console.WriteLine("- Dígite [2] para selecionar os campos.");
                Console.Write("- Escolha...: ");
                escolha = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (escolha == 1)
                {
                    int simNao;

                    Console.WriteLine("\t\t---Modelo Sequência---");
                    Console.WriteLine();
                    Console.WriteLine("- Etapa 1");
                    Console.Write("- Informe o salário base do funcionário: R$ ");
                    SalarioBase = double.Parse(Console.ReadLine());
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 2");
                        Console.WriteLine("- O funcionario possui adiantamento quinzenal? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularAdiantamentoQuinzenal();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                AdiantamentoQuinzenal = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do { 
                        Console.WriteLine("- Etapa 3");
                        Console.WriteLine("- O funcionario possui adicional noturno? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularAdicionalNoturno();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                ValorDoAdicionalNoturno = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();


                    do
                    {
                        Console.WriteLine("- Etapa 4");
                        Console.WriteLine("- O funcionario atua sobre periculosidade ou insalubridade? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularPericulosidadeInsalubridade();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                ValorTotalDePericulosidadeInsalubridade = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 5");
                        Console.WriteLine("- O funcionario realizou horas extras este mês? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch(simNao)
                        {
                            case 1:
                                CalcularHoraExtra();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                TotalDeHorasExtras = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    // Vou deixar esta parte comentada porque será o espaço destinado para a etapa de férias.
                    /*Console.WriteLine("- Etapa 6");
                    Console.WriteLine("- O funcionario irá tirar férias este mês? Para SIM dígite [1], para NÃO dígite [2]");
                    Console.Write("- Escolha...: ");
                    simNao = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 7");
                        Console.WriteLine("- O funcionario possui vale transporte? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularValeTransporte();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                DescontoDoValeTransporte = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    }while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 8");
                        Console.WriteLine("- O funcionario possui vale refeição ou alimentação? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularValeAlimentacao();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                DescontoDoValeRefeicaoAlimentacao = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 9");
                        Console.WriteLine("- O funcionario possui convênio médico? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularConvenioMedico();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                DescontoDoConvenioMedico = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 10");
                        Console.WriteLine("- O funcionario possui convênio odontológico? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularConvenioOdontologico();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                DescontoDoConvenioOdontologico = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 11");
                        Console.WriteLine("- O funcionario possui dependentes? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularDependencia();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                DescontoTotalDeDependentes = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 12");
                        Console.WriteLine("- O funcionario teve atrasos durante o mês? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularAtrasos();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                TotalDeAtrasos = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    Console.WriteLine("- Etapa 13");
                    Console.WriteLine("- Chegou a hora de calcular o INSS.");
                    Console.WriteLine();
                    CalcularInss();
                    Console.WriteLine();
                    Console.WriteLine("- Proseguindo para a próxima etapa.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();
                    
                    do
                    {
                        Console.WriteLine("- Etapa 14");
                        Console.WriteLine("- O funcionario contribui paga pensão? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularPensao();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                DescontoTotalDePensao = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    Console.WriteLine("- Etapa 15");
                    Console.WriteLine("- Chegou a hora de calcular o IRRF.");
                    Console.WriteLine();
                    CalcularIrrf();
                    Console.WriteLine();
                    Console.WriteLine("- Proseguindo para a próxima etapa.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    do
                    {
                        Console.WriteLine("- Etapa 16");
                        Console.WriteLine("- O funcionario ira receber o décimo salário? Para SIM dígite [1], para NÃO dígite [2]");
                        Console.Write("- Escolha...: ");
                        simNao = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (simNao)
                        {
                            case 1:
                                CalcularFormulasDoDecimoTerceiro();
                                Console.WriteLine();
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            case 2:
                                ValorDoDecimoTerceiro = 0;
                                Console.WriteLine("- Proseguindo para a próxima etapa.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                break;

                            default:
                                Console.WriteLine("- Error, Opção invalida, selecione entre as opções.");
                                Console.WriteLine("- Dígite qualquer coisa para continuar.");
                                Console.ReadKey();
                                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                                Console.WriteLine();
                                break;
                        }
                    } while (simNao != 1 && simNao != 2);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    Console.WriteLine("- Etapa 17");
                    Console.WriteLine("- Chegou a hora de calcular o FGTS.");
                    Console.WriteLine();
                    CalcularFgts();
                    Console.WriteLine();
                    Console.WriteLine("- Proseguindo para a próxima etapa.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                    Console.WriteLine();

                    Console.WriteLine("- CONCLUIDO! O processo chegou ao fim.");
                    Console.WriteLine("- Para gerar a folha de pagamento dígite qualquer coisa.");
                    Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine();

                    Vencimentos = SalarioBase + AdiantamentoQuinzenal + TotalDeHorasExtras + ValorTotalDePericulosidadeInsalubridade + ValorDoAdicionalNoturno;
                    Descontos = DescontoDoValeTransporte + DescontoDoValeRefeicaoAlimentacao + DescontoDoConvenioMedico + DescontoDoConvenioOdontologico + DescontoDeAtrasos + DescontoTotalDeDependentes + DescontoTotalDePensao + DescontoDoInss + DescontoDoIrrf;
                    SalarioLiquido = Vencimentos - Descontos;

                    Console.WriteLine("Nome Do Funcionário..................................... | Cargo..................................................");
                    Console.WriteLine();
                    Console.WriteLine("Salario................................................. | Empresa................................................");
                    Console.WriteLine();
                    Console.WriteLine("Conta................................................... | Registro...............................................");
                    Console.WriteLine();
                    // Console.WriteLine($"|Férias                   | ");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("VENCIMENTOS");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine($"|Salário Base           | {SalarioBase:f2}");
                    Console.WriteLine($"|Horas Extras           | {TotalDeHorasExtras:f2}");
                    Console.WriteLine($"|Insalubridade          | {ValorTotalDePericulosidadeInsalubridade:f2}");
                    Console.WriteLine($"|Adicional Noturno      | {ValorDoAdicionalNoturno:f2}");

                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("DESCONTOS");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine($"|Adiantamento Quinzenal | {AdiantamentoQuinzenal:f2}");
                    Console.WriteLine($"|Vale Alimentação       | {DescontoDoValeRefeicaoAlimentacao:f2}");
                    Console.WriteLine($"|Convênio Médico        | {DescontoDoConvenioMedico:f2}");
                    Console.WriteLine($"|Vale Transporte        | {DescontoDoValeTransporte:f2}");
                    Console.WriteLine($"|Convênio Odontológico  | {DescontoDoConvenioOdontologico:f2}");
                    Console.WriteLine($"|Atrasos                | {DescontoDeAtrasos:f2}");
                    Console.WriteLine($"|Dependente             | {DescontoTotalDeDependentes:f2}");
                    Console.WriteLine($"|Pensão                 | {DescontoTotalDePensao:f2}");
                    Console.WriteLine($"|INSS                   | {DescontoDoInss:f2}");
                    Console.WriteLine($"|IRRF                   | {DescontoDoIrrf:f2}");
                    Console.WriteLine();

                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("TOTAIS");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine($"|VENCIMENTOS            | {Vencimentos:f2}");
                    Console.WriteLine($"|DESCONTOS              | {Descontos:f2}");
                    Console.WriteLine($"|LÍQUIDO                | {SalarioLiquido:f2}");
                    Console.WriteLine();
                    Console.WriteLine("- Precione qualquer coisa para concluir e encerrar.");
                    Console.ReadKey();
                    /* Quando a folha de pagamento do funcionario for gerada eu terei que incluir mais uma etapa que sera, gerar o recibo de férias.
                    Para isso eu vou consumir dentro do método GerarFolhaDePagamento() da classe FolhaDePagamento, o método GerarReciboDeFerias() da classe Ferias
                    e só após isso vou encerrar o processo.

                    IMPORTATNE: O método de OpcaoDeFerias() que vai ser usado dentro do método GerarFolhaDePagamento() deve ser chamado ANTES do calculo do FGTS.
                    Caso o funcionário não vá tirar ferias o sistema deve concluir o processo e gerar a folha de pagamento.
                    
                }
                else if (escolha == 2)
                {
                    Console.WriteLine("- Informe quais os atributos serão utilizados para gerar o holerite.");
                    Console.WriteLine();
                    Console.WriteLine("- Vale Transporte...........................[1]");
                    Console.WriteLine("- Vale alimentação..........................[2]");
                    Console.WriteLine("- Adiantamento Quinzenal....................[3]");
                    Console.WriteLine("- Horas Extras..............................[4]");
                    Console.WriteLine("- Periculosidade ou Insalubridade...........[5]");
                    Console.WriteLine("- Adicional Noturno.........................[6]");
                    Console.WriteLine("- Convenio Médico...........................[7]");
                    Console.WriteLine("- Convenio Odontológico.....................[8]");
                    Console.WriteLine("- Atrasos...................................[9]");
                    Console.WriteLine("- Dependencia...............................[10]");
                    Console.WriteLine("- Pensão....................................[11]");
                    Console.WriteLine("- INSS......................................[12]");
                    Console.WriteLine("- IR........................................[13]");
                    Console.WriteLine("- FGTS......................................[14]");
                }
                else
                {
                    Console.WriteLine("-Error, Opção invalida, selecione entre as opções.");
                    Console.WriteLine("- Dígite qualquer coisa para continuar.");
                    Console.ReadKey();
                    Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨ REFAÇA A OPERAÇÃO ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                    Console.WriteLine();
                }

            } while (escolha != 1 && escolha != 2);
            return valor;
        }*/
    }
}
