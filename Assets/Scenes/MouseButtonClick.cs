using UnityEngine;
using UnityEngine.InputSystem;  // �ǉ�
using UnityEngine.UI;           // �ǉ�

public class MouseButtonClick : MonoBehaviour
{
  /// <summary>����\������e�L�X�g�I�u�W�F�N�g�B</summary>
  [SerializeField] private Text TextObject;
  [SerializeField] private Canvas CanvasObject;

  /// <summary>Canvas �� RectTransform �̎Q�Ƃł��B</summary>
  private RectTransform CanvasRect;

  // �ŏ��̃t���[���X�V�̑O�ɊJ�n���Ăяo����܂�
  void Start()
  {
    if (CanvasObject == null)
    {
      Debug.Log($"{nameof(CanvasObject)} �� null �ł��B");
      return;
    }

    // Canvas ���� RectTransform ���擾���Ă����܂��B
    CanvasRect = CanvasObject.GetComponent<RectTransform>();
  }

  // �X�V�̓t���[�����Ƃ�1��Ăяo����܂�
  void Update()
  {
    if (TextObject == null)
    {
      Debug.Log($"{nameof(TextObject)} �� null �ł��B");
      return;
    }
    if (CanvasObject == null)
    {
      Debug.Log($"{nameof(CanvasObject)} �� null �ł��B");
      return;
    }

    var mouse = Mouse.current;
    if (mouse == null)
    {
      Debug.Log("�}�E�X������܂���B");
      return;
    }

    var transform = TextObject.transform;

    // �}�E�X�̈ʒu���擾����
    var mousePosition = mouse.position.ReadValue();

    // �}�E�X�̈ʒu�� Canvas �̍��W�ɕϊ�����
    var mouseOnCanvas = new Vector2(mousePosition.x - CanvasRect.sizeDelta.x / 2, mousePosition.y - CanvasRect.sizeDelta.y / 2);

    // ���{�^�����N���b�N�����^�C�~���O������
    if (mouse.leftButton.wasPressedThisFrame)
    {
      transform.localPosition = mouseOnCanvas;
    }

    // �E�{�^���������Ă���Ԃ̓I�u�W�F�N�g����]������
    if (mouse.rightButton.isPressed)
    {
      transform.Rotate(0, 0, 1);
    }
  }
}
