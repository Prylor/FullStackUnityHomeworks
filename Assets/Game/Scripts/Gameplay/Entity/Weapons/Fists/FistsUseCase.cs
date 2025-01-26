using System.Buffers;
using Atomic.Entities;
using Gameplay.Entity.Common.TakeDamage;
using UnityEngine;


namespace SampleGame.Weapons
{
    public static class FistsUseCase
    {
        public static bool Attack(IEntity fists)
        {
            if (fists.GetAttackCondition().Invoke())
            {
                var attackPoint = fists.GetAttackPoint().position;
                var attackRadius = fists.GetAttackRadius().Value;

                if (OverlapSphereCharacter(attackPoint, attackRadius, out var character))
                {
                    var args = new TakeDamageArgs(fists, fists.GetDamage().Value);
                    TakeDamageUseCase.TakeDamage(character, args);
                }

                fists.GetAttackCooldown().Reset();
                fists.GetAttackEvent().Invoke();
                return true;
            }

            return false;
        }

        // Можно вынести в более общий скоуп, но пока только тут нужно
        public static bool OverlapSphereCharacter(Vector3 point, float radius, out IEntity character)
        {
            character = null;

            var results = ArrayPool<Collider>.Shared.Rent(5);
            var count = Physics.OverlapSphereNonAlloc(point, radius, results);

            for (var i = 0; i < count; i++)
            {
                var collider = results[i];

                if (collider.TryGetComponent<IEntity>(out var entity) && entity.HasCharacterTag())
                {
                    character = entity;
                    return true;
                }
            }

            return false;
        }
    }
}