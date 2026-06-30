# SuperCube - Unity Project

Das ist das Haupt-Repository für das **SuperCube** Unity-Projekt. Es enthält alle C#-Skripte, Szenen und Assets, die für die Entwicklung des Spiels benötigt werden.

🎮 **Live-Spiel testen:** [michdo93.github.io/SuperCube](https://michdo93.github.io/SuperCube/)  
📦 **Fertiger WebGL-Build (Hosting):** [Michdo93/SuperCube](https://github.com/Michdo93/SuperCube)  
⚙️ **Highscore-Backend (FastAPI):** [Michdo93/SuperCube-Backend](https://github.com/Michdo93/SuperCube-Backend)

---

## Voraussetzungen

* **Unity Editor:** Empfohlen wird Version `2022.3 LTS` (oder höher, je nachdem, welche du nutzt).
* **Build-Support:** Stelle sicher, dass das **WebGL Build Support** Modul in Unity Hub installiert ist.

## Erste Schritte im Editor

1. Klone dieses Repository:
   ```bash
   git clone [https://github.com/Michdo93/SuperCube-Unity-Project.git](https://github.com/Michdo93/SuperCube-Unity-Project.git)
   ```
2. Öffne den **Unity Hub** und füge das Projekt hinzu.
3. Öffne die Hauptszene unter `Assets/Scenes/Main.unity` (Pfad eventuell anpassen).

## Highscore-Anbindung konfigurieren

Das Spiel kommuniziert mit dem FastAPI-Backend. Um die API-URL für deine eigene Instanz zu ändern:

1. Suche im Unity-Projekt nach dem Skript/Manager für das Highscore-System (z.B. `HighscoreManager.cs`).
2. Passe die `BASE_URL` an deine Render.com-Adresse an:
```csharp
private string baseUrl = "[https://dein-backend.onrender.com/highscores](https://dein-backend.onrender.com/highscores)";
```

## WebGL Build erstellen

1. Gehe in Unity auf `File` -> `Build Settings`.
2. Wechsel die Plattform auf **WebGL**.
3. Klicke auf **Build** und wähle einen Zielordner.
4. Der Inhalt dieses Ordners entspricht der Struktur, die im [Frontend-Repo](https://github.com/Michdo93/SuperCube) hochgeladen werden muss.
