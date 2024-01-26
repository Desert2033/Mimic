public class MobileInputService : IInputService
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    public float GetAxisVertical => SimpleInput.GetAxis(Vertical);
    public float GetAxisHorizontal => SimpleInput.GetAxis(Horizontal);
}
