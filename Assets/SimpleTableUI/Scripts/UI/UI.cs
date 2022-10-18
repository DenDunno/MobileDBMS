using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TablePreview _tablePreview;
    [SerializeField] private TablePanel _tablePanel;
    [SerializeField] private ColumnAddingPanel _columnAddingPanel;
    private Panel[] _uiElements;

    private void Start()
    {
        _uiElements = new Panel[] {_tablePanel, _columnAddingPanel, _tablePreview};
    }

    public void ShowTable() => ShowPanel(_tablePanel);

    public void ShowColumnAddingPanel() => ShowPanel(_columnAddingPanel);
    
    public void ShowTablePreview() => ShowPanel(_tablePreview);

    private void ShowPanel(Panel panel)
    {
        foreach (Panel uiElement in _uiElements)
        {
            uiElement.gameObject.SetActive(false);
        }
        
        panel.gameObject.SetActive(true);
    }
}