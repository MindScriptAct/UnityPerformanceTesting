using UnityEngine;
using Zenject;

public class ZenjectEventContainersInstaller : MonoInstaller
{
    public override void InstallBindings()
    {

        Container.Bind<ZenjectEventContainer>().AsSingle();

        //Container.DeclareSignal<SignalTestParam0>();
        //Container.DeclareSignal<SignalTestParam1>();
        //Container.DeclareSignal<SignalTestParam5>();
    }
}