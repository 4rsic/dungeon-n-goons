using UnityEngine;

public class statsmanager : MonoBehaviour
{
    public static statsmanager Instance;

    [Header("Combat Stats")]
    public float damage;

    public float maxHealth;
    public float chealth;

    [Header("Movement Stats")]
    public float speed;
    public float sprintSpeed;

    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;

        }
        else Destroy(gameObject);


    }
}
