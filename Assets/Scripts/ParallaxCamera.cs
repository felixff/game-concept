using UnityEngine;

[ExecuteInEditMode]
public class ParallaxCamera : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float deltaMovement);
    public ParallaxCameraDelegate onCameraTranslate;

    private float oldPosition;

    void Start()
    {
        oldPosition = transform.position.x;
    }

    void Update()
    {
        float newPosition = transform.position.x;
        if (newPosition != oldPosition)
        {
            if (onCameraTranslate != null)
            {
                float delta = oldPosition - newPosition;
                onCameraTranslate(delta);
            }
            oldPosition = newPosition;
        }
    }
}