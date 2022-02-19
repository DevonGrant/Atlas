using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Class allows us to raycast to the gameobject in unity so it can act as a button without actually being one.
public class ButtonScript : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Converts mouse position to world space.
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null )//&& hit.collider.gameObject.tag == "Button")
            {
                DBClick tester = hit.collider.gameObject.GetComponent<DBClick>();
                tester.Click();
            }

            
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
