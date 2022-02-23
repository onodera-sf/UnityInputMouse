using System.Text;              // �ǉ�
using UnityEngine;
using UnityEngine.InputSystem;  // �ǉ�
using UnityEngine.UI;           // �ǉ�

public class MouseInfo : MonoBehaviour
{
  /// <summary>����\������e�L�X�g�I�u�W�F�N�g�B</summary>
  [SerializeField] private Text TextObject;

  private StringBuilder Builder = new StringBuilder();

  /// <summary>�X�N���[�������ʂ�ێ�����B</summary>
  private Vector2 ScrollValue = Vector2.zero;

  // �X�V�̓t���[�����Ƃ�1��Ăяo����܂�
  void Update()
  {
    if (TextObject == null)
    {
      Debug.Log($"{nameof(TextObject)} �� null �ł��B");
      TextObject.text = "";
      return;
    }

    var mouse = Mouse.current;
    if (mouse == null)
    {
      Debug.Log("�}�E�X������܂���B");
      TextObject.text = "";
      return;
    }

    // �X�N���[���ʂ��擾���ێ�����
    ScrollValue += mouse.scroll.ReadValue();

    Builder.Clear();

    // �}�E�X�̈ʒu���擾����
    Builder.AppendLine($"Mouse.position={mouse.position.ReadValue()}");
    // �X�N���[���ʂ�\��
    Builder.AppendLine($"ScrollValue={ScrollValue}");

    TextObject.text = Builder.ToString();
  }
}
