using System.Collections.Generic;
using Tripledot.Adventure.Analytics.Interfaces;
using Tripledot.Adventure.Enums;

namespace Tripledot.Adventure.Analytics
{
    public class KnownCreaturesRepository : IKnownCreaturesRepository
    {
        private readonly HashSet<EnemyType> knownEnemyTypes;
        private readonly HashSet<BossType> knownBossTypes;

        public KnownCreaturesRepository()
        {
            this.knownEnemyTypes = new HashSet<EnemyType>();
            this.knownBossTypes = new HashSet<BossType>();
        }
        
        public bool IsEnemyTypeKnown(EnemyType enemyType)
        {
            return this.knownEnemyTypes.Contains(enemyType);
        }

        public bool IsBossTypeKnown(BossType bossType)
        {
            return this.knownBossTypes.Contains(bossType);
        }

        public void SetEnemyTypeAsKnown(EnemyType enemyType)
        {
            this.knownEnemyTypes.Add(enemyType);
        }

        public void SetBossTypeAsKnown(BossType bossType)
        {
            this.knownBossTypes.Add(bossType);
        }
    }
}