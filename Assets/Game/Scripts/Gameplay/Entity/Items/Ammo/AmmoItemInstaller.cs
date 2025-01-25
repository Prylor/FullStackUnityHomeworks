using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class AmmoItemInstaller : SceneEntityInstaller
    {
        [SerializeField] 
        private int clips = 10;
        
        [SerializeField] 
        private ItemCoreInstaller itemCoreInstaller;

        public override void Install(IEntity entity)
        {
            itemCoreInstaller.Install(entity);

            entity.AddTransform(transform);

            entity.AddUseCondition(new BaseFunction<IEntity, bool>(entity =>
                entity.HasWeapon() &&
                entity.GetWeapon().HasAmmo()));

            entity.AddUseAction(new BaseAction<IEntity>(target =>
            {
                if (!entity.GetUseCondition().Invoke(target))
                    return;
                
                if (WeaponUseCase.AddClips(target, clips))
                {
                    entity.GetUseEvent().Invoke();
                }
            }));
        }
    }
}