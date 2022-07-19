/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using System;
using Tripledot.Adventure.Enemies.Interfaces;
using Tripledot.Adventure.Enums;
using Tripledot.Adventure.Logging.Interfaces;
using UnityEngine;

namespace Tripledot.Adventure.Logging
{
    public class SpawnerLogger : ISpawnerLogger
    {
        private static readonly string LoggerTag = $"<b>{nameof(SpawnerLogger)}</b>";
        
        private readonly ILogger logger;

        public SpawnerLogger(ILogger logger)
        {
            this.logger = logger;
        }
        public void LogEnemy(IEnemy enemy)
        {
            var enemyType = $"<b><i>{Enum.GetName(typeof(EnemyType), enemy.EnemyType)}</i></b>";
            this.logger.Log(LoggerTag, $"Spawned enemy of type: {enemyType}.");
        }

        public void LogBoss(IBoss boss)
        {
            var enemyType = $"<b><i>{Enum.GetName(typeof(EnemyType), boss.EnemyType)}</i></b>";
            var bossType = $"<b><i>{Enum.GetName(typeof(BossType), boss.BossType)}</i></b>";
            this.logger.Log(LoggerTag, $"Spawned a {bossType} boss of type: {enemyType}.");
        }
    }
}