using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Gameplay.Entity.Common.Move
{
    public class MoveToTargetBehaviour : IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            if (!entity.TryGetTarget(out var target) || target.Value == null)
            {
                entity.GetMoveDirection().Value = Vector2.zero;
                return;
            }
            
            var selfPosition = entity.GetTransform().position;
            var targetPosition = target.Value.GetTransform().position;
            var direction = targetPosition - selfPosition;
            entity.GetMoveDirection().Value = new Vector2(direction.x, direction.z).normalized;
        }
    }
}