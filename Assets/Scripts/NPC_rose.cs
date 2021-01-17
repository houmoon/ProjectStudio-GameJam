using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NPC_rose : Object
{
    public GameObject arrow;
    public GameObject Portal;
    public Sprite RoseWithCover;
    public Text dialog;
    public List<string> dialogs;
    public int dialognum = 0;

    private void Start()
    {
        SetCallBack(DiaplayDialog);
    }

    private void DiaplayDialog()
    {
        if(PlayerController.Instance.GetGlass && dialognum == 2)
            dialognum = 3;

        switch(dialognum)
        {
            case 0:
                arrow.SetActive(false);
                dialog.text = string.Empty;
                dialog.DOText(dialogs[0],0.5f).OnComplete(() => arrow.SetActive(true));
                dialognum++;
                break;
            case 1:
                arrow.SetActive(false);
                dialog.text = string.Empty;
                dialog.DOText(dialogs[1],0.5f).OnComplete(() => arrow.SetActive(true));
                dialognum++;
                break;
            case 2:
                arrow.SetActive(false);
                dialog.text = string.Empty;
                dialog.DOText(dialogs[2],0.5f);
                dialognum = 2;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = RoseWithCover;
                Portal.SetActive(true);
                arrow.SetActive(false);
                dialog.text = string.Empty;
                dialog.DOText(dialogs[3],0.5f).OnComplete(() => arrow.SetActive(true));
                dialognum++;
                break;
            case 4:
                arrow.SetActive(false);
                dialog.text = string.Empty;
                dialog.DOText(dialogs[4],0.5f).OnComplete(() => arrow.SetActive(true));
                dialognum++;
                break;
            case 5: //end talking
                arrow.SetActive(false);
                dialog.text = string.Empty;
                break;
        }
    }
}
