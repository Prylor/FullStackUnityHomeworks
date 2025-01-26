using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Gameplay.GameContext.Projectiles;
using SampleGame;
using UnityEngine;

namespace Gameplay.GameContext
{
    public class GameContextInstaller : SceneContextInstaller<IGameContext>
    {
        [SerializeField] private SceneEntity character;
        [SerializeField] private Transform  poolContainer;
        [SerializeField] private ProjectileSystemInstaller projectileSystemInstaller;
        
        protected override void Install(IGameContext context)
        {
            context.SetKills(new ReactiveInt());
            context.SetCharacter(character);
            context.AddGlobalPool(new GlobalSceneEntityPool(poolContainer));
            projectileSystemInstaller.Install(context);
        }
    }
}