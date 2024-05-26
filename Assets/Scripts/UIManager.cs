using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public GameObject healthTextPrefab;
    public GameObject arrowTextPrefab;
        
    public Canvas gameCanvas;

    private void Awake()
    {
        gameCanvas = FindObjectOfType<Canvas>();        
    }

    private void OnEnable()
    {
        CharacterEvents.charaterDamaged += CharacterTookDamage;
        CharacterEvents.charaterHealed += CharacterHealed;
        CharacterEvents.characterPickArrow += CharacterPickArrow;
    }

    private void OnDisable()
    {
        CharacterEvents.charaterDamaged -= CharacterTookDamage;
        CharacterEvents.charaterHealed -= CharacterHealed;
        CharacterEvents.characterPickArrow -= CharacterPickArrow;
    }

    public void CharacterTookDamage(GameObject character, int damageReceived) //create text damage
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position); 

        TMP_Text tmpText = Instantiate(damageTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();

        tmpText.text = damageReceived.ToString();
    }

    public void CharacterHealed(GameObject character, int healthReceived)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(healthTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();

        tmpText.text = healthReceived.ToString();
    }

    public void CharacterPickArrow(GameObject character, int arrowReceived)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(arrowTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();

        tmpText.text = arrowReceived.ToString();
    }

    public void OnExitGame(InputAction.CallbackContext context)
    {
       if (context.started)
        {
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
                Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        #endif

        #if (UNITY_EDITOR)
                UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE)
                Application.Quit();
        #elif (UNITY_WEBGL)
                Scene.Manager.LoadScene("QuitScene");
        #endif

        }
    }
}
