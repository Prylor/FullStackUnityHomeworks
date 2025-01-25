using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveAnimBehaviour : IEntityInit, IEntityUpdate
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        
        private Animator _animator;
        
        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            _animator.SetBool(IsMoving, MoveUseCase.IsMoving(entity));
        }
    }
}