using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ItemVisualInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private ParticleSystem _vfx;

        [SerializeField]
        private Transform _visual;

        [SerializeField]
        private AudioSource _audioSource;
        
        public override void Install(IEntity entity)
        {
            entity.AddAudioSource(_audioSource);
            entity.AddVisualRoot(_visual);
            entity.AddBehaviour(new ItemUseVfxBehaviour(_vfx));
            entity.AddBehaviour(new ItemUseSfxBehaviour());
        }
    }
}