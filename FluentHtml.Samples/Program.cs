using FluentHtml.Samples.Pages;
using Microsoft.AspNetCore.Mvc;

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
app.MapGet("/todo", TodoPage.Render);
app.MapPost("/todo/add", (HttpContext http, [FromForm] string title) => TodoPage.AddTodo(http, title));
app.MapPost("/todo/toggle/{id}", (HttpContext http, int id) => TodoPage.ToggleTodo(http, id));
app.MapDelete("/todo/delete/{id}", (HttpContext http, int id) => TodoPage.DeleteTodo(http, id));
app.MapGet("/dashboard", DashboardPage.Render);
app.MapGet("/customers", CrudPage.Render);
app.MapGet("/customers/table", () => CrudPage.RenderCustomerTable().ToHtmlResult());
app.MapPost("/customers/create", ([FromForm] string name, [FromForm] string email, [FromForm] string phone) => CrudPage.CreateCustomer(name, email, phone));
app.MapGet("/customers/edit/{id}", (int id) => CrudPage.EditCustomer(id));
app.MapGet("/customers/cancel/{id}", (int id) => CrudPage.CancelEdit(id));
app.MapPost("/customers/update/{id}", (int id, [FromForm] string name, [FromForm] string email, [FromForm] string phone) => CrudPage.UpdateCustomer(id, name, email, phone));
app.MapDelete("/customers/delete/{id}", (int id) => CrudPage.DeleteCustomer(id));

app.Run();
