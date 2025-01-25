using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Gameplay.Context.Game
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