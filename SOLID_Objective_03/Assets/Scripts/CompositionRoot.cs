/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content.
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using Tripledot.Adventure;
using Tripledot.Adventure.Analytics;
using Tripledot.Adventure.Factories;
using Tripledot.Adventure.Factories.Interfaces;
using Tripledot.Adventure.Logging;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Adventures/Create Composition Root", fileName = "CompositionRoot")]
    public class CompositionRoot : ScriptableObject
    {
        private readonly IEnemySpawner enemySpawner = new InstrumentedSpawner(
            new EnemySpawnerDefault(),
            new SpawnerLogger(Debug.unityLogger),
            new SpawnerAnalytics(Debug.unityLogger)
        );

        public IEnemySpawner EnemySpawner => this.enemySpawner;
    }
}