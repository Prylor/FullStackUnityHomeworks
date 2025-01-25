using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public class ItemUseVfxBehaviour : IEntityInit, IEntityDispose
    {
        private readonly ParticleSystem _vfx;

        public ItemUseVfxBehaviour(ParticleSystem vfx)
        {
            _vfx = vfx;
        }

        public void Init(in IEntity entity)
        {
            entity.GetUseEvent().Subscribe(OnUse);
        }


        public void Dispose(in IEntity entity)
        {
            entity.GetUseEvent()?.Unsubscribe(OnUse);
        }

        private void OnUse()
        {
            _vfx.Play();
        }
    }
}