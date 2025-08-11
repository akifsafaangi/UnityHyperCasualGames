using Mono.Cecil;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ColorChanger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "red")
        {
            gameObject.GetComponent<Collider>().enabled = false;
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            GetComponent<Rigidbody>().AddForce(Vector3.down * 50, ForceMode.Impulse);
            HeartsFun(collision.gameObject);
            Destroy(gameObject, 0.5f);
            print("Game Over");
        }
        else
        {
            GameObject.Find("HitSound").GetComponent<AudioSource>().Play();
            gameObject.gameObject.GetComponent<Collider>().enabled = false;
            GameObject splashObject = Instantiate(Resources.Load("splash1")) as GameObject;
            splashObject.transform.parent = collision.gameObject.transform;
            Destroy(splashObject, 0.1f);
            collision.gameObject.name = "color";
            collision.gameObject.tag = "red";
            StartCoroutine(ChangeColor(collision.gameObject));
        }
    }

    IEnumerator ChangeColor(GameObject target)
    {
        yield return new WaitForSeconds(0.1f);
        target.gameObject.GetComponent<MeshRenderer>().enabled = true;
        target.gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.ballColor;
        Destroy(base.gameObject);
    }
    void HeartsFun(GameObject g)
    {
        int @int = PlayerPrefs.GetInt("hearts");
        if (@int == 1)
        {
            FindFirstObjectByType<GameManager>().FailGame();
            FindFirstObjectByType<GameManager>().DecreaseHeart();
        }
    }
}
