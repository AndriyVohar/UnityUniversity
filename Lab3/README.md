# Lab2. Завдання: Полоса перешкод

## Структура проекту

```
Lab2
├── Assets
│   ├── Scenes
│   │   └── SampleScene.unity
│   ├── Materials
│   │   ├── FinishMaterial.mat
│   │   ├── BorderMaterial.mat
│   │   ├── PlaneMaterial.mat
│   │   └── PlayerMaterial.mat
│   └── Scripts
│       ├── Finish.cs
│       └── Player.cs
├── .gitignore
```

## Опис
Цей проект містить рівень гри «Полоса перешкод», який складається з рухомого головного героя та перешкод:
1. **Головний герой** – рухається вперед із постійною швидкістю, може рухатися вліво-вправо, стрибати та прискорюватися.
2. **Перешкоди** – коробки.
3. **Фініш** – сіро-чорна площина.

## Завдання
1. Реалізувати рух головного героя вздовж полоси з постійною швидкістю.
2. Реалізувати можливості руху вліво-вправо.
3. Доповнити полосу перешкодами.
4. Доповнити полосу фінішом.
5. Реалізувати можливість перестрибувати перешкоди.
6. Реалізувати прискорення героя, яке не може тривати більше `n` секунд.

### Code Snippets

```csharp
// Player.cs
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float acceleration = 2f;
    public float maxAccelerationTime = 2f;
    private float accelerationTime = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
        Accelerate();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 1.0f);
        rb.velocity = movement * speed;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Accelerate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && accelerationTime < maxAccelerationTime)
        {
            speed += acceleration * Time.deltaTime;
            accelerationTime += Time.deltaTime;
        }
        else
        {
            speed = 5f;
            accelerationTime = 0f;
        }
    }
}
```

```csharp
// Finish.cs
using UnityEngine;

public class Finish : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You win!");
            
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
```