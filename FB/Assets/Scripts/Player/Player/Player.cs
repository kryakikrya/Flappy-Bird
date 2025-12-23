using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [Inject] private SignalBus _signalBus;

    public void Death()
    {
        _signalBus.Fire<PlayerDiedSignal>();
    }
}
