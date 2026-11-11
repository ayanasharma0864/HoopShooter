using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public ScoreManager manager;
    public bool isTop;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball")) return;

        if (isTop) manager.BallEnteredTop();
        else manager.BallEnteredBottom();
    }
}