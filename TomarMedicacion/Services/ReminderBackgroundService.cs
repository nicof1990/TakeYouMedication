using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TomarMedicacion.Models;

namespace TomarMedicacion.Services
{
    public class ReminderBackgroundService: BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<ReminderBackgroundService> _logger;

        public ReminderBackgroundService(
            IServiceScopeFactory scopeFactory,
            ILogger<ReminderBackgroundService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(
       CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();

                    var context =
                        scope.ServiceProvider.GetRequiredService<TomarMedicacionContext>();

                    _logger.LogInformation(
                        "Checking reminders: {Time}",
                        DateTime.Now);

                    var reminders =
                        await context.Recordatorio
                            .Where(r => r.Horario.Hours == DateTime.Now.Hour && r.Horario.Minutes == DateTime.Now.Minute).ToListAsync<Recordatorio>();

                    foreach (var reminder in reminders)
                    {
                        _logger.LogInformation(
                            "Reminder found: {Name}",
                            reminder.Nombre);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,
                        "Error while checking reminders");
                }

                await Task.Delay(
                    TimeSpan.FromMinutes(1),
                    stoppingToken);
            }
        }
    }
}
