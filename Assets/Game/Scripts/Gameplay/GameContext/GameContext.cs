using Atomic.Contexts;

namespace Gameplay.GameContext
{
    public interface IGameContext : IContext
    {
    }
    
    public class GameContext: SingletonSceneContext<GameContext>, IGameContext
    {
    }
}