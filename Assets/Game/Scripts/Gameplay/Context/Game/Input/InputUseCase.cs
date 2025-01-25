using SampleGame;
using UnityEngine;

namespace Gameplay.Context.Game.Input
{
    public static class InputUseCase
    {
        public static void SetMoveDirection(IGameContext gameContext, Vector2 direction)
        {
            if (!gameContext.TryGetCharacter(out var character))
                return;

            if (!character.TryGetMoveDirection(out var moveDirection))
                return;

            moveDirection.Value = direction;
        }

        public static void SetAimDirection(IGameContext gameContext, Vector2 direction)
        {
            if (!gameContext.TryGetCharacter(out var character))
                return;

            if (!character.TryGetAimDirection(out var aimDirection))
                return;

            aimDirection.Value = direction;
        }

        public static void TriggerAttack(IGameContext gameContext)
        {
            if (!gameContext.TryGetCharacter(out var character))
                return;

            if (!character.TryGetAttackAction(out var attackAction))
                return;

            attackAction.Invoke();
        }
    }
}