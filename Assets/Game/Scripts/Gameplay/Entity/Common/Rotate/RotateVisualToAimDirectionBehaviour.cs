using Atomic.Entities;
using SampleGame;

namespace Gameplay.Entity.Common.Rotate
{
    public class RotateVisualToAimDirectionBehaviour: IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            var direction = entity.GetAimDirection().Value;
            RotateUseCase.RotateVisualAround(entity, direction, deltaTime);
        }
    }
}