using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class GameInfoInstaller : MonoInstaller
{
    [SerializeField] private WallsInfo _wallsInfo;

    [SerializeField] private List<Portal> _portals;

    public override void InstallBindings()
    {
        WallsPool pool = new WallsPool();

        Container.Bind<WallsInfo>().FromInstance(_wallsInfo).AsSingle();

        Container.Bind<List<Portal>>().FromInstance(_portals).AsSingle();

        Container.Bind<WallsPool>().AsSingle();
    }
}
