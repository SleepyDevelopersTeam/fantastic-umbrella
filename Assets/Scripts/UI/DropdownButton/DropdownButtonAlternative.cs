using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropdownButtonAlternative : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string Alternative;

    public Sprite SelectedImage, DisabledImage;
    private Sprite normalImage;

    public bool IsEnabled = true;

    /// <summary>
    /// While selected shows, whether this alternative was selected with user's finger now,
    /// active shows if this alternative is currently active.
    /// </summary>
    private bool selected;
    private Image img;
    // public DropdownButton Parent { get; set; }
    public bool Active { get; set; }
    private DropdownAltIcon altIcon;
    public Sprite IconSprite { get { return altIcon.IconSprite; } }

    private void Awake()
    {
        img = GetComponent<Image>();
        normalImage = img.sprite;

        altIcon = GetComponentInChildren<DropdownAltIcon>();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        selected = false;
        UpdateImage();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public bool HideAndCheckActivation()
    {
        Hide();
        return selected;
    }

    public bool IsSelected()
    {
        return selected;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selected = true;
        UpdateImage();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selected = false;
        UpdateImage();
    }

    protected void UpdateImage()
    {
        if (!IsEnabled)
        {
            if (DisabledImage != null) img.sprite = DisabledImage;
            return;
        }

        if (selected || Active)
        {
            img.sprite = SelectedImage;
        }
        else
        {
            img.sprite = normalImage;
        }
    }
}
