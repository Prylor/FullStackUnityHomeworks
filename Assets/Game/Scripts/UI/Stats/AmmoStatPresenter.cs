using Atomic.Presenters;
using Gameplay.GameContext;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.UI
{
    public class AmmoStatPresenter: Presenter
    {
        [SerializeField]
        private StatView statView;

        private Ammo _ammo;

        protected override void OnInit()
        {
            var gameContext = GameContext.Instance;
            var character = gameContext.GetCharacter();
            var weapon = character.GetWeapon();
            _ammo = weapon.GetAmmo();
        }

        protected override void OnShow()
        {
            _ammo.OnStateChanged += UpdateHealth;
            UpdateHealth();
        }
        
        protected override void OnHide()
        {
            _ammo.OnStateChanged -= UpdateHealth;
        }

        private void UpdateHealth()
        {
            statView.SetText(_ammo.GetCount().ToString());
        }
    }
}