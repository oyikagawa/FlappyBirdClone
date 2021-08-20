using UnityEngine;

public class SliderBehavior : MonoBehaviour
{
    [SerializeField]
    private float _slideSpeed;
    [SerializeField]
    private float _difficultySpeedRate;
    [SerializeField]
    private float _maxSlideSpeed;

    void Awake()
    {
        GameEvents.gameEvents.OnDifficultyChange += OnSpeedRise;
    }

    private void OnSpeedRise()
    {
        if (_slideSpeed < _maxSlideSpeed)
        {
            _slideSpeed += _difficultySpeedRate;
            if (_slideSpeed > _maxSlideSpeed)
            {
                _slideSpeed = _maxSlideSpeed;
            }
        }
    }

    public void SlideObject(GameObject gameObject)
    {
        if (!GameStatesController.gameStatesController.isGameOver)
        {
            gameObject.transform.position += Vector3.left * _slideSpeed * Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        GameEvents.gameEvents.OnDifficultyChange -= OnSpeedRise;
    }
}
