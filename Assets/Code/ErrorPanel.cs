using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ErrorPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private RectTransform _popUp;
    [SerializeField] private Image _image;
    private Tween _animation;
    private const float _duration = 0.5f;

    public static ErrorPanel Instance;

    private void Start()
    {
        Instance = this;
    }

    public void ShowError(string message)
    {
        _text.text = message;
        AnimatePanel(1);
    }

    public void HidePanel()
    {
        AnimatePanel(0);
    }

    private void AnimatePanel(int targetScale)
    {
        _image.raycastTarget = targetScale == 1;
        _animation?.Kill();
        _animation = _popUp.transform.DOScale(targetScale, _duration);
    }
}