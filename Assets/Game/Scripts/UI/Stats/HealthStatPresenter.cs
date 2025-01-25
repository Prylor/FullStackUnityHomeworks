using Atomic.Presenters;
using Gameplay.Context.Game;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.UI
{
    public class HealthStatPresenter: Presenter
    {
        [SerializeField]
        private StatView statView;

        private Health _health;

        protected override void OnInit()
        {
            var gameContext = GameContext.Instance;
            _health = gameContext.GetCharacter().GetHealth();
        }

        protected override void OnShow()
        {
            _health.OnStateChanged += UpdateHealth;
            UpdateHealth();
        }
        
        protected override void OnHide()
        {
            _health.OnStateChanged -= UpdateHealth;
        }

        private void UpdateHealth()
        {
            statView.SetProgress(_health.GetPercent());
            statView.SetText(_health.GetCurrent().ToString());
        }
    }
}