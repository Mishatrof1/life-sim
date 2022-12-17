
VAR NpcName = "npc name"
VAR Relationship = 0
VAR Bubble = "hey"
VAR Dialog_BaseValue = 10
VAR Dialog_RelationshipParametersMatrix = ""
 
Початиться с {NpcName}  

* [Поинтересоваться здоровьем]
~Dialog_RelationshipParametersMatrix = "1!2!3"
 -> Res
* [Поболтать не о чем]
 -> Res
* [Пошутить]
 -> Res
* [Поделиться новостями]
 -> Res


=== Res ===
~Bubble = "Расскажи еще что-нибудь"
Вы прекрасно побеседовали с {NpcName}. Это укрепило вашу дружбу.
* [Ok] ->END