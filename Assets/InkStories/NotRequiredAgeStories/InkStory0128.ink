VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

У меня пропал попугай. Я его обнаружил у соседей, но они отказываются его возвращать. Что делать?
* [Заявить в полицию]
    -> res1
* [Выкрасть своего попугая]
    -> res2
* [Пригрозить соседям расправой]
    -> res3
* [Может, это действительно их попугай? Заведу себе нового питомца]
    -> res4

=== res1 === 
Я не смог доказать право на владение попугаем, он остался у соседей
~TextForLog = "У меня пропал попугай. Я его обнаружил у соседей, но они отказались его возвращать. Я заявил в полицию, но доказать, что это мой попугай, не сумел."
* [Ok]
-> END
=== res2 === 
Я действовал грамотно и успешно. Мой попугай у меня
~TextForLog = "У меня пропал попугай. Я его обнаружил у соседей, но они отказались его возвращать. Тогда я его выкрал."
* [Ok]
-> END
=== res3 === 
Соседи не ожидали от меня такой решительности и вернули мне попугая
~TextForLog = "У меня пропал попугай. Я его обнаружил у соседей, но они отказались его возвращать. Я пригрозил им расправой и только так смог вернуть своего питомца."
* [Ok]
-> END
=== res4 === 
Я некоторое время надеялся, что мой попугай прилетит назад, ко мне. Но этого не случилось, я завел нового и забыл об этой истории
~TextForLog = "У меня пропал попугай. Я его обнаружил у соседей, но они отказались его возвращать. Я надеялся, что мой попугай сам от них удерет ко мне, но этого не произошло. Тогда я завел нового попугая."
* [Ok]
-> END