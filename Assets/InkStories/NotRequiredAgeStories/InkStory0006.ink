VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Male"
VAR GroupTitle = "Школа"
VAR TextForLog = ""

VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Один добрый дяденька сказал, что у него в гараже есть ненужный мопед и предложил мне его отдать. Что делать?
* [Пойти с дяденькой в его гараж]
    -> res1
* [Не рисковать, вежливо отказаться]
    -> res2
* [Отказаться, но не уйти а проследить, ведь это может быть маньяк]
    -> res3
* [Запомнить приметы дяденьки и сообщить в полицию]
    -> res4

=== res1 === 
Мне достался классный мопед, хоть и не новый.
~TextForLog = "Один добрый дяденька подарил мне классный мопед."
* [Ok]
-> END
=== res2 === 
Мой сосед похвастался, что какой-то добрый дядя подарил ему классный мопед. Чувствую себя дураком и трусом.
~TextForLog = "Один добрый дяденька предложил подарить мне мопед. Но я побоялся идти с ним. Поэтому мопед достался соседскому мальчику."
* [Ok]
-> END
=== res3 === 
Он заметил слежку и прогнал меня. А мопед подарил соседу. Сосед рад, а я нет.
~TextForLog = "Один добрый дяденька предложил подарить мне мопед, но я принял его за маньяка и решил проследить. Он заметил слежку и прогнал меня. А мопед достался соседскому мальчику."
* [Ok]
-> END
=== res4 === 
Ложная тревога. В полиции меня похвалили, а мопед был подарен соседу. Так себе результат.
~ChangeHappiness = 2
~ChangeSmarts = 1
~TextForLog = "Один добрый дяденька предложил подарить мне мопед. Я принял его за маньяка и сообщил в полицию. Это оказалась ложная тревога, а мопед достался соседскому мальчику."
* [Ok]
-> END