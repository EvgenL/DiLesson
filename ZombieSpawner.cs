using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace Scripts
{
    public class ZombieSpawner : ITickable
    {
        [Inject] private Func<float, Zombie> _zombieFactory;
        private float _spawnTimer = 1f;
        private float _spawnCooldown = 1f;
        
        public void Tick()
        {
            _spawnTimer -= Time.deltaTime;
            if (_spawnTimer <= 0)
            {
                _spawnTimer = _spawnCooldown;
                _zombieFactory(Random.Range(1f, 2f));
            }
        }
    }
}