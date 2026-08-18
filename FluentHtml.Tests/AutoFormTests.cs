using FluentHtml.Enums;
using FluentHtml.Forms;
using FluentHtml.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentHtml.Tests;

public class AutoFormTests
{
    private readonly Renderer _renderer = new();

    public class SimpleModel
    {
        [Display(Name = "Full Name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        public int Age { get; set; }

        public bool IsActive { get; set; }

        public string? Notes { get; set; }
    }

    public enum Role { Admin, User, Guest }

    public class EnumModel
    {
        public Role UserRole { get; set; }
    }

    public class HiddenModel
    {
        public string Name { get; set; } = string.Empty;

        [ScaffoldColumn(false)]
        public string Secret { get; set; } = string.Empty;
    }

    [Fact]
    public void AutoForm_GeneratesFormElement()
    {
        var model = new SimpleModel();
        var form = model.AutoForm("/submit");
        var html = _renderer.Render(form);
        Assert.Contains("<form", html);
        Assert.Contains("action=\"/submit\"", html);
        Assert.Contains("method=\"post\"", html);
    }

    [Fact]
    public void AutoForm_GeneratesLabelsWithDisplayAttribute()
    {
        var model = new SimpleModel();
        var form = model.AutoForm("/submit");
        var html = _renderer.Render(form);
        Assert.Contains("Full Name", html);
        Assert.Contains("Email", html);
    }

    [Fact]
    public void AutoForm_GeneratesInputsForProperties()
    {
        var model = new SimpleModel();
        var form = model.AutoForm("/submit");
        var html = _renderer.Render(form);
        Assert.Contains("name=\"Name\"", html);
        Assert.Contains("name=\"Email\"", html);
        Assert.Contains("name=\"Age\"", html);
    }

    [Fact]
    public void AutoForm_EmailField_GeneratesEmailInput()
    {
        var model = new SimpleModel();
        var form = model.AutoForm("/submit");
        var html = _renderer.Render(form);
        Assert.Contains("type=\"email\"", html);
    }

    [Fact]
    public void AutoForm_NumberField_GeneratesNumberInput()
    {
        var model = new SimpleModel();
        var form = model.AutoForm("/submit");
        var html = _renderer.Render(form);
        Assert.Contains("type=\"number\"", html);
    }

    [Fact]
    public void AutoForm_BooleanField_GeneratesCheckbox()
    {
        var model = new SimpleModel();
        var form = model.AutoForm("/submit");
        var html = _renderer.Render(form);
        Assert.Contains("type=\"checkbox\"", html);
    }

    [Fact]
    public void AutoForm_RequiredField_HasRequiredAttribute()
    {
        var model = new SimpleModel();
        var form = model.AutoForm("/submit");
        var html = _renderer.Render(form);
        Assert.Contains("required", html);
    }

    [Fact]
    public void AutoForm_GeneratesSubmitButton()
    {
        var model = new SimpleModel();
        var form = model.AutoForm("/submit");
        var html = _renderer.Render(form);
        Assert.Contains("type=\"submit\"", html);
        Assert.Contains("Submit", html);
    }

    [Fact]
    public void AutoForm_EnumField_GeneratesSelect()
    {
        var model = new EnumModel();
        var form = model.AutoForm("/submit");
        var html = _renderer.Render(form);
        Assert.Contains("<select", html);
        Assert.Contains("Admin", html);
        Assert.Contains("User", html);
    }

    [Fact]
    public void AutoForm_WithExclude()
    {
        var model = new SimpleModel();
        var form = model.AutoForm("/submit", MethodType.Post, null, c => c.Exclude(m => m.Notes));
        var html = _renderer.Render(form);
        Assert.DoesNotContain("name=\"Notes\"", html);
    }

    [Fact]
    public void AutoForm_WithCustomSubmitText()
    {
        var model = new SimpleModel();
        var form = model.AutoForm("/submit", MethodType.Post, null, c => c.SubmitText = "Create");
        var html = _renderer.Render(form);
        Assert.Contains("Create", html);
    }

    [Fact]
    public void AutoForm_WithHTMX()
    {
        var model = new SimpleModel();
        var form = model.AutoForm("/submit", MethodType.Post, hx =>
        {
            hx.Target = "#results";
            hx.Swap = "innerHTML";
        });
        var html = _renderer.Render(form);
        Assert.Contains("hx-target=\"#results\"", html);
        Assert.Contains("hx-swap=\"innerHTML\"", html);
    }
}
