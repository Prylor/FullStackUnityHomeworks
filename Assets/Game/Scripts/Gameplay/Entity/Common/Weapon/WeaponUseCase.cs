using Atomic.Entities;

namespace SampleGame
{
    public static class WeaponUseCase
    {
        public static bool AddClips(in IEntity character, in int clips)
        {
            var weapon = character.GetWeapon();
            if (weapon == null)
                return false;

            if (!weapon.TryGetAmmo(out var ammo))
                return false;

            ammo.Add(clips);
            return true;
        }
    }
}