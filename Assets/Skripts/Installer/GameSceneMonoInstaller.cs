using Zenject;

public class GameSceneMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Yandex>().AsSingle();
        Container.Bind<SceneControle>().AsSingle();
    }
}