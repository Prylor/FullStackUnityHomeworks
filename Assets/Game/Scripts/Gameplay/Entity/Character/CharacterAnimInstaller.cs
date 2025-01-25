using Atomic.Entities;
using Gameplay.Entity.Common;
using Gameplay.Entity.Common.Rotate;
using Modules.Gameplay;
using SampleGame;
using SampleGame.Common.Attack;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class CharacterAnimInstaller : SceneEntityInstaller
    {
        private const string fireEvent = "fire_event";

        [SerializeField] private Animator _animator;

        [SerializeField] private AnimationEventReceiver _animationReceiver;

        public override void Install(IEntity entity)
        {
            entity.SetVisualRoot(transform);
            entity.SetAnimator(_animator);
            entity.SetAnimationEventReceiver(_animationReceiver);
            
            entity.AddBehaviour(new RotateVisualToMoveDirectionBehaviour());
            entity.AddBehaviour(new RotateVisualToAimDirectionBehaviour());
            entity.AddBehaviour(new MoveAnimBehaviour());
            entity.AddBehaviour(new AimAnimBehaviour());
            entity.AddBehaviour(new AttackAnimBehaviour());
            entity.AddBehaviour(new DeathAnimBehaviour());
            entity.AddBehaviour(new LinkRootToTransformBehavior());
            entity.AddBehaviour(new TakeDamageAnimBehaviour());
            entity.AddBehaviour(new AnimationTriggerBehaviour(fireEvent, () =>
            {
                entity.GetWeapon().GetAttackAction().Invoke();
            }));
        }
    }
}