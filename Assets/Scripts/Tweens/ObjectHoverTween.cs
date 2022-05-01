using UnityEngine;

public class ObjectHoverTween : MonoBehaviour
{
    [SerializeField] private GameObject objectToTween;
    [SerializeField] private float moveToY = 0.1f;
    [SerializeField] private float tweenTime = 0.5f;
    [SerializeField] private LeanTweenType easeType;
    private void OnEnable()
    {
        LeanTween.moveY(objectToTween, transform.position.y + moveToY, tweenTime).setLoopPingPong().setEase(easeType);
    }
}
