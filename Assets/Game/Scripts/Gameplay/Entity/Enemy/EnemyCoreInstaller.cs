using Atomic.Elements;
using Atomic.Entities;
using Gameplay.Context.Game;
using Gameplay.Entity.Common.Attack;
using Gameplay.Entity.Common.Move;
using Gameplay.Entity.Common.TakeDamage;
using Modules.Gameplay;
using SampleGame;
using SampleGame.Common;
using SampleGame.Common.Health;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class EnemyCoreInstaller : SceneEntityInstaller
    {
        [SerializeField] private int health = 3;
        [SerializeField] private float angularSpeed = 10f;
        [SerializeField] private SceneEntity fists;
        [SerializeField] private float stoppingDistance = .2f;
        [SerializeField] private Transform visualRoot;
        
        public override void Install(IEntity entity)
        {
            var gameContext = GameContext.Instance;
            
            entity.SetTransform(transform);
            entity.SetVisualRoot(visualRoot);
            
            InstallMovement(entity);
            InstallHealth(entity);
            InstallWeapon(entity);
            InstallCombat(entity);
            InstallTarget(entity);

            entity.GetDeathTakenEvent().Subscribe(_ => gameContext.GetKills().Value++);
            
            entity.AddBehaviour(new MoveToTargetBehaviour());
            entity.AddBehaviour(new AttackTargetBehaviour());
        }

        private void InstallTarget(IEntity entity)
        {
            entity.AddTarget(new ReactiveVariable<IEntity>());
        }

        private void InstallMovement(IEntity entity)
        {
            entity.SetMoveDirection(new ReactiveVector2());
            entity.AddMoveCondition(new AndExpression(
                () => HealthUseCase.IsAlive(entity),
                () => !TargetUseCase.IsTargetReached(entity)
            ));
            entity.AddRotateCondition(new AndExpression(() => HealthUseCase.IsAlive(entity)));
            entity.SetAngularSpeed(new Const<float>(angularSpeed));
            entity.SetStoppingDistance(new Const<float>(stoppingDistance));
        }

        private void InstallHealth(IEntity entity)
        {
            entity.AddDamageableTag();
            entity.SetHealth(new Health(health, health));
            entity.SetDamageTakenEvent(new BaseEvent<TakeDamageArgs>());
            entity.SetDeathTakenEvent(new BaseEvent<TakeDamageArgs>());
        }

        private void InstallWeapon(IEntity entity)
        {
            entity.AddWeapon(fists);
            entity.GetWeapon().GetAttackEvent().Subscribe(() => entity.GetInAttack().Value = false);
        }

        private void InstallCombat(IEntity entity)
        {
            entity.AddInAttack(new ReactiveBool());
            entity.AddAttackEvent(new BaseEvent());
            entity.AddAttackCondition(new AndExpression(
                () => HealthUseCase.IsAlive(entity),
                () => fists.GetAttackCondition().Invoke(),
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