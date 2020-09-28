using BankService;
using BankService.Entities;
using BankService.Interfaces;
using BankService.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace SRJBancTransferForm
{
    public partial class Form1 : Form
    {
        private readonly ILogger<Worker> _logger;

        private readonly IBankService BankService = new APIBankService();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IOperadora Operator = new SRJService(tbUsuarioSRJ.Text,
                                                 tbSenhaSRJ.Text);

            IBank Bank = new QeshServices(tbUsuarioT28.Text,
                                          tbSenhaT28.Text,
                                          tbSenha4Dig.Text);

            var resultado = new ResultadoProcessamento();
            resultado.Horario = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            DayOfWeek dayOfWeek = DateTime.Now.DayOfWeek;

            if ((dayOfWeek != DayOfWeek.Saturday) && (dayOfWeek != DayOfWeek.Sunday))
            {
                try
                {
                    _logger.LogInformation("Worker executando em: {time}", DateTimeOffset.Now);

                    // Fazer uma rotina de Schedule disso, para executar quantas vezes for schedulado por dia
                    BankService.MakeDayTransfers(_logger, Operator, Bank);

                    resultado.Status = "Success";

                    //await Task.Delay(
                    //    _serviceConfigurations.Intervalo, stoppingToken);

                    string jsonResultado = JsonConvert.SerializeObject(resultado);
                }
                catch (Exception ex)
                {
                    resultado.Status = "Exception";
                    resultado.Exception = ex;
                    string jsonResultado = JsonConvert.SerializeObject(resultado);
                    _logger.LogError(jsonResultado);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
