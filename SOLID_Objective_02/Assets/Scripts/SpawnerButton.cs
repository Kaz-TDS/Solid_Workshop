/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using Factories;
using Tripledot.Adventure.Enums;
using Tripledot.Adventure.Factories.Interfaces;
using Tripledot.Adventure.Logging;
using UnityEngine;

namespace Tripledot.Adventure
{
    public class SpawnerButton : MonoBehaviour
    {
        public EnemyType enemyType;
        public BossType bossType;
        private readonly IEnemySpawner spawner = new LoggingEnemySpawner(new EnemySpawnerDefault(), new SpawnerLogger(Debug.unityLogger));

        public void SpawnEnemy()
        {
            this.spawner.SpawnEnemy(this.enemyType);
        }

        public void SpawnBoss()
        {
            switch (this.bossType) {
                case BossType.Weak:
                    this.spawner.SpawnWeakBoss(this.enemyType);
                    break;
                case BossType.Average:
                    this.spawner.SpawnAverageBoss(this.enemyType);
                    break;
                case BossType.Strong:
                    this.spawner.SpawnStrongBoss(this.enemyType);
                    break;
                default:
                    Debug.LogError("Unknown boss type requested");
                    break;
            }
        }

        public void SpawnRandomBossLevel()
        {
            this.spawner.SpawnRandomBoss(this.enemyType);
        }
    }    
}
