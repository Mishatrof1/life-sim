﻿VAR AgeMinCondition = ""
VAR AgeMaxCondition = ""
VAR SexCondition = "Male"
VAR GroupTitle = "Школа"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Нужно пропустить презентацию проекта из-за дополнительной репетиции перед концертом
* [Пропустить без объяснения причин]
    -> res1
* [Пропустить и подделать справку о болезни]
    -> res2
* [Честно предупредить преподавателя и пропустить]
    -> res3
* [Не пропускать занятия]
    -> res4

=== res1 === 
Мой преподаватель зол, очень зол
~TextForLog = "Мне нужно было на репетицию вместо учебы. Я пропустил презентацию, не ставя никого в известность. Преподаватель на меня зол. Кажется, с учебой теперь будет больше проблем. Зато репетиция прошла хорошо, а я еще лучше отработал партию."
* [Ok]
-> END
=== res2 === 
Преподаватель не поверил, но не задал лишних вопросов. Отлично, шалость удалась! 
~TextForLog = "Чтобы попасть на репетицию вместо учебы, я подделал справку о простуде, но не думаю, что мне поверили. В любом случае, я был официально освобожден от школы и попал на репетицию. Мой номер отточен до идеала."
* [Ok]
-> END
=== res3 === 
Преподаватель разрешил перенести презентацию на другой день. Отлично, я везде успею!
~TextForLog = "Репетиция концерта выпала ровно на время моей презентации. Хорошо, что преподаватель согласился закрыть глаза на мой прогул, а я успел на репетицию. Теперь концерт пройдёт отлично."
* [Ok]
-> END
=== res4 === 
Ребята из клуба разочаровались во мне. Ну, а что я сделаю? Образование важнее
~TextForLog = "Мне пришлось выбирать между учебой и репетицией. Я презентовал свой проект, преподаватель остался доволен. Жаль, что пришлось отказаться от репетиции. Не думаю, что коллектив так просто это забудет."
* [Ok]
-> END