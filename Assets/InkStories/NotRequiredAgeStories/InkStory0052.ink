VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Male"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

В баре я заметил сильно пьяного мужчину, который открыто демонстрировал портмоне с кучей денег. Он начал собираться на выход. Как реагировать?
* [Не реагировать, пусть идет своей дорогой]
    -> res1
* [Когда он выйдет из бара, пойти за ним и ограбить]
    -> res2
* [Вызвать ему такси, чтобы уберечь отнеприятностей]
    -> res3
* [Предупредить, чтобы был поосторожнее со своими деньгами]
    -> res4

=== res1 === 
Он вышел, и мы услышали крики. Оказалось, некто в маске отнял у пьяного портмоне
~TextForLog = "В баре я заметил сильно пьяного мужчину, который открыто демонстрировал портмоне с кучей денег. Он начал собираться на выход. Я решил не вмешиваться и его ограбили."
* [Ok]
-> END
=== res2 === 
Он слабо сопротивлялся, мне это не помешало отнять его бумажник и спокойно уйти. Ибо нечего!
~TextForLog = "В баре я заметил сильно пьяного мужчину, который открыто демонстрировал портмоне с кучей денег. Он начал собираться на выход. Я пошел за ним и ограбил. Он сам виноват, нечего было светить бумажник."
* [Ok]
-> END
=== res3 === 
Когда такси увезло пьянчужку, я от души пожелал ему добраться домой без приключений
~TextForLog = "В баре я заметил сильно пьяного мужчину, который открыто демонстрировал портмоне с кучей денег. Он начал собираться на выход. Я вызвал ему такси. надеюсь, он добрался домой без приключений."
* [Ok]
-> END
=== res4 === 
Он посмотрел на меня осоловело и ушел. Вскоре мы услышали крики. Оказалось, некто в маске отнял у пьяного портмоне
~TextForLog = "В баре я заметил сильно пьяного мужчину, который открыто демонстрировал портмоне с кучей денег. Он начал собираться на выход. Я посоветовал ему быть осторожнее. Это не помогло, его вскоре ограбили."
* [Ok]
-> END