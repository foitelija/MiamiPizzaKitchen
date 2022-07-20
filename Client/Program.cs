global using BlazorMiamiPizza.Shared;
global using System.Net.Http.Json;
global using BlazorMiamiPizza.Client.Services.ProductService;
global using BlazorMiamiPizza.Client.Services.CategoryService;
global using BlazorMiamiPizza.Client.Services.CartService;
global using BlazorMiamiPizza.Client.Services.AuthService;
global using BlazorMiamiPizza.Client.Services.OrderService;
global using BlazorMiamiPizza.Client.Services.AddressService;
global using BlazorMiamiPizza.Client.Services.ProductTypeService;
global using Microsoft.AspNetCore.Components.Authorization;
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
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
