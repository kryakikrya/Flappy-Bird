using Zenject;

public class ScoreController : Controller
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<PortalPassedSignal>(OnInput);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<PortalPassedSignal>(OnInput);
    }

    public override void OnInput()
    {
        _model.SetData();
    }
}
