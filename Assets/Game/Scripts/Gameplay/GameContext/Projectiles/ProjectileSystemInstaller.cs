using System;
using Atomic.Contexts;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Gameplay.GameContext.Projectiles
{
    [Serializable]
    public sealed class ProjectileSystemInstaller : IContextInstaller<IGameContext>
    {
        [SerializeField]
        private SceneEntity bulletPrefab;

        public void Install(IGameContext context)
        {
            context.AddProjectilePrefab(bulletPrefab);
        }
    }
}