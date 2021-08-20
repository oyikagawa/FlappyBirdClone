using UnityEngine;

public class GroundController : SliderBehavior
{
    [SerializeField]
    private GameObject _firstGround;
    [SerializeField]
    private GameObject _secondGround;

    private float _groundDistanceDifference;

    void Start()
    {
        _groundDistanceDifference = _secondGround.transform.position.x - _firstGround.transform.position.x;
    }

    void Update()
    {
        SlideObject(_firstGround);
        SlideObject(_secondGround);

        TranferGround(_firstGround);
        TranferGround(_secondGround);
    }

    private void TranferGround(GameObject gameObject)
    {
        if (gameObject.transform.position.x < -_groundDistanceDifference)
        {
            Vector3 transferTargetPosition = new Vector3(_groundDistanceDifference * 2f, 0, 0);
            gameObject.transform.position = gameObject.transform.position + transferTargetPosition;
        }
    }
}
