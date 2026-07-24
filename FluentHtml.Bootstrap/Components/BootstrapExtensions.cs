using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

public static class BootstrapExtensions
{
    public static T Primary<T>(this T element) where T : Element => (T)element.Class("primary");

    public static T Secondary<T>(this T element) where T : Element => (T)element.Class("secondary");

    public static T Success<T>(this T element) where T : Element => (T)element.Class("success");

    public static T Warning<T>(this T element) where T : Element => (T)element.Class("warning");

    public static T Danger<T>(this T element) where T : Element => (T)element.Class("danger");

    public static T Info<T>(this T element) where T : Element => (T)element.Class("info");

    public static T Light<T>(this T element) where T : Element => (T)element.Class("light");

    public static T Dark<T>(this T element) where T : Element => (T)element.Class("dark");

    public static T TextCenter<T>(this T element) where T : Element => (T)element.Class("text-center");

    public static T TextStart<T>(this T element) where T : Element => (T)element.Class("text-start");

    public static T TextEnd<T>(this T element) where T : Element => (T)element.Class("text-end");

    public static T DNone<T>(this T element) where T : Element => (T)element.Class("d-none");

    public static T DInline<T>(this T element) where T : Element => (T)element.Class("d-inline");

    public static T DBlock<T>(this T element) where T : Element => (T)element.Class("d-block");

    public static T DInlineBlock<T>(this T element) where T : Element => (T)element.Class("d-inline-block");

    public static T DFlex<T>(this T element) where T : Element => (T)element.Class("d-flex");

    public static T Mt<T>(this T element, int value) where T : Element => (T)element.Class($"mt-{value}");

    public static T Mb<T>(this T element, int value) where T : Element => (T)element.Class($"mb-{value}");

    public static T Ms<T>(this T element, int value) where T : Element => (T)element.Class($"ms-{value}");

    public static T Me<T>(this T element, int value) where T : Element => (T)element.Class($"me-{value}");

    public static T M<T>(this T element, int value) where T : Element => (T)element.Class($"m-{value}");

    public static T Pt<T>(this T element, int value) where T : Element => (T)element.Class($"pt-{value}");

    public static T Pb<T>(this T element, int value) where T : Element => (T)element.Class($"pb-{value}");

    public static T Ps<T>(this T element, int value) where T : Element => (T)element.Class($"ps-{value}");

    public static T Pe<T>(this T element, int value) where T : Element => (T)element.Class($"pe-{value}");

    public static T P<T>(this T element, int value) where T : Element => (T)element.Class($"p-{value}");

    public static T Flex<T>(this T element) where T : Element => (T)element.Class("flex");

    public static T FlexRow<T>(this T element) where T : Element => (T)element.Class("flex-row");

    public static T FlexColumn<T>(this T element) where T : Element => (T)element.Class("flex-column");

    public static T FlexWrap<T>(this T element) where T : Element => (T)element.Class("flex-wrap");

    public static T JustifyCenter<T>(this T element) where T : Element => (T)element.Class("justify-content-center");

    public static T JustifyBetween<T>(this T element) where T : Element => (T)element.Class("justify-content-between");

    public static T AlignCenter<T>(this T element) where T : Element => (T)element.Class("align-items-center");

    public static T AlignStart<T>(this T element) where T : Element => (T)element.Class("align-items-start");

    public static T AlignEnd<T>(this T element) where T : Element => (T)element.Class("align-items-end");

    public static T WAuto<T>(this T element) where T : Element => (T)element.Class("w-auto");

    public static T W100<T>(this T element) where T : Element => (T)element.Class("w-100");

    public static T PositionRelative<T>(this T element) where T : Element => (T)element.Class("position-relative");

    public static T PositionAbsolute<T>(this T element) where T : Element => (T)element.Class("position-absolute");

    public static T PositionFixed<T>(this T element) where T : Element => (T)element.Class("position-fixed");

    public static T PositionSticky<T>(this T element) where T : Element => (T)element.Class("position-sticky");

    public static T OverflowAuto<T>(this T element) where T : Element => (T)element.Class("overflow-auto");

    public static T OverflowHidden<T>(this T element) where T : Element => (T)element.Class("overflow-hidden");

    public static T Shadow<T>(this T element) where T : Element => (T)element.Class("shadow");

    public static T ShadowSm<T>(this T element) where T : Element => (T)element.Class("shadow-sm");

    public static T ShadowLg<T>(this T element) where T : Element => (T)element.Class("shadow-lg");

    public static T Border<T>(this T element) where T : Element => (T)element.Class("border");

    public static T BorderTop<T>(this T element) where T : Element => (T)element.Class("border-top");

    public static T BorderBottom<T>(this T element) where T : Element => (T)element.Class("border-bottom");

    public static T BorderStart<T>(this T element) where T : Element => (T)element.Class("border-start");

    public static T BorderEnd<T>(this T element) where T : Element => (T)element.Class("border-end");

    public static T Rounded<T>(this T element) where T : Element => (T)element.Class("rounded");

    public static T RoundedSm<T>(this T element) where T : Element => (T)element.Class("rounded-sm");

    public static T RoundedLg<T>(this T element) where T : Element => (T)element.Class("rounded-lg");

    public static T RoundedCircle<T>(this T element) where T : Element => (T)element.Class("rounded-circle");

    public static T RoundedPill<T>(this T element) where T : Element => (T)element.Class("rounded-pill");

    public static T Opacity25<T>(this T element) where T : Element => (T)element.Class("opacity-25");

    public static T Opacity50<T>(this T element) where T : Element => (T)element.Class("opacity-50");

    public static T Opacity75<T>(this T element) where T : Element => (T)element.Class("opacity-75");

    public static T Opacity100<T>(this T element) where T : Element => (T)element.Class("opacity-100");

    public static T Clearfix<T>(this T element) where T : Element => (T)element.Class("clearfix");

    public static T StretchedLink<T>(this T element) where T : Element => (T)element.Class("stretched-link");

    public static T Visible<T>(this T element) where T : Element => (T)element.Class("visible");

    public static T Invisible<T>(this T element) where T : Element => (T)element.Class("invisible");
}
