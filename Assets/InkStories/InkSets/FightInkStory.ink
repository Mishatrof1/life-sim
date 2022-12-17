VAR NpcName = "npc name"
VAR Health = 0
VAR PlayerGender = "female" 
VAR Relationship = 44
VAR Happiness = 0 
VAR NpcLooks = 0
VAR Looks = 0
VAR Bubble = "hey"
 
Драка {NpcName}  
{
-PlayerGender == "male":
* [Дать пощечину]  -> Ok 
* [Ударить кулаком в лицо] -> Ok
* [Нанести серию ударов] -> Ok 
}
{
-PlayerGender == "female":
* [Вцепиться в волосы]  -> Ok 
* [Ударить туфлей] -> Ok
* [Расцарапать лицо] -> Ok  
}


// -> Ok  
 
== Ok == 
~ temp dice_roll = RANDOM(1, 100) 
 { (dice_roll > 50): -> YouDidIt }   
 
 -> YouHaveProblem 
 
=== YouDidIt ===
Вы одержали верх в драке! Наслаждайтесь триумфом. 
~Bubble ="Ты - монстр! Я всем расскажу о твоей жестокости"
~Happiness += 15 
~Relationship -= 15
{Relationship < 0: Relationship = 0 } 
{Happiness > 100: Happiness = 100 } 
+ [Ok]-> END
 
=== YouHaveProblem ===
Противник оказался сильнее. Вам остается лишь зализывать свои раны.
~Bubble = "Беги, жалуйся мамочке"
~Health -= 15 
~Relationship -= 15
~Looks -= 15
{Health < 0: Health = 0 } 
{Looks < 0: Looks = 0 } 
{Relationship < 0: Relationship = 0 } 
 + [Ok]-> END
-> END
