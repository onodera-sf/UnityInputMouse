using System.Text;              // 追加
using UnityEngine;
using UnityEngine.InputSystem;  // 追加
using UnityEngine.UI;           // 追加

public class MouseInfo : MonoBehaviour
{
  /// <summary>情報を表示するテキストオブジェクト。</summary>
  [SerializeField] private Text TextObject;

  private StringBuilder Builder = new StringBuilder();

  /// <summary>スクロールした量を保持する。</summary>
  private Vector2 ScrollValue = Vector2.zero;

  // 更新はフレームごとに1回呼び出されます
  void Update()
  {
    if (TextObject == null)
    {
      Debug.Log($"{nameof(TextObject)} が null です。");
      TextObject.text = "";
      return;
    }

    var mouse = Mouse.current;
    if (mouse == null)
    {
      Debug.Log("マウスがありません。");
      TextObject.text = "";
      return;
    }

    // スクロール量を取得し保持する
    ScrollValue += mouse.scroll.ReadValue();

    Builder.Clear();

    // マウスの位置を取得する
    Builder.AppendLine($"Mouse.position={mouse.position.ReadValue()}");
    // スクロール量を表示
    Builder.AppendLine($"ScrollValue={ScrollValue}");

    TextObject.text = Builder.ToString();
  }
}
