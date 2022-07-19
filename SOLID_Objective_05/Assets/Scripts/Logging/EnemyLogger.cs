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
    public class EnemyLogger : IEnemyLogger
    {
        private static readonly string LoggerTag = $"<b>{nameof(EnemyLogger)}</b>";
        
        private readonly ILogger logger;

        public EnemyLogger(ILogger logger)
        {
            this.logger = logger;
        }
        public void LogEnemy(IEnemy enemy)
        {
            var enemyType = EnemyUtilities.GetEnemyType(enemy.EnemyType);
            this.logger.Log(LoggerTag, $"Spawned enemy of type: {enemyType}.");
        }
    }
}