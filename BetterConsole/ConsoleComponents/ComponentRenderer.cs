using System;

namespace BetterConsole.ConsoleComponents
{
    public abstract class ComponentRenderer
    {
        public abstract ComponentBuilder Render();
    }

    public abstract class ComponentRenderer<T> : ComponentRenderer
    {
        protected T Object;

        public ComponentRenderer(T obj)
        {
            Object = obj;
        }
    }
}
