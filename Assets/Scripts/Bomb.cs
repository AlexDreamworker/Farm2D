using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float countdown;
    public GameObject blastPrefab;

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            Instantiate(blastPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
