VAR AgeMinCondition = 50
VAR AgeMaxCondition = 67
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я увидел, как на спортплощадке подростки издеваются над мальчишкой, младше их. Что делать?
* [Не вмешиваться, это опасно]
    -> res1
* [Вмешаться и кулаками разогнать подростков]
    -> res2
* [Вмешаться и словами добиться, чтобы жертву оставили в покое]
    -> res3
* [Снять на видео и выложить в сеть]
    -> res4

=== res1 === 
Все участники вскоре разошлись. Надеюсь, мальчонка, которого обижали, повзрослев, научится давать отпор хулиганам
~TextForLog = "Я увидел, как на спортплощадке подростки издеваются над мальчишкой, младше их. Я не стал вмешиваться, это их дело."
* [Ok]
-> END
=== res2 === 
Подростки разбежались, а позже их родители обвинили меня в нападении на мирно играющих ребят. Мне с трудом удалось уладить эту проблему
~TextForLog = "Я увидел, как на спортплощадке подростки издеваются над мальчишкой, младше их. Я накинулся на хулиганов с кулаками и спас мальчонку, но из-за этой истории у меня были неприятности."
* [Ok]
-> END
=== res3 === 
Подростки оставили свою жертву и, отойдя на приличное расстояние, осыпали меня оскорблениями. Я еле сдержался, чтобы не наброситься на них с кулаками.
~TextForLog = "Я увидел, как на спортплощадке подростки издеваются над мальчишкой, младше их. Я пристыдил их и спас этим мальчонку, хотя хулиганы и осыпали меня оскорблениями."
* [Ok]
-> END
=== res4 === 
Эта история привлекла всеобщее внимание, благодаря мне хулиганов выявили и привлекли к ответственности
~TextForLog = "Я увидел, как на спортплощадке подростки издеваются над мальчишкой, младше их. Я снял происходящее на видео и выложил в сеть. Эта история привлекла всеобщее внимание, благодаря мне хулиганов выявили и привлекли к ответственности."
* [Ok]
-> END