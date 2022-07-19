/*
 * (c) 2022 Tripledot Studios, all rights reserved.
 * Tripledot Studios owns the copyright to this file and all of it's content.
 * The file may not be reproduced in any form without permission.
 * 
 * Created and maintained by:
 * Kazimierz Luska (kazimierz.luska@tripledotstudios.com
 */

using Tripledot.Adventure;
using UnityEngine;

public class ModeSelectorController : MonoBehaviour
{
    public GameObject spawnerCanvas;
    public CompositionRoot compositionRoot;

    public void StartNormal()
    {
        this.compositionRoot.useAlternativeSpawner = false;
        this.spawnerCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void StartAlternative()
    {
        this.compositionRoot.useAlternativeSpawner = true;
        this.spawnerCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
