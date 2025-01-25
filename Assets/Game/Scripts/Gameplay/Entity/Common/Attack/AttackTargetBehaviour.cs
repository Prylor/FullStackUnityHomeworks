using Atomic.Entities;
using SampleGame;
using SampleGame.Common;
using SampleGame.Common.Health;

namespace Gameplay.Entity.Common.Attack
{
    public class AttackTargetBehaviour: IEntityUpdate
    {
        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            if(!entity.TryGetTarget(out var target) || target.Value == null)
                return;

            if (TargetUseCase.IsTargetReached(entity) && HealthUseCase.IsAlive(target.Value))
            {
                entity.GetAttackAction().Invoke();
            }
        }
    }
}