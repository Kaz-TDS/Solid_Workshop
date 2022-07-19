/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content.
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using System.Collections.Generic;
using Tripledot.Adventure.Analytics.Interfaces;
using Tripledot.Adventure.Enemies.Interfaces;
using Tripledot.Adventure.Enums;
using Tripledot.Adventure.Utilities;
using UnityEngine;

namespace Tripledot.Adventure.Analytics
{
    public class SpawnerAnalytics : ISpawnerAnalytics
    {
        private readonly ILogger logger;
        private readonly HashSet<EnemyType> knownEnemyTypes;
        private readonly HashSet<BossType> knownBossTypes;

        private static readonly string LoggerTag = $"<b>{nameof(SpawnerAnalytics)}</b>";
        private static readonly string NewEnemyType = $"<b><color=#CF5959>NEW_ENEMY_TYPE</color></b>";
        private static readonly string NewBossType = $"<b><color=#A0CF59>NEW_BOSS_TYPE</color></b>";
        private static readonly string EnemySpawned = $"<b><color=#59BBCF>ENEMY_SPAWNED</color></b>";
        private static readonly string BossSpawned = $"<b><color=#CF59A4>BOSS_SPAWNED</color></b>";

        public SpawnerAnalytics(ILogger logger)
        {
            this.logger = logger;
            this.knownEnemyTypes = new HashSet<EnemyType>();
            this.knownBossTypes = new HashSet<BossType>();
        }
        
        public void TrackEnemy(IEnemy enemy)
        {
            var enemyType = EnemyUtilities.GetEnemyType(enemy.EnemyType);
            if (!this.knownEnemyTypes.Contains(enemy.EnemyType)) {
                // Track NewEnemyType event
                this.logger.Log(LoggerTag, $"{NewEnemyType} - First encounter with an {enemyType}.");
                this.knownEnemyTypes.Add(enemy.EnemyType);
            }
            // Track EnemySpawned
            this.logger.Log(LoggerTag, $"{EnemySpawned} - Spawned {enemyType}");
        }

        public void TrackBoss(IBoss boss)
        {
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