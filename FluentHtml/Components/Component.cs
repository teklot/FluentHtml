using FluentHtml.Nodes;

namespace FluentHtml.Components;

/// <summary>
/// Abstract base class for reusable UI components. Components compose existing nodes
/// into larger UI structures. Override <see cref="Render"/> to define the component's output.
/// </summary>
public abstract class Component : Node
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Component"/> class.
    /// </summary>
    protected Component()
    {
    }

    /// <summary>
    /// Renders this component to a node tree.
    /// </summary>
    /// <returns>The node tree representing this component.</returns>
    public abstract Node Render();
}

/// <summary>
/// Abstract base class for strongly-typed reusable UI components. Components accept
/// data of type <typeparamref name="T"/> and render UI based on that data.
/// </summary>
/// <typeparam name="T">The type of data this component operates on.</typeparam>
public abstract class Component<T> : Component
{
    /// <summary>
    /// Gets the data associated with this component.
    /// </summary>
    protected T Data { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Component{T}"/> class with the specified data.
    /// </summary>
    /// <param name="data">The data to render.</param>
    protected Component(T data)
    {
        Data = data;
    }

    /// <inheritdoc/>
    public override Node Render()
    {
        return Build(Data);
    }

    /// <summary>
    /// Builds the node tree for this component based on the provided data.
    /// </summary>
    /// <param name="data">The data to render.</param>
    /// <returns>The node tree representing this component.</returns>
    protected abstract Node Build(T data);
}