/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content.
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using System;
using Tripledot.Adventure.Enemies;
using Tripledot.Adventure.Enemies.Interfaces;
using Tripledot.Adventure.Enums;
using UnityEngine;
using Random = System.Random;

namespace Tripledot.Adventure.Factories
{
    public class EnemyFactory
    {
        private readonly EnemyType enemyType;
        private readonly EnemySpawnerStats spawnerStats;
        
        private readonly Random rng;

        public EnemyFactory(
            EnemyType enemyType,
            EnemySpawnerStats spawnerStats)
        {
            this.enemyType = enemyType;
            this.spawnerStats = spawnerStats;
            
            this.rng = new Random(DateTime.Now.Millisecond);
        }
        
        public IEnemy CreateEnemy()
        {
            return new CommonEnemy(
                this.enemyType,
                this.rng.Next(this.spawnerStats.MinHealth, this.spawnerStats.MaxHealth),
                this.rng.Next(this.spawnerStats.MinSpeed, this.spawnerStats.MaxSpeed),
                this.rng.Next(this.spawnerStats.MinDamage, this.spawnerStats.MaxDamage),
                Vector2Int.zero);
        }
    }
}