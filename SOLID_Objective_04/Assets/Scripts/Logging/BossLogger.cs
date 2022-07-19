/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content.
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using Tripledot.Adventure.Enemies.Interfaces;
using Tripledot.Adventure.Logging.Interfaces;
using Tripledot.Adventure.Utilities;
using UnityEngine;

namespace Tripledot.Adventure.Logging
{
    public class BossLogger : IBossLogger
    {
        private static readonly string LoggerTag = $"<b>{nameof(BossLogger)}</b>";
        
        private readonly ILogger logger;

        public BossLogger(ILogger logger)
        {
            this.logger = logger;
        }
        public void LogBoss(IBoss boss)
        {
            var enemyType = EnemyUtilities.GetEnemyType(boss.EnemyType);
            var bossType = EnemyUtilities.GetBossType(boss.BossType);
            this.logger.Log(LoggerTag, $"Spawned a {bossType} boss of type: {enemyType}.");
        }
    }
}