using Atomic.Entities;
using Gameplay.GameContext;
using Gameplay.GameContext.Projectiles;

namespace SampleGame.Weapons
{
    public static class PistolUseCase
    {
        public static bool Fire(IGameContext gameContext, IEntity pistol)
        {
            if (pistol.GetAttackCondition().Invoke())
            {
                var firePoint = pistol.GetAttackPoint();
                var ammo = pistol.GetAmmo();
                
                ProjectileUseCase.SpawnProjectile(gameContext, firePoint.position, firePoint.rotation);
                
                ammo.Spend();
                pistol.GetAttackCooldown().Reset();
                pistol.GetAttackEvent().Invoke();
                return true;
            }

            return false;
        }
    }
}