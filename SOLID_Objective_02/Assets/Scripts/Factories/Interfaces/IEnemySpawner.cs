/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using Tripledot.Adventure.Enemies.Interfaces;
using Tripledot.Adventure.Enums;

namespace Tripledot.Adventure.Factories.Interfaces
{
    public interface IEnemySpawner
    {
        IEnemy SpawnEnemy(EnemyType enemyType);
        IBoss SpawnMidBoss(EnemyType enemyType);
        IBoss SpawnLevelBoss(EnemyType enemyType);
        IBoss SpawnBigBoss(EnemyType enemyType);
        IBoss SpawnRandomBoss(EnemyType enemyType);
    }
}
