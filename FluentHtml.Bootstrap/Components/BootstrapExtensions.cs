using FluentHtml.Nodes;

namespace FluentHtml.Bootstrap.Components;

/// <summary>
/// Bootstrap CSS utility extension methods for FluentHtml elements. These methods
/// provide a fluent API for applying Bootstrap CSS classes.
/// </summary>
public static class BootstrapExtensions
{
    /// <summary>
    /// Applies Bootstrap text-center alignment.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T TextCenter<T>(this T element) where T : Element<T> => element.Class("text-center");

    /// <summary>
    /// Applies Bootstrap text-start alignment.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T TextStart<T>(this T element) where T : Element<T> => element.Class("text-start");

    /// <summary>
    /// Applies Bootstrap text-end alignment.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T TextEnd<T>(this T element) where T : Element<T> => element.Class("text-end");

    /// <summary>
    /// Applies Bootstrap display-none utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T DNone<T>(this T element) where T : Element<T> => element.Class("d-none");

    /// <summary>
    /// Applies Bootstrap display-inline utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T DInline<T>(this T element) where T : Element<T> => element.Class("d-inline");

    /// <summary>
    /// Applies Bootstrap display-block utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T DBlock<T>(this T element) where T : Element<T> => element.Class("d-block");

    /// <summary>
    /// Applies Bootstrap display-inline-block utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T DInlineBlock<T>(this T element) where T : Element<T> => element.Class("d-inline-block");

    /// <summary>
    /// Applies Bootstrap display-flex utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T DFlex<T>(this T element) where T : Element<T> => element.Class("d-flex");

    /// <summary>
    /// Applies Bootstrap margin-top with the specified spacing value.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <param name="value">The spacing value (0-5).</param>
    /// <returns>The element for method chaining.</returns>
    public static T Mt<T>(this T element, int value) where T : Element<T> => element.Class($"mt-{value}");

    /// <summary>
    /// Applies Bootstrap margin-bottom with the specified spacing value.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <param name="value">The spacing value (0-5).</param>
    /// <returns>The element for method chaining.</returns>
    public static T Mb<T>(this T element, int value) where T : Element<T> => element.Class($"mb-{value}");

    /// <summary>
    /// Applies Bootstrap margin-start with the specified spacing value.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <param name="value">The spacing value (0-5).</param>
    /// <returns>The element for method chaining.</returns>
    public static T Ms<T>(this T element, int value) where T : Element<T> => element.Class($"ms-{value}");

    /// <summary>
    /// Applies Bootstrap margin-end with the specified spacing value.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <param name="value">The spacing value (0-5).</param>
    /// <returns>The element for method chaining.</returns>
    public static T Me<T>(this T element, int value) where T : Element<T> => element.Class($"me-{value}");

    /// <summary>
    /// Applies Bootstrap margin on all sides with the specified spacing value.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <param name="value">The spacing value (0-5).</param>
    /// <returns>The element for method chaining.</returns>
    public static T M<T>(this T element, int value) where T : Element<T> => element.Class($"m-{value}");

    /// <summary>
    /// Applies Bootstrap padding-top with the specified spacing value.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <param name="value">The spacing value (0-5).</param>
    /// <returns>The element for method chaining.</returns>
    public static T Pt<T>(this T element, int value) where T : Element<T> => element.Class($"pt-{value}");

    /// <summary>
    /// Applies Bootstrap padding-bottom with the specified spacing value.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <param name="value">The spacing value (0-5).</param>
    /// <returns>The element for method chaining.</returns>
    public static T Pb<T>(this T element, int value) where T : Element<T> => element.Class($"pb-{value}");

    /// <summary>
    /// Applies Bootstrap padding-start with the specified spacing value.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <param name="value">The spacing value (0-5).</param>
    /// <returns>The element for method chaining.</returns>
    public static T Ps<T>(this T element, int value) where T : Element<T> => element.Class($"ps-{value}");

    /// <summary>
    /// Applies Bootstrap padding-end with the specified spacing value.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <param name="value">The spacing value (0-5).</param>
    /// <returns>The element for method chaining.</returns>
    public static T Pe<T>(this T element, int value) where T : Element<T> => element.Class($"pe-{value}");

    /// <summary>
    /// Applies Bootstrap padding on all sides with the specified spacing value.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <param name="value">The spacing value (0-5).</param>
    /// <returns>The element for method chaining.</returns>
    public static T P<T>(this T element, int value) where T : Element<T> => element.Class($"p-{value}");

    /// <summary>
    /// Applies Bootstrap flex display utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T Flex<T>(this T element) where T : Element<T> => element.Class("flex");

    /// <summary>
    /// Applies Bootstrap flex-row direction.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T FlexRow<T>(this T element) where T : Element<T> => element.Class("flex-row");

    /// <summary>
    /// Applies Bootstrap flex-column direction.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T FlexColumn<T>(this T element) where T : Element<T> => element.Class("flex-column");

    /// <summary>
    /// Applies Bootstrap flex-wrap utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T FlexWrap<T>(this T element) where T : Element<T> => element.Class("flex-wrap");

    /// <summary>
    /// Applies Bootstrap justify-content-center alignment.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T JustifyCenter<T>(this T element) where T : Element<T> => element.Class("justify-content-center");

    /// <summary>
    /// Applies Bootstrap justify-content-between alignment.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T JustifyBetween<T>(this T element) where T : Element<T> => element.Class("justify-content-between");

    /// <summary>
    /// Applies Bootstrap align-items-center alignment.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T AlignCenter<T>(this T element) where T : Element<T> => element.Class("align-items-center");

    /// <summary>
    /// Applies Bootstrap align-items-start alignment.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T AlignStart<T>(this T element) where T : Element<T> => element.Class("align-items-start");

    /// <summary>
    /// Applies Bootstrap align-items-end alignment.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T AlignEnd<T>(this T element) where T : Element<T> => element.Class("align-items-end");

    /// <summary>
    /// Applies Bootstrap width-auto utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T WAuto<T>(this T element) where T : Element<T> => element.Class("w-auto");

    /// <summary>
    /// Applies Bootstrap width-100% utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T W100<T>(this T element) where T : Element<T> => element.Class("w-100");

    /// <summary>
    /// Applies Bootstrap position-relative utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T PositionRelative<T>(this T element) where T : Element<T> => element.Class("position-relative");

    /// <summary>
    /// Applies Bootstrap position-absolute utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T PositionAbsolute<T>(this T element) where T : Element<T> => element.Class("position-absolute");

    /// <summary>
    /// Applies Bootstrap position-fixed utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T PositionFixed<T>(this T element) where T : Element<T> => element.Class("position-fixed");

    /// <summary>
    /// Applies Bootstrap position-sticky utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T PositionSticky<T>(this T element) where T : Element<T> => element.Class("position-sticky");

    /// <summary>
    /// Applies Bootstrap overflow-auto utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T OverflowAuto<T>(this T element) where T : Element<T> => element.Class("overflow-auto");

    /// <summary>
    /// Applies Bootstrap overflow-hidden utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T OverflowHidden<T>(this T element) where T : Element<T> => element.Class("overflow-hidden");

    /// <summary>
    /// Applies Bootstrap shadow utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T Shadow<T>(this T element) where T : Element<T> => element.Class("shadow");

    /// <summary>
    /// Applies Bootstrap shadow-sm (small shadow) utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T ShadowSm<T>(this T element) where T : Element<T> => element.Class("shadow-sm");

    /// <summary>
    /// Applies Bootstrap shadow-lg (large shadow) utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T ShadowLg<T>(this T element) where T : Element<T> => element.Class("shadow-lg");

    /// <summary>
    /// Applies Bootstrap border utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T Border<T>(this T element) where T : Element<T> => element.Class("border");

    /// <summary>
    /// Applies Bootstrap border-top utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T BorderTop<T>(this T element) where T : Element<T> => element.Class("border-top");

    /// <summary>
    /// Applies Bootstrap border-bottom utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T BorderBottom<T>(this T element) where T : Element<T> => element.Class("border-bottom");

    /// <summary>
    /// Applies Bootstrap border-start utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T BorderStart<T>(this T element) where T : Element<T> => element.Class("border-start");

    /// <summary>
    /// Applies Bootstrap border-end utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T BorderEnd<T>(this T element) where T : Element<T> => element.Class("border-end");

    /// <summary>
    /// Applies Bootstrap rounded utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T Rounded<T>(this T element) where T : Element<T> => element.Class("rounded");

    /// <summary>
    /// Applies Bootstrap rounded-sm (small border-radius) utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T RoundedSm<T>(this T element) where T : Element<T> => element.Class("rounded-sm");

    /// <summary>
    /// Applies Bootstrap rounded-lg (large border-radius) utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T RoundedLg<T>(this T element) where T : Element<T> => element.Class("rounded-lg");

    /// <summary>
    /// Applies Bootstrap rounded-circle (pill shape) utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T RoundedCircle<T>(this T element) where T : Element<T> => element.Class("rounded-circle");

    /// <summary>
    /// Applies Bootstrap rounded-pill utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T RoundedPill<T>(this T element) where T : Element<T> => element.Class("rounded-pill");

    /// <summary>
    /// Applies Bootstrap opacity-25 utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T Opacity25<T>(this T element) where T : Element<T> => element.Class("opacity-25");

    /// <summary>
    /// Applies Bootstrap opacity-50 utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T Opacity50<T>(this T element) where T : Element<T> => element.Class("opacity-50");

    /// <summary>
    /// Applies Bootstrap opacity-75 utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T Opacity75<T>(this T element) where T : Element<T> => element.Class("opacity-75");

    /// <summary>
    /// Applies Bootstrap opacity-100 utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T Opacity100<T>(this T element) where T : Element<T> => element.Class("opacity-100");

    /// <summary>
    /// Applies Bootstrap clearfix utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T Clearfix<T>(this T element) where T : Element<T> => element.Class("clearfix");

    /// <summary>
    /// Applies Bootstrap stretched-link utility to make the entire card clickable.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T StretchedLink<T>(this T element) where T : Element<T> => element.Class("stretched-link");

    /// <summary>
    /// Applies Bootstrap visible utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T Visible<T>(this T element) where T : Element<T> => element.Class("visible");

    /// <summary>
    /// Applies Bootstrap invisible utility.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="element">The element to style.</param>
    /// <returns>The element for method chaining.</returns>
    public static T Invisible<T>(this T element) where T : Element<T> => element.Class("invisible");
}
