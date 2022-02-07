using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] GameObject VaccinePrefab;
    private GameObject Needle;

    GameObject shootingPos;
    bool canFire = true;

    public float reloadTime = 0.5f;

    float previousReloadTime;
    void Start()
    {
        shootingPos = GameObject.Find("shootingPos");
        Needle = gameObject.transform.GetChild(1).gameObject;
        previousReloadTime = reloadTime;
    }

    static float AngleTowardsMouse(Vector3 pos)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(pos);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        return angle;
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire)
        {
            float angle = AngleTowardsMouse(Needle.transform.position);
            Needle.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
        }
        if (Input.GetMouseButton(0) && canFire)
        {

            Needle.SetActive(false);
            Fire();
        }
        else
        {
            if (reloadTime > 0)
            {
                reloadTime -= 0.1f * Time.deltaTime;
            }
            else
            {
                reloadTime = previousReloadTime;
                canFire = true;
                Needle.SetActive(true);
            }
        }
    }

    void Fire()
    {
        float VaccineSpeed = 10f;
        FindObjectOfType<AudioManager>().Play("Gunshot");
        float angle = AngleTowardsMouse(shootingPos.transform.position);

        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        Vaccine Vaccine = Instantiate(VaccinePrefab, shootingPos.transform.position, rotation).GetComponent<Vaccine>();
        Vaccine.VaccineVelocity = VaccineSpeed;

        canFire = false;
    }
}
