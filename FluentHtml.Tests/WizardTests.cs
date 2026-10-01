using FluentHtml.Rendering;
using static FluentHtml.Bootstrap.Components.WizardExtensions;

namespace FluentHtml.Tests;

public class WizardTests
{
    private readonly Renderer _renderer = new();

    private static FluentHtml.Bootstrap.Components.WizardComponent BuildWizard() =>
        Wizard()
            .Id("wizard")
            .Step("Account", new FluentHtml.Elements.ParagraphElement("Step one"))
            .Step("Profile", "/wizard/profile")
            .Step("Review")
            .FinishHxPost("/wizard/complete");

    [Fact]
    public void Wizard_Renders_Root_Container()
    {
        var html = _renderer.Render(BuildWizard());
        Assert.Contains("id=\"wizard\"", html);
        Assert.Contains("wizard", html);
    }

    [Fact]
    public void Wizard_Renders_Step_Indicator_With_Nav_Tabs()
    {
        var html = _renderer.Render(BuildWizard());
        Assert.Contains("nav nav-tabs wizard-steps", html);
        Assert.Contains("wizard-step", html);
    }

    [Fact]
    public void Wizard_Renders_All_Step_Titles()
    {
        var html = _renderer.Render(BuildWizard());
        Assert.Contains("Account", html);
        Assert.Contains("Profile", html);
        Assert.Contains("Review", html);
    }

    [Fact]
    public void Wizard_Renders_Panel_With_Derived_Id()
    {
        var html = _renderer.Render(BuildWizard());
        Assert.Contains("id=\"wizard-panel\"", html);
        Assert.Contains("wizard-panel", html);
    }

    [Fact]
    public void Wizard_Renders_Inline_Step_Content_In_Panel()
    {
        var html = _renderer.Render(BuildWizard());
        Assert.Contains("Step one", html);
    }

    [Fact]
    public void Wizard_Panel_Does_Not_Load_Inline_Active_Step()
    {
        var html = _renderer.Render(BuildWizard());
        Assert.DoesNotContain("hx-trigger=\"load\"", html);
    }

    [Fact]
    public void Wizard_Emits_Step_Metadata_For_Client_State()
    {
        // Navigation is client-side, so the server must describe every step; otherwise locked
        // steps and Back/Next/Finish stay frozen at the server-rendered step.
        var html = _renderer.Render(BuildWizard());

        Assert.Contains("data-wizard-linear=\"true\"", html);
        Assert.Contains("data-wizard-current=\"0\"", html);
        Assert.Contains("data-wizard-url-1=\"/wizard/profile\"", html);
    }

    [Fact]
    public void Wizard_Renders_Nav_Roles_For_Every_Footer_Button()
    {
        var html = _renderer.Render(BuildWizard());

        Assert.Contains("data-wizard-nav=\"prev\"", html);
        Assert.Contains("data-wizard-nav=\"next\"", html);
        Assert.Contains("data-wizard-nav=\"finish\"", html);
    }

    [Fact]
    public void Wizard_Hides_Finish_Until_Last_Step()
    {
        var html = _renderer.Render(BuildWizard());
        var finishIndex = html.IndexOf("data-wizard-nav=\"finish\"", StringComparison.Ordinal);

        Assert.True(finishIndex > 0);
        Assert.Contains("display: none;", html.Substring(finishIndex, 80));
    }

    [Fact]
    public void Wizard_Does_Not_Bake_Htmx_Attributes_On_Panel()
    {
        // URL-backed content is fetched by the wizard script, so nothing on the panel may carry a
        // stale hx-get; baked attributes would survive navigation and refetch the wrong step.
        var wizard = Wizard()
            .Id("w")
            .Step("One", "/step/one")
            .Step("Two", "/step/two");

        var html = _renderer.Render(wizard);

        Assert.DoesNotContain("hx-get", html);
        Assert.DoesNotContain("hx-trigger", html);
    }

    [Fact]
    public void Wizard_Include_Is_Emitted_As_Client_Metadata()
    {
        var wizard = Wizard()
            .Id("w")
            .Step("One", new FluentHtml.Elements.ParagraphElement("First"))
            .Step("Two", "/step/two")
            .Include("#billing");

        var html = _renderer.Render(wizard);

        Assert.Contains("data-wizard-include=\"#billing\"", html);
    }

    [Fact]
    public void Wizard_Marks_Active_Step_With_Aria_Current()
    {
        var html = _renderer.Render(BuildWizard());
        Assert.Contains("aria-current=\"step\"", html);
        Assert.Contains("active", html);
    }

    [Fact]
    public void Wizard_Linear_Disables_Steps_After_Active()
    {
        var html = _renderer.Render(BuildWizard());
        Assert.Contains("disabled", html);
    }

    [Fact]
    public void Wizard_Last_Step_Keeps_Back_But_Hides_Next()
    {
        var wizard = Wizard()
            .Id("w")
            .Step("One", "/step/one")
            .Step("Two", "/step/two")
            .ActiveStep(1);

        var html = _renderer.Render(wizard);

        // Back stays available so a user can correct an earlier step from the review page.
        var prevStart = html.IndexOf("data-wizard-nav=\"prev\"", StringComparison.Ordinal);
        var nextStart = html.IndexOf("data-wizard-nav=\"next\"", StringComparison.Ordinal);
        Assert.True(prevStart >= 0 && nextStart > prevStart, "footer should render Back before Next");
        Assert.DoesNotContain("display: none;", html[prevStart..nextStart]);

        // Next has nothing left to advance to, so it is hidden in favour of Finish.
        Assert.Contains("display: none;", html[nextStart..html.IndexOf("data-wizard-nav=\"finish\"", StringComparison.Ordinal)]);
    }

    [Fact]
    public void Wizard_Finish_Uses_Collected_Values_Not_Just_Visible_Fields()
    {
        // hx-include can only reach fields currently in the DOM, and a swapped-out step's fields
        // are gone. The finish request must ask the wizard for everything it collected.
        var wizard = Wizard()
            .Id("signup-wizard")
            .Step("One", "/step/one")
            .Step("Two", "/step/two")
            .Include("[name=email]")
            .FinishHxPost("/step/done");

        var html = _renderer.Render(wizard);

        // Neither hx-include nor hx-vals can express "every step's values": both resolve against
        // the DOM at request time. The script issues the request from its own value store instead.
        Assert.DoesNotContain("hx-include", html);
        Assert.DoesNotContain("hx-vals", html);
        Assert.DoesNotContain("hx-post", html);
        Assert.Contains("data-wizard-finish-method=\"POST\"", html);
        Assert.Contains("data-wizard-finish-url=\"/step/done\"", html);
    }

    [Fact]
    public void Wizard_Label_Is_Padded_And_Counted_By_Script()
    {
        var wizard = Wizard()
            .Id("w")
            .Step("One", "/step/one")
            .Step("Two", "/step/two")
            .Label("Step 1 of 2");

        var html = _renderer.Render(wizard);

        Assert.Contains("wizard-label text-muted small mt-2 mb-2", html);
        // The server value is only the initial text; the script keeps "Step M of N" accurate.
        Assert.Contains("'Step ' + (index + 1) + ' of ' + count", html);
    }

    [Fact]
    public void Wizard_Keeps_Collected_Values_Across_Swaps()
    {
        // Navigating swaps the panel and destroys the current step's fields, so the script must
        // hold collected values for the wizard's lifetime and restore them on the way back.
        var html = _renderer.Render(BuildWizard());

        Assert.Contains("__wizardValues", html);
        Assert.Contains("function restore(root)", html);
        Assert.Contains("function collect(root)", html);
    }

    [Fact]
    public void Wizard_NonLinear_Does_Not_Disable_Future_Steps()
    {
        var wizard = Wizard()
            .Id("wizard")
            .Step("One", "/wizard/one")
            .Step("Two", "/wizard/two")
            .ActiveStep(1)
            .Linear(false);

        var html = _renderer.Render(wizard);

        // Back must not be disabled (we are past step 0) and no step link may be locked.
        Assert.DoesNotContain("aria-disabled=\"true\"", html);
        Assert.DoesNotContain("nav-link wizard-step-link\" disabled", html);

        // Exactly one step is current; the rest must not claim to be.
        Assert.Equal(1, CountOccurrences(html, "aria-current=\"step\""));
    }

    [Fact]
    public void Wizard_Hx_Step_Exposes_Url_For_Client_Fetch()
    {
        // URL-backed steps are fetched by the wizard script from this metadata rather than from
        // baked hx-* attributes, which would survive navigation and refetch the wrong step.
        var html = _renderer.Render(BuildWizard());

        Assert.Contains("data-wizard-url-1=\"/wizard/profile\"", html);
        Assert.Contains("data-wizard-step=\"1\"", html);
    }

    private static int CountOccurrences(string haystack, string needle)
    {
        var count = 0;
        var index = 0;
        while ((index = haystack.IndexOf(needle, index, StringComparison.Ordinal)) >= 0)
        {
            count++;
            index += needle.Length;
        }

        return count;
    }

    [Fact]
    public void Wizard_Linear_Marks_Future_Steps_Not_Current()
    {
        var html = _renderer.Render(BuildWizard());
        Assert.Contains("aria-current=\"false\"", html);
    }

    [Fact]
    public void Wizard_Hx_Step_Renders_Htmx_Attributes()
    {
        var html = _renderer.Render(BuildWizard());
        Assert.Contains("data-wizard-url-1=\"/wizard/profile\"", html);
    }

    [Fact]
    public void Wizard_Renders_Back_And_Next_Buttons()
    {
        var html = _renderer.Render(BuildWizard());
        Assert.Contains("Back", html);
        Assert.Contains("Next", html);
    }

    [Fact]
    public void Wizard_First_Step_Disables_Back()
    {
        var html = _renderer.Render(BuildWizard());
        Assert.Contains("btn-outline-secondary", html);
    }

    [Fact]
    public void Wizard_Last_Step_Renders_Finish()
    {
        var wizard = Wizard()
            .Id("wizard")
            .Step("One")
            .Step("Two")
            .ActiveStep(1);

        var html = _renderer.Render(wizard);
        Assert.Contains("Finish", html);
    }

    [Fact]
    public void Wizard_Omits_Finish_Button_When_No_Action_Configured()
    {
        // Without FinishHref or FinishHx* there is nothing the button could do, so it must not be
        // rendered at all rather than appear and silently fail.
        var wizard = Wizard()
            .Id("wizard")
            .Step("One", "/wizard/one")
            .Step("Two", "/wizard/two");

        var html = _renderer.Render(wizard);

        // Scope to the footer: the embedded script contains the same selector string.
        var footer = html[html.IndexOf("wizard-footer", StringComparison.Ordinal)..];
        Assert.DoesNotContain("data-wizard-nav=\"finish\"", footer[..footer.IndexOf("<script", StringComparison.Ordinal)]);
        Assert.Contains("data-wizard-nav=\"next\"", footer);
    }

    [Fact]
    public void Wizard_Finish_HxPost_Renders_Client_Metadata()
    {
        var wizard = Wizard()
            .Id("wizard")
            .Step("One")
            .ActiveStep(0)
            .FinishHxPost("/wizard/complete");

        var html = _renderer.Render(wizard);

        Assert.Contains("data-wizard-finish-method=\"POST\"", html);
        Assert.Contains("data-wizard-finish-url=\"/wizard/complete\"", html);
    }

    [Fact]
    public void Wizard_Finish_Clears_Navigation_When_Completed()
    {
        // Once finished the flow is over: Back and Next no longer apply, and the panel holds the
        // completion response.
        var html = _renderer.Render(BuildWizard());

        Assert.Contains("function finish(root, button)", html);
        Assert.Contains("data-wizard-finished", html);
        Assert.Contains("htmx.ajax(method, url, {", html);
    }

    [Fact]
    public void Wizard_Custom_Button_Texts_Are_Rendered()
    {
        var wizard = Wizard()
            .Id("wizard")
            .Step("One", "/wizard/one")
            .Step("Two", "/wizard/two")
            .PrevText("Previous")
            .NextText("Continue");

        var html = _renderer.Render(wizard);
        Assert.Contains("Previous", html);
        Assert.Contains("Continue", html);
    }

    [Fact]
    public void Wizard_Label_Is_Rendered_When_Set()
    {
        var wizard = Wizard().Id("wizard").Step("One").Label("Step 1 of 1");
        var html = _renderer.Render(wizard);
        Assert.Contains("Step 1 of 1", html);
    }

    [Fact]
    public void Wizard_Renders_All_Inline_Step_Panes()
    {
        // Every inline step is rendered so navigation between them is a client-side toggle.
        var wizard = Wizard()
            .Id("wizard")
            .Step("One", new FluentHtml.Elements.ParagraphElement("First"))
            .Step("Two", new FluentHtml.Elements.ParagraphElement("Second"))
            .Step("Three", new FluentHtml.Elements.ParagraphElement("Third"));

        var html = _renderer.Render(wizard);

        Assert.Contains("wizard-step-1", html);
        Assert.Contains("wizard-step-2", html);
        Assert.Contains("wizard-step-3", html);
    }

    [Fact]
    public void Wizard_Inline_Next_Button_Is_Not_Disabled()
    {
        // Inline steps have no URL, so disabling Next on a missing URL would make inline
        // wizards permanently stuck on step one.
        var html = _renderer.Render(BuildWizard());

        Assert.DoesNotContain("disabled class=\"btn btn-primary\"", html);
        Assert.Contains("data-wizard-nav=\"next\"", html);
    }

    [Fact]
    public void Wizard_Step_Links_Carry_Target_Index()
    {
        var html = _renderer.Render(BuildWizard());

        Assert.Contains("data-wizard-step=\"0\"", html);
        Assert.Contains("data-wizard-step=\"1\"", html);
        Assert.Contains("data-wizard-step=\"2\"", html);
    }

    [Fact]
    public void Wizard_Non_Linear_Does_Not_Lock_Steps()
    {
        var wizard = Wizard()
            .Id("wizard")
            .Step("One", new FluentHtml.Elements.ParagraphElement("First"))
            .Step("Two", new FluentHtml.Elements.ParagraphElement("Second"))
            .Linear(false);

        var html = _renderer.Render(wizard);

        Assert.Contains("data-wizard-linear=\"false\"", html);
        Assert.DoesNotContain("aria-disabled=\"true\"", html);
    }

    [Fact]
    public void Wizard_Script_Honours_Step_Rejection()
    {
        // A step endpoint rejects by marking its root with data-wizard-reject; the indicator must
        // then return to the originating step so errors appear on the tab the user came from.
        var html = _renderer.Render(BuildWizard());

        Assert.Contains("data-wizard-reject", html);
        Assert.Contains("htmx:afterSwap", html);
    }

    [Fact]
    public void Wizard_Renders_Navigation_Script()
    {
        var html = _renderer.Render(BuildWizard());

        Assert.Contains("__fluentHtmlWizard", html);
        Assert.Contains("data-wizard-nav", html);
    }

    [Fact]
    public void Wizard_Throws_When_Id_Missing()
    {
        var wizard = Wizard().Step("One");
        Assert.Throws<InvalidOperationException>(() => _renderer.Render(wizard));
    }

    [Fact]
    public void Wizard_Throws_When_No_Steps()
    {
        var wizard = Wizard().Id("wizard");
        Assert.Throws<InvalidOperationException>(() => _renderer.Render(wizard));
    }

    [Fact]
    public void Wizard_Throws_When_ActiveStep_Out_Of_Range()
    {
        var wizard = Wizard().Id("wizard").Step("One").ActiveStep(5);
        Assert.Throws<InvalidOperationException>(() => _renderer.Render(wizard));
    }
}
