using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using nexti.Application.Services;
using nexti.Domain.DTOs;
using nexti.Domain.Interfaces.Repository;
using nexti.Domain.Interfaces.Service;
using nexti.Domain.Models;
using nexti.Infrastructure.Persistence.Context;
using nexti.Infrastructure.Persistence.Repositories;
namespace nexti.Config 
{ 
    public static class DependencyInjectionConfig 
    { 
        public static IServiceCollection InjectDependencies(this IServiceCollection services, IConfiguration configuration) 
        { 
            // add controllers
            services.AddControllers(); 
            services.AddEndpointsApiExplorer(); 
            services.AddSwaggerGen();

            // add dbcontext
            services.AddDbContext<NTContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Con"));
            });

            // add cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            // add servicios
            services.AddScoped<EventoService>();
            services.AddScoped<UsuarioService>();

            // implement services
            services.AddScoped<IEventoService<Evento, EventoDTO, NewEventoDTO, CreatedEventoDTO, UpdateEventoDTO>, EventoService>();
            services.AddScoped<IUsuarioService<Usuario, UsuarioDTO, NewUserDTO, CreatedUserDTO, UpdateUserDTO>, UsuarioService>();

            // add repos
            services.AddScoped<EventoRepository>();
            services.AddScoped<UsuarioRepository>();

            // implement repos
            services.AddScoped<IEventoRepository<Evento>, EventoRepository>();
            services.AddScoped<IUsuarioRepository<Usuario>, UsuarioRepository>();

            return services; 
        } 
    } 
} 
