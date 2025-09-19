# Unity AR Business Card

An **Augmented Reality (AR)** project built with **Unity + Vuforia Engine**, as part of the **Holberton School AR/VR specialization (C#24)**.

---

## 🎯 Overview

This app displays an **interactive AR business card** when scanning a physical marker with the device camera.  
Features include:

- **Digital layout** with name, title, and interactive buttons.  
- **Audio feedback** when clicking buttons.  
- **Interactivity**: buttons open links (Medium, GitHub, LinkedIn) or compose an email.  
- **Dynamic visibility**: the layout shows when the marker is tracked and hides automatically when it’s lost.  
- **Sequential reveal**: elements (name, title, buttons) appear one after another with delays, simulating an entry animation.  

---

## 📂 Project Structure

```
unity_ar_business_card/
 ├── Assets/Scenes/ARBusinessCard.unity   # Main scene
 ├── Assets/Scripts/LinkOpener.cs         # Link handling & sound
 ├── Assets/Scripts/TargetVisibility.cs   # Visibility control with Vuforia
 ├── Assets/Scripts/SequentialReveal.cs   # Sequential element reveal
 ├── Builds/                              # Local builds (ignored in Git)
 └── README.md
```

---

## 🛠️ Requirements

- **Unity Hub** + **Unity 2022.3 LTS** (tested on `2022.3.44f1`)  
- **Vuforia Engine** (installed as a Unity package)  
- **Android Build Support** (NDK, SDK & OpenJDK)  
- Android device with **API Level 29 (Android 10)** or higher.  

---

## 📱 Builds

### Android
- A functional **APK** (`ARBusinessCard.apk`) was built and tested on a real device.  
- ⚠️ Due to GitHub’s 100MB file size limit, builds are hosted on Google Drive:  

[⬇️ Download Android APK](https://drive.google.com/file/d/1qxE1KMzEawXPs9z-U1QZucK1KV4WvRSv/view)

### iOS
- An **Xcode project** was generated from Unity.  
- ⚠️ Code signing and provisioning must be configured in **Xcode** with an Apple Developer account.  

[⬇️ Download iOS Build (Xcode project)](soon)

---

## 🚀 How to Run

1. Clone this repository:
   ```bash
   git clone https://github.com/gomez7373/holbertonschool-unity.git
   cd unity_ar_business_card
   ```

2. Open the project using **Unity Hub**.  

3. Scan the AR marker with your device camera to display the digital card.  

---

## 👩‍💻 Author

**Sheila G. Cubero (SGC)**  
- 🌐 [Medium](https://medium.com/@sgc.holberton)  
- 💻 [GitHub](https://github.com/gomez7373)  
- 💼 [LinkedIn](https://www.linkedin.com/in/sheilagomezcubero)  
- ✉️ se.gomez.sheila@gmail.com  

