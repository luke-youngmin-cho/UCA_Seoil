using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    [SerializeField] private Button _toggleBox;
    [SerializeField] private GameObject _box;


    private void OnEnable()
    {
        Debug.Log($"[{nameof(UITest)}] enabled.");
        _toggleBox.onClick.AddListener(ToggleBox); // UI 활성화시 토글기능 구독
    }

    private void OnDisable()
    {
        Debug.Log($"[{nameof(UITest)}] disabled.");
        _toggleBox.onClick.RemoveListener(ToggleBox); // UI 비활성화시 토글기능 구독해제
    }

    void ToggleBox()
    {
        _box.SetActive(!_box.activeSelf);
    }
}
