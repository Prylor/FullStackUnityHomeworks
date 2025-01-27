using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using SampleGame;

namespace Game.Gameplay
{
    public class DeathBehaviour: IEntityInit, IEntityEnable, IEntityDisable
    {
        private Health _health;
        private IEvent _deathEvent;
        
        public void Init(in IEntity entity)
        {
            _health = entity.GetHealth();
            _deathEvent = entity.GetDeathEvent();
        }

        public void Enable(in IEntity entity)
        {
            _health.OnHealthEmpty += OnHealthEmpty;
        }

        public void Disable(in IEntity entity)
        {
            _health.OnHealthEmpty -= OnHealthEmpty;
        }

        private void OnHealthEmpty()
        {
            _deathEvent.Invoke();
        }
    }
}