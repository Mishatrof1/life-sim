VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я застала своего бойфренда с любовницей. Как поступить?
* [Наброситься на них с кулаками]
    -> res1
* [Присоединиться. Я и раньше хотела попробовать тройничок]
    -> res2
* [Выгнать их, вышвырнуть его вещи и забыть]
    -> res3
* [Устроить истерику]
    -> res4

=== res1 === 
Глупо, только кулаки отбила. Они ушли, а я сижу, реву
~TextForLog = "Я застала своего бойфренда с любовницей и набросилась на них с кулаками."
* [Ok]
-> END
=== res2 === 
Все получили удовольствие. В следующий раз попробую с двумя парнями
~TextForLog = "Я застала своего бойфренда с любовницей и присоединилась к ним в сексе."
* [Ok]
-> END
=== res3 === 
Все, начинаю жизнь с чистого листа. Только этот лист не белый, а какой-то серый
~TextForLog = "Я застала своего бойфренда с любовницей. Я выгнала его и забыла."
* [Ok]
-> END
=== res4 === 
Любовница удрала, а мой парень так нежно меня успокаивал, что я решила его простить.
~TextForLog = "Я застала своего бойфренда с любовницей. Ее выгнала, а его простила."
* [Ok]
-> END