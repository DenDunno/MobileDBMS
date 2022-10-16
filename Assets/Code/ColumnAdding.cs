using UnityEngine;

public class ColumnAdding : MonoBehaviour
{
    [SerializeField] private ColumnAddingPanel _columnAddingPanel;
    [SerializeField] private TablePanel _table;
    
    public void ShowPanel()
    {
        TogglePanel(true);
    }

    private void TogglePanel(bool activate)
    {
        _columnAddingPanel.gameObject.SetActive(activate);
        _table.gameObject.SetActive(activate == false);
    }
}