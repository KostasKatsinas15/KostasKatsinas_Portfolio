using KostasKatsinas.Portfolio.Services;
using KostasKatsinas.Portfolio.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<JsonFileProductService>();
builder.Services.AddControllers();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

var carouselDataService = app.Services.CreateScope().ServiceProvider.GetRequiredService<CarouselImageController>();
carouselDataService.UpdateImageDatabase();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapRazorPages();
	endpoints.MapControllers();
	endpoints.MapBlazorHub();
});

app.MapRazorPages();

app.Run();


