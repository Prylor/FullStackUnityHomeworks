using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class MoveTowardsBehaviour : IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            var direction = entity.GetMoveDirection();
            MoveUseCase.MoveTowards(entity, direction.Value, deltaTime);
        }
    }
}