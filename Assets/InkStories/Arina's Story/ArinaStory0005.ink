VAR AgeMinCondition = ""
VAR AgeMaxCondition = ""
VAR SexCondition = "Female"
VAR GroupTitle = "Школа"
VAR TextForLog = ""



VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

На концерте я забываю слова прямо в начале сольной партии
* [Прекратить петь и убежать со сцены]
    -> res1
* [Попросить включить песню заново]
    -> res2
* [Начать импровизировать и взаимодействовать с залом]
    -> res3


=== res1 === 
Я в испуге замерла, увидела полные жалости взгляды и убежала со сцены, бросив микрофон. Какая драма!
~TextForLog = "Забыв слова на концерте, я не смогла справиться со стрессом и убежала со сцены. Как же мне теперь появляться на репетициях?"
* [Ok]
-> END
=== res2 === 
Я попросила, и мне заново включили мою песню. Ладно, сосредоточились. Раз, два, три, вперед!
~TextForLog = "Слова песни вылетели из головы в самом начале песни, но я попросила включить мне ее заново. Я вспомнила слова и допела без проблем."
* [Ok]
-> END
=== res3 === 
Я взяла ситуацию в свои руки, начав хлопать в ритм вместе с залом, чтобы вспомнить слова. Супер, это точно попадет в школьные новости!
~TextForLog = "Даже забыв слова песни, мне удалось взять ситуацию под контроль. Зрители в поддержку хлопали вместе со мной в ритм, и я смогла сосредоточиться, чтобы допеть без проблем. Но коллектив, кажется, недоволен."
* [Ok]
-> END
