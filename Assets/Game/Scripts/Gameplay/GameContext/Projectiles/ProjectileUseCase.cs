using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Gameplay.GameContext.Projectiles
{
    public sealed class ProjectileUseCase
    {
        public static IEntity SpawnProjectile(
            in IGameContext context,
            in Vector3 position,
            in Quaternion rotation
        )
        {
            var prefab = context.GetProjectilePrefab();
            var bullet = context.GetGlobalPool().Rent(prefab, position, rotation);

            bullet.GetLifetime().Reset();

            var forward = bullet.GetTransform().forward;
            bullet.GetMoveDirection().Value = new Vector2(forward.x, forward.z);
            
            return bullet;
        }

        public static void DespawnProjectile(in IGameContext context, in IEntity bullet)
        {
            context.GetGlobalPool().Return(bullet);
        }
    }
}