global using BlazorMiamiPizza.Shared;
global using System.Net.Http.Json;
global using BlazorMiamiPizza.Client.Services.ProductService;
global using BlazorMiamiPizza.Client.Services.CategoryService;
global using BlazorMiamiPizza.Client.Services.CartService;
global using BlazorMiamiPizza.Client.Services.AuthService;
using Blazored.LocalStorage;
using BlazorMiamiPizza.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();

await builder.Build().RunAsync();
