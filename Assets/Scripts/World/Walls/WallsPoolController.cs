using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WallsPoolController : MonoBehaviour
{
    private WallsPool _pool;

    private WallsInfo _wallsInfo;

    private List<Portal> _portalList;

    private float _cooldown;
    private float _baseCooldown;
    private float _cooldownOffset;
    private float _timer = 0;

    private SignalBus _signalBus;

    [Inject]
    public void InitializeInfo(WallsInfo wallsInfo, List<Portal> portalList, WallsPool pool, SignalBus signalBus)
    {
        _pool = pool;

        _wallsInfo = wallsInfo;
        _portalList = portalList;

        _cooldown = wallsInfo.Cooldown;
        _cooldownOffset = wallsInfo.CooldownOffset;
        _baseCooldown = _cooldown;

        _signalBus = signalBus;

        _pool.InitializeInfo(wallsInfo, this);

        _pool.CreateWall();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _cooldown)
        {
            _pool.CreateWall();
            _timer = 0;

            _cooldown = _baseCooldown + Random.Range(-_cooldownOffset, _cooldownOffset);
        }
    }

    public Wall CreateNewWall()
    {
        Wall wall = Instantiate(_wallsInfo.WallPrefab, transform);

        _pool.InitializeWall(wall);

        CreatePortal(wall);

        return wall;
    }

    public void CreatePortal(Wall wall)
    {
        int rnd = Random.Range(0, _portalList.Count);

        Portal portal = _portalList[rnd];

        wall.SetPortal(portal, _signalBus);
    }
}
