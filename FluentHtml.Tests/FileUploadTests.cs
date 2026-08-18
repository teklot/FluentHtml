using FluentHtml.Forms;
using FluentHtml.Rendering;

namespace FluentHtml.Tests;

public class FileUploadTests
{
    private readonly Renderer _renderer = new();

    public class UploadModel
    {
        public string Avatar { get; set; } = string.Empty;
        public string Documents { get; set; } = string.Empty;
    }

    [Fact]
    public void FileInputFor_GeneratesFileInput()
    {
        var model = new UploadModel();
        var input = model.FileInputFor(m => m.Avatar);
        var html = _renderer.Render(input);
        Assert.Contains("type=\"file\"", html);
        Assert.Contains("name=\"Avatar\"", html);
    }

    [Fact]
    public void FileInputFor_WithMultiple()
    {
        var model = new UploadModel();
        var input = model.FileInputFor(m => m.Documents, multiple: true);
        var html = _renderer.Render(input);
        Assert.Contains("multiple", html);
    }

    [Fact]
    public void FileInputFor_WithAcceptFilter()
    {
        var model = new UploadModel();
        var input = model.FileInputFor(m => m.Avatar, accept: ".jpg,.png");
        var html = _renderer.Render(input);
        Assert.Contains("accept=\".jpg,.png\"", html);
    }

    [Fact]
    public void FileInputGroup_WithLabel()
    {
        var model = new UploadModel();
        var group = model.FileInputGroup(m => m.Avatar, label: "Upload Photo");
        var html = _renderer.Render(group);
        Assert.Contains("Upload Photo", html);
        Assert.Contains("type=\"file\"", html);
    }
}
