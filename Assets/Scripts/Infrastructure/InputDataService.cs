using UnityEngine;

public class InputDataService : IInputService
{

    private const string horizontalLabel = "Horizontal";
    private const string verticalLabel = "Vertical";

    public Vector2 GetDirection()
    {
        var horizantal = Input.GetAxisRaw(horizontalLabel);
        var vertical = Input.GetAxisRaw(verticalLabel);
        return new Vector2(horizantal, vertical);
    }
}
