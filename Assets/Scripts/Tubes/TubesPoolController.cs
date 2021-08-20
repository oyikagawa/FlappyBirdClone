using UnityEngine;

public class TubesPoolController : MonoBehaviour
{
    [SerializeField]
    private GameObject _tubesPrefab;
    private GameObject[] _tubes;

    [SerializeField]
    private int _tubesPoolSize;
    [SerializeField]
    private float _maxSpawnRate;
    [SerializeField]
    private float _minSpawnRate;
    [SerializeField]
    private float _tubesSpawnChangeRate;
    [SerializeField]
    private float _spawnTubesRiseRate;
    private int _tubesCount = 0;
    private float _timeSinceLastSpawn;
    private int _curPoolTubes = 0;

    private float _spawnXPos = 1.5f;
    private float _minYSpawnPos = -.75f;
    private float _maxYSpawnPos = .5f;
    private Vector2 _initTubesOutCamSpawnPos = new Vector2(-2f, -4f);
    
    void Start()
    {
        _tubes = new GameObject[_tubesPoolSize];
        _tubes[_tubesPoolSize-1] = Instantiate(_tubesPrefab, GenerateSpawnPos(), Quaternion.identity);
        _tubesCount++;

        for (var i = 0; i < _tubesPoolSize-1; i++)
        {
            _tubes[i] = Instantiate(_tubesPrefab, _initTubesOutCamSpawnPos, Quaternion.identity);
        }
    }

    void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        if (!GameStatesController.gameStatesController.isGameOver && _timeSinceLastSpawn >= _maxSpawnRate)
        {
            _timeSinceLastSpawn = 0;
            _tubes[_curPoolTubes].transform.position = GenerateSpawnPos();
            _curPoolTubes++;
            _tubesCount++;

            if (_curPoolTubes >= _tubesPoolSize)
            {
                _curPoolTubes = 0;
            }

            if (_tubesCount >= _tubesSpawnChangeRate && _maxSpawnRate > _minSpawnRate)
            {
                _maxSpawnRate -= _spawnTubesRiseRate;
                if (_maxSpawnRate < _minSpawnRate)
                {
                    _maxSpawnRate = _minSpawnRate;
                }
                GameEvents.gameEvents.DifficultyChange();
                _tubesCount = 0;
            }
        }
    }

    private Vector2 GenerateSpawnPos()
    {
        float spawnYPosition = Random.Range(_minYSpawnPos, _maxYSpawnPos);
        return new Vector2(_spawnXPos, spawnYPosition);
    }
}
