/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content.
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using Tripledot.Adventure.Analytics;
using Tripledot.Adventure.Analytics.Interfaces;
using Tripledot.Adventure.Factories;
using Tripledot.Adventure.Factories.Interfaces;
using Tripledot.Adventure.Logging;
using UnityEngine;

namespace Tripledot.Adventure
{
    [CreateAssetMenu(menuName = "Adventures/Create Composition Root", fileName = "CompositionRoot")]
    public class CompositionRoot : ScriptableObject
    {
        private static readonly IEnemySpawner EnemySpawner;
        private static readonly IEnemySpawner AlternativeEnemySpawner;
        private static readonly IKnownCreaturesRepository KnownCreaturesRepository;

        public bool useAlternativeSpawner = false;
        
        static CompositionRoot()
        {
            KnownCreaturesRepository = new KnownCreaturesRepository();
            AlternativeEnemySpawner = new InstrumentedSpawner(
                new EnemySpawnerDefault(),
                new SpawnerLogger(
                    new AlternativeEnemyLogger(Debug.unityLogger),
                    new BossLogger(Debug.unityLogger)),
                new SpawnerAnalytics(
                    new AlternativeEnemyAnalyticsTracker(Debug.unityLogger, KnownCreaturesRepository),
                    new BossAnalyticsTracker(Debug.unityLogger, KnownCreaturesRepository))
            );
            EnemySpawner = new InstrumentedSpawner(
                new EnemySpawnerDefault(),
                new SpawnerLogger(
                    new EnemyLogger(Debug.unityLogger),
                    new BossLogger(Debug.unityLogger)),
                new SpawnerAnalytics(
                    new EnemyAnalyticsTracker(Debug.unityLogger, KnownCreaturesRepository),
                    new BossAnalyticsTracker(Debug.unityLogger, KnownCreaturesRepository))
            );
        }

        public IEnemySpawner GetEnemySpawner() => this.useAlternativeSpawner ? AlternativeEnemySpawner : EnemySpawner;
    }
}