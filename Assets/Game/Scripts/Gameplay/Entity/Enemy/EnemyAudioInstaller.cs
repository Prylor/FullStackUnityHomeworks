using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyAudioInstaller : SceneEntityInstaller
    {
        private const string AttackEventName = "start_attack_event";
        
        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private AudioClip[] _deathClips;

        [SerializeField]
        private AudioClip[] _attackClips;

        [SerializeField]
        private AudioClip[] _damageClips;

        [SerializeField]
        private AudioClip _bodyFallClip;

        [SerializeField]
        private AudioClip _meleeDamageClip;

        [SerializeField]
        private AudioClip _bulletDamageClip;
        
        public override void Install(IEntity entity)
        {
            entity.AddAudioSource(_audioSource);
            entity.AddBehaviour(new TakeDamageSoundTypeBehaviour(_meleeDamageClip, _bulletDamageClip));
            entity.AddBehaviour(new TakeDamageSoundBehaviour(_damageClips));
            entity.AddBehaviour(new BodyFallSoundBehaviour(_bodyFallClip));
            entity.AddBehaviour(new DeathSoundBehaviour(_deathClips));
            entity.AddBehaviour(new AttackSoundBehaviour(AttackEventName, _attackClips));
        }
    }
}