using FluentHtml.Samples.Pages;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAntiforgery();

var app = builder.Build();

app.UseAntiforgery();

app.MapGet("/", HomePage.Render);
app.MapGet("/core", CorePage.Render);
app.MapGet("/htmx", HtmxPage.Render);
app.MapGet("/htmx/table", HtmxPage.RenderTable);
app.MapGet("/htmx/alert", HtmxPage.RenderAlert);
app.MapGet("/htmx/alert/dismiss", HtmxPage.DismissAlert);
app.MapGet("/bootstrap", BootstrapPage.Render);
app.MapGet("/rendering", RenderingPage.Render);
app.MapGet("/forms", FormsPage.Render);
app.MapPost("/forms/create", FormsPage.CreateUser);

app.Run();
