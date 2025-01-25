using System;
using Atomic.Entities;

namespace Gameplay.Entity.Common.TakeDamage
{
    public class TakeDamageArgs
    {
        public readonly int Damage;
        public readonly IEntity Source;

        public TakeDamageArgs(IEntity source, int damage)
        {
            Source = source;
            Damage = damage;
        }
    }
}