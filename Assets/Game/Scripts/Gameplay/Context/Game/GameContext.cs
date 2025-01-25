using Atomic.Contexts;

namespace Gameplay.Context.Game
{
    public interface IGameContext : IContext
    {
    }
    
    public class GameContext: SingletonSceneContext<GameContext>, IGameContext
    {
    }
}