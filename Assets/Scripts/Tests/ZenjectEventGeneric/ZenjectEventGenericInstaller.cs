using UnityEngine;
using Zenject;

public class ZenjectEventGenericInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GenericEventTest>().AsSingle();
    }
}