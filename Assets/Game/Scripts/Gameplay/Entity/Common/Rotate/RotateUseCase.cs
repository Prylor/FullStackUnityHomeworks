using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public static class RotateUseCase
    {
        public static void RotateAround(in IEntity entity, in Vector2 direction, in float deltaTime)
        {
            if (direction == Vector2.zero)
                return;

            if (!entity.TryGetTransform(out var transform))
                return;
            
            if(!entity.TryGetAngularSpeed(out var angularSpeed))
                return;
            
            if(!entity.TryGetRotateCondition(out var rotateCondition) || !rotateCondition.Invoke())
                return;
            
            RotateAround(direction, deltaTime, transform, angularSpeed);
        }

        public static void RotateVisualAround(in IEntity entity, in Vector2 direction, in float deltaTime)
        {
            if (direction == Vector2.zero)
                return;

            if (!entity.TryGetVisualRoot(out var transform))
                return;
            
            if(!entity.TryGetAngularSpeed(out var angularSpeed))
                return;
            
            if(!entity.TryGetRotateCondition(out var rotateCondition) || !rotateCondition.Invoke())
                return;
            
            RotateAround(direction, deltaTime, transform, angularSpeed);
        }

        private static void RotateAround(Vector2 direction, float deltaTime, Transform transform, IValue<float> angularSpeed)
        {
            var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            var targetRotation = Quaternion.Euler(0, angle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, angularSpeed.Value * deltaTime);
        }
    }
}