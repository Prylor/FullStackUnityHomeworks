using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public class ItemUseSfxBehaviour : IEntityInit, IEntityDispose
    {
        private AudioSource _audioSource;

        public void Init(in IEntity entity)
        {
            _audioSource = entity.GetAudioSource();
            entity.GetUseEvent().Subscribe(OnUse);
        }

        public void Dispose(in IEntity entity)
        {
            entity.GetUseEvent()?.Unsubscribe(OnUse);
        }

        private void OnUse()
        {
            _audioSource.Play();
        }
    }
}