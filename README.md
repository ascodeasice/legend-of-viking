# Legend of Viking
Unity homework project for NCKU course, Window Programming.
# Environment
- Unity Editor 2021.3.12f1
# How to Play
- WASD : Move
- Shift+WASD : Sprint
- Space : Jump
- Left Click : Attack
- F : Pick Up Item
- Esc : Back to Menu

# Description(Your Game)
## Story
You are a viking warrior defending invaders of your hometown, you must defeat as many enemies as possible to protect your people.   

## Mechanism
The enemy will spawn every few seconds, you must defeat them while staying distance with them. And collect as many coins as possible.

The enemy will chase you if you're near them, and stop when you're far away.
# Bonus
## Mentioned in PowerPoint
- Background music(Song of Storms, Legend of Zelda OST) 
- Invincible item player can consume(press F) (10% drop rate)
- Special game object: health item (10% chance), player can consume (press F) and restore 10HP
- Code Structure(See below)

## Additional
- Additional Visual Effects   
    - Different colors of health bar to show player HP is high/low
    - Better fonts, and design of UI ( than default components )
    - hover effects of button
    - Rotation of dropped items
    - death animation for enemies
- Additional Sound Effects
    - Jump sound
    - Collect item sound
- Invincible time for player and enemy when they get hit
- Game story(a scene)
## Code Structure

我根據功能將script分裝在
  1. enemy
  2. map
  3. player
  4. sceneManaging
  5. UI 
---
五個資料夾中，這樣規劃的優點是:

### 一、分類直覺
如果要為敵人加上新功能，如新攻擊方式，就可以在enemy資料夾創新的檔案就好；有關地圖物件的script都在map資料夾中；有關玩家的在player；如果要做場景間的切換，就在sceneManaging；而關於canvas設計、物件的腳本則在UI資料夾。

在分類時不需要多想就能開始寫程式。
### 二、容易新增功能
因為每個資料夾相當於定義物件的行為，所以要新增功能時，就可以簡易的讓物件做出對應的行為。

例如:敵人死亡掉落金幣、玩家按F可以撿起這個功能:

就可以分別在enemy資料夾用一個檔案定義敵人死亡行為、在player資料夾用另一個檔案偵測玩家撿起，實作功能上很直覺化。
### 三、容易找出bug來源
因為程式對應到(資料夾名稱的)物件，所以哪裡出了問題就可以直接找到對應的資料夾、C#檔案，不斷往回推問題開始的地方，方便Debug。
# Feedback
我從這個作業學到了很多東西，除了基本Unity遊戲製作之外，我覺得最有價值的東西是Debug與處理問題的經驗。  

因為一個變數常常會隨著多個Script傳到不同物件中，所以出Bug時就會需要逐步追尋從哪裡出了問題，而因為需要更有效率地找出問題在哪，也連帶改善了script的分工、架構方式，讓我對於如何分類和組織程式更有想法。

我學到的另一件事情是「將抽象想法實現的能力」，例如作業中的ground spawner，一開始對於怎麼做完全沒有想法。在嘗試了幾種方法過後（使用BFS生成外圍地板、玩家墜落時傳送並生成地板等），最終才想到同時實用又簡單的方法，也是一個學習的過程。

而我覺得作業中很多功能都有在Unity課堂上講過了，這點讓製作的過程簡單了不少，但是作業同時也包含了一些沒講到過的功能，讓過程多了不少挑戰性。

而我覺得作業沒有詳細列出每個功能的特性，讓同學依照自己的想法發揮這件事情是一件很好的事情，讓我能自己判斷該怎麼做，遊戲才能更符合我的期待、讓玩家的體驗更好。

最後，很感激助教的三堂Unity教學，雖然只有三周的時間沒辦法完全顧及到每個Unity的功能，但還是幾乎都有講到重要的事情，對於新手很有幫助，同時也可以感覺到有認真的教學態度。