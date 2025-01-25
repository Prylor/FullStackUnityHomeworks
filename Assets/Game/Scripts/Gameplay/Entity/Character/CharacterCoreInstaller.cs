using Atomic.Elements;
using Atomic.Entities;
using Gameplay.Entity.Common.TakeDamage;
using Modules.Gameplay;
using SampleGame;
using SampleGame.Common.Health;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private int maxHealth = 10;
        [SerializeField] private float angularSpeed = 10f;
        [SerializeField] private SceneEntity pistol;

        public override void Install(IEntity entity)
        {
            entity.AddCharacterTag();
            
            entity.SetTransform(transform);

            InstallMovement(entity);
            InstallHealth(entity);
            InstallWeapon(entity);
            InstallCombat(entity);
        }

        private void InstallMovement(IEntity entity)
        {
            entity.SetMoveDirection(new ReactiveVector2());
            entity.AddMoveCondition(new AndExpression(() => HealthUseCase.IsAlive(entity)));
            entity.AddRotateCondition(new AndExpression(() => HealthUseCase.IsAlive(entity)));
            entity.SetAngularSpeed(new Const<float>(angularSpeed));
            entity.AddAimDirection(new ReactiveVector2());
        }

        private void InstallHealth(IEntity entity)
        {
            entity.AddDamageableTag();
            entity.SetHealth(new Health(maxHealth, maxHealth));
            entity.SetDamageTakenEvent(new BaseEvent<TakeDamageArgs>());
            entity.SetDeathTakenEvent(new BaseEvent<TakeDamageArgs>());
        }

        private void InstallWeapon(IEntity entity)
        {
            entity.AddWeapon(pistol);
            entity.GetWeapon().GetAttackEvent().Subscribe(() => entity.GetInAttack().Value = false);
        }

        private void InstallCombat(IEntity entity)
        {
            entity.AddInAttack(new ReactiveBool());
            entity.AddAttackEvent(new BaseEvent());
            
            entity.AddAttackCondition(new AndExpression(
                () => HealthUseCase.IsAlive(entity),
                () => pistol.GetAttackCondition().Invoke(),
                () => !entity.GetInAttack().Value
            ));

            entity.AddAttackAction(new BaseAction(() =>
            {
                if (entity.GetAttackCondition().Invoke())
                {
                    entity.GetInAttack().Value = true;
                    entity.GetAttackEvent().Invoke();
                }
            }));
        }
    }
}