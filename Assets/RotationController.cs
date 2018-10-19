using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Add Images
        AddCard("41_2");
        AddCard("41_20");
        AddCard("41_72");
        AddCard("41_82");
        AddCard("41_93");
        AddCard("41_96");


        LayoutImages();

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

    void LayoutImages()
    {

        Rect pRect = this.transform.GetComponent<RectTransform>().rect;
        float posOffset = 0.0f;

        for (int i = 0; i < this.transform.childCount; ++i)
        {
            Transform t = this.transform.GetChild(i);

            RectTransform rT = t.GetComponent<RectTransform>();
            float scale = rT.rect.width / pRect.width;

            //rT.rect = new Rect(0, posOffset, rT.rect.height * scale, rT.rect.height * scale);
            rT.localPosition = new Vector3(0, posOffset, 0);
            rT.sizeDelta = new Vector2(0, pRect.width);
            //t.localScale = new Vector3(scale, scale, scale);
            posOffset += pRect.width;

        }
    }


    // Update is called once per frame
    void Update () {
		//Calculate Position
	}

    void UpdatePosition(float fPos)
    {
        //Move Images
    }
}
