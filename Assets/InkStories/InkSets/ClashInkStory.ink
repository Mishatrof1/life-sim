VAR NpcName = "npc name" 
VAR Relationship = 44
VAR Happiness = 0  
VAR NpcGender = "female"
VAR Bubble = "hey"
 
Унижение {NpcName}  
* [Видел бы ты себя со стороны…] 
~Happiness += 3 
~Relationship -= 3
-> Ok 
* [У тебя воняет изо рта]
~Happiness += 5 
~Relationship -= 5
-> Ok
* [Ты мне надоел]
~Happiness += 10
~Relationship -= 10
-> Ok 
  
 -> Ok  
 
== Ok ==  
{
-NpcGender == "male":
~Bubble = "Перестань, мне же обидно"
}
{
-NpcGender == "female":
~Bubble = "Я сейчас заплачу"
}

Вы унизили {NpcName}, зато сами возвысились!
{Relationship < 0: Relationship = 0 } 
{Happiness > 100: Happiness = 100 } 
 + [Ok]-> END
-> END