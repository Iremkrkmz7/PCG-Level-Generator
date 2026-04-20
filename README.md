# PCG-Level-Generator
# 🎮 PCG Level Generator + NPC AI

> 🇹🇷 Türkçe aşağıda / 🇬🇧 English below

---

## 🇬🇧 English

### What is this?
A Unity game that combines **Procedural Content Generation (PCG)** and **Finite State Machine (FSM)** based enemy AI. Every level is automatically generated and gets progressively harder as you collect coins.

### Systems

**1. Level Progression System**
- 4 levels total
- Each level the plane gets smaller and harder to survive on
- Collect all coins to advance to the next level

| Level | Plane Size | Coins | Enemies | Color |
|-------|-----------|-------|---------|-------|
| 1 | Large | 3 | 1 | Green |
| 2 | Medium | 4 | 2 | Blue |
| 3 | Small | 5 | 3 | Orange |
| 4 | Tiny | 6 | 4 | Red |



<img width="242" height="181" alt="Ekran görüntüsü 2026-04-21 002112" src="https://github.com/user-attachments/assets/21618fac-0b10-42e3-afd5-fc5940a3d33a" />
<img width="288" height="218" alt="Ekran görüntüsü 2026-04-21 002032" src="https://github.com/user-attachments/assets/5ee54560-82af-46c7-bc44-cd047c566df2" />
<img width="403" height="270" alt="Ekran görüntüsü 2026-04-21 002016" src="https://github.com/user-attachments/assets/67d1e1df-5eea-4e42-8ae8-04e4c6aa9c90" />
<img width="502" height="347" alt="Ekran görüntüsü 2026-04-21 001949" src="https://github.com/user-attachments/assets/cba64b1d-243e-4bbb-bacc-b6733404f56e" />
<img width="515" height="328" alt="Ekran görüntüsü 2026-04-21 002453" src="https://github.com/user-attachments/assets/70038696-b4c5-440a-ac4c-672c12ce578d" />


**2. PCG (Procedural Content Generation)**
- Enemies and coins are placed randomly on the plane every level
- Plane size shrinks algorithmically as levels progress
- No two playthroughs are the same

**3. NPC AI (FSM)**
- Enemy uses a 3-state Finite State Machine
- `Idle` → stands still, player out of range
- `Chase` → moves toward player when detected
- `Attack` → triggers Game Over when close enough

```
[ Idle ] → player enters range → [ Chase ] → player too close → [ Attack ]
              ↑                                                      
         player leaves range                                         
```

### How to Run
1. Open project in Unity
2. Open the main scene
3. Press **Play**
4. Move with mouse click (NavMesh based movement)
5. Collect coins to progress levels
6. Avoid enemies

### Tech Stack
- Unity
- C#
- NavMesh (AI Navigation)
- FSM Pattern
- PCG (Procedural Content Generation)

### Files
```
PCG-Level-Generator
 ┣ LevelGenerator.cs   ← PCG + Level system + Coin
 ┣ NPC.cs              ← FSM based enemy AI
 ┣ Player.cs           ← NavMesh player movement
 ┗ README.md
```

---

## 🇹🇷 Türkçe

### Bu ne?
**Prosedürel İçerik Üretimi (PCG)** ve **Finite State Machine (FSM)** tabanlı düşman yapay zekasını birleştiren bir Unity oyunu. Her level otomatik üretilir ve coin topladıkça zorluk artar.

### Sistemler

**1. Level İlerleme Sistemi**
- Toplam 4 level
- Her levelde zemin küçülür, hayatta kalmak zorlaşır
- Tüm coinleri topla, sonraki levele geç

| Level | Zemin Boyutu | Coin | Düşman | Renk |
|-------|-------------|------|--------|------|
| 1 | Geniş | 3 | 1 | Yeşil |
| 2 | Orta | 4 | 2 | Mavi |
| 3 | Dar | 5 | 3 | Turuncu |
| 4 | Çok dar | 6 | 4 | Kırmızı |

**2. PCG (Prosedürel İçerik Üretimi)**
- Düşmanlar ve coinler her levelde rastgele yerleşir
- Zemin boyutu her level algoritmik olarak küçülür
- Her oynanış farklıdır

**3. NPC Yapay Zekası (FSM)**
- Düşman 3 durumlu Finite State Machine kullanır
- `Idle` → bekler, oyuncu menzil dışında
- `Chase` → oyuncuyu algılayınca kovalar
- `Attack` → yeterince yaklaşınca Game Over tetikler

```
[ Idle ] → oyuncu yaklaşır → [ Chase ] → çok yaklaşır → [ Attack ]
              ↑                                                      
         oyuncu uzaklaşır                                         
```

### Nasıl Çalıştırılır
1. Projeyi Unity'de aç
2. Ana sahneyi aç
3. **Play**'e bas
4. Fareyle tıklayarak hareket et (NavMesh tabanlı)
5. Coinleri toplayarak level atla
6. Düşmanlardan kaç

### Kullanılan Teknolojiler
- Unity
- C#
- NavMesh (AI Navigation)
- FSM (Finite State Machine)
- PCG (Prosedürel İçerik Üretimi)

### Dosyalar
```
PCG-Level-Generator
 ┣ LevelGenerator.cs   ← PCG + Level sistemi + Coin
 ┣ NPC.cs              ← FSM tabanlı düşman AI
 ┣ Player.cs           ← NavMesh ile oyuncu hareketi
 ┗ README.md
```

---

## 🔗 Proje Serisi / Project Series

| # | Proje | Açıklama |
|---|-------|----------|
| 1 | NPC AI | FSM tabanlı düşman |
| 2 | **PCG Level Generator** ← bu repo | Prosedürel level + NPC birleşimi |
