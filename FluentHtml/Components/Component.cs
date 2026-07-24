using FluentHtml.Nodes;

namespace FluentHtml.Components;

public abstract class Component : Node
{
    protected Component()
    {
    }

    public abstract Node Render();
}

public abstract class Component<T> : Component
{
    protected T Data { get; }

    protected Component(T data)
    {
        Data = data;
    }

    public override Node Render()
    {
        return Build(Data);
    }

    protected abstract Node Build(T data);
}
