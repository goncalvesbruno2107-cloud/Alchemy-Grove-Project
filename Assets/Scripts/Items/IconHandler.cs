using UnityEngine;
using UnityEngine.UI;

public class IconHandler : MonoBehaviour
{
    private Image Image;
    private Sprite Sprite;

    public void Initialize(Sprite Sprite)
    {
        this.Sprite = Sprite;
        Image = GetComponent<Image>();
        RenderIcon();
    }

    private void RenderIcon()
    {
        Image.sprite = Sprite;
    }
}
