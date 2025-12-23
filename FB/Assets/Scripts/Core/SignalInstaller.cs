using Zenject;

public class SignalInstaller : MonoInstaller
{
    private SceneController _sceneController;

    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<PortalPassedSignal>();
    }
}
