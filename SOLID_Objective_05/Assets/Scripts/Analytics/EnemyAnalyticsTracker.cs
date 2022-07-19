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
using Tripledot.Adventure.Utilities;
using UnityEngine;

namespace Tripledot.Adventure.Analytics
{
    public class EnemyAnalyticsTracker : IEnemyAnalyticsTracker
    {
        private static readonly string LoggerTag = $"<b>{nameof(EnemyAnalyticsTracker)}</b>";
        
        private static readonly string NewEnemyType = $"<b><color=#CF5959>NEW_ENEMY_TYPE</color></b>";
        private static readonly string EnemySpawned = $"<b><color=#59BBCF>ENEMY_SPAWNED</color></b>";
        
        private readonly IKnownCreaturesRepository knownCreatures;
        private readonly ILogger logger;

        public EnemyAnalyticsTracker(ILogger logger, IKnownCreaturesRepository knownCreaturesRepository)
        {
            this.logger = logger;
            this.knownCreatures = knownCreaturesRepository;
        }
        
        public void TrackEnemy(IEnemy enemy, bool onlyIfUnknown = false)
        {
            var enemyType = EnemyUtilities.GetEnemyType(enemy.EnemyType);
            if (!this.knownCreatures.IsEnemyTypeKnown(enemy.EnemyType)) {
                // Track NewEnemyType event
                this.logger.Log(LoggerTag, $"{NewEnemyType} - First encounter with an {enemyType}.");
                this.knownCreatures.SetEnemyTypeAsKnown(enemy.EnemyType);
            }
            if (!onlyIfUnknown) {
                // Track EnemySpawned
                this.logger.Log(LoggerTag, $"{EnemySpawned} - Spawned {enemyType}");
            }
        }
    }
}