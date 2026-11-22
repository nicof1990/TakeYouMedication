
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using TomarMedicacion.Services;
using TomarMedicacion.Services.Interfaces;

namespace TomarMedicacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<TomarMedicacionContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("TomarMedicacionConexion")));

            var aa =
builder.Configuration.GetConnectionString("TomarMedicacionConexion");

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IMedicationService, MedicationService>();
            builder.Services.AddScoped<IRecordatorioService, RecordatorioService>();

            builder.Services.AddHostedService<ReminderBackgroundService>();

            builder.Services.AddSingleton<TelegramService>();

            var app = builder.Build();            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
