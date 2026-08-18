using FluentHtml.Forms;
using FluentHtml.Rendering;
using static FluentHtml.Forms.DragDropUploadExtensions;

namespace FluentHtml.Tests;

public class DragDropTests
{
    private readonly Renderer _renderer = new();

    [Fact]
    public void DragDropUpload_RendersDropZone()
    {
        var dd = DragDropUpload("/upload", "files");
        var html = _renderer.Render(dd);
        Assert.Contains("hx-post=\"/upload\"", html);
        Assert.Contains("hx-encoding=\"multipart/form-data\"", html);
    }

    [Fact]
    public void DragDropUpload_ContainsFileInput()
    {
        var dd = DragDropUpload("/upload", "files");
        var html = _renderer.Render(dd);
        Assert.Contains("type=\"file\"", html);
        Assert.Contains("name=\"files\"", html);
    }

    [Fact]
    public void DragDropUpload_ContainsJavaScript()
    {
        var dd = DragDropUpload("/upload", "files");
        var html = _renderer.Render(dd);
        Assert.Contains("<script>", html);
        Assert.Contains("dragover", html);
        Assert.Contains("drop", html);
    }

    [Fact]
    public void DragDropUpload_WithCustomAccept()
    {
        var dd = DragDropUpload("/upload", "files").Accept(".pdf,.docx");
        var html = _renderer.Render(dd);
        Assert.Contains("accept=\".pdf,.docx\"", html);
    }

    [Fact]
    public void DragDropUpload_WithTarget()
    {
        var dd = DragDropUpload("/upload", "files").Target("#result");
        var html = _renderer.Render(dd);
        Assert.Contains("hx-target=\"#result\"", html);
    }
}
