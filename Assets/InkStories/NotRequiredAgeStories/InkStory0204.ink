﻿VAR AgeMinCondition = 50
VAR AgeMaxCondition = 67
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я очень боюсь лечить зубы и редко посещаю дантиста. Поэтому, у меня много порченных зубов. Что делать?
* [Буду как учитель Мао: тигру не нужен дантист, чтобы терзать клыками добычу]
    -> res1
* [Пойду, наконец, к дантисту]
    -> res2



=== res1 === 
У меня всегда болели зубы. Облегчене пришло только вместе со вставными челюстями
~TextForLog = "Я очень боялся лечить зубы и редко посещал дантиста. Поэтому, у меня появилось много порченных зубов. От этой напасти я избавился, только вставив себе искусственные челюсти."
* [Ok]
-> END
=== res2 === 
Это оказалось не так страшно, как я представлял. Жаль, что столько лет терпел зубную боль и жаль, что не уберег множество зубов
~TextForLog = "Я очень боялся лечить зубы и редко посещал дантиста. Поэтому, у меня появилось много порченных зубов. Однако, голос разума возобладал и я пошел к дантисту. Это оказалось не так страшно, как я думал."
* [Ok]
-> END
