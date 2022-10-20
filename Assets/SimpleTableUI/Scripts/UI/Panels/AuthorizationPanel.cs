using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AuthorizationPanel : Panel
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private RectTransform _tableInterface;
    [SerializeField] private Image _tableEditing;
    [SerializeField] private Button _createDatabaseButton;
    [SerializeField] private Button _createTableButton;
    [SerializeField] private UI _ui;
    private const string _adminPassword = "admin";
    private const string _userPassword = "user";
        
    public void TryAccept()
    {
        string password = _inputField.text;

        if (password != _adminPassword && password != _userPassword)
        {
            ErrorPanel.Instance.ShowError("Wrong password");
        }
        else
        {
            ChangeUI(password);
            _ui.ShowPanel<StartPanel>();
        }
    }

    private void ChangeUI(string password)
    {
        bool isAdmin = password == _adminPassword;
        User.IsAdmin = isAdmin;
        
        _tableInterface.gameObject.SetActive(isAdmin);
        _tableEditing.gameObject.SetActive(isAdmin);
        _createDatabaseButton.gameObject.SetActive(isAdmin);
        _createTableButton.gameObject.SetActive(isAdmin);
    }
}