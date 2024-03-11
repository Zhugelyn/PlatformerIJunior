using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string JumpInput = "Jump";
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    public Vector2 GetInput() => new Vector2(Input.GetAxisRaw(HorizontalAxis), Input.GetAxisRaw(VerticalAxis));

    public float GetHorizontalAxisInput() => Input.GetAxisRaw(HorizontalAxis);

    public float GetVerticalAxisInput() => Input.GetAxisRaw(VerticalAxis);

    public bool GetJumpInput() => Input.GetButtonDown(JumpInput);

    public bool GetAttackInput() => Input.GetKeyDown(KeyCode.Mouse0);
}
