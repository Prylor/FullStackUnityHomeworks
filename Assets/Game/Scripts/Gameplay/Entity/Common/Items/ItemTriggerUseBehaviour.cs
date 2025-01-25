using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace SampleGame
{
    public sealed class ItemTriggerUseBehaviour : IEntityInit, IEntityDispose
    {
        private TriggerEventReceiver _trigger;
        private IEntity _entity;
        
        public void Init(in IEntity entity)
        {
            _entity = entity;
            _trigger = entity.GetTrigger();
            _trigger.OnEntered += this.OnTriggerEntered;
        }

        public void Dispose(in IEntity entity)
        {
            _trigger.OnEntered -= this.OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            ItemUseCase.Use(_entity, collider);
        }
    }
}