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
using Tripledot.Adventure.Factories;
using Tripledot.Adventure.Factories.Interfaces;

namespace DefaultNamespace
{
    public class EnemySpawnerHard : IEnemySpawner
    {
        private const float BossHealthMultiplier = 0.5f;
        private const int BossDamageModifier = 2;
        
        private readonly Random rng = new Random(DateTime.Now.Millisecond);
        
        private readonly EnemyFactory goblinFactory;
        private readonly EnemyFactory orcFactory;
        private readonly EnemyFactory ogreFactory;

        private readonly BossFactory goblinBossFactory;
        private readonly BossFactory orcBossFactory;
        private readonly BossFactory ogreBossFactory;

        public EnemySpawnerHard()
        {
            var goblinStats = new EnemySpawnerStats(20, 50, 3, 5, 1, 3);
            var orcStats = new EnemySpawnerStats(30, 60, 2, 4, 2, 4);
            var ogreStats = new EnemySpawnerStats(50, 100, 1, 3, 3, 6);

            this.goblinFactory = new EnemyFactory(EnemyType.Goblin, goblinStats);
            this.orcFactory = new EnemyFactory(EnemyType.Orc, orcStats);
            this.ogreFactory = new EnemyFactory(EnemyType.Ogre, ogreStats);

            this.goblinBossFactory = new BossFactory(EnemyType.Goblin, goblinStats, BossHealthMultiplier, BossDamageModifier);
            this.orcBossFactory = new BossFactory(EnemyType.Orc, orcStats, BossHealthMultiplier, BossDamageModifier);
            this.ogreBossFactory = new BossFactory(EnemyType.Ogre, ogreStats, BossHealthMultiplier, BossDamageModifier);
        }
        
        public IEnemy SpawnEnemy(EnemyType enemyType)
        {
            switch (enemyType) {
                case EnemyType.Goblin:
                    return this.goblinFactory.CreateEnemy();
                case EnemyType.Orc:
                    return this.orcFactory.CreateEnemy();
                case EnemyType.Ogre:
                    return this.ogreFactory.CreateEnemy();
                default:
                    return null;
            }
        }

        public IBoss SpawnMidBoss(EnemyType enemyType)
        {
            return SpawnBoss(enemyType, BossType.Weak);
        }

        public IBoss SpawnLevelBoss(EnemyType enemyType)
        {
            return SpawnBoss(enemyType, BossType.Average);
        }

        public IBoss SpawnBigBoss(EnemyType enemyType)
        {
            return SpawnBoss(enemyType, BossType.Strong);
        }

        public IBoss SpawnRandomBoss(EnemyType enemyType)
        {
            var bossType = (BossType)this.rng.Next(0, 3);
            return SpawnBoss(enemyType, bossType);
        }

        private IBoss SpawnBoss(EnemyType enemyType, BossType bossType)
        {
            switch (enemyType) {
                case EnemyType.Goblin:
                    return this.goblinBossFactory.CreateBoss(bossType);
                case EnemyType.Orc:
                    return this.orcBossFactory.CreateBoss(bossType);
                case EnemyType.Ogre:
                    return this.ogreBossFactory.CreateBoss(bossType);
                default:
                    return null;
            }
        }
    }
}