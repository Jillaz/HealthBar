public class ButtonHandlerHeal : ButtonHandlerHit
{
    protected override void Click()
    {
        _health.Healing(_value);
    }
}
