using Atomic.Entities;
using SampleGame;
using SampleGame.Common.Aim;

namespace Gameplay.Entity.Common.Rotate
{
    public class RotateVisualToMoveDirectionBehaviour: IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            if(AimUseCases.IsAiming(entity))
                return;
            
            var direction = entity.GetMoveDirection().Value;
            RotateUseCase.RotateVisualAround(entity, direction, deltaTime);
        }
    }
}