using UnityEngine;

/// <summary> Scales the transform rotation to face the direction of movement </summary>
/// <remarks> Only applies if the graphicsObject (exported 3D model) is assigned </remarks>
public class GraphicsDirectionHandler
{
    private GameObject graphicsObject;
    /// <summary> Constant int representing <c>0</c> to eliminate magic numbers </summary>
    private const int iZero = 0;
    /// <summary> Constant Float representing <c>0f</c> to eliminate magic numbers </summary>
    private const float fZero = 0f;
    private const int flipXRotation = 180;

    public GraphicsDirectionHandler(GameObject graphicsObject)
    {
        this.graphicsObject = graphicsObject;
    }

    /// <summary> Flips the graphics object based on the horizontal movement input.</summary>
    /// <param name="moveInputX">The horizontal movement input. A negative value rotates the object to face left,  a positive value rotates it to
    /// face right, and a value of zero leaves the orientation unchanged.</param>
    public void ApplyDirection(float moveInputX)
    {
        if (moveInputX < fZero)
        {
            graphicsObject.transform.localRotation = Quaternion.Euler(iZero, flipXRotation, iZero);
        }
        else if (moveInputX > fZero)
        {
            graphicsObject.transform.localRotation = Quaternion.Euler(iZero, iZero, iZero);
        }
    }
}
