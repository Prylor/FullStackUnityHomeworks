using Atomic.Elements;
using Atomic.Entities;
using Gameplay.Entity.Common.TakeDamage;
using Modules.Gameplay;
using UnityEngine;

namespace SampleGame
{
    public sealed class ProjectileCollisionBehaviour : IEntityInit, IEntityDispose
    {
        private IAction _destroyAction;
        private CollisionEventReceiver _collision;
        private IValue<int> _damage;
        private IEntity _self;

        public void Init(in IEntity entity)
        {
            _self = entity;
            _destroyAction = entity.GetDestroyAction();
            _damage = entity.GetDamage();

            _collision = entity.GetCollision();
            _collision.OnEntered += this.OnCollisionEntered;
        }

        public void Dispose(in IEntity entity)
        {
            _collision.OnEntered -= this.OnCollisionEntered;
        }

        private void OnCollisionEntered(Collision collision)
        {
            var damage = _damage.Value;
            var args = new TakeDamageArgs(_self, damage);
            
            if (collision.collider.TryGetComponent(out IEntity target) && TakeDamageUseCase.TakeDamage(target, args))
                _destroyAction.Invoke();
        }
    }
}