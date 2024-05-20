using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public GameObject healthTextPrefab;
        
    public Canvas gameCanvas;

    private void Awake()
    {
        gameCanvas = FindObjectOfType<Canvas>();        
    }

    private void OnEnable()
    {
        CharacterEvents.charaterDamaged += CharacterTookDamage;
        CharacterEvents.charaterHealed += CharacterHealed;
    }

    private void OnDisable()
    {
        CharacterEvents.charaterDamaged -= CharacterTookDamage;
        CharacterEvents.charaterHealed -= CharacterHealed;
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
}
