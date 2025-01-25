using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public static class ItemUseCase
    {
        public static bool Use(in IEntity item, in Collider collider)
        {
            return collider != null && collider.TryGetComponent(out IEntity other) && Use(item, other);
        }

        public static bool Use(in IEntity item, in IEntity target)
        {
            if (target == null)
                return false;

            if (item == null || !item.HasItemTag())
                return false;

            if (!item.TryGetUseCondition(out var condition) || !condition.Invoke(target))
                return false;

            // Сделал по простому
            item.GetVisualRoot().gameObject.SetActive(false);
            item.GetCollider().enabled = false;
            item.GetUseAction().Invoke(target);
            
            return true;
        }
    }
}