/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content.
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using Tripledot.Adventure.Enemies.Interfaces;

namespace Tripledot.Adventure.Analytics.Interfaces
{
    public interface IEnemyAnalyticsTracker
    {
        void TrackEnemy(IEnemy enemy, bool onlyIfUnknown = false);
    }
}