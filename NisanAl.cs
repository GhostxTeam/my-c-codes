using UnityEngine;

public class NisanAl : MonoBehaviour
{
    public Vector3 nisanpos;
    public Vector3 normalpos;
    public float aimspeed;
    public GameObject Crosshair;

    void Start()
    {
        Crosshair.SetActive(true); // Ba�lang��ta Crosshair'i etkinle�tirin (g�sterin)
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, nisanpos, aimspeed * Time.deltaTime);
            Crosshair.SetActive(false); // Crosshair'i gizle
        }
        else
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, normalpos, aimspeed * Time.deltaTime);
            Crosshair.SetActive(true); // Fare tu�una bas�lmad���nda Crosshair'i tekrar etkinle�tirin (g�sterin)
        }
    }
}
