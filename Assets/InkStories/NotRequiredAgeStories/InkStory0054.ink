VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Male"
VAR GroupTitle = "Семья"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Мы с братом решили проверить, кто сильнее с помощью армрестлинга. Я заметил, что для него очень важно победить. Как поступить?
* [Поддаться, пусть брат порадуется]
    -> res1
* [Использовать любые приемы, в том числе и нечестные, чтобы победить брата]
    -> res2
* [Устроить так, чтобы один раз победил он, а другой - я]
    -> res3
* [Уклониться от поединка]
    -> res4

=== res1 === 
Брат был просто счастлив, так как ему редко удается взять верх надо мной. Я тоже счастлив за брата
~TextForLog = "Мы с братом решили проверить, кто сильнее с помощью армрестлинга. Я заметил, что для него очень важно победить. Поэтому поддался. Брат был просто счастлив, так как ему редко удается взять верх надо мной. Я тоже счастлив за брата."
* [Ok]
-> END
=== res2 === 
Цель оправдывает средсва. Я всегда иду до конца ради победы. Она делае меня счастливее
~TextForLog = "Мы с братом решили проверить, кто сильнее с помощью армрестлинга. Я заметил, что для него очень важно победить. Но я не позволил ему одержать победу. Цель оправдывает средсва. Я всегда иду до конца ради победы. Она делае меня счастливее."
* [Ok]
-> END
=== res3 === 
Отлично, никому не обидно, все счастливы
~TextForLog = "Мы с братом решили проверить, кто сильнее с помощью армрестлинга. Я заметил, что для него очень важно победить. Я устроил все так, чтобы мы победили по разу каждый. Никому не обидно."
* [Ok]
-> END
=== res4 === 
Никто не выиграл, но никто и не проиграл. Никому не обидно
~TextForLog = "Мы с братом решили проверить, кто сильнее с помощью армрестлинга. Я заметил, что для него очень важно победить, поэтому уклонился от поединка.икто не выиграл, но никто и не проиграл. Никому не обидно."
* [Ok]
-> END