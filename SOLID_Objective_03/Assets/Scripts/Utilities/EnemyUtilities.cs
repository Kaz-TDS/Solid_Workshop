/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content.
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using System;
using Tripledot.Adventure.Enums;

namespace Tripledot.Adventure.Utilities
{
    public static class EnemyUtilities
    {
        public static string GetEnemyType(EnemyType enemyType)
        {
            return $"<b><i>{Enum.GetName(typeof(EnemyType), enemyType)}</i></b>";
        }

        public static string GetBossType(BossType bossType)
        {
            return $"<b><i>{Enum.GetName(typeof(BossType), bossType)}</i></b>";
        }
    }
}