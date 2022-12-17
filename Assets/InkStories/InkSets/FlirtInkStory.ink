VAR NpcName = "npc name" 
VAR PlayerGender = "male" 
VAR NpcGender = "male"
VAR PlayerAge = 0
VAR Relationship = 44
VAR Happiness = 0
VAR Look = 51
VAR Health = 0
VAR LoverStatus = false
VAR ChangeMoneyAmount = 0
VAR Bubble = "hey"
  
Вы хотите флирт с {NpcName}
* [Подмигнуть] -> Ok
* { PlayerGender == "male" } [Восхищенно присвистнуть] -> Ok
* { PlayerGender == "female" } [Призывно улыбаться] -> Ok
 
-> Ok

== Ok ==  
 ~Relationship += 5 
 { (Relationship > 50) && (Look > 50): -> YouDidIt } 
  
  -> YouHaveProblem 


=== YouDidIt ===
{
-NpcGender == "male":
    ~Bubble = "Меня от тебя бросает в жар" 
    Получилось! Теперь вы с {NpcName} любовники! 
}
{
-NpcGender == "female":
    ~Bubble = "О, у меня кружится голова"
    Получилось! Теперь вы с {NpcName} любовники! 
}
~Happiness += 5 

{Happiness > 100: Happiness = 100 } 
{Relationship > 100: Relationship = 100 } 
~LoverStatus = true
+ [Ok]-> END


=== YouHaveProblem ===
{
-NpcGender == "male":
   ~Bubble = "Что ты себе позволяешь"
    Это фиаско! Но не отчаивайтесь, пробуйте еще!
}
{
-NpcGender == "female":
    ~Bubble = "Глупости какие"
    Это фиаско! Но не отчаивайтесь, пробуйте еще!
} 
~Happiness -= 5 
{Happiness <0: Happiness = 0 } 
 + [Ok]-> END
-> END
