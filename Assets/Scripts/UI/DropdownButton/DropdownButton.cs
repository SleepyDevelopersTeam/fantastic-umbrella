using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DropdownButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Sprite PressedImage, DisabledImage;
    private Sprite normalImage;

    public bool IsToggable, IsEnabled = true;
    public float LongTapDelay = 0.5F;

    public string ActiveAlternative { get; private set; }

    private bool isPressed = false, isToggled = false, inLongTap = false;
    private Image img;

    private DropdownButtonAlternative[] alternatives;

    public Image Icon;

    private void Awake()
    {
        img = GetComponent<Image>();
        normalImage = img.sprite;

        alternatives = GetComponentsInChildren<DropdownButtonAlternative>();
        foreach (var alt in alternatives)
        {
            alt.Hide();
        }

        ActivateAlternativeByIndex(0);
    }

    private float lastTimePressed = float.NegativeInfinity;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        isToggled = !isToggled;
        lastTimePressed = Time.unscaledTime;
        UpdateImage();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        UpdateImage();
        if (inLongTap)
        {
            inLongTap = false;
            HideAlternativesAndChangeActive();
        }
    }

    private void Update()
    {
        if (isPressed && !inLongTap)
        {
            // checking for longtap
            if (Time.unscaledTime - lastTimePressed > LongTapDelay)
            {
                inLongTap = true;
                DisplayAlternatives();
            }
        }
    }

    protected void UpdateImage()
    {
        if (!IsEnabled)
        {
            if (DisabledImage != null) img.sprite = DisabledImage;
            return;
        }

        if (isPressed || (IsToggable && isToggled))
        {
            img.sprite = PressedImage;
        }
        else
        {
            img.sprite = normalImage;
        }
    }

    protected void ActivateAlternativeByIndex(int idx)
    {
        if (idx >= 0 && idx < alternatives.Length)
        {
            for (int i = 0; i < alternatives.Length; i++)
            {
                alternatives[i].Active = i == idx;
            }

            ActiveAlternative = alternatives[idx].Alternative;
            if (Icon != null)
            {
                Icon.sprite = alternatives[idx].IconSprite;
            }
        }
    }

    protected void DisplayAlternatives()
    {
        foreach (var alt in alternatives)
        {
            alt.Show();
        }
    }

    protected void HideAlternativesAndChangeActive()
    {
        int activated = -1;
        for (int i = 0; i < alternatives.Length; i++)
        {
            var alt = alternatives[i];
            if (alt.HideAndCheckActivation())
            {
                activated = i;
            }
        }
        ActivateAlternativeByIndex(activated);
    }
}
