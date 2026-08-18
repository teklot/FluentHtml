using FluentHtml.Forms;
using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class UploadPage
{
    public class UploadModel
    {
        public string Document { get; set; } = string.Empty;
    }

    public static IResult Render(HttpContext http)
    {
        var model = new UploadModel();

        var page = Layout.Page(http,
            H1("File Upload"),
            P("File upload helpers including drag-and-drop support."),
            Hr(),

            Div(
                Div(
                    Card(
                        CardHeader("Basic File Upload"),
                        CardBody(
                            model.FileInputGroup(m => m.Document, label: "Choose a file", accept: ".pdf,.doc,.txt")
                        )
                    )
                ).Class("col-md-6 mb-4"),
                Div(
                    Card(
                        CardHeader("Drag & Drop Upload"),
                        CardBody(
                            DragDropUpload("/upload", "files", "Drop files here or click to browse")
                                .Accept(".pdf,.doc,.jpg,.png")
                                .Target("#upload-result")
                                .DropZoneClass("border border-2 border-dashed rounded p-5 text-center")
                        )
                    )
                ).Class("col-md-6 mb-4")
            ).Class("row"),

            Div().Id("upload-result"),

            H2("Features"),
            Ul(
                Li("FileInputFor with accept filters and multiple file support"),
                Li("FileInputGroup with optional label"),
                Li("DragDropUpload with HTMX-powered server upload"),
                Li("Configurable accepted file types"),
                Li("Minimal inline JavaScript for drag/drop events")
            )
        );

        return page.ToHtmlResult();
    }
}
