using Atomic.Entities;
using UnityEngine;

namespace SampleGame.Common.Aim
{
    public class AimUseCases
    {
        public static bool IsAiming(in IEntity entity)
        {
            if (!entity.TryGetAimDirection(out var aimDirection))
                return false;
            
            return entity.GetAimDirection().Value != Vector2.zero;
        }
    }
}