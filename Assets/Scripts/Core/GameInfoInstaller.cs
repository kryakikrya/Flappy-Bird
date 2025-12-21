using UnityEngine;
using Zenject;
using System.Collections.Generic;

public class GameInfoInstaller : MonoInstaller
{
    [SerializeField] private WallsInfo _wallsInfo;

    private List<Portal> _portals = new List<Portal>();

    [SerializeField] private float _force;
    [SerializeField] private float _gravity;

    public override void InstallBindings()
    {
        WallsPool pool = new WallsPool();

        Container.Bind<WallsInfo>().FromInstance(_wallsInfo).AsSingle();

        IMoveStrategy defaultStrategy = new UfoStrategy(_force, _gravity);

        Container.Bind<IMoveStrategy>().To<UfoStrategy>().AsSingle().WithArguments(_force, _gravity);

        InitializePortals();

        Container.Bind<List<Portal>>().FromInstance(_portals).AsSingle();

        Container.Bind<WallsPool>().AsSingle();
    }

    public void InitializePortals()
    {
        _portals.Add(new UfoPortal(_force, _gravity, Color.red));
        _portals.Add(new WavePortal(_force, Color.blue));
        _portals.Add(new ReversePortal(Color.yellow));
    }
}
