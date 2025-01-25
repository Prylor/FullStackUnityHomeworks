using Atomic.Elements;
using Atomic.Entities;
using SampleGame.Common.Health;
using UnityEngine;

namespace SampleGame
{
    public sealed class HealthItemInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private int restorePoints = 3;

        [SerializeField]
        private ItemCoreInstaller itemCoreInstaller;
        
        public override void Install(IEntity entity)
        {
            itemCoreInstaller.Install(entity);
            
            entity.AddTransform(transform);
            
            entity.AddUseCondition(new BaseFunction<IEntity, bool>(target =>
                target.HasHealth() &&
                !target.GetHealth().IsFull()));
            
            entity.AddUseAction(new BaseAction<IEntity>(target =>
            {
                if (!entity.GetUseCondition().Invoke(target))
                    return;
                
                if (HealthUseCase.Restore(target, restorePoints))
                {
                    entity.GetUseEvent().Invoke();
                }
            }));
        }
    }
}