using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    [SerializeField] private Button _toggleBox;
    [SerializeField] private GameObject _box;


    private void OnEnable()
    {
        Debug.Log($"[{nameof(UITest)}] enabled.");
        _toggleBox.onClick.AddListener(ToggleBox); // UI Ȱ��ȭ�� ��۱�� ����
    }

    private void OnDisable()
    {
        Debug.Log($"[{nameof(UITest)}] disabled.");
        _toggleBox.onClick.RemoveListener(ToggleBox); // UI ��Ȱ��ȭ�� ��۱�� ��������
    }

    void ToggleBox()
    {
        _box.SetActive(!_box.activeSelf);
    }
}
