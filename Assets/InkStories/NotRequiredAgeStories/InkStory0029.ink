VAR AgeMinCondition = 15
VAR AgeMaxCondition = 17
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""
VAR FatherCondition = true
VAR FriendCondition = true


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Подруга зовет меня на тайную вечеринку, где возможен секс. Что делать?
* [Отказаться: в этот раз без меня]
    -> res1
* [Согласиться и пойти, тайком от родителей]
    -> res2
* [Попытаться отговорить подругу, ведь это опасно]
    -> res3
* [Пойти, но позвонить родителям, чтоб не волновались]
    -> res4

=== res1 === 
Подруга пошла одна. Там ее напоили и жестоко изнасиловали. теперь она в больнице. Сама виновата
~TextForLog = "Подруга позвала меня на тайную вечеринку, где возможен секс, но я отказалась. Подруга пошла одна. Там ее напоили и жестоко изнасиловали. теперь она в больнице. Сама виновата."
* [Ok]
-> END
=== res2 === 
Мы с подругой оттянулись на всю катушку. Но групповой секс мне не понравился, это не мое
~TextForLog = "Подруга позвала меня на тайную вечеринку, где возможен секс. Я согласилась и пошла, тайком от родителей. Мы с подругой оттянулись на всю катушку. Но групповой секс мне не понравился, это не мое."
* [Ok]
-> END
=== res3 === 
Мы разругались  и перестали быть подругами. Она не пошла, потому что якобы, я обломала ей кайф
~TextForLog = "Подруга позвала меня на тайную вечеринку, где возможен секс. Яне пошла и ей не дала. Мы разругались  и перестали быть подругами."
* [Ok]
-> END
=== res4 === 
В разгар веселья заявился мой отец и обломал всем кайф. Ненавижу его! ненавижу себя! Ненавижу всех!
~TextForLog = "Подруга позвала меня на тайную вечеринку, где возможен секс. Я пошла, но предварительно позвонила родителям, чтоб не волновались. В разгар веселья заявился мой отец и обломал всем кайф. Ненавижу его! ненавижу себя! Ненавижу всех!"
* [Ok]
-> END