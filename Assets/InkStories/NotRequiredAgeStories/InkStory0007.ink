VAR AgeMinCondition = 11
VAR AgeMaxCondition = 14
VAR SexCondition = "Male"
VAR GroupTitle = "Школа"
VAR TextForLog = ""

VAR ChangeHappiness = 0
VAR ChangeLooks = 0
VAR ChangeSmarts = 0
VAR ChangeHealth = 0

Я поранил руку в школе. Что делать?
* [Обращусь к медсестре]
    -> res1
* [Само заживет]
    -> res2
* [Приду домой, обработаю рану]
    -> res3
* [Буду симулировать тяжелое ранение, чтобы получить освобождение от занятий]
    -> res4

=== res1 === 
Профессиональная помощь дала результат, рана быстро зажила.
~ChangeHappiness = 5
~TextForLog = "Я поранил руку в школе и обратился к медсестре. Профессиональная помощь дала результат, рана быстро зажила."
* [Ok]
-> END
=== res2 === 
Развилось заражение, я чуть не умер, теперь рука плохо работает.
~ChangeHappiness = -3
~ChangeSmarts = -3
~ChangeHealth = -10
~TextForLog = "Я поранил руку в школе и решил, что само заживет. В результате развилось зараженние, я чуть не умер, теперь рука плохо работает."
* [Ok]
-> END
=== res3 === 
Рана долго заживала, после нее остался уродливый шрам.
~ChangeHappiness = -10
~ChangeLooks = -15
~ChangeSmarts = -3
~ChangeHealth = -5
~TextForLog = "Я поранил руку в школе и  самостоятельно обработал рану. Она долго заживала, после нее остался уродливый шрам."
* [Ok]
-> END
=== res4 === 
Обман раскусили, а меня опозорили. Может, мне лучше перевестись в другую школу?
~ChangeHappiness = -10
~ChangeSmarts = 2
~TextForLog = "Я поранил руку в школе и решил симулировать тяжелую травму, чтобы получить освобождение от занятий. Обман раскусили, а меня опозорили."
* [Ok]
-> END