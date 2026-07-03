using UnityEngine;
using UnityEngine.EventSystems;

public class DragColher : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private Vector2 posicaoInicial;

    [Header("Área do Caldeirão")]
    public RectTransform areaCalderao;

    [Header("Animator do Caldeirão")]
    public Animator animatorCalderao;

    [Header("Rotação da Colher")]
    public float rotacaoNormal = 90f;
    public float rotacaoMexendo = 0f;

    private bool dentroDoCalderao = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        posicaoInicial = rectTransform.anchoredPosition;

        // deixa a colher na rotação normal no começo
        rectTransform.localEulerAngles = new Vector3(0, 0, rotacaoNormal);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.8f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // arrasta a colher com o mouse
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        // verifica se está em cima do caldeirão
        VerificarSeEstaNoCalderao();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        VerificarSeEstaNoCalderao();

        if (dentroDoCalderao)
        {
            // coloca a colher no centro da área do caldeirão
            rectTransform.anchoredPosition = areaCalderao.anchoredPosition;

            // faz a colher ficar em pé / posição de mexer
            rectTransform.localEulerAngles = new Vector3(0, 0, rotacaoMexendo);

            // ativa animação do caldeirão, se tiver Animator
            if (animatorCalderao != null)
            {
                animatorCalderao.SetBool("Mexendo", true);
            }
        }
        else
        {
            // volta para o lugar inicial
            rectTransform.anchoredPosition = posicaoInicial;

            // volta para a rotação normal
            rectTransform.localEulerAngles = new Vector3(0, 0, rotacaoNormal);

            // para a animação do caldeirão, se tiver Animator
            if (animatorCalderao != null)
            {
                animatorCalderao.SetBool("Mexendo", false);
            }
        }
    }

    void VerificarSeEstaNoCalderao()
    {
        if (areaCalderao == null)
        {
            dentroDoCalderao = false;
            return;
        }

        dentroDoCalderao = RectTransformUtility.RectangleContainsScreenPoint(
            areaCalderao,
            rectTransform.position,
            null
        );
    }
}