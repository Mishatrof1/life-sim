VAR NpcName = "npc name" 
VAR Relationship = 53
VAR UnFriendStatus = false
VAR Bubble = "hey"
 
-Вы хотите раздружиться с {NpcName}
* [Ok] 
    ~Bubble = "Да пофиг!"
    ~UnFriendStatus = true 
    -> itog
    
== itog ==
Вы больше не друзья с {NpcName}
* [Ok]
-> END