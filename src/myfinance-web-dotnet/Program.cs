using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;
using myfinance_web_dotnet.Service;
using myfinance_web_dotnet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyFinanceDbContext>();

builder.Services.AddScoped<iPlanoContaService, PlanoContaService>();
builder.Services.AddScoped<iTransacaoService, TransacaoService>();

builder.Services.AddScoped<iRepository<PlanoConta>, RepositoryService<PlanoConta>>();
builder.Services.AddScoped<iRepository<Transacao>, RepositoryService<Transacao>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
