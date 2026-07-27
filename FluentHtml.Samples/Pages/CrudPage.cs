using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class CrudPage
{
    private static readonly List<Customer> _customers =
    [
        new(1, "Alice Johnson", "alice@example.com", "555-0101"),
        new(2, "Bob Smith", "bob@example.com", "555-0102"),
        new(3, "Charlie Brown", "charlie@example.com", "555-0103"),
        new(4, "Diana Prince", "diana@example.com", "555-0104")
    ];
    private static int _nextId = 5;

    public static IResult Render(HttpContext http)
    {
        return Layout.Page(http,
            BreadcrumbHelper.MakeBreadcrumb(("Home", "/"), ("Customers", null)),
            H1("Customer Management").Class("mb-4"),
            Div(
                Div(
                    Card(
                        CardHeader(H4("Add New Customer")),
                        CardBody(CreateForm(http))
                    )
                ).Class("col-lg-4 mb-4"),
                Div(
                    Card(
                        CardHeader(H4("Customers")),
                        CardBody(RenderCustomerTable())
                    )
                ).Class("col-lg-8 mb-4")
            ).Class("row")
        ).ToHtmlResult();
    }

    public static Node CreateForm(HttpContext http)
    {
        return Form(
            Div(Label("Name").Class("form-label"), Input().Type("text").Name("name").Placeholder("Full name").Class("form-control")).Class("mb-3"),
            Div(Label("Email").Class("form-label"), Input().Type("email").Name("email").Placeholder("email@example.com").Class("form-control")).Class("mb-3"),
            Div(Label("Phone").Class("form-label"), Input().Type("tel").Name("phone").Placeholder("555-0100").Class("form-control")).Class("mb-3"),
            Btn("Create Customer").Primary().Type("submit")
        ).Method("post")
            .HxPost("/customers/create")
            .HxTarget("#customer-table")
            .HxSwap("beforeend")
            .Id("create-form")
            .Antiforgery(http);
    }

    public static Node RenderCustomerTable()
    {
        return Table(
            new TheadElement(new TrElement(
                new ThElement("ID"), new ThElement("Name"), new ThElement("Email"), new ThElement("Phone"), new ThElement("Actions")
            )),
            new TbodyElement(_customers.Select(RenderCustomerRow).ToArray()).Id("customer-table")
        ).Class("table table-striped table-hover");
    }

    public static IResult CreateCustomer(string name, string email, string phone)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            return new RawHtml("").ToHtmlResult();

        var customer = new Customer(_nextId++, name, email, phone ?? "");
        _customers.Add(customer);
        return RenderCustomerRow(customer).ToHtmlResult();
    }

    public static IResult EditCustomer(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer is null)
            return new RawHtml("").ToHtmlResult();

        return new TrElement(
            new TdElement(customer.Id.ToString()),
            new TdElement(Input().Type("text").Value(customer.Name).Name("name").Class("form-control form-control-sm")),
            new TdElement(Input().Type("email").Value(customer.Email).Name("email").Class("form-control form-control-sm")),
            new TdElement(Input().Type("tel").Value(customer.Phone).Name("phone").Class("form-control form-control-sm")),
            new TdElement(
                Btn("Save").Success().Small()
                    .HxPost($"/customers/update/{customer.Id}")
                    .HxTarget("closest tr")
                    .HxSwap("outerHTML")
                    .HxInclude("#create-form input[type='hidden'], .table-active input"),
                new SpanElement(" "),
                Btn("Cancel").Secondary().Small()
                    .HxGet($"/customers/cancel/{customer.Id}")
                    .HxTarget("closest tr")
                    .HxSwap("outerHTML")
            )
        ).Class("table-active").Id($"row-{id}").ToHtmlResult();
    }

    public static IResult CancelEdit(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer is null)
            return new RawHtml("").ToHtmlResult();
        return RenderCustomerRow(customer).ToHtmlResult();
    }

    public static IResult UpdateCustomer(int id, string name, string email, string phone)
    {
        var index = _customers.FindIndex(c => c.Id == id);
        if (index < 0)
            return new RawHtml("").ToHtmlResult();

        var updated = _customers[index] with { Name = name, Email = email, Phone = phone ?? "" };
        _customers[index] = updated;
        return RenderCustomerRow(updated).ToHtmlResult();
    }

    public static IResult DeleteCustomer(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer is not null)
            _customers.Remove(customer);

        return new RawHtml("").ToHtmlResult();
    }

    private static Node RenderCustomerRow(Customer c)
    {
        return new TrElement(
            new TdElement(c.Id.ToString()),
            new TdElement(c.Name),
            new TdElement(c.Email),
            new TdElement(c.Phone),
            new TdElement(
                Btn("Edit").Warning().Small()
                    .HxGet($"/customers/edit/{c.Id}")
                    .HxTarget("closest tr")
                    .HxSwap("outerHTML"),
                new SpanElement(" "),
                Btn("Delete").Danger().Small()
                    .HxDelete($"/customers/delete/{c.Id}")
                    .HxTarget("closest tr")
                    .HxSwap("outerHTML")
                    .HxConfirm("Are you sure you want to delete this customer?")
            )
        );
    }

    private record Customer(int Id, string Name, string Email, string Phone);
}
