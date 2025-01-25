using System;
using Atomic.Contexts;
using Atomic.Entities;
using Gameplay.Context.Game;
using UnityEngine;

namespace SampleGame
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