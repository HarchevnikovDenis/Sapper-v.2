using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            CatchPlayerInput();
        }
    }

    private void CatchPlayerInput()
    {
        Touch[] touches = Input.touches;
        foreach(Touch touch in touches)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 1));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.CompareTag("Cell") && touch.phase == TouchPhase.Began)
                {
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
        }
    }
}
