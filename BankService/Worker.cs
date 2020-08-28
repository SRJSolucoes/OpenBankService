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
using BankService.Interfaces;

namespace BankService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ServiceConfigurations _serviceConfigurations;
        private readonly IBankService BankService = new APIBankService();

        private readonly IOperadora Operator = new SRJService();
        private readonly IBank Bank = new QeshServices();

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
                var resultado = new ResultadoProcessamento();
                resultado.Horario = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                try
                {
                    _logger.LogInformation("Worker executando em: {time}", DateTimeOffset.Now);

                    // Fazer uma rorina de Schedule disso, para executar quantas vezes for schedulado por dia
                    BankService.MakeDayTransfers(_logger, Operator, Bank);

                    resultado.Status = "Success";

                    await Task.Delay(
                        _serviceConfigurations.Intervalo, stoppingToken);

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
    }
}