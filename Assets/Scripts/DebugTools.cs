using System.Collections.Generic;
using UnityEngine;

// Small debug panel docked in the top-right corner (Editor and Development Builds only).
//   1-4  spawn an enemy type at a random spawner (in the order they appear in a run)
//   O    toggle whether the player (and shield) can take damage
//   `    hide/show the panel (keys keep working while hidden)
public class DebugTools : MonoBehaviour
{
    // Checked by everything that can destroy the player or shield. Always true in release builds.
    public static bool PlayerCanTakeDamage { get; private set; } = true;

#if UNITY_EDITOR || DEVELOPMENT_BUILD
    // Enemy prefab names in the order they first appear, with the label shown in the panel
    private static readonly string[] EnemyPrefabNames = { "FollowingEnemy", "ShootEnemy", "DashingEnemy", "DashingBossy" };
    private static readonly string[] EnemyLabels = { "Chaser", "Shooter", "Dasher", "Boss" };

    private const float PanelWidth = 170f;
    private const float Margin = 8f;

    private bool isVisible = true;
    private string lastAction = "";
    private GUIStyle textStyle;
    private Texture2D backgroundTexture;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void Create()
    {
        PlayerCanTakeDamage = true;
        GameObject debugObject = new GameObject("DebugTools");
        DontDestroyOnLoad(debugObject);
        debugObject.AddComponent<DebugTools>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            isVisible = !isVisible;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerCanTakeDamage = !PlayerCanTakeDamage;
            lastAction = PlayerCanTakeDamage ? "Damage ON" : "Damage OFF";
        }

        for (int i = 0; i < EnemyPrefabNames.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) || Input.GetKeyDown(KeyCode.Keypad1 + i))
            {
                SpawnEnemy(i);
            }
        }
    }

    private void SpawnEnemy(int index)
    {
        // Use the scene's own spawners: their prefab references and spawn points
        EnemySpawn[] spawners = FindObjectsByType<EnemySpawn>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        GameObject prefab = null;
        List<Transform> spawnPoints = new List<Transform>();
        foreach (EnemySpawn spawner in spawners)
        {
            if (spawner.spawnPoint != null)
            {
                spawnPoints.Add(spawner.spawnPoint);
            }
            if (prefab == null && spawner.enemyPrefab != null && spawner.enemyPrefab.name == EnemyPrefabNames[index])
            {
                prefab = spawner.enemyPrefab;
            }
        }

        if (prefab == null || spawnPoints.Count == 0)
        {
            lastAction = "No " + EnemyLabels[index] + " spawner here";
            return;
        }

        Transform point = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(prefab, point.position, Quaternion.identity);
        lastAction = "Spawned " + EnemyLabels[index];
    }

    private void OnGUI()
    {
        if (!isVisible) return;

        if (textStyle == null)
        {
            textStyle = new GUIStyle(GUI.skin.label) { fontSize = 11, richText = true };
            textStyle.normal.textColor = Color.white;
            backgroundTexture = new Texture2D(1, 1);
            backgroundTexture.SetPixel(0, 0, new Color(0f, 0f, 0f, 0.6f));
            backgroundTexture.Apply();
        }

        string damage = PlayerCanTakeDamage ? "<color=#7CFC7C>ON</color>" : "<color=#FF6B6B>OFF</color>";
        string text =
            "<b>DEBUG</b>   <color=#AAAAAA>` hide</color>\n" +
            "1 Chaser  2 Shooter\n" +
            "3 Dasher  4 Boss\n" +
            "O Damage: " + damage;
        if (lastAction.Length > 0)
        {
            text += "\n<color=#AAAAAA>" + lastAction + "</color>";
        }

        GUIContent content = new GUIContent(text);
        float height = textStyle.CalcHeight(content, PanelWidth - 12f) + 8f;
        Rect panel = new Rect(Screen.width - PanelWidth - Margin, Margin, PanelWidth, height);

        GUI.DrawTexture(panel, backgroundTexture);
        GUI.Label(new Rect(panel.x + 6f, panel.y + 4f, panel.width - 12f, panel.height - 8f), content, textStyle);
    }

    private void OnDestroy()
    {
        if (backgroundTexture != null)
        {
            Destroy(backgroundTexture);
        }
    }
#endif
}
