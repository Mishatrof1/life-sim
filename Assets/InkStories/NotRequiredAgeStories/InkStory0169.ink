VAR AgeMinCondition = 30
VAR AgeMaxCondition = 50
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Ко мне обратился незнакомец, назвавшийся продюсером и предложил роль в своем фильме. Я пришла по указанному адресу, оказалось, что фильм - порно. Как быть?
* [Всегда мечтала стать звездой, пусть даже порно! Я соглашусь!]
    -> res1
* [Устрою скандал с порчей реквизита и уйду оттуда]
    -> res2
* [Немедленно убегу без оглядки]
    -> res3
* [Приму решение в зависимости от предлагаемых условий]
    -> res4

=== res1 === 
Я начала карьеру порнозвезды. Неплохой жизненный выбор
~TextForLog = "Ко мне обратился незнакомец, назвавшийся продюсером и предложил роль в своем фильме. Я пришла по указанному адресу, оказалось, что фильм - порно.Я согласилась и снялась в нескольких порнофильмах."
* [Ok]
-> END
=== res2 === 
Я хорошо отыгралась на их имуществе за этот подлый обман. Когда пытаешься завлечь в свои сети крупную рыбу, будь готов к тому, что рыба вырвется и испортит твои сети
~TextForLog = "Ко мне обратился незнакомец, назвавшийся продюсером и предложил роль в своем фильме. Я пришла по указанному адресу, оказалось, что фильм - порно. Я сокрушила им весь реквизит, как они сокрушили мои надежды на карьеру в кино."
* [Ok]
-> END
=== res3 === 
Ужас. Подумать только, я чуть было не преступила порог ада. Продюсер - это наверное то же самое, что змей-искуситель
~TextForLog = "Ко мне обратился незнакомец, назвавшийся продюсером и предложил роль в своем фильме. Я пришла по указанному адресу, оказалось, что фильм - порно. Я, естественно, убежала без оглядки."
* [Ok]
-> END
=== res4 === 
Мне предложили приличные условия. Такие деньги я врядли смогу заработать иным способом. Я начала карьеру порнозвезды
~TextForLog = "Ко мне обратился незнакомец, назвавшийся продюсером и предложил роль в своем фильме. Я пришла по указанному адресу, оказалось, что фильм - порно. Я изучила условия и решила попробовать. После чего снялась в нескольких порнофильмах."
* [Ok]
-> END