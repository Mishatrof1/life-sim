VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я решил поднять самооценку и записался в школу боевых искусств. Но меня там постоянно избивают. Что делать?
* [Терпеть и тренироваться. Однажды они все почувствуют мой кулак ярости!]
    -> res1
* [Бросить занятия и перейти в танцевальную студию]
    -> res2
* [Прибегнуть к нечестному приему: подложить в кимоно сковородку]
    -> res3
* [Пожаловаться учителю]
    -> res4

=== res1 === 
У меня уже были перелом ключицы, растяжение запястья и сотрясение мозга. Мне кажется, что я терпел достаточно, пора валить отсюда!
~TextForLog = "Я решил поднять самооценку и записался в школу боевых искусств. Но меня там постоянно избивали. Я терпел, сколько мог, но в конце концов решил уйти."
* [Ok]
-> END
=== res2 === 
Я открыл великую истину: объятия красивых женщин лучше, нежели пинки и тумаки
~TextForLog = "Я решил поднять самооценку и записался в школу боевых искусств. Но меня там постоянно избивали. Поэтому, я бросил занятия и перешел в танцевальную студию."
* [Ok]
-> END
=== res3 === 
Отличный результат, мой главный обидчик сломал об меня палец. Меня, правда, выгнали, но я и сам собирался уходить
~TextForLog = "Я решил поднять самооценку и записался в школу боевых искусств. Но меня там постоянно избивали. Я подложил под кимоно сковородку и мой главный обидчик сломал об нее палец. Пришлось уйти из школы."
* [Ok]
-> END
=== res4 === 
Учитель сам мной занялся. Стало еще больнее
~TextForLog = "Я решил поднять самооценку и записался в школу боевых искусств. Но меня там постоянно избивали. Я пожаловался учителю, но он в ответ сам начал меня избивать."
* [Ok]
-> END