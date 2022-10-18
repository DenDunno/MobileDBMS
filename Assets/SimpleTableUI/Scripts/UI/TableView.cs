using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TableView : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Button _button;
    private TableSetting _tableSetting;
    private Table _table;
    private UI _ui;

    public void Init(TableSetting tableSetting, Table table, UI ui)
    {
        _tableSetting = tableSetting;
        _table = table;
        _ui = ui;
        _name.text = table.Name;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OpenTable);
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(OpenTable);
    }

    private void OpenTable()
    {
        _tableSetting.SetUpTable(_table);
        _ui.ShowPanel<TablePanel>();
    }
}