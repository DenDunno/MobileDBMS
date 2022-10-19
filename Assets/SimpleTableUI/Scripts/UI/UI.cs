using System;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TablePanel _tablePanel;
    [SerializeField] private ColumnAddingPanel _columnAddingPanel;
    [SerializeField] private StartPanel _startPanel;
    [SerializeField] private DatabasePreviewPanel _databasePreviewPanel;
    [SerializeField] private DatabaseCreationPanel _databaseCreationPanel;
    [SerializeField] private DatabaseOpeningPanel _databaseOpeningPanel;
    [SerializeField] private TableCreationPanel _tableCreationPanel;
    private Panel[] _panels;

    private void Start()
    {
        _panels = new Panel[]
        {
            _tablePanel, _columnAddingPanel, _databasePreviewPanel, _startPanel,
            _databaseCreationPanel, _databaseOpeningPanel, _tableCreationPanel,
        };
    }

    public void ShowPanel<T>() where T : Panel
    {
        bool failToOpen = true;
        
        foreach (Panel panel in _panels)
        {
            if (panel is T)
            {
                panel.Show();
                failToOpen = false;
            }
            else
            {
                panel.Hide();
            }
        }

        if (failToOpen)
        {
            throw new Exception($"Cannot open panel with type {typeof(T)}");
        }
    }
}