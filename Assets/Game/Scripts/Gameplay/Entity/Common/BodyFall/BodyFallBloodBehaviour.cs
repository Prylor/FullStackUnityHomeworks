using Atomic.Entities;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class BodyFallBloodBehaviour : IEntityInit, IEntityDispose
    {
        private const string ANIM_EVENT = "body_fall_event";

        private readonly ParticleSystem _deadBloodSfx;
        private readonly ParticleSystem _bloodVfx;
        private readonly Transform _groundPoint;
        
        private AnimationEventReceiver _eventReceiver;

        public BodyFallBloodBehaviour(ParticleSystem bloodVfx, Transform groundPoint)
        {
            this._bloodVfx = bloodVfx;
            this._groundPoint = groundPoint;
        }

        public void Init(in IEntity entity)
        {
            _eventReceiver = entity.GetAnimationEventReceiver();
            _eventReceiver.OnEvent += OnAnimEvent;
        }

        public void Dispose(in IEntity entity)
        {
            _eventReceiver.OnEvent -= OnAnimEvent;
        }

        private void OnAnimEvent(string message)
        {
            if (message != ANIM_EVENT)
                return;

            this._bloodVfx.transform.parent = null; //TODO: Временно, сделать через пул и рейкасты!
            this._bloodVfx.transform.position = this._groundPoint.position;
            this._bloodVfx.Play(withChildren: true);
        }
    }
}