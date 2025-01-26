using Atomic.Entities;
using SampleGame.Common.Health;
using UnityEngine;

namespace SampleGame.Common
{
    public class TargetUseCase
    {
        public static bool IsTargetReached(in IEntity entity)
        {
            if (!entity.TryGetTarget(out var target) || target.Value == null)
                return false;

            if (!entity.TryGetStoppingDistance(out var stoppingDistance))
                return false; 
            
            var transform = entity.GetTransform();
            var targetTransform = target.Value.GetTransform();
            
            return Vector3.Distance(transform.position, targetTransform.position) <= stoppingDistance.Value;
        }

        public static bool IsTargetAlive(IEntity entity)
        {
            if (!entity.TryGetTarget(out var target) || target.Value == null)
                return false;
            
            return HealthUseCase.IsAlive(target.Value);
        }
    }
}