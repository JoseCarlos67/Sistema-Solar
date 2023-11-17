using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailControl : MonoBehaviour
{   
// Crie uma lista para armazenar todos os Trail Renderers dos planetas
    public List<TrailRenderer> planetTrailRenderers = new List<TrailRenderer>();

    // Crie uma lista para armazenar todos os Toggles dos planetas
    public List<Toggle> planetToggles = new List<Toggle>();

    void Start()
    {
        // Adicione um listener para cada Toggle, associando-o ao método ToggleTrailRenderer
        for (int i = 0; i < planetToggles.Count; i++)
        {
            int index = i; // Cria uma cópia da variável para evitar problemas de closure
            planetToggles[i].onValueChanged.AddListener(isTrailActive => ToggleTrailRenderer(index, isTrailActive));
        }
    }

    void ToggleTrailRenderer(int planetIndex, bool isTrailActive)
    {
        // Ativa ou desativa o Trail Renderer do planeta correspondente
        planetTrailRenderers[planetIndex].enabled = isTrailActive;
    }
}
