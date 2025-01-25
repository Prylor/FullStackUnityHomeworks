using System;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame.Weapons
{
    [Serializable]
    public class WeaponVfxInstaller : IEntityInstaller
    {
        [SerializeField]
        private ParticleSystem attackVfx;

        public void Install(IEntity entity)
        {
            entity.GetAttackEvent().Subscribe(() => attackVfx.Play());
        }
    }
}