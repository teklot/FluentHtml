using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class TodoPage
{
    private static readonly List<TodoItem> _todos =
    [
        new(1, "Learn FluentHtml", true),
        new(2, "Build a sample app", false),
        new(3, "Write documentation", false)
    ];
    private static int _nextId = 4;

    public static IResult Render(HttpContext http)
    {
        return Layout.Page(http,
            BreadcrumbHelper.MakeBreadcrumb(("Home", "/"), ("Todo", null)),
            H1("Todo Application"),
            P("A simple todo app demonstrating HTMX partial rendering with FluentHtml.").Class("text-muted mb-4"),
            Div(
                AddForm(http),
                H4("Tasks").Class("mt-4"),
                Div(_todos.Select(t => TodoItemRow(t, http)).ToArray()).Id("todo-list").Class("list-group")
            ).Class("col-lg-8")
        ).ToHtmlResult();
    }

    public static IResult AddTodo(HttpContext http, string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Alert("Please enter a task title.").Danger().ToHtmlResult();

        var item = new TodoItem(_nextId++, title.Trim(), false);
        _todos.Add(item);
        return TodoItemRow(item, http).ToHtmlResult();
    }

    public static IResult ToggleTodo(HttpContext http, int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo is null)
            return new RawHtml("").ToHtmlResult();

        var updated = todo with { IsDone = !todo.IsDone };
        _todos[_todos.IndexOf(todo)] = updated;
        return TodoItemRow(updated, http).ToHtmlResult();
    }

    public static IResult DeleteTodo(HttpContext http, int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo is not null)
            _todos.Remove(todo);
        return new RawHtml("").ToHtmlResult();
    }

    private static FormElement AddForm(HttpContext http)
    {
        return Form(
            Div(Input().Type("text").Name("title").Placeholder("Enter a new task...").Class("form-control").Required()).Class("mb-2"),
            Btn("Add Task").Primary().Type("submit")
                .HxPost("/todo/add")
                .HxTarget("#todo-list")
                .HxSwap("beforeend")
        ).Method("post").Action("/todo/add").Antiforgery(http);
    }

    private static FormElement TodoItemRow(TodoItem todo, HttpContext http)
    {
        var itemClass = todo.IsDone
            ? "list-group-item d-flex align-items-center text-decoration-line-through text-muted"
            : "list-group-item d-flex align-items-center";

        var checkbox = Input().Type("checkbox").Class("form-check-input me-2");
        if (todo.IsDone) checkbox.Checked();

        return Form(
            checkbox
                .HxPost($"/todo/toggle/{todo.Id}")
                .HxTarget("closest form")
                .HxSwap("outerHTML"),
            Span(todo.Title).Class("flex-grow-1"),
            Btn("Delete").Danger().Small()
                .HxDelete($"/todo/delete/{todo.Id}")
                .HxTarget("closest form")
                .HxSwap("outerHTML")
        ).Method("post").Class(itemClass).Antiforgery(http);
    }

    private record TodoItem(int Id, string Title, bool IsDone);
}
