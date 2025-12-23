using Zenject;

public class SignalInstaller : MonoInstaller
{
    private SceneController _sceneController;

    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<PlayerDiedSignal>();

        Container.DeclareSignal<PortalPassedSignal>();

        SceneController controller = new SceneController(Container.Resolve<SignalBus>());
    }

    private void OnDestroy()
    {
        _sceneController?.Unsubscribe();
    }
}
