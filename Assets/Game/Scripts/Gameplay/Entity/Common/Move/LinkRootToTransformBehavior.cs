using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public class LinkRootToTransformBehavior: IEntityUpdate, IEntityInit
    {
        private Transform _root;
        private Transform _transform;

        public void Init(in IEntity entity)
        {
            _root = entity.GetTransform();
            _transform = entity.GetVisualRoot();
        }

        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
            _root.position += _transform.localPosition;
            _transform.localPosition = Vector3.zero;
        }
    }
}