public class MvcEventParam1 : MvcEvent<int>
{
    public override void Invoke(int nr) => base.Invoke(nr);
}
