﻿VAR AgeMinCondition = 50
VAR AgeMaxCondition = 67
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

В обычных семьях мужчины страдают алкоголизмом. А у меня жена спивается. Что мне с ней делать?
* [Уговорить жену посещать Клуб Анонимных Алкоголиков]
    -> res1
* [Развестись]
    -> res2
* [Положить жену в клинику на реабилитацию]
    -> res3


=== res1 === 
Жена продержалась 3 месяца, а потом сорвалась и набухалась. Говорят, женский алкоголизм труднее вылечить
~TextForLog = "Моя жена начала спиваться. Я уговорил ее посещать Клуб Анонимных Алкоголиков. Жена продержалась 3 месяца, а потом сорвалась и набухалась."
* [Ok]
-> END
=== res2 === 
Я пытался, но этому воспротивились все родственники. Сказали, что это я жену довел до нынешнего состояния, а теперь должен ей помочь
~TextForLog = "Моя жена начала спиваться. Я пытался развестись, но этому воспротивились все родственники. Сказали, что это я жену довел до нынешнего состояния, а теперь должен ей помочь."
* [Ok]
-> END
=== res3 === 
В клинике опытные врачи, они избавили жену от алкогольной зависимости. Теперь я слежу за каждым ее шагом
~TextForLog = "Моя жена начала спиваться. Я положил ее в клинику на реабилитацию. Опытные врачи, они избавили жену от алкогольной зависимости."
* [Ok]
-> END
