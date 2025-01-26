using Atomic.Elements;
using Atomic.Entities;
using Gameplay.GameContext;
using Gameplay.GameContext.Projectiles;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Gameplay
{
    public sealed class ProjectileCoreInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private float moveSpeed = 3;

        [SerializeField]
        private int damage;

        [SerializeField]
        private CollisionEventReceiver collision;

        [SerializeField]
        private float lifetime;

        public override void Install(IEntity entity)
        {
            var gameContext = GameContext.Instance;

            entity.AddProjectileTag();
            entity.AddTransform(transform);
            entity.AddGameObject(gameObject);
            entity.AddDamage(new ReactiveInt(damage));
            
            entity.AddLifetime(new Cooldown(lifetime, lifetime));
            entity.AddDestroyAction(new BaseAction(() => ProjectileUseCase.DespawnProjectile(gameContext, entity)));
            
            entity.AddMoveSpeed(new ReactiveFloat(moveSpeed));
            entity.AddMoveDirection(new ReactiveVariable<Vector2>());
            entity.AddCollision(collision);
            
            entity.AddBehaviour<ProjectileLifetimeBehaviour>();
            entity.AddBehaviour<MoveTowardsBehaviour>();
            entity.AddBehaviour<ProjectileCollisionBehaviour>();
        }
    }
}