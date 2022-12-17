VAR NpcName = "npc name"
VAR Relationship = 0
VAR PlayerGender = "male"
VAR NpcGender = "male" 
VAR Bubble ="hey"
 
Вы хотите сделать комплимент {NpcName}
    * [Ты  молодец] -> chap1 
    * {NpcGender == "male"} [Ты - мой лучший друг] -> chap2 
    * {NpcGender == "female"} [Ты - моя лучшая подруга] -> chap2  
    * [Ты для меня пример в жизни ] -> chap3
 
=== chap1 ===
{
-NpcGender == "male":
    ~Bubble = "Ой-ой, какие нежности…"
    Вы сказали {NpcName}, что он молодец 
}
{
-NpcGender == "female":
    ~Bubble = "Хи-хи. Это так забавно"
    Вы сказали {NpcName}, что она молодец 
}
~ Relationship += 5 
{Relationship > 100: Relationship = 100 } 
 + [Ok]-> END
=== chap2 ===
{
-NpcGender == "male":
    ~Bubble = "Это приятно слышать"
    Вы сказали {NpcName}, что он лучший друг 
}
{
-NpcGender == "female":
    ~Bubble = "Ты - милашка"
    Вы сказали {NpcName}, что она лучшая подруга 
}
 
~ Relationship += 10
{Relationship > 100: Relationship = 100 } 
 + [Ok]-> END

=== chap3 ===
Вы сказали {NpcName}, что он для вас пример в жизни
~ Relationship += 15
{Relationship > 100: Relationship = 100 } 
 + [Ok]-> END
