using GeekShopping.Frontend.WebApp.Services;
using GeekShopping.Frontend.WebApp.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddHttpClient<IProductService, ProductService>(
    c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ProductAPI"])     
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
