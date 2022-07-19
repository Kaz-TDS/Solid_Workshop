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

namespace Tripledot.Adventure.Logging
{
    public class SpawnerLogger : ISpawnerLogger
    {
        private readonly IEnemyLogger enemyLogger;
        private readonly IBossLogger bossLogger;

        public SpawnerLogger(IEnemyLogger enemyLogger, IBossLogger bossLogger)
        {
            this.enemyLogger = enemyLogger;
            this.bossLogger = bossLogger;
        }
        public void LogEnemy(IEnemy enemy)
        {
            this.enemyLogger.LogEnemy(enemy);
        }

        public void LogBoss(IBoss boss)
        {
            this.bossLogger.LogBoss(boss);
        }
    }
}