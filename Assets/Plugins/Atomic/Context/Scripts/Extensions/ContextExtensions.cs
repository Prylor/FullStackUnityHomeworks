using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Atomic.Contexts
{
    public static class ContextExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddValues(this IContext context, in IReadOnlyDictionary<int, object> values)
        {
            if (values == null)
                return;

            foreach ((int key, object value) in values)
                context.AddValue(key, value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddControllers(this IContext context, in IEnumerable<IContextController> systems)
        {
            if (systems == null)
                return;

            foreach (IContextController system in systems)
                context.AddController(system);
        }
    }
}