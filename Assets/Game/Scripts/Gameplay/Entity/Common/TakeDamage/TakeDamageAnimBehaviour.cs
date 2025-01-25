using Atomic.Elements;
using Atomic.Entities;
using Gameplay.Entity.Common.TakeDamage;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class TakeDamageAnimBehaviour : IEntityInit, IEntityDispose
    {
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");
        
        private IReactive<TakeDamageArgs> _damageEvent;
        private Animator _animator;

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _damageEvent = entity.GetDamageTakenEvent();

            _damageEvent.Subscribe(OnDamageTaken);
        }

        public void Dispose(in IEntity entity)
        {
            _damageEvent.Unsubscribe(OnDamageTaken);
        }

        private void OnDamageTaken(TakeDamageArgs _)
        {
           _animator.SetTrigger(TakeDamage);
        }
    }
}