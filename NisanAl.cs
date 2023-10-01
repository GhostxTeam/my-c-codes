using UnityEngine;

public class NisanAl : MonoBehaviour
{
    public Vector3 nisanpos;
    public Vector3 normalpos;
    public float aimspeed;
    public GameObject Crosshair;

    void Start()
    {
        Crosshair.SetActive(true); // Baþlangýçta Crosshair'i etkinleþtirin (gösterin)
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
            Crosshair.SetActive(true); // Fare tuþuna basýlmadýðýnda Crosshair'i tekrar etkinleþtirin (gösterin)
        }
    }
}
