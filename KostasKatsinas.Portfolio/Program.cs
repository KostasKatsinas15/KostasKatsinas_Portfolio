using KostasKatsinas.Portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<CarouselImageService>();

var app = builder.Build();

var carouselImageService = app.Services.CreateScope().ServiceProvider.GetRequiredService<CarouselImageService>();
carouselImageService.UpdateImageDatabase();

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
	endpoints.MapBlazorHub();
});

app.MapRazorPages();

app.Run();


