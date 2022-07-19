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
    public class BossAnalyticsTracker : IBossAnalyticsTracker
    {
        private readonly ILogger logger;
        private readonly HashSet<BossType> knownBossTypes;

        private static readonly string LoggerTag = $"<b>{nameof(BossAnalyticsTracker)}</b>";
        
        private static readonly string NewBossType = $"<b><color=#A0CF59>NEW_BOSS_TYPE</color></b>";
        
        private static readonly string BossSpawned = $"<b><color=#CF59A4>BOSS_SPAWNED</color></b>";

        public BossAnalyticsTracker(ILogger logger)
        {
            this.logger = logger;
            this.knownBossTypes = new HashSet<BossType>();
        }
        public void TrackBoss(IBoss boss)
        {
            if (boss == null) {
                throw new ArgumentNullException(nameof(boss));
            }

            var enemyType = EnemyUtilities.GetEnemyType(boss.EnemyType);
            var bossType = EnemyUtilities.GetBossType(boss.BossType);
            if (!this.knownBossTypes.Contains(boss.BossType)) {
                // Track NewBossType event
                this.logger.Log(LoggerTag, $"{NewBossType} - First encounter with an {enemyType} boss of the {bossType} variety.");
                this.knownBossTypes.Add(boss.BossType);
            }
            // Track BossSpawned
            this.logger.Log(LoggerTag, $"{BossSpawned} - Spawned an {enemyType} boss of the {bossType} variety.");
        }
    }
}