using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public static class MoveUseCase
    {
        public static bool IsMoving(in IEntity entity)
        {
            return entity.GetMoveDirection().Value != Vector2.zero && entity.GetMoveCondition().Value;
        }
        
        public static void MoveTowards(in IEntity entity, in Vector2 direction, in float deltaTime)
        {
            if (entity.TryGetMoveCondition(out var condition) && !condition.Value)
                return;

            var transform = entity.GetTransform();
            var speed = entity.GetMoveSpeed();
            var delta = direction * (speed.Invoke() * deltaTime);
            transform.position += new Vector3(delta.x, 0, delta.y);
        }
    }
}