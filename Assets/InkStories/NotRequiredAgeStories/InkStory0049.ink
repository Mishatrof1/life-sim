VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я разговаривала по телефону за рулем и случайно сбила человека. Как быть?
* [Быстро уехать с места происшествия]
    -> res1
* [Оказать пострадавшему первую помощь, вызвать неотложку и полицию]
    -> res2
* [Затащить его в машину и быстро доставить в больницу]
    -> res3
* [Звонить знакомым и выяснять у знакомых, что делать]
    -> res4

=== res1 === 
Полиция быстро меня нашла. Я лишена прав и у меня подписка о невыезде. Хорошо, что прохожий не сильно пострадал
~TextForLog = "Я разговаривала по телефону за рулем и случайно сбила человека.  Я быстро уехала оттуда, но полиция нашла меня и привлекла к ответственности. К счастью, потерпевший не сильно пострадал."
* [Ok]
-> END
=== res2 === 
С пострадавшим все нормально, это главное. А я заслужила неприятности
~TextForLog = "Я разговаривала по телефону за рулем и случайно сбила человека. Я оказала ему первую помощь и вызвала ннеотложку и полицию. У меня были неприятности, к счастью, потерпевший не сильно пострадал."
* [Ok]
-> END
=== res3 === 
Обошлось без полиции, т.к что пострадавший меня не выдал. А он ничего, такой, между нами промелькнула искра
~TextForLog = "Я разговаривала по телефону за рулем и случайно сбила человека. Я быстра доставила его в больницу. Его травмы были не серьезны и он не стал сообщать в полицию."
* [Ok]
-> END
=== res4 === 
За этим меня застала полиция. У меня серьезные проблемы, их было бы больше, но к счастью, пострадавший выжил.
~TextForLog = "Я разговаривала по телефону за рулем и случайно сбила человека. Я стала звонить друзьям и просить помощи. Приехавшие полицейские устроили мне большие проблемы. Хорошо, что травмы пострадавшего оказались не опасны для жизни."
* [Ok]
-> END