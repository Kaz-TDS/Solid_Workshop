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

namespace Tripledot.Adventure.Analytics
{
    public class SpawnerAnalytics : ISpawnerAnalytics
    {
        private readonly IEnemyAnalyticsTracker enemyTracker;
        private readonly IBossAnalyticsTracker bossTracker;

        public SpawnerAnalytics(IEnemyAnalyticsTracker enemyTracker, IBossAnalyticsTracker bossTracker)
        {
            this.enemyTracker = enemyTracker;
            this.bossTracker = bossTracker;
        }
        
        public void TrackEnemy(IEnemy enemy)
        {
            this.enemyTracker.TrackEnemy(enemy);
        }

        public void TrackBoss(IBoss boss)
        {
            this.bossTracker.TrackBoss(boss);
        }
    }
}