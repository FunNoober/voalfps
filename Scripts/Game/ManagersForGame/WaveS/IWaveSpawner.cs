using System;
using UnityEngine.Events;

public interface IWaveSpawner
{
    event Action onKilled;
    event Action onSpawn;
}
