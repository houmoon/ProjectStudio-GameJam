using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIElement : MonoBehaviour
{
    public static UIElement Instance;
    private void Awake()    {Instance = this;}

    public HPContainer hpContainer;
    public ItemContainer itemcontainer;

    public Image InteractionIcon;
    public Text SpreaderText;

    public void UpdateSpreaderAmount()
    {
        SpreaderText.text = PlayerController.Instance.SpreaderAmount.ToString();
    }

    public void Debug_ItemAdd(int a)
    {
        PlayerController.Instance.GetItem((ItemType)a);
    }

    public void FocusInteraction(Transform target)
    {
        InteractionIcon.rectTransform.anchoredPosition = Camera.main.WorldToScreenPoint(target.position);

        InteractionIcon.gameObject.SetActive(true);
        InteractionIcon.DOFade(1,0.25f);
    }

    public void DefocusInteraction()
    {
        InteractionIcon.DOFade(0,0.25f).SetEase(Ease.OutQuart).OnComplete(() => InteractionIcon.gameObject.SetActive(false));
    }

}
