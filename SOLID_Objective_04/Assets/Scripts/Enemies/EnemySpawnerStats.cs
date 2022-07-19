/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content.
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

namespace Tripledot.Adventure.Enemies
{
    public readonly struct EnemySpawnerStats
    {
        public readonly int MinHealth;
        public readonly int MaxHealth;
        public readonly int MinSpeed;
        public readonly int MaxSpeed;
        public readonly int MinDamage;
        public readonly int MaxDamage;

        public EnemySpawnerStats(int minHealth, int maxHealth, int minSpeed, int maxSpeed, int minDamage, int maxDamage)
        {
            this.MinHealth = minHealth;
            this.MaxHealth = maxHealth;
            this.MinSpeed = minSpeed;
            this.MaxSpeed = maxSpeed;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
        }
    }
}