using Tripledot.Adventure.Enemies.Interfaces;
using Tripledot.Adventure.Enums;

namespace Tripledot.Adventure.Analytics.Interfaces
{
    public interface IKnownCreaturesRepository
    {
        bool IsEnemyTypeKnown(EnemyType enemy);
        bool IsBossTypeKnown(BossType boss);
        void SetEnemyTypeAsKnown(EnemyType enemy);
        void SetBossTypeAsKnown(BossType boss);
    }
}