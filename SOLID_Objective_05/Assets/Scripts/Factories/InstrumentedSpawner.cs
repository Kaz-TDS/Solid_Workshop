/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content.
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using Tripledot.Adventure.Analytics.Interfaces;
using Tripledot.Adventure.Enemies.Interfaces;
using Tripledot.Adventure.Enums;
using Tripledot.Adventure.Factories.Interfaces;
using Tripledot.Adventure.Logging.Interfaces;

namespace Tripledot.Adventure.Factories
{
    public class InstrumentedSpawner : IEnemySpawner
    {
        private readonly IEnemySpawner spawner;
        private readonly ISpawnerLogger logger;
        private readonly ISpawnerAnalytics analytics;

        public InstrumentedSpawner(IEnemySpawner spawner, ISpawnerLogger logger, ISpawnerAnalytics analytics)
        {
            this.spawner = spawner;
            this.logger = logger;
            this.analytics = analytics;
        }
        public IEnemy SpawnEnemy(EnemyType enemyType)
        {
            var enemy = this.spawner.SpawnEnemy(enemyType);
            this.logger.LogEnemy(enemy);
            this.analytics.TrackEnemy(enemy);
            return enemy;
        }

        public IBoss SpawnWeakBoss(EnemyType enemyType)
        {
            var boss = this.spawner.SpawnWeakBoss(enemyType);
            this.logger.LogBoss(boss);
            this.analytics.TrackBoss(boss);
            return boss;
        }

        public IBoss SpawnAverageBoss(EnemyType enemyType)
        {
            var boss = this.spawner.SpawnAverageBoss(enemyType);
            this.logger.LogBoss(boss);
            this.analytics.TrackBoss(boss);
            return boss;
        }

        public IBoss SpawnStrongBoss(EnemyType enemyType)
        {
            var boss = this.spawner.SpawnStrongBoss(enemyType);
            this.logger.LogBoss(boss);
            this.analytics.TrackBoss(boss);
            return boss;
        }

        public IBoss SpawnRandomBoss(EnemyType enemyType)
        {
            var boss = this.spawner.SpawnRandomBoss(enemyType);
            this.logger.LogBoss(boss);
            this.analytics.TrackBoss(boss);
            return boss;
        }
    }
}