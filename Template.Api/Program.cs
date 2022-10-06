using AutoWrapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Template.Api.Response;
using Template.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    }
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.RegisterAppServices();
builder.RegisterCors();
builder.RegisterJobs();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseWebCors();
app.MapControllers();

app.UseApiResponseAndExceptionWrapper<ApiResonse>(new AutoWrapperOptions
{
    ShowStatusCode = true
});

app.Run();