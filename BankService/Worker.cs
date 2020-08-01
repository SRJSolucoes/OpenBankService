using BankService.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using BankService.Services;
using BankService.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BankService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ServiceConfigurations _serviceConfigurations;

        public Worker(ILogger<Worker> logger,
            IConfiguration configuration)
        {
            _logger = logger;

            _serviceConfigurations = new ServiceConfigurations();
            new ConfigureFromConfigurationOptions<ServiceConfigurations>(
                configuration.GetSection("ServiceConfigurations"))
                    .Configure(_serviceConfigurations);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker executando em: {time}", DateTimeOffset.Now);

                // Fazer uma rorina de Schedule disso, para executar quantas vezes for schedulado por dia
                Transferencias();
                LeituradeRetorno();

                await Task.Delay(
                    _serviceConfigurations.Intervalo, stoppingToken);
            }
        }

        protected void Transferencias()
        {
            var resultado = new ResultadoProcessamento();
            resultado.Horario = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {

                APISRJService QeshAccountDetail = new APISRJService();

                QeshAccountDetail.GetAccountDetail();


                foreach (PagamentoModel pagamento in QeshAccountDetail.GetLimaPagamentosdoDiaCorrente())
                {
                    QeshAccountDetail.TED(new TEDModel());
                }

                resultado.Status = "Sucess";
                string jsonResultado = JsonConvert.SerializeObject(resultado);
                _logger.LogInformation(jsonResultado);
            }
            catch (Exception ex)
            {
                resultado.Status = "Exception";
                resultado.Exception = ex;
                string jsonResultado = JsonConvert.SerializeObject(resultado);
                _logger.LogError(jsonResultado);
            }
        }

        protected void LeituradeRetorno() { 
        }
    }
}