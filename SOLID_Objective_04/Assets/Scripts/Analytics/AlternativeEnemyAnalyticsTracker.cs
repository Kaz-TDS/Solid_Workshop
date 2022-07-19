/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content.
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using System;
using System.Collections.Generic;
using Tripledot.Adventure.Analytics.Interfaces;
using Tripledot.Adventure.Enemies.Interfaces;
using Tripledot.Adventure.Enums;
using Tripledot.Adventure.Utilities;
using UnityEngine;

namespace Tripledot.Adventure.Analytics
{
    public class AlternativeEnemyAnalyticsTracker : IEnemyAnalyticsTracker
    {
        private static readonly string LoggerTag = $"<b>{nameof(AlternativeEnemyAnalyticsTracker)}</b>";
        
        private static readonly string NewEnemyType = $"<b><color=#CF5959>NEW_ENEMY_TYPE</color></b>";
        private static readonly string EnemySpawned = $"<b><color=#59BBCF>ENEMY_SPAWNED</color></b>";
        
        private readonly HashSet<EnemyType> knownEnemyTypes;
        private readonly ILogger logger;

        public AlternativeEnemyAnalyticsTracker(ILogger logger)
        {
            this.logger = logger;
            this.knownEnemyTypes = new HashSet<EnemyType>();
        }
        
        public void TrackEnemy(IEnemy enemy)
        {
            if (enemy == null) {
                throw new ArgumentNullException(nameof(enemy));
            }

            var enemyType = EnemyUtilities.GetEnemyType(enemy.EnemyType);
            if (!this.knownEnemyTypes.Contains(enemy.EnemyType)) {
                // Track NewEnemyType event
                this.logger.Log(LoggerTag, $"<size=25>{NewEnemyType} - First encounter with an {enemyType}.</size>");
                this.knownEnemyTypes.Add(enemy.EnemyType);
            }
            // Track EnemySpawned
            this.logger.Log(LoggerTag, $"<size=25>{EnemySpawned} - Spawned {enemyType}</size>");
        }
    }
}