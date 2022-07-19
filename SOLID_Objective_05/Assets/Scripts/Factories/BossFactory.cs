/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content.
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using System;
using Tripledot.Adventure.Enemies;
using Tripledot.Adventure.Enemies.Interfaces;
using Tripledot.Adventure.Enums;
using UnityEngine;
using Random = System.Random;

namespace Tripledot.Adventure.Factories
{
    public class BossFactory
    {
        private readonly EnemyType enemyType;
        private readonly EnemySpawnerStats spawnerStats;
        private readonly float healthMultiplier;
        private readonly int damageModifier;

        private readonly Random rng;

        public BossFactory(
            EnemyType enemyType,
            EnemySpawnerStats spawnerStats,
            float healthMultiplier,
            int damageModifier)
        {
            this.enemyType = enemyType;
            this.spawnerStats = spawnerStats;
            this.healthMultiplier = healthMultiplier;
            this.damageModifier = damageModifier;

            this.rng = new Random(DateTime.Now.Millisecond);
        }
        
        public IBoss CreateBoss(BossType bossType)
        {
            var bossMinHealth = (int)(this.spawnerStats.MinHealth * (this.healthMultiplier * (int)bossType));
            var bossMaxHealth = (int)(this.spawnerStats.MaxHealth * (this.healthMultiplier * (int)bossType));
            var bossMinDamage = this.spawnerStats.MinDamage + this.damageModifier * (int)bossType;
            var bossMaxDamage = this.spawnerStats.MaxDamage + this.damageModifier * (int)bossType;
            return new BossEnemy(
                this.enemyType,
                this.rng.Next(bossMinHealth, bossMaxHealth),
                this.rng.Next(this.spawnerStats.MinSpeed, this.spawnerStats.MaxSpeed),
                this.rng.Next(bossMinDamage, bossMaxDamage),
                Vector2Int.zero,
                bossType);
        }
    }
}