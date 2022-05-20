using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private bool selected;
    bool selectable = true;

    void Update()
    {
        if (selectable == true)
        {
            if (selected == true)
            {
                Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector2(cursorPos.x, cursorPos.y);
            }

            if (Input.GetMouseButtonUp(0))
            {
                selected = false;
            }
        }
    }

    void OnMouseOver()
    {
        if (selectable == true)
        {
            if (Input.GetMouseButton(0))
            {
                selected = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bowl")
        {
            selectable = false;
            transform.position = collision.gameObject.transform.position;
        }
    }
}
