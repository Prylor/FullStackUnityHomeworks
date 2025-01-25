/**
* Code generation. Don't modify! 
**/

using Atomic.Contexts;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Entities;
using Gameplay.Context.Game;
using Gameplay.Context.Game.Input;
using Atomic.Elements;

namespace SampleGame
{
	public static class GameContextAPI
	{


		///Values
		public const int Character = 294335127; // IEntity
		public const int GlobalPool = -2116782381; // GlobalSceneEntityPool
		public const int ProjectilePrefab = 1557533000; // SceneEntity
		public const int Kills = -291106651; // IReactiveVariable<int>


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEntity GetCharacter(this IGameContext obj) => obj.GetValue<IEntity>(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharacter(this IGameContext obj, out IEntity value) => obj.TryGetValue(Character, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCharacter(this IGameContext obj, IEntity value) => obj.AddValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacter(this IGameContext obj) => obj.HasValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacter(this IGameContext obj) => obj.DelValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharacter(this IGameContext obj, IEntity value) => obj.SetValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GlobalSceneEntityPool GetGlobalPool(this IGameContext obj) => obj.GetValue<GlobalSceneEntityPool>(GlobalPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGlobalPool(this IGameContext obj, out GlobalSceneEntityPool value) => obj.TryGetValue(GlobalPool, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddGlobalPool(this IGameContext obj, GlobalSceneEntityPool value) => obj.AddValue(GlobalPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGlobalPool(this IGameContext obj) => obj.HasValue(GlobalPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGlobalPool(this IGameContext obj) => obj.DelValue(GlobalPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGlobalPool(this IGameContext obj, GlobalSceneEntityPool value) => obj.SetValue(GlobalPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity GetProjectilePrefab(this IGameContext obj) => obj.GetValue<SceneEntity>(ProjectilePrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetProjectilePrefab(this IGameContext obj, out SceneEntity value) => obj.TryGetValue(ProjectilePrefab, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddProjectilePrefab(this IGameContext obj, SceneEntity value) => obj.AddValue(ProjectilePrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasProjectilePrefab(this IGameContext obj) => obj.HasValue(ProjectilePrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelProjectilePrefab(this IGameContext obj) => obj.DelValue(ProjectilePrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetProjectilePrefab(this IGameContext obj, SceneEntity value) => obj.SetValue(ProjectilePrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetKills(this IGameContext obj) => obj.GetValue<IReactiveVariable<int>>(Kills);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetKills(this IGameContext obj, out IReactiveVariable<int> value) => obj.TryGetValue(Kills, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddKills(this IGameContext obj, IReactiveVariable<int> value) => obj.AddValue(Kills, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasKills(this IGameContext obj) => obj.HasValue(Kills);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelKills(this IGameContext obj) => obj.DelValue(Kills);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetKills(this IGameContext obj, IReactiveVariable<int> value) => obj.SetValue(Kills, value);
    }
}
