using UnityEngine;

public class StartPanelTransitionButton : PanelTransitionButton<StartPanel>
{
    [SerializeField] private DatabaseManagementSystem _databaseManagementSystem;
    
    protected override void OnShow()
    {
        _databaseManagementSystem.Save();
    }
}