using Gameplay.Entity.Common.TakeDamage;
using SampleGame;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class DeathAnimBehaviour : IEntityInit, IEntityDispose
    {
        private static readonly int Death = Animator.StringToHash("Death");
        
        private Animator _animator;
        private IReactive _deathEvent;

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _deathEvent = entity.GetDeathEvent();
            _deathEvent.Subscribe(OnDeath);
        }

        public void Dispose(in IEntity entity)
        {
            _deathEvent.Unsubscribe(OnDeath);
        }

        private void OnDeath()
        {
           _animator.SetTrigger(Death);
        }
    }
}