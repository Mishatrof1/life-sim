VAR AgeMinCondition = 18
VAR AgeMaxCondition = 30
VAR SexCondition = "Female"
VAR GroupTitle = "Улица"
VAR TextForLog = ""


VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Отдыхая на побережье, я обнаужила дельфина, который выбросился на берег, но еще жив. Что делать?
* [Позвонить в службу спасения]
    -> res1
* [Позвать на помощь людей и столкнуть дельфина в воду]
    -> res2
* [Этот морской зверь выглядит опасно, лучше его не трогать, он может покалечить]
    -> res3
* [К сожалению, этому не помочь. Самоубийство дельфинов - вещь необратимая, как само время]
    -> res4

=== res1 === 
Спасатели приехали, при помощи крана и тросов подняли дельфина и опустили в воду. Дельфин уплыл. Я молодец
~TextForLog = "Отдыхая на побережье, я обнаужила дельфина, который выбросился на берег. Я вызвала спасателей и те спасли дельфина."
* [Ok]
-> END
=== res2 === 
Мы пытались, но у нас ничего не получилось. Хорошо, что кто-то умный догадался вызвать спасателей. Те сумели спасти дельфина
~TextForLog = "Отдыхая на побережье, я обнаужила дельфина, который выбросился на берег. Я позвала людей, но у нас не получалось спасти дельфина, пока кто-то умный не вызвал спасателей. Те его спасли."
* [Ok]
-> END
=== res3 === 
Я быстро ушла. Не хочу думать о трагических случаях. Нужно быть на позитиве
~TextForLog = "Отдыхая на побережье, я обнаужила дельфина, который выбросился на берег. Я ничем не могла ему помочь, просто прошла мимо и постаралась думать о чем-то позитивном."
* [Ok]
-> END
=== res4 === 
Жизнь полна страданий, идя дальше по пляжу, я сочинила поэму об умирающем дельфине. На моей страничке в Интернете эта поэма собрала 8000 лайков
~TextForLog = "Отдыхая на побережье, я обнаужила дельфина, который выбросился на берег. Увы, я ничем не могла ему помочь. Но его смерть не стала напрасной - я увековечила ее в поэме."
* [Ok]
-> END