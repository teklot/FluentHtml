var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAntiforgery();

var app = builder.Build();

app.UseAntiforgery();

var routes = app.FluentRouting();
routes.MapGet("/", HomePage.Render);
routes.MapGet("/core", CorePage.Render);
routes.MapGet("/htmx", HtmxPage.Render);
routes.MapGet("/htmx/table", HtmxPage.RenderTable);
routes.MapGet("/htmx/alert", HtmxPage.RenderAlert);
routes.MapGet("/htmx/alert/dismiss", HtmxPage.DismissAlert);
routes.MapGet("/bootstrap", BootstrapPage.Render);
routes.MapGet("/rendering", RenderingPage.Render);
routes.MapGet("/forms", FormsPage.Render);
routes.MapPost("/forms/create", FormsPage.CreateUser);
routes.MapGet("/todo", TodoPage.Render);
routes.MapPost("/todo/add", TodoPage.AddTodo);
routes.MapPatch("/todo/toggle/{id}", TodoPage.ToggleTodo);
routes.MapDelete("/todo/delete/{id}", TodoPage.DeleteTodo);
routes.MapGet("/dashboard", DashboardPage.Render);
routes.MapGet("/customers", CrudPage.Render);
routes.MapGet("/customers/table", CrudPage.RenderCustomerTable);
routes.MapPost("/customers/create", CrudPage.CreateCustomer);
routes.MapGet("/customers/edit/{id}", CrudPage.EditCustomer);
routes.MapGet("/customers/cancel/{id}", CrudPage.CancelEdit);
routes.MapPost("/customers/update/{id}", CrudPage.UpdateCustomer);
routes.MapDelete("/customers/delete/{id}", CrudPage.DeleteCustomer);

app.Run();
