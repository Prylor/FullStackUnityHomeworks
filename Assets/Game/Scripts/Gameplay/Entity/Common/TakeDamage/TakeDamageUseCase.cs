using Atomic.Entities;
using Gameplay.Entity.Common.TakeDamage;

namespace SampleGame
{
    public static class TakeDamageUseCase
    {
        public static bool TakeDamage(in IEntity target, in TakeDamageArgs args)
        {
            if (!target.HasDamageableTag())
                return false;

            var health = target.GetHealth();

            if (health.Reduce(args.Damage))
            {
                target.GetDamageTakenEvent().Invoke(args);
                return true;
            }
            
            return false;
        }
    }
}