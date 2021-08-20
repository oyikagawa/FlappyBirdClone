using UnityEngine;

public class TubesController : SliderBehavior
{
    void Update()
    {
        SlideObject(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameEvents.gameEvents.TubePass();
    }
}
