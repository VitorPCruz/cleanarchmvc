using CleanArchMvc.Infra.IoC;
using System.Text.Json.Serialization;

#region Builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddControllers()
    .AddJsonOptions(j => 
        j.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region App
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
#endregion
