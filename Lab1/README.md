# Lab 1
### Структура проєкту
```
Lab1
├── Assets
│   ├── Scenes
│   │   ├── Task1-Domino.unity
│   │   └── Task2-BCE.unity
│   └── Scripts
│       ├── Task1
│       │   └── Domino.cs
│       └── Task2
│           ├── RotatingRod.cs
│           ├── SpiralPlatform.cs
│           ├── Pendulum.cs
├── .gitignore
```

## Завдання 1: Доміно

### Опис
1. Створити нову сцену в Unity
2. Розмістити декілька об'єктів які виконують роль доміно.
3. Розмістити один об'єкт так, щоб його падіння під силою тяжіння запускала ефект доміно.
4. Закомітити проєкт до репозиторію. Особливу увагу приділити .gitignore

### Виконання
1. Створено нову сцену в Unity
2. Розміщено 5 об'єктів які виконують роль доміно
3. Розміщено один об'єкт який падає під силою тяжіння і запускає ефект доміно

## Завдання 2: Полоса перешкод у Unity3D

### Опис
Використовуючи методи Translate Побудувати рівень гри «Полоса перешкод», що містить такі перешкоди:
1. **Стержень** – рівномірно обертається навколо одного зі своїх кінців.
2. **Маятник** – здійснює коливальні рухи на заданий кут.
3. **Плита** – рухається по спіралі.

### Виконання
1. Стержень – рівномірно обертається навколо одного зі своїх кінців.
2. Маятник – здійснює коливальні рухи на заданий кут.
3. Плита – рухається по спіралі.

### Code Snippets
```csharp
// RotatingRod.cs
using UnityEngine;

public class RotatingRod : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
```

```csharp
// SpiralPlatform.cs
using UnityEngine;

public class SpiralPlatform : MonoBehaviour
{
    public float speed = 1f;
    public float radius = 5f;
    private float angle = 0f;

    void Update()
    {
        angle += speed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;
        transform.position = new Vector3(x, transform.position.y, z);
    }
}
```

```csharp
// Pendulum.cs
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float angle = 30f;
    public float speed = 2f;

    void Update()
    {
        float rotation = Mathf.Sin(Time.time * speed) * angle;
        transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }
}
```
