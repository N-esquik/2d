using UnityEngine;

public class ChickenRotation : MonoBehaviour
{
    private int _rotation;

    public void Rotate(float direction)
    {
        if(direction < 0)
        {
            _rotation = 0;
            SetRotation(_rotation);
        }
        else if(direction > 0)
        {
            _rotation = 180;
            SetRotation(_rotation);
        }
    }

    private void SetRotation(int angle)
    {
        Quaternion rotation = transform.rotation;
        rotation.y = angle;
        transform.rotation = rotation;
    }
}
