VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Male"
VAR GroupTitle = "Семья"
VAR TextForLog = ""
VAR FatherCondition = true
VAR MotherCondition = true


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Отец пришел из бара пьяный и кричит на мать
* [Заступиться за мать]
    -> res1
* [Спрятаться подальше от этого кошмара]
    -> res2
* [Устроить истерику]
    -> res3
* [Уйти из дома, хлопнув дверью]
    -> res4

=== res1 === 
Отец ударил меня, но мать я защитил. Ненавижу его
~TextForLog = "Отец пришел из бара пьяный и стал  кричать на мать. Я за нее заступился. Отец ударил меня, но мать я защитил. Ненавижу его."
* [Ok]
-> END
=== res2 === 
Отец ударил мать. Видимо, они не будут жить вместе
~TextForLog = "Отец пришел из бара пьяный и стал  кричать на мать. Я спрятался. Отец ударил мать."
* [Ok]
-> END
=== res3 === 
Отец разозлился и ударил меня. Мать начала заступаться и он также ее ударил. Ненавижу отца
~TextForLog = "Отец пришел из бара пьяный и стал  кричать на мать. Я устроил истерику. Отец разозлился и ударил меня. Мать начала заступаться и он также ее ударил. Ненавижу отца."
* [Ok]
-> END
=== res4 === 
Родители помирились и кинулись меня искать. Я нашелся сам, они были рады, а я рад, что они не ссорятся
~TextForLog = "Отец пришел из бара пьяный и стал  кричать на мать. Я ушел из дому, хлопнув дверью. Родители помирились и кинулись меня искать. Я нашелся сам, они были рады, а я рад, что они не ссорятся."
* [Ok]
-> END