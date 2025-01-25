using Atomic.Entities;

namespace SampleGame.Common.Health
{
    public static class HealthUseCase
    {
        public static bool IsAlive(in IEntity entity)
        {
            if (!entity.TryGetHealth(out var health))
                return false;

            return health.Exists();
        }

        public static bool Restore(IEntity entity, int restorePoints)
        {
            if (!entity.TryGetHealth(out var health))
                return false;

            return  health.Add(restorePoints);
        }
    }
}