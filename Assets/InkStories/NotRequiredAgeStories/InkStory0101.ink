VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я застала племянника с пистолетом у виска. Он хочет застрелиться. Что делать?
* [Внезапно выхватить у него пистолет]
    -> res1
* [Узнать, что случилось, и предложить помощь]
    -> res2
* [Начать с ним ласково разговаривать, а когда он чуть успокоитcя, попросить у него оружие]
    -> res3
* [Позвонить на горячую линию и предложить племяннику трубку]
    -> res4

=== res1 === 
Я пыталась вырвать у него пистолет, но неудачно. Племянник застрелился
~TextForLog = "Я застала племянника с пистолетом у виска. Он хотел застрелиться. Я пыталась вырвать у него пистолет, но он все равно застрелился."
* [Ok]
-> END
=== res2 === 
Племянник отказался рассказывать, а когда я проявила настойчивость, выстрелил в себя и убил
~TextForLog = "Я застала племянника с пистолетом у виска. Он хотел застрелиться. Я предложила ему помощь, но он все равно застрелился."
* [Ok]
-> END
=== res3 === 
Он расслабился, а когда я протянула руку за оружием, попытался убить себя. К счастью, я успела отвести его руку и пуля прошла мимо
~TextForLog = "Я застала племянника с пистолетом у виска. Он хотел застрелиться. Я отвлекла его внимание разговорами и отвела его руку во время выстрела."
* [Ok]
-> END
=== res4 === 
Племянник согласился на разговор с психологом и тот разубедил его кончать с собой. Я без труда отняла пистолет у парня
~TextForLog = "Я застала племянника с пистолетом у виска. Он хотел застрелиться. Я позвонила на горячуюю психологическую линию, это спасло племяннику жизнь."
* [Ok]
-> END