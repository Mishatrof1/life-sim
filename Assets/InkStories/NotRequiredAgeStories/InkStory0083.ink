VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

У меня бывают приступы снохождения и летаргии. И вот, произошло то, что меня всегда страшило: я проснулась в заколоченном гробу.
* [В такой ситуации никто не сохранит хладнокровие. Поддамся чувствам]
    -> res1
* [Я видела в кино, что надо делать: выбивать кулаком верхнюю доску]
    -> res2
* [Подтяну ноги к груди и буду выдавливать ими крышку гроба]
    -> res3
* [Перевернусь, встану на четвереньки буду выдавливать спиной крышку гроба]
    -> res4

=== res1 === 
На мои крики прибежала мама и заявила: все как в детстве, дочь уснула в шкафу и устроила там беспорядок
~TextForLog = "У меня бывают приступы снохождения и летаргии. И вот, произошло то, что меня всегда страшило: я проснулась в заколоченном гробу. В ужасе я начала метаться... Хорошо, что то был не гроб, а мамин шкаф."
* [Ok]
-> END
=== res2 === 
Мне это удалось, доска отскочила и на меня сверху посыпались... мамины вещи. Оказалось, я уснула в ее шкафу
~TextForLog = "У меня бывают приступы снохождения и летаргии. И вот, произошло то, что меня всегда страшило: я проснулась в заколоченном гробу. Я выбила верхнюю доску. Оказалось, что я уснула в мамином шкафу."
* [Ok]
-> END
=== res3 === 
Мне это удалось, крышка поддалась и на меня сверху посыпались... мамины вещи. Оказалось, я уснула в ее шкафу
~TextForLog = "У меня бывают приступы снохождения и летаргии. И вот, произошло то, что меня всегда страшило: я проснулась в заколоченном гробу. Я вытолкнула верхнюю крышку ногами. Оказалось, что я не в гробу, а в мамином шкафу."
* [Ok]
-> END
=== res4 === 
Мне это удалось, крышка поддалась и на меня сверху посыпались... мамины вещи. Оказалось, я уснула в ее шкафу
~TextForLog = "У меня бывают приступы снохождения и летаргии. И вот, произошло то, что меня всегда страшило: я проснулась в заколоченном гробу. Я выдавила крышку спиной. Хорошо, что это был не гроб, а мамин шкаф, в котором я уснула."
* [Ok]
-> END