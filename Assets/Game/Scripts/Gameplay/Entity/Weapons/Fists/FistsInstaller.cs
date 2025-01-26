using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;
using UnityEngine.Serialization;

namespace SampleGame.Weapons
{
    public class FistsInstaller: SceneEntityInstaller
    {
        [SerializeField] 
        private float attackRadius = 1f;
        
        [SerializeField] 
        private WeaponCoreInstaller core;
        
        public override void Install(IEntity entity)
        {
            entity.AddTransform(transform);
            entity.AddMeleeTag();

            core.Install(entity);
            
            entity.AddAttackRadius(new Const<float>(attackRadius));
            entity.AddAttackAction(new BaseAction(() => FistsUseCase.Attack(entity)));
        }
    }
}