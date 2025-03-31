# Модульна контрольна робота №1.
## Вогар Андрій - Варіант 16

---

### Завдання:
1. Клас Vector3.
2. Дано вектори (1,8,-7) та (2,0,-6). Нормалізувати їх суму.
3. Створити сцену для моделювання їзди велосипедиста. повороти здійснювати після натискання певних клавіш.

---

### Структура проєкту
```
MKR1
├── Assets
│   ├── Bycicle.fbx
│   ├── Scenes
│   │   ├── Task2.unity
│   │   └── Task3.unity
│   └── Scripts
│       │── Task2
│       │   └── NormalizingSumVectors.cs
│       └── Task3
│           └── BicycleController.cs
├── .gitignore
```

---
## Виконання

### Завдання 1. Клас Vector3.

Vector3 - це клас, який служить для зберігання координат у тривимірному просторі, замість того щоб зберігати їх як три окремі змінні.ґ
Він дозволяє зберігати значення типу `float` для `x`, `y` та `z` координат, а також надає різні методи для роботи з цими значеннями.
Основні методи класу `Vector3`:
- `Vector3.zero` - повертає вектор з нульовими значеннями.
- `Vector3.Normalize()` - нормалізує вектор.
- `Vector3.Distance(Vector3 a, Vector3 b)` - обчислює відстань між двома векторами.
- `Vector3.Cross(Vector3 a, Vector3 b)` - обчислює векторний добуток двох векторів. 

та інші.

#### Приклад:

```csharp
using UnityEngine;

public class Vector3Example : MonoBehaviour
{
    void Start()
    {
        Vector3 vector = new Vector3(1, 2, 3);
        Vector3 zeroVector = Vector3.zero;
        Vector3 normalizedVector = vector.normalized;
        float distance = Vector3.Distance(vector, zeroVector);
        Vector3 crossProduct = Vector3.Cross(vector, zeroVector);

        Debug.Log("Vector: " + vector);
        Debug.Log("Zero vector: " + zeroVector);
        Debug.Log("Normalized vector: " + normalizedVector);
        Debug.Log("Distance between vector and zero vector: " + distance);
        Debug.Log("Cross product of vector and zero vector: " + crossProduct);
    }
}
```

#### Використання `Vector3` для відстані між об'єктами

Зробимо вигляд, що нам потрібно виконати функцію на основі відстані між гравцем та іншим `GameObject`.
Ми могли б отримати значення `x`, `y` та `z` гравця і зберегти їх у окремих змінні,
та все ж набагато ефективніше зберігати позицію гравця в одному `Vector3`.

##### Використання змінних для позиції гравця:

```csharp
float playerX;
float playerY;
float playerZ;
GameObject player;

void Update(){
    playerX = player.transform.position.x;
    playerY = player.transform.position.y;
    playerZ = player.transform.position.z;
}
```

##### Використання `Vector3` для позиції гравця:

```csharp
Vector3 playerPos;
GameObject player;

void Update(){
    playerPos = player.transform.position;
}
```

Тому використання `Vector3` використовується для зберігання координат трьох вимірів та містить додаткові часто вживані методи, що полегшує роботу з ними.


### Завдання 2. Нормалізація суми векторів.
#### Дано вектори (1,8,-7) та (2,0,-6). Нормалізувати їх суму.

#### [NormalizingSumVectors.cs](Assets/Scripts/Task2/NormalizingSumVectors.cs)

```csharp
using UnityEngine;

/**
 * Дано вектори (1,8,-7) та (2,0,-6). Нормалізувати їх суму.
 */
public class NormalizingSumVectors : MonoBehaviour
{    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 vector1 = new Vector3(1, 8, -7);
        Vector3 vector2 = new Vector3(2, 0, -6);
        Vector3 sum = vector1 + vector2;
        Vector3 normalizedSum = sum.normalized;

        Debug.Log("Normalized sum: " + normalizedSum); // Normalized sum: (0.19, 0.51, -0.84)
    }
}
```

#### Результат виконання:

```csharp
Normalized sum: (0.19, 0.51, -0.84)
```

### Завдання 3. Моделювання їзди велосипедиста.
#### Створити сцену для моделювання їзди велосипедиста. повороти здійснювати після натискання певних клавіш.

1. Додав модель велосипеда `Bicycle` у сцену.
2. Прикріпив камеру до велосипеда.
3. Додав клас `BicycleController`, який дозволяє керувати велосипедистом за допомогою клавіш `W`, `A`, `S`, `D`.

#### [BicycleController.cs](Assets/Scripts/Task3/BicycleController.cs)

```csharp
using UnityEngine;

public class CicleController : MonoBehaviour
{
    public float speed = 10f;       // Швидкість руху вперед
    public float turnSpeed = 50f;   // Швидкість повороту
    public float brakeForce = 5f;   // Сила гальмування

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // Забороняємо перевертання
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.linearVelocity = transform.forward * -speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocity = transform.forward * speed / 2;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.fixedDeltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.fixedDeltaTime);
        }
    }
}
```