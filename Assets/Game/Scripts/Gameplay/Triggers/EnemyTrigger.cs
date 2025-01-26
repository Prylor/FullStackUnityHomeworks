using System;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    [RequireComponent(typeof(Collider))]
    public sealed class EnemyTrigger : MonoBehaviour
    {
        [SerializeField] private SceneEntity[] _enemies;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<IEntity>(out var entity) || !entity.HasCharacterTag())
                return;
            
            foreach (var enemy in _enemies)
            {
                EnemyUseCase.SetTarget(enemy, entity);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent<IEntity>(out var entity) || !entity.HasCharacterTag())
                return;
            
            foreach (var enemy in _enemies)
            {
                EnemyUseCase.ResetTarget(enemy);
            }
        }
    }
}