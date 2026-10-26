namespace CarSharing.WebApi.Client
{
    using System.Text.Json.Serialization;
    using CarSharing.WebApi.Common.DI;
    using CarSharing.WebApi.Common.Handlers.Exception;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.RegisterTypes(builder.Configuration);

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition   = JsonIgnoreCondition.Never;
                    options.JsonSerializerOptions.AllowDuplicateProperties = false;
                });
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddProblemDetails();
            builder.Services.AddExceptionHandler<ProblemDetailsExceptionHandler>();
            builder.Services.AddExceptionHandler<TextExceptionHandler>();

            var allowedOrigins = builder.Configuration.GetSection("CORS:AllowedOrigins").Get<string[]>();
            
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins(allowedOrigins)
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = builder.Configuration["Jwt:Authority"];
                    options.Audience  = builder.Configuration["Jwt:Audience"];
                    
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer           = true,
                        ValidateAudience         = true,
                        ValidateLifetime         = true,
                        ValidateIssuerSigningKey = true
                    };
                });
            
            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseExceptionHandler();

            app.UseStatusCodePages();

            app.UseHttpsRedirection();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseCors("AllowFrontend");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
