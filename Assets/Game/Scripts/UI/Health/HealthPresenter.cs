using Atomic.Elements;
using Atomic.Presenters;
using Gameplay.Context.Game;
using Gameplay.Entity.Common.TakeDamage;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.UI
{
    public class HealthPresenter: Presenter
    {
        [SerializeField]
        private HealthScreen healthScreen;
        
        private Health _health;
        private IReactive<TakeDamageArgs> _takeDamageEvent;
        
        protected override void OnInit()
        {
            var gameContext = GameContext.Instance;
            var character = gameContext.GetCharacter();
            
            _health = character.GetHealth();
            _takeDamageEvent = character.GetDamageTakenEvent();
        }

        protected override void OnShow()
        {
            _health.OnStateChanged += UpdateHealth;
            _takeDamageEvent.Subscribe(OnTakeDamage);
        }
        
        protected override void OnHide()
        {
            _health.OnStateChanged += UpdateHealth;
            _takeDamageEvent.Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(TakeDamageArgs args)
        {
            healthScreen.TakeDamage(args.Damage);
        }

        private void UpdateHealth()
        {
            healthScreen.ChangePercent(_health.GetPercent());
        }
    }
}