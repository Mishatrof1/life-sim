VAR NpcName = "npc name" 
VAR Relationship = 53
VAR FriendStatus = false
VAR Bubble = "Hey"
 
Вы хотите подружиться с {NpcName}
* [Подружиться]
 {
 -Relationship >50:
    Вы теперь друзья с {NpcName}
    ~Bubble = "Дружба? Это прекрасно!"
    ~FriendStatus = true
  -> itog
 } 
 {
 -Relationship <51: 
 ~Bubble = "Серьезно? Отвали"
 С вами не хотят дружить 
 -> itog
 }
 
== itog ==
 
* [Ok]
-> END
