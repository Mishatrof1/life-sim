﻿VAR AgeMinCondition = 50
VAR AgeMaxCondition = 67
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Раньше над моим шутками все смеялись, а сейчас они мало кого трогают, особенно молодых. Как вернуть способность шутить?
* [Нужно меньше шутить с молодежью и больше шутить с ровесниками]
    -> res1
* [Надо изучать интересы молодых и тогда можно долго отаваться в тренде]
    -> res2
* [Я свое отшутил. Пора стать серьезнее]
    -> res3


=== res1 === 
Все встало на свои места, стоило мне начать идти в ногу со временем
~TextForLog = "Окружающие перестали смеяться над моими шутками. Особенно молодежь. Я стал болбше шутить с ровесниками, а не с молодежью и все встало на свои места."
* [Ok]
-> END
=== res2 === 
Это оказалось сложнее, чем я думал. Потому что меня воротит от их музыки, от их моды и сленга, который они используют. Молодежь мне платит тем же
~TextForLog = "Окружающие перестали смеяться над моими шутками. Особенно молодежь. Я попытался приобщиться к молодежной культуре, но в результате только возненавидел ее."
* [Ok]
-> END
=== res3 === 
Я перестал носить молодежную одежду, полюбил рубашки с галстуками, и я всегда серьезен. Новый имидж зрелого человека мне нравится больше прежнего
~TextForLog = "Окружающие перестали смеяться над моими шутками. Особенно молодежь. Я решил, что пора стать серьезнее."
* [Ok]
-> END
