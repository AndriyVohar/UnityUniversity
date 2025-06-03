# Lab3. Полоса перешкод з системою прогресу

## Опис проекту
Цей проект представляє собою 3D-гру "Полоса перешкод", де гравець керує персонажем, який повинен дістатися фінішу, уникаючи перешкод, збираючи монети та вкладаючись у відведений час. Проект демонструє використання паттерна Singleton, системи подій, збереження даних у JSON та базову механіку ігрової сесії.

## Структура проекту

```
Assets/
  ├─ Scripts/
  │   ├─ Player.cs              - Логіка руху гравця та обробка колізій
  │   ├─ GlobalStorage.cs       - Глобальне сховище даних (Singleton)
  │   ├─ Lives.cs               - Відображення життів на інтерфейсі
  │   ├─ Finish.cs              - Обробка досягнення фінішу
  │   └─ TimerController.cs     - Контроль часу рівня
```

## Реалізовані функціональності

### 1. Монети та пастки
- **Монети**: При зіткненні з монетою, гравець отримує +1 життя, а монета зникає
- **Пастки (коробки)**: При зіткненні з пасткою, гравець втрачає одне життя

### 2. Глобальне сховище даних (Singleton)
- Зберігає:
- Таблицю рекордів
- Кількість життів
- Кількість зіткнень з пастками
- Час від запуск**у рівня
- Кількість зібраних монет**

### 3. Збереження даних
- Формат: JSON
- Збереження: При виході з гри
- Завантаження: При запуску гри

### 4. Система життів та програшу
- Початкова кількість життів: 3
- При зіткненні з пасткою: -1 життя
- При зібранні монети: +1 життя
- При досягненні 0 життів: програш

### 5. Обмеження часу
- Визначений час на проходження рівня
- При вичерпанні часу: програш

## Приклади реалізації

### Глобальне сховище (Singleton)
```csharp
public class GlobalStorage : MonoBehaviour
{
    public static GlobalStorage Instance { get; private set; }

    public RecordData data = new RecordData();
    private string savePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Path.Combine(Application.persistentDataPath, "saveData.json");
            LoadData();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Методи збереження та завантаження даних...
}
```

### Обробка зіткнень та збір монет
```csharp
private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = true;
    }

    if (collision.gameObject.CompareTag("Box"))
    {
        GlobalStorage.Instance.data.lives--;
        GlobalStorage.Instance.data.collisions++;
        Debug.Log("Player hit! Lives remaining: " + GlobalStorage.Instance.data.lives);

        if (GlobalStorage.Instance.data.lives <= 0)
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    if (collision.gameObject.CompareTag("Money"))
    {
        GlobalStorage.Instance.data.coinsCollected++;
        GlobalStorage.Instance.data.lives++;
        Destroy(collision.gameObject);
    }
}
```

### Система таймера
```csharp
void Update()
{
    if (isGameOver) return;

    remainingTime -= Time.deltaTime;

    if (timerText != null)
    {
        timerText.text = "Time: " + Mathf.CeilToInt(remainingTime).ToString();
    }

    if (remainingTime <= 0)
    {
        GameOver();
    }
}

void GameOver()
{
    isGameOver = true;
    Debug.Log("Час вичерпано! Програш.");
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
}
```

## Керування
- **W/A/S/D** або **Стрілки**: Рух персонажа
- **Пробіл**: Стрибок
- **Shift**: Тимчасове прискорення