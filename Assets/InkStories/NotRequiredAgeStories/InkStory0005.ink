VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Male"
VAR GroupTitle = "Школа"
VAR TextForLog = ""

VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я нашел на улице дорогой смартфон. Что делать?
* [Уничтожу сим-карту, очищу память и возьму себе]
    -> res1
* [Отнесу в полицию]
    -> res2
* [Самостоятельно найду владельца]
    -> res3
* [Разобью его]
    -> res4

=== res1 === 
Теперь у меня есть отличный гаджет, всем на зависть.
~ChangeHappiness = 5
~ChangeSmarts = 15
~TextForLog = "Я нашел на улице дорогой смартфон и решил оставить его себе."
* [Ok]
-> END
=== res2 === 
Оказалось, смартфон принадлежит наркоторговцу, полиция отследила его контакты и накрыла всю сеть. Меня представили к награде.
~ChangeHappiness = 2
~ChangeSmarts = 5
~TextForLog = "Я нашел на улице дорогой смартфон и отнес его в полицию. Оказалось, это смартфон наркоторговца, полиция отследила его контакты и накрыла всю сеть. Меня наградили."
* [Ok]
-> END
=== res3 === 
Оказалось, смартфон принадлежит наркоторговцу. Меня попытались втянуть в наркотрафик, но я убежал.
~ChangeHappiness = -3
~ChangeSmarts = -2
~TextForLog = "Я нашел на улице дорогой смартфон и решил вернуть его владельцу. Оказалось, смартфон принадлежит наркоторговцу. Меня попытались втянуть в наркотрафик, но я убежал."
* [Ok]
-> END
=== res4 === 
Оказалось, смартфон принадлежит наркоторговцу. Хорошо,что никто не видел, как я его разбил.
~ChangeSmarts = -1
~TextForLog = "Я нашел на улице дорогой смартфон и решил его разбить. Оказалось, смартфон принадлежит наркоторговцу.Хорошо,что никто не видел, как я его разбил."
* [Ok]
-> END