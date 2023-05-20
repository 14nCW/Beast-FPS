using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Object : MonoBehaviour {
    #region Variables
    [SerializeField] public string _material;


    [SerializeField] private float _maxHealth;
    [SerializeField] private Slider slider;
    private float _currentHealth;
    [SerializeField] private TextMeshProUGUI _materialName;
    [SerializeField] private TextMeshProUGUI _HPText;
    [SerializeField] private Camera _camera;
    [SerializeField] private Canvas _canvas;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        _materialName.text = _material;
    }

    // Update is called once per frame
    void Update()
    {
        RefreshHealthBar();
        _canvas.transform.rotation = _camera.transform.rotation;
    }


    void RefreshHealthBar() {
        slider.value = _currentHealth / _maxHealth;
        _HPText.text = _currentHealth + "/" + _maxHealth;
    }

    public void TakeDamage(int p_damage) {
            _currentHealth -= p_damage;
            RefreshHealthBar();

            if (_currentHealth <= 0) {
                Destroy(gameObject);
            }
    }
}
