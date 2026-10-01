using FluentHtml.Samples.Components;

namespace FluentHtml.Samples.Pages;

public static class WizardPage
{
    public static IResult Render(HttpContext http)
    {
        return Layout.Page(http,
            BreadcrumbHelper.MakeBreadcrumb(("Home", "/"), ("Wizard", null)),
            H1("Wizard"),
            P("Linear multi-step flows. Steps backed by a URL load their panel over HTMX, and validation happens server-side."),

            SectionHelper.ShowSection("HTMX Steps", Wizard()
                .Id("signup-wizard")
                .Step("Account", "/wizard/step/account")
                .Step("Profile", "/wizard/step/profile")
                .Step("Review", "/wizard/step/review")
                .Label("Step 1 of 3")
                .Include("[name=email],[name=name]")
                .FinishHxPost("/wizard/step/complete")),

            SectionHelper.ShowSection("Inline Steps", Wizard()
                .Id("inline-wizard")
                // Both labels are btn-outline-primary so Bootstrap's btn-check styling can show the
                // selection; a filled btn-primary would look selected either way.
                .Step("Choose a plan",
                    P("Select the plan that fits your team."),
                    new DivElement(
                        new InputElement().Type("radio").Name("plan").Id("plan-starter")
                            .Value("starter").Class("btn-check"),
                        new LabelElement("Starter").For("plan-starter").Class("btn btn-outline-primary"),
                        new InputElement().Type("radio").Name("plan").Id("plan-pro")
                            .Value("pro").Class("btn-check"),
                        new LabelElement("Pro").For("plan-pro").Class("btn btn-outline-primary")
                    ).Role("group").Aria("label", "Plan"))
                .Step("Billing",
                    P("Billing details are collected on the next step."))
                .Step("Confirm",
                    P("Review your order and confirm."))
                .Label("Step 1 of 3")
                .Include("[name=plan]")
                .NextText("Continue")
                .PrevText("Back")
                .FinishHxPost("/wizard/step/complete")),

            SectionHelper.ShowSection("Non-Linear", Wizard()
                .Id("free-wizard")
                .Step("One", P("Jump to any step."))
                .Step("Two", P("Second step content."))
                .Step("Three", P("Third step content."))
                .Label("Step 1 of 3")
                .Linear(false)
                .FinishHxPost("/wizard/step/complete"))
        ).ToHtmlResult();
    }

    public static IResult StepAccount(HttpContext http)
    {
        return AccountContent().ToHtmlResult();
    }

    private static DivElement AccountContent()
    {
        return Div(
            Label("Email").For("wizard-email"),
            new InputElement().Type("email").Id("wizard-email").Name("email").Class("form-control"),
            P("Enter an email to continue. The wizard carries this field into the next step.")
        );
    }

    public static IResult StepProfile(HttpContext http)
    {
        // Server-side validation decides whether the flow may advance. Rejecting returns the
        // account step again with data-wizard-reject, so the error appears on the Account tab
        // instead of the wizard having moved on to Profile.
        var email = http.Request.Query["email"].ToString();
        if (string.IsNullOrWhiteSpace(email))
        {
            var rejected = Div(
                Alert("Email is required before continuing.").Danger(),
                AccountContent());
            rejected.Attributes.Set("data-wizard-reject", "true");
            return rejected.ToHtmlResult();
        }

        return ProfileContent().ToHtmlResult();
    }

    private static DivElement ProfileContent()
    {
        return Div(
            Label("Full name").For("wizard-name"),
            new InputElement().Type("text").Id("wizard-name").Name("name").Class("form-control")
        );
    }

    public static IResult StepReview(HttpContext http)
    {
        // The wizard's own Finish button posts here, so this step only renders the summary.
        // Both values arrive because the wizard keeps what every step collected, not just what
        // happened to be on screen.
        var email = http.Request.Query["email"].ToString();
        var name = http.Request.Query["name"].ToString();
        return Div(
            P($"Email: {email}"),
            P($"Name: {name}"),
            P("Press Finish to complete the flow.")
        ).ToHtmlResult();
    }

    public static IResult StepComplete(HttpContext http)
    {
        return Div(
            Alert("Wizard complete. The flow finished via HTMX POST.").Success()
        ).ToHtmlResult();
    }
}
