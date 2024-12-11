using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public float duration = 2f;
    public float speed = 1f;
    public Vector3 offset = new Vector3(0, 2, 0);

    private TextMeshPro textMesh;
    private float elapsedTime = 0f;

    private void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
        transform.position += offset;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        elapsedTime += Time.deltaTime;
        if (elapsedTime >= duration)
        {
            Destroy(gameObject);
        }
    }

    public void SetText(string text, Color color)
    {
        if (textMesh != null)
        {
            textMesh.text = text;
            textMesh.color = color;
        }
    }
}
