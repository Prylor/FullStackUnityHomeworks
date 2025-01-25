using System;
using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class ItemCoreInstaller : IEntityInstaller
    {
        [SerializeField]
        private TriggerEventReceiver trigger;
        
        [SerializeField]
        private Collider collider;
        
        public void Install(IEntity entity)
        {
            entity.AddItemTag();
            entity.AddCollider(collider);
            entity.SetUseEvent(new BaseEvent());
            entity.AddTrigger(trigger);
            entity.AddBehaviour(new ItemTriggerUseBehaviour());
        }
    }
}