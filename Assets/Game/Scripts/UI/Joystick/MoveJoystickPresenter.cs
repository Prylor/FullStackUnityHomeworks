using Atomic.Presenters;
using Gameplay.Context.Game;
using Gameplay.Context.Game.Input;
using Modules.Common;
using UnityEngine;

namespace UI
{
    public class MoveJoystickPresenter: Presenter
    {
        [SerializeField]
        private Joystick moveJoystick;
        
        private bool _isMoving;
        private IGameContext _gameContext;

        protected override void OnInit() 
            => _gameContext = GameContext.Instance;

        protected override void OnShow() 
            => moveJoystick.PointerDown += OnStartMoving;

        protected override void OnHide() 
            => moveJoystick.PointerDown -= OnStartMoving;

        private void Update()
        {
            if (_isMoving)
            {
                InputUseCase.SetMoveDirection(_gameContext, moveJoystick.Direction);
            }
        }

        private void OnStartMoving()
        {
            _isMoving = true;
        }
    }
}