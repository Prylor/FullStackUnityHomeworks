using Atomic.Presenters;
using Gameplay.Context.Game;
using Gameplay.Context.Game.Input;
using Modules.Common;
using Modules.Gameplay;
using UnityEngine;

namespace UI
{
    public class AttackJoystickPresenter: Presenter
    {
        [SerializeField]
        private Joystick attackJoystick;

        [SerializeField] 
        private float attackStartDelay;
        
        private bool _isAttacking;
        private IGameContext _gameContext;
        private Cooldown _cooldown;
        
        protected override void OnInit()
        {
            _gameContext = GameContext.Instance;
            _cooldown = new Cooldown(attackStartDelay);
        }

        protected override void OnShow()
        {
            attackJoystick.PointerDown += OnStartAttack;
            attackJoystick.PointerUp += OnEndAttack;
        }
        
        protected override void OnHide()
        {
            attackJoystick.PointerDown -= OnStartAttack;
            attackJoystick.PointerUp -= OnEndAttack;
        }
        
        private void Update()
        {
            if (_isAttacking && _cooldown.IsExpired())
            {
                InputUseCase.TriggerAttack(_gameContext);
            }
            
            _cooldown.Tick(Time.deltaTime);
        }

        private void OnStartAttack()
        {
            _isAttacking = true;
            _cooldown.Reset();
        }
        
        private void OnEndAttack()
        {
            _isAttacking = false;
        }
    }
}