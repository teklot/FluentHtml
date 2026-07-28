using System.ComponentModel.DataAnnotations;
using FluentHtml.Forms;
using FluentHtml.Rendering;

namespace FluentHtml.Tests;

public class FormsTests
{
    private readonly Renderer _renderer = new();

    private class TestModel
    {
        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        [Display(Name = "Is Active User")]
        public bool IsActive { get; set; }
    }

    [Fact]
    public void ModelExpression_ExtractsPropertyName_And_DisplayName()
    {
        var model = new TestModel();
        var exprName = ModelExpression.For<TestModel>(m => m.Name);
        var exprAge = ModelExpression.For<TestModel>(m => m.Age);

        Assert.Equal("Name", exprName.PropertyName);
        Assert.Equal("Name", exprName.HtmlFieldName);
        Assert.Equal("Full Name", exprName.DisplayName);

        Assert.Equal("Age", exprAge.PropertyName);
        Assert.Equal("Age", exprAge.DisplayName);
    }

    [Fact]
    public void ModelExpression_ThrowsForInvalidExpression()
    {
        var expr = new ModelExpression<TestModel>(m => m.ToString());
        Assert.Throws<InvalidOperationException>(() => expr.PropertyName);
    }

    [Fact]
    public void InputFor_GeneratesTextInput()
    {
        var model = new TestModel();
        var input = model.InputFor(m => m.Name);
        var html = _renderer.Render(input);

        Assert.Contains("type=\"text\"", html);
        Assert.Contains("name=\"Name\"", html);
        Assert.Contains("id=\"Name\"", html);
        Assert.Contains("class=\"form-control\"", html);
    }

    [Fact]
    public void InputFor_WithType_GeneratesCustomTypeInput()
    {
        var model = new TestModel();
        var input = model.InputFor(m => m.Name, "email");
        var html = _renderer.Render(input);

        Assert.Contains("type=\"email\"", html);
        Assert.Contains("name=\"Name\"", html);
    }

    [Fact]
    public void LabelFor_GeneratesLabelElement()
    {
        var model = new TestModel();
        var label = model.LabelFor(m => m.Name);
        var html = _renderer.Render(label);

        Assert.Contains("<label", html);
        Assert.Contains("for=\"Name\"", html);
        Assert.Contains("class=\"form-label\"", html);
        Assert.Contains("Full Name</label>", html);
    }

    [Fact]
    public void TextAreaFor_GeneratesTextareaElement()
    {
        var model = new TestModel();
        var textarea = model.TextAreaFor(m => m.Description, rows: 6, cols: 40);
        var html = _renderer.Render(textarea);

        Assert.Contains("<textarea", html);
        Assert.Contains("name=\"Description\"", html);
        Assert.Contains("id=\"Description\"", html);
        Assert.Contains("rows=\"6\"", html);
        Assert.Contains("cols=\"40\"", html);
        Assert.Contains("class=\"form-control\"", html);
    }

    [Fact]
    public void SelectFor_GeneratesSelectElementWithOptions()
    {
        var model = new TestModel();
        SelectListItem[] items =
        [
            new() { Text = "United States", Value = "US" },
            new() { Text = "Canada", Value = "CA", Selected = true }
        ];

        var select = model.SelectFor(m => m.Country, items);
        var html = _renderer.Render(select);

        Assert.Contains("<select", html);
        Assert.Contains("name=\"Country\"", html);
        Assert.Contains("class=\"form-select\"", html);
        Assert.Contains("<option value=\"US\">United States</option>", html);
        Assert.Contains("<option value=\"CA\" selected>", html);
    }

    [Fact]
    public void CheckboxFor_And_CheckboxLabelFor_GenerateCheckboxElements()
    {
        var model = new TestModel();
        var checkbox = model.CheckboxFor(m => m.IsActive);
        var labelDefault = model.CheckboxLabelFor(m => m.IsActive);
        var labelCustom = model.CheckboxLabelFor(m => m.IsActive, "Active Status");

        var htmlCheckbox = _renderer.Render(checkbox);
        var htmlDefault = _renderer.Render(labelDefault);
        var htmlCustom = _renderer.Render(labelCustom);

        Assert.Contains("type=\"checkbox\"", htmlCheckbox);
        Assert.Contains("class=\"form-check-input\"", htmlCheckbox);

        Assert.Contains("class=\"form-check-label\"", htmlDefault);
        Assert.Contains("Is Active User</label>", htmlDefault);

        Assert.Contains("Active Status</label>", htmlCustom);
    }

    [Fact]
    public void SubmitButton_GeneratesSubmitButtons()
    {
        var defaultBtn = FluentFormExtensions.SubmitButton();
        var customBtn = FluentFormExtensions.SubmitButton("Save Changes", "btn btn-success");

        var htmlDefault = _renderer.Render(defaultBtn);
        var htmlCustom = _renderer.Render(customBtn);

        Assert.Contains("type=\"submit\"", htmlDefault);
        Assert.Contains("class=\"btn btn-primary\"", htmlDefault);
        Assert.Contains("Submit</button>", htmlDefault);

        Assert.Contains("type=\"submit\"", htmlCustom);
        Assert.Contains("class=\"btn btn-success\"", htmlCustom);
        Assert.Contains("Save Changes</button>", htmlCustom);
    }
}
