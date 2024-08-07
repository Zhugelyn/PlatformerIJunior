using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    public Vector2 GetInput() => new Vector2(Input.GetAxisRaw(HorizontalAxis), Input.GetAxisRaw(VerticalAxis));

    public float GetHorizontalAxisInput() => Input.GetAxisRaw(HorizontalAxis);

    public float GetVerticalAxisInput() => Input.GetAxisRaw(VerticalAxis);

    public bool GetJumpInput() => Input.GetKeyDown(KeyCode.W);

    public bool GetAttackInput() => Input.GetKeyDown(KeyCode.Mouse0);

    public bool GetBoostInput() => Input.GetKey(KeyCode.LeftShift);

    public bool GetVampirismInput() => Input.GetKey(KeyCode.V);
}
