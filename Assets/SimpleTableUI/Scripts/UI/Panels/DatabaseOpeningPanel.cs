using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseOpeningPanel : Panel
{
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private DatabaseOpenButton _databaseOpenButton;
    [SerializeField] private DatabaseManagementSystem _databaseManagementSystem;
    [SerializeField] private UI _ui;
    
    protected override void OnShow()
    {
        string json = PlayerPrefs.GetString("Save");
        var saveData = JsonConvert.DeserializeObject<SaveData>(json);
        _gridLayoutGroup.transform.DestroyChildren();
        
        if (saveData == null)
            return;
        
        foreach (Database database in saveData.Databases.Values)
        {
            DatabaseOpenButton databaseOpenButton = Instantiate(_databaseOpenButton, _gridLayoutGroup.transform);
            databaseOpenButton.Init(_databaseManagementSystem, database.Name, _ui);
        }
    }
}