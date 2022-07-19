/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content.
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using Tripledot.Adventure.Enemies.Interfaces;
using Tripledot.Adventure.Enums;
using UnityEngine;

namespace Tripledot.Adventure.Enemies
{
    public class BossEnemy : IBoss
    {
        public EnemyType EnemyType { get; private set; }
        public int Health { get; private set; }
        public int Speed { get; private set; }
        public int Damage { get; private set; }
        public Vector2Int Position { get; private set; }
        public BossType BossType { get; private set; }
    
        public BossEnemy(EnemyType enemyType, int health, int speed, int damage, Vector2Int position, BossType bossType)
        {
            EnemyType = enemyType;
            Health = health;
            Speed = speed;
            Damage = damage;
            Position = position;
            BossType = bossType;
        }
    }
}
