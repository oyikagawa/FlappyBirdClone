using UnityEngine;
using UnityEngine.UI;

public class MenuController : ChangeSceneBehavior
{
    [SerializeField]
    private Text _highscoresTable;
    [SerializeField]
    private GameObject _buttons;
    [SerializeField]
    private GameObject _table;

    private string _highscores;
    private bool _isTable = false;

    void Awake()
    {
        _highscores = HighscoreSaveLoadController.CreateHigscoresTable();
        _highscoresTable.text = _highscores;
    }

    public void LoadHighscoresTable()
    {
        if (!_isTable)
        {
            ActivateTable(true);
        } else
        {
            ActivateTable(false);
        }
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    private void ActivateTable(bool isActive)
    {
        _buttons.SetActive(!isActive);
        _table.SetActive(isActive);
        _isTable = isActive;
    }
}
