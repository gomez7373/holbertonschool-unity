using UnityEngine;
using System.Collections;

/// <summary>
/// Activa elementos de UI uno tras otro con un delay configurable.
/// Sin usar Animator, solo SetActive.
/// </summary>
public class SequentialReveal : MonoBehaviour
{
    [Tooltip("Objetos a mostrar en orden (arrástralos en el Inspector)")]
    public GameObject[] elements;

    [Tooltip("Tiempo entre cada aparición (segundos)")]
    public float delay = 0.5f;

    /// <summary>
    /// Llama a este método cuando quieras iniciar la secuencia
    /// (ej: desde TargetVisibility cuando el marcador aparece).
    /// </summary>
    public void StartReveal()
    {
        StopAllCoroutines();
        StartCoroutine(RevealSequence());
    }

    /// <summary>
    /// Oculta todos los elementos de la lista.
    /// </summary>
    public void HideAll()
    {
        foreach (var element in elements)
        {
            if (element != null)
                element.SetActive(false);
        }
    }

    private IEnumerator RevealSequence()
    {
        // Asegura que todo empieza oculto
        HideAll();

        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i] != null)
                elements[i].SetActive(true);

            yield return new WaitForSeconds(delay);
        }
    }
}
