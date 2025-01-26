using Atomic.Presenters;
using Gameplay.GameContext;
using Gameplay.GameContext.Input;
using Modules.Common;
using UnityEngine;

namespace UI
{
    public class AimJoystickPresenter: Presenter
    {
        [SerializeField]
        private Joystick aimJoystick;
        
        private bool _isAiming;
        private IGameContext _gameContext;

        protected override void OnInit() 
            => _gameContext = GameContext.Instance;

        protected override void OnShow() 
            => aimJoystick.PointerDown += OnStartMoving;

        protected override void OnHide() 
            => aimJoystick.PointerDown -= OnStartMoving;

        private void Update()
        {
            if (_isAiming)
            {
                InputUseCase.SetAimDirection(_gameContext, aimJoystick.Direction);
            }
        }

        private void OnStartMoving()
        {
            _isAiming = true;
        }
    }
}