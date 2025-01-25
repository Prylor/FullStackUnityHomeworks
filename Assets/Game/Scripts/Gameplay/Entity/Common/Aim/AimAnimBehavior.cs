using Atomic.Entities;
using SampleGame.Common.Aim;
using UnityEngine;

namespace SampleGame
{
    public sealed class AimAnimBehaviour : IEntityInit, IEntityUpdate
    {
        private static readonly int IsAiming = Animator.StringToHash("IsAiming");
        private static readonly int AimX = Animator.StringToHash("AimX");
        private static readonly int AimZ = Animator.StringToHash("AimZ");

        private Animator _animator;

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            var aimDirection = entity.GetAimDirection().Value;
            
            _animator.SetBool(IsAiming, AimUseCases.IsAiming(entity));
            _animator.SetFloat(AimX, aimDirection.x);
            _animator.SetFloat(AimZ, aimDirection.y);
        }
    }
}