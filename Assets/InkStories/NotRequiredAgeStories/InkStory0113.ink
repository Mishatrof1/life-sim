VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Male"
VAR GroupTitle = "Работа"
VAR ProfessionalType = "Criminal"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я отбываю срок в тюрьме, остается год отсидки. Сокамерник предложил бежать. Что делать?
* [Бежать с ним]
    -> res1
* [Отказаться, ведь мне остался всего год отсидки]
    -> res2
* [Заявить о готовящемся побеге]
    -> res3
* [Отговорить сокамерника]
    -> res4

=== res1 === 
Нас поймали и добавили еще по году. Я неудачник!
~TextForLog = "Я отбывал срок в тюрьме, остается год отсидки. Сокамерник предложил бежать. Нас поймали и добавили еще год."
* [Ok]
-> END
=== res2 === 
Я поступил правильно. Сокамерника поймали и добавили еще год
~TextForLog = "Я отбывал срок в тюрьме, остается год отсидки. Сокамерник предложил бежать. Я отказался, и правильно сделал, сокамерника поймали."
* [Ok]
-> END
=== res3 === 
Сокамерника поймали и добавили год. А мне скостили срок за помощь и я скоро выхожу. Правда, когда сокамерник выйдет, проблем не избежать
~TextForLog = "Я отбывал срок в тюрьме, остается год отсидки. Сокамерник предложил бежать. Я заявил о готовящемся побеге и мне скостили год отсидки."
* [Ok]
-> END
=== res4 === 
Я сумел его отговорить, а потом выяснилось, что охрана знала о побеге. Сокамерник мне благодарен за спасение
~TextForLog = "Я отбывал срок в тюрьме, остается год отсидки. Сокамерник предложил бежать. Я его отговорил, и правильно сделал - охрана знала о готовящемся побеге."
* [Ok]
-> END