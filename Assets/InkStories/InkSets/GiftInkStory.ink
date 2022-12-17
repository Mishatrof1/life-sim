VAR NpcName = "npc name"
VAR Relationship = 0
VAR NpcGender = "male"
VAR Bubble ="hey"
 
Сделать подарок {NpcName}

* [Приятная мелочь  10$]
    ~Relationship += 5
 -> Res
* [Полезная вещь 50$]
~Relationship += 10
 -> Res
* [Ценный подарок 100$]
~Relationship += 15
 -> Res


=== Res === 
{Relationship > 100: Relationship = 100 } 
{
-NpcGender == "male":
Вы сделали другу подарок от чистого сердца.
~Bubble = "О, это то, о чем я мечтал"
}
{
-NpcGender == "female":
Вы сделали подруге подарок от чистого сердца.
~Bubble = "Ой, какая прелесть"
}
 Чаще поступайте так и ваша дружба будет вечной.
* [Ok] ->END