﻿VAR AgeMinCondition = 50
VAR AgeMaxCondition = 67
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Мы с приятелем выпили в баре. Я уговорил его сесть за руль автомобиля, чтобы отвезти меня домой. По дороге, приятель совершил ДТП, ему придется оплатить штраф и ремонт авто. Как поступить?
* [Приятель виновен, значит должен платить]
    -> res1
* [Это я виноват. Все расходы возьму на себя]
    -> res2
* [Все расходы мы поделим пополам, так как оба виновны]
    -> res3


=== res1 === 
Расходов я не понес, но лишился приятеля
~TextForLog = "Я уговорил пьяного приятеля сесть за руль, чтобы отвезти меня домой. По дороге, приятель совершил ДТП. Ему пришлось оплатить крупный штраф и ремонт авто. Надо было быть более внимательным."
* [Ok]
-> END
=== res2 === 
Мой банковский счет основательно оскудел, но наша дружба окрепла
~TextForLog = "Я уговорил пьяного приятеля сесть за руль, чтобы отвезти меня домой. По дороге, приятель совершил ДТП. Я взял расходы на себя, так как это я виноват."
* [Ok]
-> END
=== res3 === 
Оптимальное решение. Пример, как надо поступать в подобных случаях
~TextForLog = "Я уговорил пьяного приятеля сесть за руль, чтобы отвезти меня домой. По дороге, приятель совершил ДТП. Пришлось платить крупный штраф и ремонтровать авто. Мы поделили расходы пополам, как и положено приятелям."
* [Ok]
-> END