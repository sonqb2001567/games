using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopUp : MonoBehaviour
{
    TextMeshPro popupText;
    float disappearTimer;
    Color textColor;

    private void Awake()
    {
        popupText = this.transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damageDealt)
    {
        popupText.SetText(damageDealt.ToString());
        textColor = popupText.color;
    }

    private void Update()
    {
        float moveYSpeed = 10f;
        transform.position += new Vector3(0, moveYSpeed, 0) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            popupText.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
