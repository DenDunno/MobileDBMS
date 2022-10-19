using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class PanelTransitionButton<T> : MonoBehaviour where T : Panel
{
    [SerializeField] private UI _ui;
    private Button _button;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ShowPanel);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ShowPanel);
    }

    private void ShowPanel()
    {
        OnShow();
        _ui.ShowPanel<T>();
    }

    protected virtual void OnShow() { }
}