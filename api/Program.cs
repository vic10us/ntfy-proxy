using api.Features.Ntfy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.Configure<NtfyOptions>
    (builder.Configuration.GetSection(NtfyOptions.ConfigurationSection));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INtfyClient, NtfyClient>();

builder.Services.AddHttpClient<NtfyClient>("Ntfy", client => {
    var section = builder.Configuration.GetSection(NtfyOptions.ConfigurationSection);
    var options = section.Get<NtfyOptions>();
    client.BaseAddress = new Uri(options.ServerUrl);
    if (!string.IsNullOrWhiteSpace(options.ApiKey))
    {
        client.DefaultRequestHeaders.Add("X-Api-Key", options.ApiKey);
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
