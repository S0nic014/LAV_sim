using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Camera player;
    public GameObject nameObject;

    private void Start() {
        Text enemyName=nameObject.GetComponent<Text>();
        enemyName.text=transform.parent.name;
    }
    void Update()
    {
        transform.LookAt(transform.position+player.transform.rotation*Vector3.back, player.transform.rotation*Vector3.up);
    }
}
