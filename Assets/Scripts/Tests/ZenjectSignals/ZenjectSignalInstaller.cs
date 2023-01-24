using UnityEngine;
using Zenject;

public class ZenjectSignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Debug.LogWarning("ZenjectSignalInstaller > InstallBindings [" + this.gameObject.name);
        // install sygnal Bus.
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<SignalTestParam0>();
        Container.DeclareSignal<SignalTestParam1>();
        Container.DeclareSignal<SignalTestParam5>();
    }
}