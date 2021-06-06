using UnityEngine;

public interface IIgnoreUiRaycastWhenInactive
{
    bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera);
}

public class IgnoreUiRaycastWhenInactive : MonoBehaviour, ICanvasRaycastFilter
{
    public bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
    {
        return gameObject.activeInHierarchy;
    }
}