using UnityEngine;

public class Panel : MonoBehaviour
{
    public void Show()
    {
        OnShow();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnShow() { }
}