VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

В супермаркете оставалась последняя удобная тележка. Когда я потянулась за ней, одна сука выхватила ее раньше. Что делать?
* [Грубо обругать суку и плюнуть ей в лицо, а тележкой пусть подавится]
    -> res1
* [Ничего не делать. Обычная конкуренция]
    -> res2
* [Ударить суку и отнять тележку]
    -> res3
* [Вцепиться в тележку и громко визжать]
    -> res4

=== res1 === 
Она хотела кинуться на меня, но тут какой-то парень попытался отнять у нее тележку, и она была вынуждена переключиться на него. Было смешно
~TextForLog = "Когда я была в супермаркете, там осталась последняя удобная тележка. Я потянулась за ней, одна сука выхватила ее раньше. Пока мы сн ней ругались, какой-то парень завладел тележкой и укатил."
* [Ok]
-> END
=== res2 === 
Она укатила с тележкой, а я нашла себе другую, более громоздкую
~TextForLog = "Когда я была в супермаркете, там осталась последняя удобная тележка. Я потянулась за ней, одна сука выхватила ее раньше. Я не стала конфликтовать и взяла другую тележку - большую и неудобную."
* [Ok]
-> END
=== res3 === 
Она ударила меня в ответ и пока мыв дрались, какой-то парень завладел спорной тележкой и укатил
~TextForLog = "Когда я была в супермаркете, там осталась последняя удобная тележка. Я потянулась за ней, одна сука выхватила ее раньше.Мы подрались, а тем временем какой-то парень укатил с этой тележкой."
* [Ok]
-> END
=== res4 === 
Это возымело действие, сука отстала от меня и от моей тележки
~TextForLog = "Когда я была в супермаркете, там осталась последняя удобная тележка. Я потянулась за ней, одна сука выхватила ее раньше. Я стала громко кричать и не позволила лишить меня удобной тележки."
* [Ok]
-> END