using UnityEngine;
using UnityEngine.InputSystem;  // 追加
using UnityEngine.UI;           // 追加

public class MouseButtonClick : MonoBehaviour
{
  /// <summary>情報を表示するテキストオブジェクト。</summary>
  [SerializeField] private Text TextObject;
  [SerializeField] private Canvas CanvasObject;

  /// <summary>Canvas の RectTransform の参照です。</summary>
  private RectTransform CanvasRect;

  // 最初のフレーム更新の前に開始が呼び出されます
  void Start()
  {
    if (CanvasObject == null)
    {
      Debug.Log($"{nameof(CanvasObject)} が null です。");
      return;
    }

    // Canvas から RectTransform を取得しておきます。
    CanvasRect = CanvasObject.GetComponent<RectTransform>();
  }

  // 更新はフレームごとに1回呼び出されます
  void Update()
  {
    if (TextObject == null)
    {
      Debug.Log($"{nameof(TextObject)} が null です。");
      return;
    }
    if (CanvasObject == null)
    {
      Debug.Log($"{nameof(CanvasObject)} が null です。");
      return;
    }

    var mouse = Mouse.current;
    if (mouse == null)
    {
      Debug.Log("マウスがありません。");
      return;
    }

    var transform = TextObject.transform;

    // マウスの位置を取得する
    var mousePosition = mouse.position.ReadValue();

    // マウスの位置を Canvas の座標に変換する
    var mouseOnCanvas = new Vector2(mousePosition.x - CanvasRect.sizeDelta.x / 2, mousePosition.y - CanvasRect.sizeDelta.y / 2);

    // 左ボタンがクリックしたタイミングか判定
    if (mouse.leftButton.wasPressedThisFrame)
    {
      transform.localPosition = mouseOnCanvas;
    }

    // 右ボタンを押している間はオブジェクトを回転させる
    if (mouse.rightButton.isPressed)
    {
      transform.Rotate(0, 0, 1);
    }
  }
}
