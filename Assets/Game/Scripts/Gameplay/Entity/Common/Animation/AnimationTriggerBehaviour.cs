using System;
using Atomic.Entities;
using Modules.Gameplay;
using SampleGame;

namespace Gameplay.Entity.Common
{
    public class AnimationTriggerBehaviour: IEntityInit, IEntityDispose
    {
        private readonly string _eventName;
        private readonly Action _action;
        private AnimationEventReceiver _animationReceiver;

        public AnimationTriggerBehaviour(string eventName, Action action)
        {
            _eventName = eventName;
            _action = action;
        }

        public void Init(in IEntity entity)
        {
            _animationReceiver = entity.GetAnimationEventReceiver();
            _animationReceiver.OnEvent += OnAnimEvent;
        }

        public void Dispose(in IEntity entity)
        {
            _animationReceiver.OnEvent -= OnAnimEvent;
        }

        private void OnAnimEvent(string name)
        {
            if (name == _eventName)
            {
                _action?.Invoke();
            }
        }
    }
}