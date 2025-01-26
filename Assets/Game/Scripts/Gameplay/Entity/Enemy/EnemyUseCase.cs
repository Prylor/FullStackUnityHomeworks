using Atomic.Entities;
using SampleGame;
using SampleGame.Common.Health;

namespace Game.Gameplay
{
    public static class EnemyUseCase
    {
        public static bool SetTarget(IEntity enemy, IEntity target)
        {
            if (target == null)
                return false;

            if (!HealthUseCase.IsAlive(enemy))
                return false;

            enemy.GetTarget().Value = target;

            return true;
        }
        
        public static bool ResetTarget(IEntity enemy)
        {
            enemy.GetTarget().Value = null;

            return true;
        }
    }
}