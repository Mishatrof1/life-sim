VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я познакомилась с мужчиной через интернет и влюбилась виртуально. А когда мы встретились в реале, оказалось, что у него нет одного глаза. Что делать?
* [Отчитать его за то что скрыл такой серьезный недостаток и уйти с разбитым сердцем]
    -> res1
* [Об отношениях не может быть и речи, я вежливо пообщаюсь с ним, но на этом - все]
    -> res2
* [Для меня это не имеет значения. Я продолжу отношения]
    -> res3
* [Я займусь с ним сексом из сострадания, но потом уйду. т.к. он не моя судьба]
    -> res4

=== res1 === 
Я гордо ушла, но потом мне стало его жалко. Я поплакала и позвонила ему. Увы, он внес меня в черный список
~TextForLog = "Я познакомилась с мужчиной через интернет и влюбилась виртуально. А когда мы встретились в реале, оказалось, что у него нет одного глаза. Может, я поступила неправильно, отчитав  его за то, что морочил мне голову и уйдя. Но это не мой вариант."
* [Ok]
-> END
=== res2 === 
Я думаю, он не обиделся. Интересно, на что он рассчитывал?
~TextForLog = "Я познакомилась с мужчиной через интернет и влюбилась виртуально. А когда мы встретились в реале, оказалось, что у него нет одного глаза. Я была вежлива при встрече, но на этом наше общение закончилось."
* [Ok]
-> END
=== res3 === 
Он оказался очень интересным человеком с богатым внутренним миром. К тому же, герой, получивший ранение в бою. Я горжусь своим выбором
~TextForLog = "Я познакомилась с мужчиной через интернет и влюбилась виртуально. А когда мы встретились в реале, оказалось, что у него нет одного глаза. Для меня важнее не внешность, а духовность. Поэтому, я продолжила общение."
* [Ok]
-> END
=== res4 === 
Я считаю, что правильно поступила. Если люди не будут проявлять сострадание друг к другу, мир погибнет
~TextForLog = "Я познакомилась с мужчиной через интернет и влюбилась виртуально. А когда мы встретились в реале, оказалось, что у него нет одного глаза. Я занялась с ним сексом из сострадания, а после этого прекратила общение."
* [Ok]
-> END