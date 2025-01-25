using System;
using Atomic.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SampleGame.Weapons
{
    [Serializable]
    public class WeaponAudioInstaller : IEntityInstaller
    {
        [SerializeField] 
        private AudioSource audioSource;
        
        [SerializeField]
        private Vector2 pitchRange = Vector2.one;

        public void Install(IEntity entity)
        {
            entity.SetAudioSource(audioSource);
            entity.GetAttackEvent().Subscribe(() =>
            {
                audioSource.pitch = Random.Range(pitchRange.x, pitchRange.y);
                audioSource.Play();
            });
            
        }
    }
}