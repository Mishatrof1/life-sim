VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

На вокзале маленькая девочка передала мне записку со словами, что ее похитили. После этого ее начал уводить какой-то мужчина. Что делать?
* [Пойду следом, не теряя их из виду, и вызову полицию]
    -> res1
* [Запомню приметы девочки и мужчины и позвоню в полицию]
    -> res2
* [Это какой-то розыгрыш. Не стану принимать в нем участие]
    -> res3
* [Немедленно вырву девочку из лап похитителя]
    -> res4

=== res1 === 
Я следила за ними и смогла навести полицию.Девочку спасли, а похитителя схватили
~TextForLog = "Маленькая девочка передала мне записку со словами, что ее похитили. После этого ее начал уводить какой-то мужчина. Я выследила похитителя и навела полицию. Девочку спасли, а злодея схватили."
* [Ok]
-> END
=== res2 === 
Полиция поблагодарила меня за помощь, но поймать похитителя и освободить девочку пока не удалось
~TextForLog = "Маленькая девочка передала мне записку со словами, что ее похитили. После этого ее начал уводить какой-то мужчина. Я запомнила приметы девочки и похитителя и сообщила полиции. Меня поблагодарили за помощь."
* [Ok]
-> END
=== res3 === 
Это был не розыгрыш, позже я увидела объявление о пропаже ребенка и фото той девочки. К сожалению, и она и похититель были уже далеко
~TextForLog = "Маленькая девочка передала мне записку со словами, что ее похитили. После этого ее начал уводить какой-то мужчина. Я решила, что это розыгрыш и не стала реагировать. Позже я узнала, что это реальное похищение. Жаль, что я ошиблась."
* [Ok]
-> END
=== res4 === 
Я спасла девочку, а похититель сумел скрыться. Полиция не смогла его найти
~TextForLog = "Маленькая девочка передала мне записку со словами, что ее похитили. После этого ее начал уводить какой-то мужчина. Я силой вырвала девочку из лап похитителя, но ему удалось скрыться."
* [Ok]
-> END