using System;
using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace SampleGame.Weapons
{
    [Serializable]
    public class WeaponCoreInstaller: IEntityInstaller
    {
        [SerializeField]
        public float attackCooldown = 1f;
        
        [SerializeField] 
        private int damage = 1;

        [SerializeField]
        private Transform attackPoint;
        
        public void Install(IEntity entity)
        {
            var cooldown = new Cooldown(attackCooldown);

            entity.AddDamage(new ReactiveInt(damage));
            entity.AddAttackPoint(attackPoint);
            entity.AddAttackCooldown(cooldown);
            entity.AddAttackEvent(new BaseEvent());
            entity.AddAttackCondition(new AndExpression(() => entity.GetAttackCooldown().IsExpired()));
            
            entity.WhenUpdate(cooldown.Tick);
        }
    }
}