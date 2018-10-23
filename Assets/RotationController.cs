using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationController : MonoBehaviour {

    // Use this for initialization
    public float offset = 0.0f;

	void Start () {
        //Add Images
        AddCard("41_2");
        AddCard("41_82");
        AddCard("41_93");
        AddCard("41_96");

        offset = 10.0f;
        LayoutImages(offset);

    }

    void AddCard(string texName) {
        // Resouces/Icons/Absorber
        Object o = Resources.Load("Card");

        GameObject c = Object.Instantiate(o, this.transform, false) as GameObject;

        Image i = c.GetComponentInChildren<Image>();
        Sprite s = Resources.Load<Sprite>(texName);

        Debug.Log(s);
        i.sprite = s;
    }


    void LayoutImages(float fOffset)
    {

        Rect pRect = this.transform.GetComponent<RectTransform>().rect;

        //
        int iconsFitInView = (int)(pRect.height / pRect.width);


        float allIconsHeight = this.transform.childCount * pRect.width;

        float fRem = fOffset % allIconsHeight;

        if (fRem < 0)
        {
            fRem += allIconsHeight;
        }

        float posOffset = fRem;
        //Disable all Icons just in case
        for (int i = 0; i < this.transform.childCount; ++i)
        {

            Transform t = this.transform.GetChild(i);
            t.gameObject.SetActive(false);
        }

        // step back to find first item. Should be possible with math but not today

        int startIdx = 0;
        for (int i = 0; i < this.transform.childCount && posOffset > 0; ++i)
        {
            startIdx -= 1;
            if(startIdx < 0)
            {
                startIdx += this.transform.childCount;
            }

            posOffset -= pRect.width;
        }

        for (int i = 0; i < this.transform.childCount; ++i)
        {
            int idx = (i + startIdx) % this.transform.childCount;
            Transform t = this.transform.GetChild(idx);
            t.gameObject.SetActive(true);

            RectTransform rT = t.GetComponent<RectTransform>();
            float scale = rT.rect.width / pRect.width;

            //rT.rect = new Rect(0, posOffset, rT.rect.height * scale, rT.rect.height * scale);
            rT.localPosition = new Vector3(0, posOffset, 0);
            rT.sizeDelta = new Vector2(0, pRect.width);
            //t.localScale = new Vector3(scale, scale, scale);
            posOffset += pRect.width;

            if (posOffset > pRect.height + pRect.width)
            {
                t.gameObject.SetActive(false);
            }

        }
    }


    // Update is called once per frame
    void Update () {
        //Calculate Position
        offset -= Time.deltaTime * 300.0f;
        LayoutImages(offset);
	}

    void UpdatePosition(float fPos)
    {
        //Move Images
    }
}
