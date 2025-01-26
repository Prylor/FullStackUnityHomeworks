using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;
using Gameplay.GameContext;
using Modules.Gameplay;
using UnityEngine;

namespace SampleGame.Weapons
{
    
    public class PistolInstaller : SceneEntityInstaller
    {
        private const string FireEventName = "fire";

        [SerializeField]
        private int initialAmmo = 5;

        [SerializeField] 
        private WeaponCoreInstaller core;
        
        [SerializeField]
        private WeaponAudioInstaller audio;
        
        [SerializeField]
        private WeaponVfxInstaller vfx;
        
        public override void Install(IEntity entity)
        {
            var gameContext = GameContext.Instance;
            var ammo = new Ammo(initialAmmo);

            core.Install(entity);
            audio.Install(entity);
            vfx.Install(entity);
            
            entity.AddAmmo(ammo);
            entity.GetAttackCondition().Append(() => entity.GetAmmo().Exists());
            
            entity.AddAttackAction(new BaseAction(() => PistolUseCase.Fire(gameContext, entity)));
        }
    }
}